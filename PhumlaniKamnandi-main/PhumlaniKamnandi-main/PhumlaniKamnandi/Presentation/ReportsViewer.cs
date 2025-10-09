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
        public ReportsViewer(string reportType, DataTable reportData, string reportTitle)
        {
            InitializeComponent();
            LoadReport(reportType, reportData, reportTitle);
        }

        private void LoadReport(string reportType, DataTable reportData, string reportTitle)
        {
            lblReportTitle.Text = reportTitle;
            lblReportType.Text = reportType;

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

            // This is to add headers
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
    }
}