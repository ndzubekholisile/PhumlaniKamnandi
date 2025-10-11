using PhumlaniKamnandi.Data;
using PhumlaniKamnandi.Business;
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
    public partial class ManageBookings : Form
    {
        private BookerController bookerController;
        private ReservationController reservationController;
        private HotelDB hotelDB;

        public ManageBookings(HotelDB hDB)
        {
            hotelDB = hDB;
            InitializeComponent();
            InitializeControllers(hDB);
            LoadBookings();
        }

        private void InitializeControllers(HotelDB hDB)
        {
            try
            {
                bookerController = new BookerController(hDB);
                reservationController = new ReservationController(hDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing manage bookings: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadBookings()
        {
            try
            {
                // Use booker controller for complex operations
                var bookings = bookerController.GetAllBookingsWithGuestInfo();
                DisplayBookings(bookings);
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBookings(List<BookerController.BookingViewModel> bookings)
        {
            dgvBookings.DataSource = bookings.Select(b => new
            {
                b.ReservationID,
                b.BookingID,
                b.GuestName,
                b.CheckIn,
                b.CheckOut,
                b.Status,
                b.DateBookedString
            }).ToList();

            // Configure the DataGridView
            dgvBookings.Columns["ReservationID"].HeaderText = "Reservation ID";
            dgvBookings.Columns["BookingID"].HeaderText = "Booking ID";
            dgvBookings.Columns["GuestName"].HeaderText = "Guest Name";
            dgvBookings.Columns["CheckIn"].HeaderText = "Check-in";
            dgvBookings.Columns["CheckOut"].HeaderText = "Check-out";
            dgvBookings.Columns["Status"].HeaderText = "Status";
            dgvBookings.Columns["DateBookedString"].HeaderText = "Date Booked";

            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect = false;
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvBookings.SelectedRows.Count > 0;
            btnViewDetails.Enabled = hasSelection;
            btnCancelBooking.Enabled = hasSelection;
        }

        private void txtSearchGuest_TextChanged(object sender, EventArgs e)
        {
            FilterBookings();
        }

        private void txtSearchBookingID_TextChanged(object sender, EventArgs e)
        {
            FilterBookings();
        }

        private void FilterBookings()
        {
            string guestSearch = ValidationHelper.SanitizeInput(txtSearchGuest.Text);
            string bookingIdSearch = ValidationHelper.SanitizeInput(txtSearchBookingID.Text);

            try
            {
                // Use booker controller for search
                var filteredBookings = bookerController.SearchBookings(guestSearch, bookingIdSearch);
                DisplayBookings(filteredBookings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBookings.SelectedRows[0];
                int reservationId = (int)selectedRow.Cells["ReservationID"].Value;

                BookingDetails bookingDetailsForm = new BookingDetails(reservationId, hotelDB);
                bookingDetailsForm.ShowDialog();
                LoadBookings(); // This will refresh after there are potential changes made
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBookings.SelectedRows[0];
                int reservationId = (int)selectedRow.Cells["ReservationID"].Value;
                string guestName = selectedRow.Cells["GuestName"].Value.ToString();

                var result = MessageBox.Show(
                    $"Are you sure you want to cancel the booking for {guestName}?",
                    "Confirm Cancellation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Use booker controller for cancellation
                        if (bookerController.CancelBooking(reservationId))
                        {
                            MessageBox.Show("Booking cancelled successfully.", "Success", 
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookings();
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel booking. Please try again.", "Error", 
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void dgvBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }
    }
}