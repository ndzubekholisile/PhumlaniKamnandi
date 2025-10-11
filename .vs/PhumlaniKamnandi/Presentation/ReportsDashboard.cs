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
    public partial class ReportsDashboard : Form
    {
        private BookerController bookerController;

        public ReportsDashboard()
        {
            InitializeComponent();
            InitializeControllers();
            InitializeForm();
        }

        private void InitializeControllers()
        {
            try
            {
                bookerController = new BookerController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing reports dashboard: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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
            if (!ValidationHelper.IsValidDateRange(dtpOccupancyStart.Value, dtpOccupancyEnd.Value))
            {
                MessageBox.Show("Please select a valid date range. End date must be after start date.", 
                              "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Uses the booker controller for report generation
                var occupancyData = bookerController.GenerateOccupancyReport(dtpOccupancyStart.Value, dtpOccupancyEnd.Value);
                
                // Generates the occupancy data with room type breakdown
                var occupancyDataWithRoomTypes = GenerateOccupancyReportWithRoomTypes(dtpOccupancyStart.Value, dtpOccupancyEnd.Value);
                
                // Calculateds the summary statistics
                var summaryStats = CalculateOccupancySummary(occupancyData);

                var reportViewer = new ReportsViewer("Occupancy Report", occupancyDataWithRoomTypes,
                    $"Occupancy Levels: {dtpOccupancyStart.Value.ToShortDateString()} to {dtpOccupancyEnd.Value.ToShortDateString()}",
                    summaryStats);
                reportViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating occupancy report: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateRevenueReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate revenue report with room type pricing
                var revenueDataWithRoomTypes = GenerateRevenueReportWithRoomTypes(dtpRevenueMonth.Value.Year, dtpRevenueMonth.Value.Month);
                
                // Calculate summary statistics
                var summaryStats = CalculateRevenueSummary(revenueDataWithRoomTypes);

                var reportViewer = new ReportsViewer("Revenue Report", revenueDataWithRoomTypes,
                    $"Revenue Report: {dtpRevenueMonth.Value.ToString("MMMM yyyy")}",
                    summaryStats);
                reportViewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating revenue report: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Report Generation Methods

        private DataTable GenerateOccupancyReportWithRoomTypes(DateTime startDate, DateTime endDate)
        {
            var roomController = new RoomController();
            var reservationController = new ReservationController();
            var dt = new DataTable();
            
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Standard Rooms", typeof(int));
            dt.Columns.Add("Deluxe Rooms", typeof(int));
            dt.Columns.Add("Executive Rooms", typeof(int));
            dt.Columns.Add("Family Rooms", typeof(int));
            dt.Columns.Add("Presidential Rooms", typeof(int));
            dt.Columns.Add("Total Occupied", typeof(int));
            dt.Columns.Add("Total Available", typeof(int));
            dt.Columns.Add("Occupancy %", typeof(string));

            var allRooms = roomController.AllRooms;
            var allReservations = reservationController.AllReservations;
            var totalRooms = allRooms?.Count ?? 0;

            if (allReservations == null || allRooms == null)
                return dt;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var occupiedReservations = allReservations
                    .Where(r => r != null && r.Status != null &&
                               r.CheckInDate <= date && r.CheckOutDate > date &&
                               (r.Status == "confirmed" || r.Status == "checked_in"))
                    .ToList();

                // Counts occupancy by room type
                var standardCount = Math.Min(occupiedReservations.Count, allRooms.Count(r => r.SuiteType == "standard"));
                var deluxeCount = Math.Min(occupiedReservations.Count, allRooms.Count(r => r.SuiteType == "deluxe"));
                var executiveCount = Math.Min(occupiedReservations.Count, allRooms.Count(r => r.SuiteType == "executive"));
                var familyCount = Math.Min(occupiedReservations.Count, allRooms.Count(r => r.SuiteType == "family"));
                var presidentialCount = Math.Min(occupiedReservations.Count, allRooms.Count(r => r.SuiteType == "presidential"));

                var totalOccupied = occupiedReservations.Count;
                var occupancyPercent = totalRooms > 0 ? (totalOccupied * 100.0) / totalRooms : 0;

                dt.Rows.Add(
                    date.ToShortDateString(),
                    standardCount,
                    deluxeCount,
                    executiveCount,
                    familyCount,
                    presidentialCount,
                    totalOccupied,
                    totalRooms,
                    $"{occupancyPercent:F1}%"
                );
            }

            return dt;
        }

        private DataTable GenerateRevenueReportWithRoomTypes(int year, int month)
        {
            var reservationController = new ReservationController();
            var roomController = new RoomController();
            var dt = new DataTable();
            
            dt.Columns.Add("Week", typeof(string));
            dt.Columns.Add("Bookings", typeof(int));
            dt.Columns.Add("Standard Revenue", typeof(decimal));
            dt.Columns.Add("Deluxe Revenue", typeof(decimal));
            dt.Columns.Add("Executive Revenue", typeof(decimal));
            dt.Columns.Add("Family Revenue", typeof(decimal));
            dt.Columns.Add("Presidential Revenue", typeof(decimal));
            dt.Columns.Add("Total Revenue", typeof(decimal));
            dt.Columns.Add("Average per Booking", typeof(decimal));

            var startOfMonth = new DateTime(year, month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            var allReservations = reservationController.AllReservations;
            var allRooms = roomController.AllRooms;

            if (allReservations == null || allRooms == null)
                return dt;

            // Room type pricing
            var roomRates = GetRoomTypeRates();

            for (int week = 1; week <= 5; week++)
            {
                var weekStart = startOfMonth.AddDays((week - 1) * 7);
                var weekEnd = weekStart.AddDays(6);

                if (weekEnd > endOfMonth) weekEnd = endOfMonth;

                var weekBookings = allReservations
                    .Where(r => r != null && r.Status != null &&
                               r.DateBooked >= weekStart && r.DateBooked <= weekEnd &&
                               r.Status != "cancelled")
                    .ToList();

                // Calculates revenue by room type
                var totalBookings = weekBookings.Count;
                var standardRevenue = CalculateRevenueByType(weekBookings, "standard", roomRates["standard"]);
                var deluxeRevenue = CalculateRevenueByType(weekBookings, "deluxe", roomRates["deluxe"]);
                var executiveRevenue = CalculateRevenueByType(weekBookings, "executive", roomRates["executive"]);
                var familyRevenue = CalculateRevenueByType(weekBookings, "family", roomRates["family"]);
                var presidentialRevenue = CalculateRevenueByType(weekBookings, "presidential", roomRates["presidential"]);

                var totalRevenue = standardRevenue + deluxeRevenue + executiveRevenue + familyRevenue + presidentialRevenue;
                var avgPerBooking = totalBookings > 0 ? totalRevenue / totalBookings : 0;

                dt.Rows.Add(
                    $"Week {week}",
                    totalBookings,
                    standardRevenue,
                    deluxeRevenue,
                    executiveRevenue,
                    familyRevenue,
                    presidentialRevenue,
                    totalRevenue,
                    avgPerBooking
                );
            }

            return dt;
        }

        private Dictionary<string, decimal> GetRoomTypeRates()
        {
            return new Dictionary<string, decimal>
            {
                {"standard", 120.00m},
                {"deluxe", 180.00m},
                {"executive", 250.00m},
                {"family", 200.00m},
                {"presidential", 500.00m}
            };
        }

        private decimal CalculateRevenueByType(List<Reservation> reservations, string roomType, decimal rate)
        {
            var roomController = new RoomController();
            var roomsOfType = roomController.AllRooms?.Count(r => r.SuiteType == roomType) ?? 0;
            var totalRooms = roomController.AllRooms?.Count ?? 1;
            
            if (totalRooms == 0) return 0;
            
            var typePercentage = (decimal)roomsOfType / totalRooms;
            var reservationsForType = (int)(reservations.Count * typePercentage);
            
            decimal totalRevenue = 0;
            for (int i = 0; i < reservationsForType && i < reservations.Count; i++)
            {
                var nights = (reservations[i].CheckOutDate - reservations[i].CheckInDate).Days;
                totalRevenue += nights * rate;
            }
            
            return totalRevenue;
        }

        private Dictionary<string, object> CalculateOccupancySummary(DataTable occupancyData)
        {
            var summary = new Dictionary<string, object>();
            
            if (occupancyData.Rows.Count == 0)
                return summary;

            var totalOccupiedSum = 0;
            var totalAvailableSum = 0;
            var maxOccupancy = 0.0;
            var minOccupancy = 100.0;

            foreach (DataRow row in occupancyData.Rows)
            {
                if (int.TryParse(row["Total Occupied"].ToString(), out int occupied))
                    totalOccupiedSum += occupied;
                
                if (int.TryParse(row["Total Available"].ToString(), out int available))
                    totalAvailableSum += available;

                var occupancyStr = row["Occupancy %"].ToString().Replace("%", "");
                if (double.TryParse(occupancyStr, out double occupancy))
                {
                    maxOccupancy = Math.Max(maxOccupancy, occupancy);
                    minOccupancy = Math.Min(minOccupancy, occupancy);
                }
            }

            var avgOccupancy = totalAvailableSum > 0 ? (totalOccupiedSum * 100.0) / (totalAvailableSum / occupancyData.Rows.Count) : 0;

            summary["Average Occupancy"] = $"{avgOccupancy:F1}%";
            summary["Peak Occupancy"] = $"{maxOccupancy:F1}%";
            summary["Lowest Occupancy"] = $"{minOccupancy:F1}%";
            summary["Total Room Nights"] = totalOccupiedSum;

            return summary;
        }

        private Dictionary<string, object> CalculateRevenueSummary(DataTable revenueData)
        {
            var summary = new Dictionary<string, object>();
            
            if (revenueData.Rows.Count == 0)
                return summary;

            decimal totalRevenue = 0;
            int totalBookings = 0;
            decimal maxWeeklyRevenue = 0;
            decimal minWeeklyRevenue = decimal.MaxValue;

            foreach (DataRow row in revenueData.Rows)
            {
                if (decimal.TryParse(row["Total Revenue"].ToString(), out decimal revenue))
                {
                    totalRevenue += revenue;
                    maxWeeklyRevenue = Math.Max(maxWeeklyRevenue, revenue);
                    minWeeklyRevenue = Math.Min(minWeeklyRevenue, revenue);
                }
                
                if (int.TryParse(row["Bookings"].ToString(), out int bookings))
                    totalBookings += bookings;
            }

            var avgWeeklyRevenue = revenueData.Rows.Count > 0 ? totalRevenue / revenueData.Rows.Count : 0;
            var avgRevenuePerBooking = totalBookings > 0 ? totalRevenue / totalBookings : 0;

            summary["Total Revenue"] = totalRevenue.ToString("C");
            summary["Average Weekly Revenue"] = avgWeeklyRevenue.ToString("C");
            summary["Peak Weekly Revenue"] = maxWeeklyRevenue.ToString("C");
            summary["Total Bookings"] = totalBookings;
            summary["Average Revenue per Booking"] = avgRevenuePerBooking.ToString("C");

            return summary;
        }

        #endregion
    }
}