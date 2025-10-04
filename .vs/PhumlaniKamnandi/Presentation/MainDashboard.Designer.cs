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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnMakeNewBooking = new System.Windows.Forms.Button();
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.pnlOccupancy = new System.Windows.Forms.Panel();
            this.lblOccupancy = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(537, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hotel Management System";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWelcome.Location = new System.Drawing.Point(12, 54);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(521, 32);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome to the Hotel Management Dashboard";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblDateTime.Location = new System.Drawing.Point(743, 42);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(286, 23);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "Monday, January 01, 2024 - 12:00:00";
            // 
            // btnMakeNewBooking
            // 
            this.btnMakeNewBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnMakeNewBooking.FlatAppearance.BorderSize = 0;
            this.btnMakeNewBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeNewBooking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMakeNewBooking.ForeColor = System.Drawing.Color.White;
            this.btnMakeNewBooking.Location = new System.Drawing.Point(171, 160);
            this.btnMakeNewBooking.Name = "btnMakeNewBooking";
            this.btnMakeNewBooking.Size = new System.Drawing.Size(286, 86);
            this.btnMakeNewBooking.TabIndex = 3;
            this.btnMakeNewBooking.Text = "Make New Booking";
            this.btnMakeNewBooking.UseVisualStyleBackColor = false;
            // 
            // btnManageBookings
            // 
            this.btnManageBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnManageBookings.FlatAppearance.BorderSize = 0;
            this.btnManageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageBookings.ForeColor = System.Drawing.Color.White;
            this.btnManageBookings.Location = new System.Drawing.Point(171, 266);
            this.btnManageBookings.Name = "btnManageBookings";
            this.btnManageBookings.Size = new System.Drawing.Size(286, 86);
            this.btnManageBookings.TabIndex = 4;
            this.btnManageBookings.Text = "Manage Existing Bookings";
            this.btnManageBookings.UseVisualStyleBackColor = false;
            // 
            // btnViewReports
            // 
            this.btnViewReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnViewReports.FlatAppearance.BorderSize = 0;
            this.btnViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewReports.ForeColor = System.Drawing.Color.White;
            this.btnViewReports.Location = new System.Drawing.Point(171, 374);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(286, 86);
            this.btnViewReports.TabIndex = 5;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = false;
            // 
            // pnlOccupancy
            // 
            this.pnlOccupancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlOccupancy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOccupancy.Location = new System.Drawing.Point(571, 160);
            this.pnlOccupancy.Name = "pnlOccupancy";
            this.pnlOccupancy.Size = new System.Drawing.Size(343, 107);
            this.pnlOccupancy.TabIndex = 6;
            // 
            // lblOccupancy
            // 
            this.lblOccupancy.AutoSize = true;
            this.lblOccupancy.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOccupancy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblOccupancy.Location = new System.Drawing.Point(153, 90);
            this.lblOccupancy.Name = "lblOccupancy";
            this.lblOccupancy.Size = new System.Drawing.Size(315, 32);
            this.lblOccupancy.TabIndex = 0;
            this.lblOccupancy.Text = "Today\'s Occupancy: 75.5%";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlMain.Controls.Add(this.lblOccupancy);
            this.pnlMain.Controls.Add(this.pnlOccupancy);
            this.pnlMain.Controls.Add(this.btnViewReports);
            this.pnlMain.Controls.Add(this.btnManageBookings);
            this.pnlMain.Controls.Add(this.btnMakeNewBooking);
            this.pnlMain.Controls.Add(this.lblDateTime);
            this.pnlMain.Controls.Add(this.lblWelcome);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1074, 640);
            this.pnlMain.TabIndex = 0;
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 640);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management System - Main Dashboard";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

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