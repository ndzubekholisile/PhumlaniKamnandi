using PhumlaniKamnandi.Business;
using PhumlaniKamnandi.Data;
using System;
using static PhumlaniKamnandi.Data.DB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhumlaniKamnandi.Presentation
{
    public partial class NewBooking : Form
    {
        private HotelDB hotelDB;
        private Guest selectedGuest;
        private bool isAvailabilityChecked = false;

        public NewBooking()
        {
            InitializeComponent();
            hotelDB = new HotelDB();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // This will set default dates
            dtpCheckIn.Value = DateTime.Today.AddDays(1);
            dtpCheckOut.Value = DateTime.Today.AddDays(2);

            // This will initially hide the guest details section
            pnlGuestDetails.Visible = false;
            pnlConfirmation.Visible = false;

            // This will disable the confirm button initially
            btnConfirmBooking.Enabled = false;

            UpdateTotalCost();
        }

        private void UpdateTotalCost()
        {
            if (isAvailabilityChecked)
            {
                var nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                var totalCost = nights * 150.00m; // Assuming $150 per night
                var deposit = totalCost * 0.20m; // The 20% deposit

                lblTotalNights.Text = $"Total Nights: {nights}";
                lblTotalCost.Text = $"Total Cost: ${totalCost:F2}";
                lblDepositRequired.Text = $"Deposit Required: ${deposit:F2}";
            }
        }

        private void rbExistingGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExistingGuest.Checked)
            {
                pnlGuestDetails.Visible = false;
                txtSelectedGuest.Text = "";
                selectedGuest = null;
                btnFindGuest.Enabled = true;
                CheckBookingReadiness();
            }
        }

        private void rbNewGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNewGuest.Checked)
            {
                pnlGuestDetails.Visible = true;
                txtSelectedGuest.Text = "";
                selectedGuest = null;
                btnFindGuest.Enabled = false;
                CheckBookingReadiness();
            }
        }

        private void btnFindGuest_Click(object sender, EventArgs e)
        {
            var guestSearchForm = new GuestSearch();
            if (guestSearchForm.ShowDialog() == DialogResult.OK)
            {
                selectedGuest = guestSearchForm.SelectedGuest;
                if (selectedGuest != null)
                {
                    txtSelectedGuest.Text = $"{selectedGuest.Name} - {selectedGuest.Telephone}";
                }
            }
            CheckBookingReadiness();
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // This will check the availability logic
            var availableRooms = hotelDB.AllRooms.Count(r => !r.IsOccupied);

            if (availableRooms > 0)
            {
                MessageBox.Show($"Rooms are available! {availableRooms} rooms currently free.", "Availability Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isAvailabilityChecked = true;
                pnlConfirmation.Visible = true;
                UpdateTotalCost();
            }
            else
            {
                MessageBox.Show("No rooms available for the selected dates.", "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isAvailabilityChecked = false;
                pnlConfirmation.Visible = false;
            }

            CheckBookingReadiness();
        }

        private void CheckBookingReadiness()
        {
            bool isGuestSelected = (rbExistingGuest.Checked && selectedGuest != null) ||
                                  (rbNewGuest.Checked && !string.IsNullOrWhiteSpace(txtGuestName.Text) &&
                                   !string.IsNullOrWhiteSpace(txtTelephone.Text));

            btnConfirmBooking.Enabled = isAvailabilityChecked && isGuestSelected;
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate booking data before proceeding
                if (!ValidateBookingData())
                {
                    return;
                }
                
                // Calculate deposit amount
                var nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                var totalCost = nights * 150.00m; // Assuming $150 per night
                var deposit = totalCost * 0.20m; // 20% deposit

                // Show payment form for deposit
                var paymentForm = new Payment(deposit);
                if (paymentForm.ShowDialog() == DialogResult.OK && paymentForm.PaymentSuccessful)
                {
                    Guest guest;

                    if (rbNewGuest.Checked)
                    {
                        // Validate and create new guest
                        if (!ValidateGuestData())
                        {
                            return;
                        }
                        
                        guest = new Guest
                        {
                            Name = SanitizeInput(txtGuestName.Text.Trim()),
                            Telephone = SanitizeInput(txtTelephone.Text.Trim()),
                            AddressLine1 = SanitizeInput(txtAddress1.Text.Trim()),
                            AddressLine2 = SanitizeInput(txtAddress2.Text.Trim()),
                            PostalCode = SanitizeInput(txtPostalCode.Text.Trim()),
                            DateBooked = DateTime.Now
                        };
                    }
                    else
                    {
                        if (selectedGuest == null)
                        {
                            MessageBox.Show("Please select a guest.", "Validation Error", 
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        guest = selectedGuest;
                    }

                    // Create reservation
                    var reservation = new Reservation
                    {
                        CheckInDate = dtpCheckIn.Value.Date,
                        CheckOutDate = dtpCheckOut.Value.Date,
                        Status = "confirmed",
                        DateBooked = DateTime.Now
                    };

                    // Save to database with proper error handling
                    if (!SaveBookingToDatabase(guest, reservation))
                    {
                        MessageBox.Show("Failed to save booking to database. Please try again.", 
                                      "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Booking confirmed and payment processed successfully!", 
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Booking cancelled - payment was not completed.", 
                                  "Booking Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}\n\nStack Trace: {ex.StackTrace}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool ValidateBookingData()
        {
            // Validate dates
            if (dtpCheckIn.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Check-in date cannot be in the past.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            // Validate availability was checked
            if (!isAvailabilityChecked)
            {
                MessageBox.Show("Please check room availability first.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        
        private bool ValidateGuestData()
        {
            // Validate guest name
            if (string.IsNullOrWhiteSpace(txtGuestName.Text))
            {
                MessageBox.Show("Please enter guest name.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestName.Focus();
                return false;
            }
            
            if (txtGuestName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Guest name must be at least 2 characters.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestName.Focus();
                return false;
            }
            
            // Validate telephone
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Please enter telephone number.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return false;
            }
            
            string phone = txtTelephone.Text.Trim().Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (phone.Length < 10)
            {
                MessageBox.Show("Please enter a valid telephone number (at least 10 digits).", 
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return false;
            }
            
            // Validate address
            if (string.IsNullOrWhiteSpace(txtAddress1.Text))
            {
                MessageBox.Show("Please enter address line 1.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress1.Focus();
                return false;
            }
            
            // Validate postal code
            if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                MessageBox.Show("Please enter postal code.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPostalCode.Focus();
                return false;
            }
            
            return true;
        }
        
        private bool SaveBookingToDatabase(Guest guest, Reservation reservation)
        {
            try
            {
                if (hotelDB == null)
                {
                    MessageBox.Show("Database connection error.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                // Save guest
                var guestObj = new HotelDB.HotelObject(guest);
                hotelDB.DataSetChange(guestObj, DB.DBOperation.Add);
                
                if (!hotelDB.UpdateDataSource(guestObj))
                {
                    return false;
                }

                // Save reservation
                var reservationObj = new HotelDB.HotelObject(reservation);
                hotelDB.DataSetChange(reservationObj, DB.DBOperation.Add);
                
                return hotelDB.UpdateDataSource(reservationObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        private string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
                
            // Remove potentially dangerous characters while preserving normal text
            return System.Text.RegularExpressions.Regex.Replace(input, @"[<>""';]", "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtGuestName_TextChanged(object sender, EventArgs e)
        {
            CheckBookingReadiness();
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            CheckBookingReadiness();
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            isAvailabilityChecked = false;
            pnlConfirmation.Visible = false;
            CheckBookingReadiness();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            isAvailabilityChecked = false;
            pnlConfirmation.Visible = false;
            CheckBookingReadiness();
        }
    }
}
