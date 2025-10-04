using System.Windows.Forms;
using System.Drawing;

namespace PhumlaniKamnandi.Presentation
{
    partial class MainDashboard
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblWelcome = new Label();
            lblDateTime = new Label();
            btnMakeNewBooking = new Button();
            btnManageBookings = new Button();
            btnViewReports = new Button();
            pnlOccupancy = new Panel();
            lblOccupancy = new Label();
            timerDateTime = new System.Windows.Forms.Timer(components);
            pnlMain = new Panel();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(12, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(537, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hotel Management System";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14F);
            lblWelcome.ForeColor = Color.FromArgb(64, 64, 64);
            lblWelcome.Location = new Point(12, 54);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(521, 32);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome to the Hotel Management Dashboard";
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 10F);
            lblDateTime.ForeColor = Color.FromArgb(128, 128, 128);
            lblDateTime.Location = new Point(743, 53);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(286, 23);
            lblDateTime.TabIndex = 2;
            lblDateTime.Text = "Monday, January 01, 2024 - 12:00:00";
            // 
            // btnMakeNewBooking
            // 
            btnMakeNewBooking.BackColor = Color.FromArgb(0, 122, 204);
            btnMakeNewBooking.FlatAppearance.BorderSize = 0;
            btnMakeNewBooking.FlatStyle = FlatStyle.Flat;
            btnMakeNewBooking.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMakeNewBooking.ForeColor = Color.White;
            btnMakeNewBooking.Location = new Point(171, 200);
            btnMakeNewBooking.Margin = new Padding(3, 4, 3, 4);
            btnMakeNewBooking.Name = "btnMakeNewBooking";
            btnMakeNewBooking.Size = new Size(286, 107);
            btnMakeNewBooking.TabIndex = 3;
            btnMakeNewBooking.Text = "Make New Booking";
            btnMakeNewBooking.UseVisualStyleBackColor = false;
            btnMakeNewBooking.Click += btnMakeNewBooking_Click;
            // 
            // btnManageBookings
            // 
            btnManageBookings.BackColor = Color.FromArgb(34, 139, 34);
            btnManageBookings.FlatAppearance.BorderSize = 0;
            btnManageBookings.FlatStyle = FlatStyle.Flat;
            btnManageBookings.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageBookings.ForeColor = Color.White;
            btnManageBookings.Location = new Point(171, 333);
            btnManageBookings.Margin = new Padding(3, 4, 3, 4);
            btnManageBookings.Name = "btnManageBookings";
            btnManageBookings.Size = new Size(286, 107);
            btnManageBookings.TabIndex = 4;
            btnManageBookings.Text = "Manage Existing Bookings";
            btnManageBookings.UseVisualStyleBackColor = false;
            btnManageBookings.Click += btnManageBookings_Click;
            // 
            // btnViewReports
            // 
            btnViewReports.BackColor = Color.FromArgb(255, 140, 0);
            btnViewReports.FlatAppearance.BorderSize = 0;
            btnViewReports.FlatStyle = FlatStyle.Flat;
            btnViewReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnViewReports.ForeColor = Color.White;
            btnViewReports.Location = new Point(171, 467);
            btnViewReports.Margin = new Padding(3, 4, 3, 4);
            btnViewReports.Name = "btnViewReports";
            btnViewReports.Size = new Size(286, 107);
            btnViewReports.TabIndex = 5;
            btnViewReports.Text = "View Reports";
            btnViewReports.UseVisualStyleBackColor = false;
            btnViewReports.Click += btnViewReports_Click;
            // 
            // pnlOccupancy
            // 
            pnlOccupancy.BackColor = Color.FromArgb(192, 255, 192);
            pnlOccupancy.BorderStyle = BorderStyle.FixedSingle;
            pnlOccupancy.Location = new Point(571, 200);
            pnlOccupancy.Margin = new Padding(3, 4, 3, 4);
            pnlOccupancy.Name = "pnlOccupancy";
            pnlOccupancy.Size = new Size(343, 133);
            pnlOccupancy.TabIndex = 6;
            // 
            // lblOccupancy
            // 
            lblOccupancy.AutoSize = true;
            lblOccupancy.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblOccupancy.ForeColor = Color.FromArgb(0, 64, 0);
            lblOccupancy.Location = new Point(153, 113);
            lblOccupancy.Name = "lblOccupancy";
            lblOccupancy.Size = new Size(315, 32);
            lblOccupancy.TabIndex = 0;
            lblOccupancy.Text = "Today's Occupancy: 75.5%";
            // 
            // timerDateTime
            // 
            timerDateTime.Enabled = true;
            timerDateTime.Interval = 1000;
            timerDateTime.Tick += timerDateTime_Tick;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 248, 255);
            pnlMain.Controls.Add(lblOccupancy);
            pnlMain.Controls.Add(pnlOccupancy);
            pnlMain.Controls.Add(btnViewReports);
            pnlMain.Controls.Add(btnManageBookings);
            pnlMain.Controls.Add(btnMakeNewBooking);
            pnlMain.Controls.Add(lblDateTime);
            pnlMain.Controls.Add(lblWelcome);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1074, 800);
            pnlMain.TabIndex = 0;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1074, 800);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Management System - Main Dashboard";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnMakeNewBooking;
        private System.Windows.Forms.Button btnManageBookings;
        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Panel pnlOccupancy;
        private System.Windows.Forms.Label lblOccupancy;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.Panel pnlMain;
    }
}