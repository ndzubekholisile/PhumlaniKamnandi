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
    public partial class BookingDetails : Form
    {
        private ReservationController reservationController;
        private GuestController guestController;
        private BookerController bookerController;
        private Reservation currentReservation;
        private Guest currentGuest;
        private bool isEditMode = false;
        private HotelDB hotelDB;

        public BookingDetails(int reservationId, HotelDB hDB)
        {
            hotelDB=hDB;
            InitializeComponent();
            InitializeControllers(hDB);
            LoadBookingDetails(reservationId);
            SetReadOnlyMode(true);
        }

        private void InitializeControllers(HotelDB hDB)
        {
            try
            {
                reservationController = new ReservationController(hDB);
                guestController = new GuestController(hDB);
                bookerController = new BookerController(hDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing booking details: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadBookingDetails(int reservationId)
        {
            try
            {
                // Use controllers to load data
                currentReservation = reservationController.Find(reservationId);
                if (currentReservation != null)
                {
                    currentGuest = guestController.AllGuests.FirstOrDefault(g => g.BookingID == currentReservation.BookingID);

                    if (currentGuest != null)
                    {
                        // Populate guest details
                        txtGuestName.Text = currentGuest.Name;
                        txtTelephone.Text = currentGuest.Telephone;
                        txtAddress1.Text = currentGuest.AddressLine1;
                        txtAddress2.Text = currentGuest.AddressLine2;
                        txtPostalCode.Text = currentGuest.PostalCode;
                        lblDateBooked.Text = $"Date Booked: {currentGuest.DateBooked.ToShortDateString()}";

                        // Populate reservation details
                        dtpCheckIn.Value = currentReservation.CheckInDate;
                        dtpCheckOut.Value = currentReservation.CheckOutDate;
                        lblStatus.Text = $"Status: {currentReservation.Status}";
                        lblReservationID.Text = $"Reservation ID: {currentReservation.ReservationID}";
                        lblBookingID.Text = $"Booking ID: {currentReservation.BookingID}";

                        // Calculate costs using controller methods
                        var nights = (currentReservation.CheckOutDate - currentReservation.CheckInDate).Days;
                        var totalCost = reservationController.CalculateReservationCost(currentReservation);
                        var deposit = reservationController.CalculateDeposit(currentReservation);

                        lblTotalNights.Text = $"Total Nights: {nights}";
                        lblTotalCost.Text = $"Total Cost: ${totalCost:F2}";
                        lblDeposit.Text = $"Deposit Paid: ${deposit:F2}";
                    }
                }
                else
                {
                    MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
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
                    // Update guest details with sanitized input
                    currentGuest.Name = ValidationHelper.SanitizeInput(txtGuestName.Text.Trim());
                    currentGuest.Telephone = txtTelephone.Text.Trim();
                    currentGuest.AddressLine1 = ValidationHelper.SanitizeInput(txtAddress1.Text.Trim());
                    currentGuest.AddressLine2 = ValidationHelper.SanitizeInput(txtAddress2.Text.Trim());
                    currentGuest.PostalCode = txtPostalCode.Text.Trim();

                    // Update reservation details
                    currentReservation.CheckInDate = dtpCheckIn.Value;
                    currentReservation.CheckOutDate = dtpCheckOut.Value;

                    // Use booker controller for update transaction
                    if (bookerController.UpdateBooking(currentGuest, currentReservation))
                    {
                        MessageBox.Show("Booking details updated successfully!", "Success", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SetReadOnlyMode(true);
                        isEditMode = false;
                        LoadBookingDetails(currentReservation.ReservationID); // Refresh display
                    }
                    else
                    {
                        MessageBox.Show("Failed to update booking details. Please try again.", "Error", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!ValidationHelper.IsValidName(txtGuestName.Text))
            {
                MessageBox.Show("Please enter a valid guest name.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestName.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhoneNumber(txtTelephone.Text))
            {
                MessageBox.Show("Please enter a valid telephone number.", "Validation Error", 
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

            if (!ValidationHelper.IsValidDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
            {
                MessageBox.Show("Please select valid dates. Check-out must be after check-in.", 
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
