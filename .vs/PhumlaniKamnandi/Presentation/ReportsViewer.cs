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
    public partial class ReportsViewer : Form
    {
        private Dictionary<string, object> summaryStatistics;
        private DataTable reportData;
        private string reportType;

        public ReportsViewer(string reportType, DataTable reportData, string reportTitle)
        {
            InitializeComponent();
            LoadReport(reportType, reportData, reportTitle);
        }

        public ReportsViewer(string reportType, DataTable reportData, string reportTitle, Dictionary<string, object> summaryStats)
        {
            InitializeComponent();
            this.summaryStatistics = summaryStats;
            LoadReport(reportType, reportData, reportTitle);
        }

        private void LoadReport(string reportType, DataTable reportData, string reportTitle)
        {
            this.reportData = reportData;
            this.reportType = reportType;
            
            lblReportTitle.Text = reportTitle;
            lblReportType.Text = reportType;

            // This will load  the summary statistics if they are available
            if (summaryStatistics != null && summaryStatistics.Count > 0)
            {
                DisplaySummaryStatistics();
            }

            // This should configure the DataGridView based on the report type
            ConfigureDataGridView(reportType);

            // This will bind the data
            dgvReport.DataSource = reportData;

            // This should auto size the columns
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // This should format the numeric columns if they exist
            FormatNumericColumns(reportData);
        }

        private void ConfigureDataGridView(string reportType)
        {
            // This will set the specific configurations based on the report type
            switch (reportType.ToLower())
            {
                case "occupancy report":
                    dgvReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case "revenue report":
                    dgvReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;
                default:
                    dgvReport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;
            }
        }

        private void FormatNumericColumns(DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.DataType == typeof(decimal) || column.DataType == typeof(double) || column.DataType == typeof(float))
                {
                    // This should format as currency for revenue, percentage for occupancy
                    if (column.ColumnName.ToLower().Contains("revenue") || column.ColumnName.ToLower().Contains("cost") || column.ColumnName.ToLower().Contains("deposit"))
                    {
                        dgvReport.Columns[column.ColumnName].DefaultCellStyle.Format = "C2";
                    }
                    else if (column.ColumnName.ToLower().Contains("average") || column.ColumnName.ToLower().Contains("per"))
                    {
                        dgvReport.Columns[column.ColumnName].DefaultCellStyle.Format = "C2";
                    }
                }
                else if (column.DataType == typeof(int))
                {
                    dgvReport.Columns[column.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 1;
                    saveDialog.FileName = $"{lblReportType.Text.Replace(" ", "_")}_{DateTime.Now.ToString("yyyyMMdd")}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCsv(saveDialog.FileName);
                        MessageBox.Show("Report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCsv(string filePath)
        {
            var sb = new StringBuilder();

            // This is too ad headers
            var headers = dgvReport.Columns.Cast<DataGridViewColumn>()
                .Select(column => column.HeaderText);
            sb.AppendLine(string.Join(",", headers));

            // This is to add data rows
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>()
                        .Select(cell => cell.Value?.ToString() ?? "");
                    sb.AppendLine(string.Join(",", cells));
                }
            }

            System.IO.File.WriteAllText(filePath, sb.ToString());
        }

        #region Statistics and Visualization

        private void DisplaySummaryStatistics()
        {
            var summaryText = new StringBuilder();
            summaryText.AppendLine("SUMMARY STATISTICS:");
            summaryText.AppendLine(new string('-', 40));
            
            foreach (var stat in summaryStatistics)
            {
                summaryText.AppendLine($"{stat.Key}: {stat.Value}");
            }

            // Create or update summary label
            if (this.Controls.Find("lblSummary", true).Length == 0)
            {
                var lblSummary = new Label
                {
                    Name = "lblSummary",
                    Text = summaryText.ToString(),
                    Font = new Font("Consolas", 9F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    BackColor = Color.FromArgb(249, 250, 251),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(34, 540),
                    Size = new Size(400, 120),
                    TextAlign = ContentAlignment.TopLeft,
                    Padding = new Padding(10)
                };
                
                pnlMain.Controls.Add(lblSummary);
                lblSummary.BringToFront();
            }
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("No data available for chart generation.", "No Data", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ShowChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating chart: {ex.Message}", "Chart Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowChart()
        {
            var chartForm = new Form
            {
                Text = $"Chart - {lblReportType.Text}",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            var chartPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            chartForm.Controls.Add(chartPanel);
            chartPanel.Paint += (s, e) => DrawChart(e.Graphics, chartPanel.ClientRectangle);

            chartForm.ShowDialog();
        }

        private void DrawChart(Graphics g, Rectangle bounds)
        {
            if (reportData == null || reportData.Rows.Count == 0) return;

            var chartArea = new Rectangle(
                bounds.X + 60, 
                bounds.Y + 40, 
                bounds.Width - 120, 
                bounds.Height - 100
            );

            // Draw chart background
            g.FillRectangle(Brushes.White, chartArea);
            g.DrawRectangle(Pens.Gray, chartArea);

            // Determine chart type based on report type
            if (reportType.ToLower().Contains("occupancy"))
            {
                DrawOccupancyChart(g, chartArea);
            }
            else if (reportType.ToLower().Contains("revenue"))
            {
                DrawRevenueChart(g, chartArea);
            }
        }

        private void DrawOccupancyChart(Graphics g, Rectangle chartArea)
        {
            var dataPoints = new List<float>();
            var labels = new List<string>();

            // Extract occupancy percentages
            foreach (DataRow row in reportData.Rows)
            {
                var occupancyStr = row["Occupancy %"].ToString().Replace("%", "");
                if (float.TryParse(occupancyStr, out float occupancy))
                {
                    dataPoints.Add(occupancy);
                    labels.Add(row["Date"].ToString());
                }
            }

            if (dataPoints.Count == 0) return;

            var maxValue = Math.Max(100f, dataPoints.Max());
            var minValue = Math.Min(0f, dataPoints.Min());
            var range = maxValue - minValue;

            // Draw line chart
            var points = new PointF[dataPoints.Count];
            for (int i = 0; i < dataPoints.Count; i++)
            {
                var x = chartArea.X + (i * chartArea.Width / (dataPoints.Count - 1));
                var y = chartArea.Bottom - ((dataPoints[i] - minValue) / range * chartArea.Height);
                points[i] = new PointF(x, y);
            }

            // Draw grid lines
            using (var gridPen = new Pen(Color.LightGray, 1))
            {
                for (int i = 0; i <= 10; i++)
                {
                    var y = chartArea.Y + (i * chartArea.Height / 10);
                    g.DrawLine(gridPen, chartArea.X, y, chartArea.Right, y);
                }
            }

            // Draw line
            if (points.Length > 1)
            {
                using (var linePen = new Pen(Color.FromArgb(59, 130, 246), 3))
                {
                    g.DrawLines(linePen, points);
                }
            }

            // Draw points
            using (var pointBrush = new SolidBrush(Color.FromArgb(59, 130, 246)))
            {
                foreach (var point in points)
                {
                    g.FillEllipse(pointBrush, point.X - 3, point.Y - 3, 6, 6);
                }
            }

            // Draw title
            using (var titleFont = new Font("Segoe UI", 14, FontStyle.Bold))
            {
                var title = "Occupancy Trend";
                var titleSize = g.MeasureString(title, titleFont);
                g.DrawString(title, titleFont, Brushes.Black, 
                    chartArea.X + (chartArea.Width - titleSize.Width) / 2, 
                    chartArea.Y - 30);
            }

            // Draw Y-axis labels
            using (var labelFont = new Font("Segoe UI", 9))
            {
                for (int i = 0; i <= 10; i++)
                {
                    var value = minValue + (range * i / 10);
                    var y = chartArea.Bottom - (i * chartArea.Height / 10);
                    g.DrawString($"{value:F0}%", labelFont, Brushes.Black, chartArea.X - 50, y - 8);
                }
            }
        }

        private void DrawRevenueChart(Graphics g, Rectangle chartArea)
        {
            var dataPoints = new List<float>();
            var labels = new List<string>();

            // Extract revenue data
            foreach (DataRow row in reportData.Rows)
            {
                if (decimal.TryParse(row["Total Revenue"].ToString(), out decimal revenue))
                {
                    dataPoints.Add((float)revenue);
                    labels.Add(row["Week"].ToString());
                }
            }

            if (dataPoints.Count == 0) return;

            var maxValue = dataPoints.Max();
            var minValue = 0f;
            var range = maxValue - minValue;

            // Draw bar chart
            var barWidth = chartArea.Width / (dataPoints.Count * 2);
            
            using (var barBrush = new SolidBrush(Color.FromArgb(34, 197, 94)))
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    var x = chartArea.X + (i * chartArea.Width / dataPoints.Count) + barWidth / 2;
                    var barHeight = (dataPoints[i] / range) * chartArea.Height;
                    var y = chartArea.Bottom - barHeight;
                    
                    var barRect = new RectangleF(x, y, barWidth, barHeight);
                    g.FillRectangle(barBrush, barRect);
                    g.DrawRectangle(Pens.DarkGreen, Rectangle.Round(barRect));
                    
                    // Draw value on top of bar
                    using (var valueFont = new Font("Segoe UI", 8))
                    {
                        var valueText = $"${dataPoints[i]:F0}";
                        var valueSize = g.MeasureString(valueText, valueFont);
                        g.DrawString(valueText, valueFont, Brushes.Black, 
                            x + (barWidth - valueSize.Width) / 2, y - 20);
                    }
                }
            }

            // Draw title
            using (var titleFont = new Font("Segoe UI", 14, FontStyle.Bold))
            {
                var title = "Weekly Revenue";
                var titleSize = g.MeasureString(title, titleFont);
                g.DrawString(title, titleFont, Brushes.Black, 
                    chartArea.X + (chartArea.Width - titleSize.Width) / 2, 
                    chartArea.Y - 30);
            }

            // Draw X-axis labels
            using (var labelFont = new Font("Segoe UI", 9))
            {
                for (int i = 0; i < labels.Count; i++)
                {
                    var x = chartArea.X + (i * chartArea.Width / dataPoints.Count) + barWidth / 2;
                    var labelSize = g.MeasureString(labels[i], labelFont);
                    g.DrawString(labels[i], labelFont, Brushes.Black, 
                        x + (barWidth - labelSize.Width) / 2, chartArea.Bottom + 10);
                }
            }
        }

        #endregion
    }
}