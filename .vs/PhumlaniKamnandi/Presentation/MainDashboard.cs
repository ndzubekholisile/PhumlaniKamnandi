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
    public partial class MainDashboard : Form
    {
        private HotelDB hotelDB;

        public MainDashboard()
        {
            InitializeComponent();
            hotelDB = new HotelDB();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // This will load the occupancy percentage
                var totalRooms = hotelDB.AllRooms.Count;
                var occupiedRooms = hotelDB.AllRooms.Count(r => r.IsOccupied);
                var occupancyPercentage = totalRooms > 0 ? (occupiedRooms * 100.0) / totalRooms : 0;

                lblOccupancy.Text = $"Today's Occupancy: {occupancyPercentage:F1}%";

                // This should update occupancy panel color based on percentage
                if (occupancyPercentage >= 90)
                    pnlOccupancy.BackColor = Color.FromArgb(255, 192, 192); // Light red
                else if (occupancyPercentage >= 70)
                    pnlOccupancy.BackColor = Color.FromArgb(255, 255, 192); // Light yellow
                else
                    pnlOccupancy.BackColor = Color.FromArgb(192, 255, 192); // Light green
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMakeNewBooking_Click(object sender, EventArgs e)
        {
            var newBookingForm = new NewBooking();
            newBookingForm.ShowDialog();
            LoadDashboardData(); // ths will refresh the data after booking
        }

        private void btnManageBookings_Click(object sender, EventArgs e)
        {
            var manageBookingsForm = new ManageBookings();
            manageBookingsForm.ShowDialog();
            LoadDashboardData();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsDashboard();
            reportsForm.ShowDialog();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy - HH:mm:ss");
        }
    }
}
