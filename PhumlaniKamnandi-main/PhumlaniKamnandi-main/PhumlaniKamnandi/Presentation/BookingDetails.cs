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
    public partial class BookingDetails : Form
    {
        private HotelDB hotelDB;
        private Reservation currentReservation;
        private Guest currentGuest;
        private bool isEditMode = false;

        public BookingDetails(int reservationId)
        {
            InitializeComponent();
            hotelDB = new HotelDB();
            LoadBookingDetails(reservationId);
            SetReadOnlyMode(true);
        }

        private void LoadBookingDetails(int reservationId)
        {
            try
            {
                currentReservation = hotelDB.AllReservations.FirstOrDefault(r => r.ReservationID == reservationId);
                if (currentReservation != null)
                {
                    currentGuest = hotelDB.AllGuests.FirstOrDefault(g => g.BookingID == currentReservation.BookingID);

                    if (currentGuest != null)
                    {
                        // These will populate guest details
                        txtGuestName.Text = currentGuest.Name;
                        txtTelephone.Text = currentGuest.Telephone;
                        txtAddress1.Text = currentGuest.AddressLine1;
                        txtAddress2.Text = currentGuest.AddressLine2;
                        txtPostalCode.Text = currentGuest.PostalCode;
                        lblDateBooked.Text = $"Date Booked: {currentGuest.DateBooked.ToShortDateString()}";

                        // These will populate reservation details
                        dtpCheckIn.Value = currentReservation.CheckInDate;
                        dtpCheckOut.Value = currentReservation.CheckOutDate;
                        lblStatus.Text = $"Status: {currentReservation.Status}";
                        lblReservationID.Text = $"Reservation ID: {currentReservation.ReservationID}";
                        lblBookingID.Text = $"Booking ID: {currentReservation.BookingID}";

                        // This will alculate the costs
                        var nights = (currentReservation.CheckOutDate - currentReservation.CheckInDate).Days;
                        var totalCost = nights * 150.00m;
                        var deposit = totalCost * 0.20m;

                        lblTotalNights.Text = $"Total Nights: {nights}";
                        lblTotalCost.Text = $"Total Cost: ${totalCost:F2}";
                        lblDeposit.Text = $"Deposit Paid: ${deposit:F2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetReadOnlyMode(bool readOnly)
        {
            txtGuestName.ReadOnly = readOnly;
            txtTelephone.ReadOnly = readOnly;
            txtAddress1.ReadOnly = readOnly;
            txtAddress2.ReadOnly = readOnly;
            txtPostalCode.ReadOnly = readOnly;
            dtpCheckIn.Enabled = !readOnly;
            dtpCheckOut.Enabled = !readOnly;

            if (readOnly)
            {
                btnEdit.Text = "Edit";
                btnSaveChanges.Visible = false;
                btnCancelEdit.Visible = false;
                lblEditMode.Text = "View Mode";
                lblEditMode.ForeColor = Color.FromArgb(34, 197, 94);
            }
            else
            {
                btnEdit.Text = "Cancel Edit";
                btnSaveChanges.Visible = true;
                btnCancelEdit.Visible = true;
                lblEditMode.Text = "Edit Mode";
                lblEditMode.ForeColor = Color.FromArgb(239, 68, 68);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // This will cancel edit mode
                SetReadOnlyMode(true);
                isEditMode = false;
                LoadBookingDetails(currentReservation.ReservationID); // Reload original data
            }
            else
            {
                // Thiss will be used to enter edit mode
                SetReadOnlyMode(false);
                isEditMode = true;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // These will update the guest details
                    currentGuest.Name = txtGuestName.Text.Trim();
                    currentGuest.Telephone = txtTelephone.Text.Trim();
                    currentGuest.AddressLine1 = txtAddress1.Text.Trim();
                    currentGuest.AddressLine2 = txtAddress2.Text.Trim();
                    currentGuest.PostalCode = txtPostalCode.Text.Trim();

                    // These will update the reservation details
                    currentReservation.CheckInDate = dtpCheckIn.Value;
                    currentReservation.CheckOutDate = dtpCheckOut.Value;

                    // These will save changes to the database
                    var guestObj = new HotelDB.HotelObject(currentGuest);
                    hotelDB.DataSetChange(guestObj, HotelDB.DBOperation.Edit);
                    hotelDB.UpdateDataSource(guestObj);

                    var reservationObj = new HotelDB.HotelObject(currentReservation);
                    hotelDB.DataSetChange(reservationObj, HotelDB.DBOperation.Edit);
                    hotelDB.UpdateDataSource(reservationObj);

                    MessageBox.Show("Booking details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetReadOnlyMode(true);
                    isEditMode = false;
                    LoadBookingDetails(currentReservation.ReservationID); // Refresh display
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            SetReadOnlyMode(true);
            isEditMode = false;
            LoadBookingDetails(currentReservation.ReservationID); // This will reload the original data
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtGuestName.Text))
            {
                MessageBox.Show("Guest name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Telephone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
