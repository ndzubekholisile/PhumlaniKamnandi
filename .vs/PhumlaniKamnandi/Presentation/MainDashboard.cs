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
    public partial class MainDashboard : Form
    {
        private RoomController roomController;
        private ReservationController reservationController;

        public MainDashboard()
        {
            InitializeComponent();
            InitializeControllers();
            ValidateSession();
            LoadDashboardData();
        }

        private void InitializeControllers()
        {
            try
            {
                roomController = new RoomController();
                reservationController = new ReservationController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing dashboard: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void ValidateSession()
        {
            try
            {
                SessionManager.ValidateSession();
                
                // Update UI with current user info if available
                if (SessionManager.IsLoggedIn)
                {
                    this.Text = $"Hotel Management System - Welcome {SessionManager.CurrentUser.Name}";
                }
            }
            catch (UnauthorizedAccessException)
            {
                this.Hide();
                var loginForm = new EmployeeLogin();
                loginForm.ShowDialog();
                if (!SessionManager.IsLoggedIn)
                {
                    Application.Exit();
                }
                this.Show();
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                // Use room controller for occupancy data
                var occupancyPercentage = roomController.GetOccupancyPercentage();
                var availableRooms = roomController.GetAvailableRoomCount();
                var totalRooms = roomController.AllRooms.Count;

                lblOccupancy.Text = $"Today's Occupancy: {occupancyPercentage:F1}% ({totalRooms - availableRooms}/{totalRooms} rooms)";

                // Update occupancy panel color based on percentage
                if (occupancyPercentage >= 90)
                    pnlOccupancy.BackColor = Color.FromArgb(255, 192, 192); // Light red
                else if (occupancyPercentage >= 70)
                    pnlOccupancy.BackColor = Color.FromArgb(255, 255, 192); // Light yellow
                else
                    pnlOccupancy.BackColor = Color.FromArgb(192, 255, 192); // Light green

                // Load additional dashboard metrics
                var activeReservations = reservationController.GetActiveReservations().Count;
                var todayCheckIns = reservationController.AllReservations
                    .Count(r => r.CheckInDate.Date == DateTime.Today && r.Status == "confirmed");
                var todayCheckOuts = reservationController.AllReservations
                    .Count(r => r.CheckOutDate.Date == DateTime.Today && r.Status == "confirmed");

                // Update additional labels if they exist
                UpdateDashboardMetrics(activeReservations, todayCheckIns, todayCheckOuts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDashboardMetrics(int activeReservations, int todayCheckIns, int todayCheckOuts)
        {
            // Update additional dashboard information if controls exist
            // This method can be expanded based on your UI design
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // End session when dashboard closes
            SessionManager.EndSession();
            base.OnFormClosing(e);
        }
    }
}
