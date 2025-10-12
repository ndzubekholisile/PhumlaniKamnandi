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

        public ManageBookings()
        {
            InitializeComponent();
            InitializeControllers();
            LoadBookings();
        }

        private void InitializeControllers()
        {
            try
            {
                bookerController = new BookerController();
                reservationController = new ReservationController();
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
                // Use booker controller for complex operations with multi-guest support
                var bookings = GetAllBookingsWithMultiGuestInfo();
                DisplayBookings(bookings);
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<BookerController.BookingViewModel> GetAllBookingsWithMultiGuestInfo()
        {
            var reservations = reservationController.AllReservations;
            var bookingViewModels = new List<BookerController.BookingViewModel>();

            if (reservations == null) return bookingViewModels;

            foreach (var reservation in reservations.Where(r => r != null))
            {
                var guests = bookerController.GetGuestsByBookingId(reservation.BookingID);
                var primaryGuest = guests.FirstOrDefault();
                
                if (primaryGuest != null)
                {
                    var guestDisplayName = guests.Count > 1 ? 
                        $"{primaryGuest.Name} (+{guests.Count - 1} more)" : 
                        primaryGuest.Name;

                    bookingViewModels.Add(new BookerController.BookingViewModel
                    {
                        ReservationID = reservation.ReservationID,
                        BookingID = reservation.BookingID,
                        GuestName = guestDisplayName,
                        CheckInDate = reservation.CheckInDate,
                        CheckOutDate = reservation.CheckOutDate,
                        Status = reservation.Status,
                        DateBooked = reservation.DateBooked
                    });
                }
            }

            return bookingViewModels;
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
                // Get all bookings with multi-guest support and then filter
                var allBookings = GetAllBookingsWithMultiGuestInfo();
                var filteredBookings = allBookings.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(guestSearch))
                {
                    filteredBookings = filteredBookings.Where(b => 
                        b.GuestName.ToLower().Contains(guestSearch.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(bookingIdSearch))
                {
                    filteredBookings = filteredBookings.Where(b => 
                        b.BookingID.ToString().Contains(bookingIdSearch));
                }

                DisplayBookings(filteredBookings.ToList());
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
                var selectedRow = dgvBookings.SelectedRows[0];
                int reservationId = (int)selectedRow.Cells["ReservationID"].Value;

                var bookingDetailsForm = new BookingDetails(reservationId);
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