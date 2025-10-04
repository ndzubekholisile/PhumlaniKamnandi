using PhumlaniKamnandi.Data;
using PhumlaniKamnandi.Business;
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
        private HotelDB hotelDB;

        public ManageBookings(HotelDB hDB)
        {
            InitializeComponent();
            hotelDB = hDB;
            LoadBookings();
        }

        private void LoadBookings()
        {
            try
            {
                var bookings = hotelDB.AllReservations.Join(
                    hotelDB.AllGuests,
                    r => r.BookingID,
                    g => g.BookingID,
                    (r, g) => new
                    {
                        r.ReservationID,
                        r.BookingID,
                        GuestName = g.Name,
                        r.CheckInDate,
                        r.CheckOutDate,
                        r.Status,
                        r.DateBooked
                    }).ToList();

                dgvBookings.DataSource = bookings.Select(b => new
                {
                    b.ReservationID,
                    b.BookingID,
                    b.GuestName,
                    CheckIn = b.CheckInDate.ToShortDateString(),
                    CheckOut = b.CheckOutDate.ToShortDateString(),
                    b.Status,
                    DateBooked = b.DateBooked.ToShortDateString()
                }).ToList();

                // This will configure the DataGridView
                dgvBookings.Columns["ReservationID"].HeaderText = "Reservation ID";
                dgvBookings.Columns["BookingID"].HeaderText = "Booking ID";
                dgvBookings.Columns["GuestName"].HeaderText = "Guest Name";
                dgvBookings.Columns["CheckIn"].HeaderText = "Check-in";
                dgvBookings.Columns["CheckOut"].HeaderText = "Check-out";
                dgvBookings.Columns["Status"].HeaderText = "Status";
                dgvBookings.Columns["DateBooked"].HeaderText = "Date Booked";

                dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBookings.MultiSelect = false;

                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string guestSearch = txtSearchGuest.Text.ToLower();
            string bookingIdSearch = txtSearchBookingID.Text.ToLower();

            try
            {
                var filteredBookings = hotelDB.AllReservations.Join(
                    hotelDB.AllGuests,
                    r => r.BookingID,
                    g => g.BookingID,
                    (r, g) => new
                    {
                        r.ReservationID,
                        r.BookingID,
                        GuestName = g.Name,
                        r.CheckInDate,
                        r.CheckOutDate,
                        r.Status,
                        r.DateBooked
                    })
                    .Where(b =>
                        (string.IsNullOrWhiteSpace(guestSearch) || b.GuestName.ToLower().Contains(guestSearch)) &&
                        (string.IsNullOrWhiteSpace(bookingIdSearch) || b.BookingID.ToString().Contains(bookingIdSearch)))
                    .Select(b => new
                    {
                        b.ReservationID,
                        b.BookingID,
                        b.GuestName,
                        CheckIn = b.CheckInDate.ToShortDateString(),
                        CheckOut = b.CheckOutDate.ToShortDateString(),
                        b.Status,
                        DateBooked = b.DateBooked.ToShortDateString()
                    })
                    .ToList();

                dgvBookings.DataSource = filteredBookings;
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

                var bookingDetailsForm = new BookingDetails(reservationId, hotelDB);
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
                        var reservation = hotelDB.AllReservations.FirstOrDefault(r => r.ReservationID == reservationId);
                        if (reservation != null)
                        {
                            reservation.Status = "cancelled";
                            var hotelObj = new HotelDB.HotelObject(reservation);
                            hotelDB.DataSetChange(hotelObj, HotelDB.DBOperation.Edit);
                            hotelDB.UpdateDataSource(hotelObj);

                            MessageBox.Show("Booking cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookings();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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