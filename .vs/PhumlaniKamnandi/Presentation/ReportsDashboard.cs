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
    public partial class ReportsDashboard : Form
    {
        private HotelDB hotelDB;

        public ReportsDashboard(HotelDB hDB)
        {
            InitializeComponent();
            hotelDB = hDB;
            InitializeForm();
        }

        private void InitializeForm()
        {
            // This shoud set the default date ranges
            dtpOccupancyStart.Value = DateTime.Today.AddDays(-30);
            dtpOccupancyEnd.Value = DateTime.Today.AddDays(30);

            dtpRevenueMonth.Value = DateTime.Today;
        }

        private void btnGenerateOccupancyReport_Click(object sender, EventArgs e)
        {
            if (dtpOccupancyStart.Value >= dtpOccupancyEnd.Value)
            {
                MessageBox.Show("End date must be after start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // This will generate the occupancy report data
                var occupancyData = GenerateOccupancyReport(dtpOccupancyStart.Value, dtpOccupancyEnd.Value);

                var reportViewer = new ReportsViewer("Occupancy Report", occupancyData,
                    $"Occupancy Levels: {dtpOccupancyStart.Value.ToShortDateString()} to {dtpOccupancyEnd.Value.ToShortDateString()}");
                reportViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating occupancy report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateRevenueReport_Click(object sender, EventArgs e)
        {
            try
            {
                // This will generate the revenue report data for the selected month
                var revenueData = GenerateRevenueReport(dtpRevenueMonth.Value.Year, dtpRevenueMonth.Value.Month);

                var reportViewer = new ReportsViewer("Revenue Report", revenueData,
                    $"Revenue Report: {dtpRevenueMonth.Value.ToString("MMMM yyyy")}");
                reportViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating revenue report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GenerateOccupancyReport(DateTime startDate, DateTime endDate)
        {
            var dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Occupied Rooms", typeof(int));
            dt.Columns.Add("Total Rooms", typeof(int));
            dt.Columns.Add("Occupancy %", typeof(string));

            var totalRooms = hotelDB.AllRooms.Count;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                // This should count the occupied rooms for this date
                var occupiedRooms = hotelDB.AllReservations
                    .Count(r => r.CheckInDate <= date && r.CheckOutDate > date &&
                               (r.Status == "confirmed" || r.Status == "checked_in"));

                var occupancyPercent = totalRooms > 0 ? (occupiedRooms * 100.0) / totalRooms : 0;

                dt.Rows.Add(
                    date.ToShortDateString(),
                    occupiedRooms,
                    totalRooms,
                    $"{occupancyPercent:F1}%"
                );
            }

            return dt;
        }

        private DataTable GenerateRevenueReport(int year, int month)
        {
            var dt = new DataTable();
            dt.Columns.Add("Week", typeof(string));
            dt.Columns.Add("Bookings", typeof(int));
            dt.Columns.Add("Revenue", typeof(decimal));
            dt.Columns.Add("Average per Booking", typeof(decimal));

            var startOfMonth = new DateTime(year, month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            // This should group by weeks 
            for (int week = 1; week <= 5; week++)
            {
                var weekStart = startOfMonth.AddDays((week - 1) * 7);
                var weekEnd = weekStart.AddDays(6);

                if (weekEnd > endOfMonth) weekEnd = endOfMonth;

                var weekBookings = hotelDB.AllReservations
                    .Where(r => r.DateBooked >= weekStart && r.DateBooked <= weekEnd &&
                               r.Status != "cancelled")
                    .ToList();

                var totalRevenue = weekBookings.Sum(r =>
                {
                    var nights = (r.CheckOutDate - r.CheckInDate).Days;
                    return nights * 150.00m; // $150 per night
                });

                var avgPerBooking = weekBookings.Count > 0 ? totalRevenue / weekBookings.Count : 0;

                dt.Rows.Add(
                    $"Week {week}",
                    weekBookings.Count,
                    totalRevenue,
                    avgPerBooking
                );
            }

            return dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}