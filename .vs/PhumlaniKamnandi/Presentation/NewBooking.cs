using PhumlaniKamnandi.Business;
using PhumlaniKamnandi.Data;
using PhumlaniKamnandi.Presentation.Infrastructure;
using System;
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
        private GuestController guestController;
        private ReservationController reservationController;
        private RoomController roomController;
        private BookerController bookerController;
        private Guest selectedGuest;
        private bool isAvailabilityChecked = false;

        public NewBooking()
        {
            InitializeComponent();
            InitializeControllers();
            InitializeForm();
        }

        private void InitializeControllers()
        {
            try
            {
                guestController = new GuestController();
                reservationController = new ReservationController();
                roomController = new RoomController();
                bookerController = new BookerController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing booking form: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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

            // Set default radio button selection to help user get started
            rbExistingGuest.Checked = true;

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
            var guestSearchForm = new GuestSearch(guestController);
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
            // Validate date range using ValidationHelper
            if (!ValidationHelper.IsValidDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
            {
                MessageBox.Show("Please select valid dates. Check-in must be today or later, and check-out must be after check-in.", 
                              "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Use room controller for availability check
                var availableRooms = roomController.GetAvailableRoomCount();

                if (availableRooms > 0)
                {
                    MessageBox.Show($"Rooms are available! {availableRooms} rooms currently free.", 
                                  "Availability Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAvailabilityChecked = true;
                    pnlConfirmation.Visible = true;
                    UpdateTotalCost();
                }
                else
                {
                    MessageBox.Show("No rooms available for the selected dates.", 
                                  "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isAvailabilityChecked = false;
                    pnlConfirmation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking availability: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CheckBookingReadiness();
        }

        private void CheckBookingReadiness()
        {
            bool isGuestSelected = false;

            if (rbExistingGuest.Checked)
            {
                isGuestSelected = selectedGuest != null;
            }
            else if (rbNewGuest.Checked)
            {
                // Use ValidationHelper for proper validation
                isGuestSelected = ValidationHelper.IsValidName(txtGuestName.Text) &&
                                ValidationHelper.IsValidPhoneNumber(txtTelephone.Text);
            }

            btnConfirmBooking.Enabled = isAvailabilityChecked && isGuestSelected;
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateBookingInput())
                return;

            try
            {
                Guest guest;

                if (rbNewGuest.Checked)
                {
                    // Create new guest with validation
                    guest = new Guest
                    {
                        Name = ValidationHelper.SanitizeInput(txtGuestName.Text.Trim()),
                        Telephone = txtTelephone.Text.Trim(),
                        AddressLine1 = ValidationHelper.SanitizeInput(txtAddress1.Text.Trim()),
                        AddressLine2 = ValidationHelper.SanitizeInput(txtAddress2.Text.Trim()),
                        PostalCode = txtPostalCode.Text.Trim(),
                        DateBooked = DateTime.Now
                    };
                }
                else
                {
                    guest = selectedGuest;
                }

                // Create reservation (BookingID will be set in BookerController after guest is saved)
                var reservation = new Reservation
                {
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Status = "confirmed",
                    DateBooked = DateTime.Now
                };

                // Use booker controller for transaction
                if (bookerController.CreateBooking(guest, reservation))
                {
                    MessageBox.Show("Booking confirmed successfully!", "Success", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create booking. Please try again.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBookingInput()
        {
            if (rbNewGuest.Checked)
            {
                if (!ValidationHelper.IsValidName(txtGuestName.Text))
                {
                    MessageBox.Show("Please enter a valid guest name.", "Validation Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGuestName.Focus();
                    return false;
                }

                if (!ValidationHelper.IsValidPhoneNumber(txtTelephone.Text))
                {
                    MessageBox.Show("Please enter a valid phone number.", "Validation Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelephone.Focus();
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && 
                    !ValidationHelper.IsValidPostalCode(txtPostalCode.Text))
                {
                    MessageBox.Show("Please enter a valid postal code.", "Validation Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPostalCode.Focus();
                    return false;
                }
            }

            if (!ValidationHelper.IsValidDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
            {
                MessageBox.Show("Please select valid dates.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
