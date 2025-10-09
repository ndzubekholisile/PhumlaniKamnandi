namespace PhumlaniKamnandi.Presentation
{
    partial class ReportsDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            btnClose = new Button();
            pnlRevenueReport = new Panel();
            btnGenerateRevenueReport = new Button();
            dtpRevenueMonth = new DateTimePicker();
            lblRevenueMonth = new Label();
            lblRevenueReportTitle = new Label();
            pnlOccupancyReport = new Panel();
            btnGenerateOccupancyReport = new Button();
            dtpOccupancyEnd = new DateTimePicker();
            lblOccupancyTo = new Label();
            dtpOccupancyStart = new DateTimePicker();
            lblOccupancyFrom = new Label();
            lblOccupancyReportTitle = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlRevenueReport.SuspendLayout();
            pnlOccupancyReport.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Controls.Add(pnlRevenueReport);
            pnlMain.Controls.Add(pnlOccupancyReport);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(914, 667);
            pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(156, 163, 175);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(690, 558);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(167, 68);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlRevenueReport
            // 
            pnlRevenueReport.BackColor = Color.FromArgb(255, 251, 235);
            pnlRevenueReport.BorderStyle = BorderStyle.FixedSingle;
            pnlRevenueReport.Controls.Add(btnGenerateRevenueReport);
            pnlRevenueReport.Controls.Add(dtpRevenueMonth);
            pnlRevenueReport.Controls.Add(lblRevenueMonth);
            pnlRevenueReport.Controls.Add(lblRevenueReportTitle);
            pnlRevenueReport.Location = new Point(57, 333);
            pnlRevenueReport.Margin = new Padding(3, 4, 3, 4);
            pnlRevenueReport.Name = "pnlRevenueReport";
            pnlRevenueReport.Size = new Size(800, 159);
            pnlRevenueReport.TabIndex = 3;
            // 
            // btnGenerateRevenueReport
            // 
            btnGenerateRevenueReport.BackColor = Color.FromArgb(255, 140, 0);
            btnGenerateRevenueReport.FlatAppearance.BorderSize = 0;
            btnGenerateRevenueReport.FlatStyle = FlatStyle.Flat;
            btnGenerateRevenueReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateRevenueReport.ForeColor = Color.White;
            btnGenerateRevenueReport.Location = new Point(571, 93);
            btnGenerateRevenueReport.Margin = new Padding(3, 4, 3, 4);
            btnGenerateRevenueReport.Name = "btnGenerateRevenueReport";
            btnGenerateRevenueReport.Size = new Size(183, 47);
            btnGenerateRevenueReport.TabIndex = 3;
            btnGenerateRevenueReport.Text = "Generate Report";
            btnGenerateRevenueReport.UseVisualStyleBackColor = false;
            btnGenerateRevenueReport.Click += btnGenerateRevenueReport_Click;
            // 
            // dtpRevenueMonth
            // 
            dtpRevenueMonth.CustomFormat = "MMMM yyyy";
            dtpRevenueMonth.Font = new Font("Segoe UI", 9F);
            dtpRevenueMonth.Format = DateTimePickerFormat.Custom;
            dtpRevenueMonth.Location = new Point(296, 107);
            dtpRevenueMonth.Margin = new Padding(3, 4, 3, 4);
            dtpRevenueMonth.Name = "dtpRevenueMonth";
            dtpRevenueMonth.ShowUpDown = true;
            dtpRevenueMonth.Size = new Size(137, 27);
            dtpRevenueMonth.TabIndex = 2;
            // 
            // lblRevenueMonth
            // 
            lblRevenueMonth.AutoSize = true;
            lblRevenueMonth.Font = new Font("Segoe UI", 10F);
            lblRevenueMonth.Location = new Point(23, 107);
            lblRevenueMonth.Name = "lblRevenueMonth";
            lblRevenueMonth.Size = new Size(267, 23);
            lblRevenueMonth.TabIndex = 1;
            lblRevenueMonth.Text = "Select Month for Revenue Report:";
            // 
            // lblRevenueReportTitle
            // 
            lblRevenueReportTitle.AutoSize = true;
            lblRevenueReportTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRevenueReportTitle.ForeColor = Color.FromArgb(234, 88, 12);
            lblRevenueReportTitle.Location = new Point(23, 27);
            lblRevenueReportTitle.Name = "lblRevenueReportTitle";
            lblRevenueReportTitle.Size = new Size(196, 32);
            lblRevenueReportTitle.TabIndex = 0;
            lblRevenueReportTitle.Text = "Revenue Report";
            // 
            // pnlOccupancyReport
            // 
            pnlOccupancyReport.BackColor = Color.FromArgb(255, 251, 235);
            pnlOccupancyReport.BorderStyle = BorderStyle.FixedSingle;
            pnlOccupancyReport.Controls.Add(btnGenerateOccupancyReport);
            pnlOccupancyReport.Controls.Add(dtpOccupancyEnd);
            pnlOccupancyReport.Controls.Add(lblOccupancyTo);
            pnlOccupancyReport.Controls.Add(dtpOccupancyStart);
            pnlOccupancyReport.Controls.Add(lblOccupancyFrom);
            pnlOccupancyReport.Controls.Add(lblOccupancyReportTitle);
            pnlOccupancyReport.Location = new Point(57, 133);
            pnlOccupancyReport.Margin = new Padding(3, 4, 3, 4);
            pnlOccupancyReport.Name = "pnlOccupancyReport";
            pnlOccupancyReport.Size = new Size(800, 159);
            pnlOccupancyReport.TabIndex = 2;
            // 
            // btnGenerateOccupancyReport
            // 
            btnGenerateOccupancyReport.BackColor = Color.FromArgb(34, 197, 94);
            btnGenerateOccupancyReport.FlatAppearance.BorderSize = 0;
            btnGenerateOccupancyReport.FlatStyle = FlatStyle.Flat;
            btnGenerateOccupancyReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateOccupancyReport.ForeColor = Color.White;
            btnGenerateOccupancyReport.Location = new Point(571, 93);
            btnGenerateOccupancyReport.Margin = new Padding(3, 4, 3, 4);
            btnGenerateOccupancyReport.Name = "btnGenerateOccupancyReport";
            btnGenerateOccupancyReport.Size = new Size(194, 47);
            btnGenerateOccupancyReport.TabIndex = 5;
            btnGenerateOccupancyReport.Text = "Generate Report";
            btnGenerateOccupancyReport.UseVisualStyleBackColor = false;
            btnGenerateOccupancyReport.Click += btnGenerateOccupancyReport_Click;
            // 
            // dtpOccupancyEnd
            // 
            dtpOccupancyEnd.Font = new Font("Segoe UI", 9F);
            dtpOccupancyEnd.Location = new Point(415, 102);
            dtpOccupancyEnd.Margin = new Padding(3, 4, 3, 4);
            dtpOccupancyEnd.Name = "dtpOccupancyEnd";
            dtpOccupancyEnd.Size = new Size(137, 27);
            dtpOccupancyEnd.TabIndex = 4;
            // 
            // lblOccupancyTo
            // 
            lblOccupancyTo.AutoSize = true;
            lblOccupancyTo.Font = new Font("Segoe UI", 9F);
            lblOccupancyTo.Location = new Point(344, 107);
            lblOccupancyTo.Name = "lblOccupancyTo";
            lblOccupancyTo.Size = new Size(64, 20);
            lblOccupancyTo.TabIndex = 3;
            lblOccupancyTo.Text = "To Date:";
            // 
            // dtpOccupancyStart
            // 
            dtpOccupancyStart.Font = new Font("Segoe UI", 9F);
            dtpOccupancyStart.Location = new Point(201, 102);
            dtpOccupancyStart.Margin = new Padding(3, 4, 3, 4);
            dtpOccupancyStart.Name = "dtpOccupancyStart";
            dtpOccupancyStart.Size = new Size(137, 27);
            dtpOccupancyStart.TabIndex = 2;
            // 
            // lblOccupancyFrom
            // 
            lblOccupancyFrom.AutoSize = true;
            lblOccupancyFrom.Font = new Font("Segoe UI", 9F);
            lblOccupancyFrom.Location = new Point(23, 107);
            lblOccupancyFrom.Name = "lblOccupancyFrom";
            lblOccupancyFrom.Size = new Size(172, 20);
            lblOccupancyFrom.TabIndex = 1;
            lblOccupancyFrom.Text = "Select Date Range From:";
            // 
            // lblOccupancyReportTitle
            // 
            lblOccupancyReportTitle.AutoSize = true;
            lblOccupancyReportTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOccupancyReportTitle.ForeColor = Color.FromArgb(59, 130, 246);
            lblOccupancyReportTitle.Location = new Point(23, 27);
            lblOccupancyReportTitle.Name = "lblOccupancyReportTitle";
            lblOccupancyReportTitle.Size = new Size(224, 32);
            lblOccupancyReportTitle.TabIndex = 0;
            lblOccupancyReportTitle.Text = "Occupancy Report";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(57, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(289, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports Dashboard";
            // 
            // ReportsDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 667);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReportsDashboard";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reports Dashboard";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlRevenueReport.ResumeLayout(false);
            pnlRevenueReport.PerformLayout();
            pnlOccupancyReport.ResumeLayout(false);
            pnlOccupancyReport.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlRevenueReport;
        private System.Windows.Forms.Button btnGenerateRevenueReport;
        private System.Windows.Forms.DateTimePicker dtpRevenueMonth;
        private System.Windows.Forms.Label lblRevenueMonth;
        private System.Windows.Forms.Label lblRevenueReportTitle;
        private System.Windows.Forms.Panel pnlOccupancyReport;
        private System.Windows.Forms.Button btnGenerateOccupancyReport;
        private System.Windows.Forms.DateTimePicker dtpOccupancyEnd;
        private System.Windows.Forms.Label lblOccupancyTo;
        private System.Windows.Forms.DateTimePicker dtpOccupancyStart;
        private System.Windows.Forms.Label lblOccupancyFrom;
        private System.Windows.Forms.Label lblOccupancyReportTitle;
        private System.Windows.Forms.Label lblTitle;
    }
}