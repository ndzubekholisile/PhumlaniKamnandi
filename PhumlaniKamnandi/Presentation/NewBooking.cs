using PhumlaniKamnandi.Business;
using PhumlaniKamnandi.Data;
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
                Guest guest;

                if (rbNewGuest.Checked)
                {
                    // This will create a new guest
                    guest = new Guest
                    {
                        Name = txtGuestName.Text.Trim(),
                        Telephone = txtTelephone.Text.Trim(),
                        AddressLine1 = txtAddress1.Text.Trim(),
                        AddressLine2 = txtAddress2.Text.Trim(),
                        PostalCode = txtPostalCode.Text.Trim(),
                        DateBooked = DateTime.Now
                    };
                }
                else
                {
                    guest = selectedGuest;
                }

                // This will create a reservation
                var reservation = new Reservation
                {
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Status = "confirmed",
                    DateBooked = DateTime.Now
                };

                // This will make sure there are saves to the database
                var hotelObj = new HotelDB.HotelObject(guest);
                hotelDB.DataSetChange(hotelObj, HotelDB.DBOperation.Add);
                hotelDB.UpdateDataSource(hotelObj);

                hotelObj = new HotelDB.HotelObject(reservation);
                hotelDB.DataSetChange(hotelObj, HotelDB.DBOperation.Add);
                hotelDB.UpdateDataSource(hotelObj);

                MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
