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
                // Use booker controller for report generation
                var occupancyData = bookerController.GenerateOccupancyReport(dtpOccupancyStart.Value, dtpOccupancyEnd.Value);

                var reportViewer = new ReportsViewer("Occupancy Report", occupancyData,
                    $"Occupancy Levels: {dtpOccupancyStart.Value.ToShortDateString()} to {dtpOccupancyEnd.Value.ToShortDateString()}");
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
                // Use booker controller for report generation
                var revenueData = bookerController.GenerateRevenueReport(dtpRevenueMonth.Value.Year, dtpRevenueMonth.Value.Month);

                var reportViewer = new ReportsViewer("Revenue Report", revenueData,
                    $"Revenue Report: {dtpRevenueMonth.Value.ToString("MMMM yyyy")}");
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
    }
}