using System.Windows.Forms;
using System.Drawing;

namespace PhumlaniKamnandi.Presentation
{
    partial class NewBooking
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlConfirmation = new System.Windows.Forms.Panel();
            this.lblDepositRequired = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalNights = new System.Windows.Forms.Label();
            this.pnlGuestDetails = new System.Windows.Forms.Panel();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.pnlGuestSelection = new System.Windows.Forms.Panel();
            this.btnFindGuest = new System.Windows.Forms.Button();
            this.txtSelectedGuest = new System.Windows.Forms.TextBox();
            this.lblSelectedGuest = new System.Windows.Forms.Label();
            this.rbNewGuest = new System.Windows.Forms.RadioButton();
            this.rbExistingGuest = new System.Windows.Forms.RadioButton();
            this.lblGuestType = new System.Windows.Forms.Label();
            this.pnlDates = new System.Windows.Forms.Panel();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlConfirmation.SuspendLayout();
            this.pnlGuestDetails.SuspendLayout();
            this.pnlGuestSelection.SuspendLayout();
            this.pnlDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.pnlConfirmation);
            this.pnlMain.Controls.Add(this.pnlGuestDetails);
            this.pnlMain.Controls.Add(this.pnlGuestSelection);
            this.pnlMain.Controls.Add(this.pnlDates);
            this.pnlMain.Controls.Add(this.lblStep3);
            this.pnlMain.Controls.Add(this.lblStep2);
            this.pnlMain.Controls.Add(this.lblStep1);
            this.pnlMain.Controls.Add(this.btnConfirmBooking);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 524);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlConfirmation
            // 
            this.pnlConfirmation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfirmation.Controls.Add(this.lblDepositRequired);
            this.pnlConfirmation.Controls.Add(this.lblTotalCost);
            this.pnlConfirmation.Controls.Add(this.lblTotalNights);
            this.pnlConfirmation.Location = new System.Drawing.Point(43, 393);
            this.pnlConfirmation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlConfirmation.Name = "pnlConfirmation";
            this.pnlConfirmation.Size = new System.Drawing.Size(514, 70);
            this.pnlConfirmation.TabIndex = 13;
            // 
            // lblDepositRequired
            // 
            this.lblDepositRequired.AutoSize = true;
            this.lblDepositRequired.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDepositRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(127)))));
            this.lblDepositRequired.Location = new System.Drawing.Point(300, 39);
            this.lblDepositRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepositRequired.Name = "lblDepositRequired";
            this.lblDepositRequired.Size = new System.Drawing.Size(169, 19);
            this.lblDepositRequired.TabIndex = 2;
            this.lblDepositRequired.Text = "Deposit Required: $0.00";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalCost.Location = new System.Drawing.Point(300, 18);
            this.lblTotalCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(119, 19);
            this.lblTotalCost.TabIndex = 1;
            this.lblTotalCost.Text = "Total Cost: $0.00";
            // 
            // lblTotalNights
            // 
            this.lblTotalNights.AutoSize = true;
            this.lblTotalNights.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalNights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTotalNights.Location = new System.Drawing.Point(17, 18);
            this.lblTotalNights.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalNights.Name = "lblTotalNights";
            this.lblTotalNights.Size = new System.Drawing.Size(105, 19);
            this.lblTotalNights.TabIndex = 0;
            this.lblTotalNights.Text = "Total Nights: 0";
            // 
            // pnlGuestDetails
            // 
            this.pnlGuestDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlGuestDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGuestDetails.Controls.Add(this.txtPostalCode);
            this.pnlGuestDetails.Controls.Add(this.lblPostalCode);
            this.pnlGuestDetails.Controls.Add(this.txtAddress2);
            this.pnlGuestDetails.Controls.Add(this.lblAddress2);
            this.pnlGuestDetails.Controls.Add(this.txtAddress1);
            this.pnlGuestDetails.Controls.Add(this.lblAddress1);
            this.pnlGuestDetails.Controls.Add(this.txtTelephone);
            this.pnlGuestDetails.Controls.Add(this.lblTelephone);
            this.pnlGuestDetails.Controls.Add(this.txtGuestName);
            this.pnlGuestDetails.Controls.Add(this.lblGuestName);
            this.pnlGuestDetails.Location = new System.Drawing.Point(43, 242);
            this.pnlGuestDetails.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlGuestDetails.Name = "pnlGuestDetails";
            this.pnlGuestDetails.Size = new System.Drawing.Size(514, 130);
            this.pnlGuestDetails.TabIndex = 12;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPostalCode.Location = new System.Drawing.Point(128, 96);
            this.txtPostalCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(172, 23);
            this.txtPostalCode.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPostalCode.Location = new System.Drawing.Point(17, 99);
            this.lblPostalCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(73, 15);
            this.lblPostalCode.TabIndex = 7;
            this.lblPostalCode.Text = "Postal Code:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress2.Location = new System.Drawing.Point(128, 70);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(172, 23);
            this.txtAddress2.TabIndex = 6;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress2.Location = new System.Drawing.Point(17, 73);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(86, 15);
            this.lblAddress2.TabIndex = 5;
            this.lblAddress2.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress1.Location = new System.Drawing.Point(128, 44);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(172, 23);
            this.txtAddress1.TabIndex = 4;
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress1.Location = new System.Drawing.Point(17, 47);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(86, 15);
            this.lblAddress1.TabIndex = 3;
            this.lblAddress1.Text = "Address Line 1:";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelephone.Location = new System.Drawing.Point(128, 18);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(172, 23);
            this.txtTelephone.TabIndex = 2;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelephone.Location = new System.Drawing.Point(17, 21);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(65, 15);
            this.lblTelephone.TabIndex = 1;
            this.lblTelephone.Text = "Telephone:";
            // 
            // txtGuestName
            // 
            this.txtGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGuestName.Location = new System.Drawing.Point(386, 18);
            this.txtGuestName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(104, 23);
            this.txtGuestName.TabIndex = 0;
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGuestName.Location = new System.Drawing.Point(326, 21);
            this.lblGuestName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(64, 15);
            this.lblGuestName.TabIndex = 9;
            this.lblGuestName.Text = "Full Name:";
            // 
            // pnlGuestSelection
            // 
            this.pnlGuestSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlGuestSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGuestSelection.Controls.Add(this.btnFindGuest);
            this.pnlGuestSelection.Controls.Add(this.txtSelectedGuest);
            this.pnlGuestSelection.Controls.Add(this.lblSelectedGuest);
            this.pnlGuestSelection.Controls.Add(this.rbNewGuest);
            this.pnlGuestSelection.Controls.Add(this.rbExistingGuest);
            this.pnlGuestSelection.Controls.Add(this.lblGuestType);
            this.pnlGuestSelection.Location = new System.Drawing.Point(43, 156);
            this.pnlGuestSelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlGuestSelection.Name = "pnlGuestSelection";
            this.pnlGuestSelection.Size = new System.Drawing.Size(514, 78);
            this.pnlGuestSelection.TabIndex = 11;
            // 
            // btnFindGuest
            // 
            this.btnFindGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnFindGuest.FlatAppearance.BorderSize = 0;
            this.btnFindGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindGuest.ForeColor = System.Drawing.Color.White;
            this.btnFindGuest.Location = new System.Drawing.Point(386, 39);
            this.btnFindGuest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFindGuest.Name = "btnFindGuest";
            this.btnFindGuest.Size = new System.Drawing.Size(103, 26);
            this.btnFindGuest.TabIndex = 5;
            this.btnFindGuest.Text = "Find Guest";
            this.btnFindGuest.UseVisualStyleBackColor = false;
            this.btnFindGuest.Click += new System.EventHandler(this.btnFindGuest_Click);
            // 
            // txtSelectedGuest
            // 
            this.txtSelectedGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtSelectedGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSelectedGuest.Location = new System.Drawing.Point(128, 39);
            this.txtSelectedGuest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSelectedGuest.Name = "txtSelectedGuest";
            this.txtSelectedGuest.ReadOnly = true;
            this.txtSelectedGuest.Size = new System.Drawing.Size(249, 23);
            this.txtSelectedGuest.TabIndex = 4;
            // 
            // lblSelectedGuest
            // 
            this.lblSelectedGuest.AutoSize = true;
            this.lblSelectedGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectedGuest.Location = new System.Drawing.Point(17, 44);
            this.lblSelectedGuest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedGuest.Name = "lblSelectedGuest";
            this.lblSelectedGuest.Size = new System.Drawing.Size(87, 15);
            this.lblSelectedGuest.TabIndex = 3;
            this.lblSelectedGuest.Text = "Selected Guest:";
            // 
            // rbNewGuest
            // 
            this.rbNewGuest.AutoSize = true;
            this.rbNewGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbNewGuest.Location = new System.Drawing.Point(128, 13);
            this.rbNewGuest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbNewGuest.Name = "rbNewGuest";
            this.rbNewGuest.Size = new System.Drawing.Size(82, 19);
            this.rbNewGuest.TabIndex = 2;
            this.rbNewGuest.Text = "New Guest";
            this.rbNewGuest.UseVisualStyleBackColor = true;
            this.rbNewGuest.CheckedChanged += new System.EventHandler(this.rbNewGuest_CheckedChanged);
            // 
            // rbExistingGuest
            // 
            this.rbExistingGuest.AutoSize = true;
            this.rbExistingGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbExistingGuest.Location = new System.Drawing.Point(17, 13);
            this.rbExistingGuest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbExistingGuest.Name = "rbExistingGuest";
            this.rbExistingGuest.Size = new System.Drawing.Size(98, 19);
            this.rbExistingGuest.TabIndex = 1;
            this.rbExistingGuest.Text = "Existing Guest";
            this.rbExistingGuest.UseVisualStyleBackColor = true;
            this.rbExistingGuest.CheckedChanged += new System.EventHandler(this.rbExistingGuest_CheckedChanged);
            // 
            // lblGuestType
            // 
            this.lblGuestType.AutoSize = true;
            this.lblGuestType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGuestType.Location = new System.Drawing.Point(13, -5);
            this.lblGuestType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuestType.Name = "lblGuestType";
            this.lblGuestType.Size = new System.Drawing.Size(0, 19);
            this.lblGuestType.TabIndex = 0;
            // 
            // pnlDates
            // 
            this.pnlDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlDates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDates.Controls.Add(this.btnCheckAvailability);
            this.pnlDates.Controls.Add(this.dtpCheckOut);
            this.pnlDates.Controls.Add(this.lblCheckOut);
            this.pnlDates.Controls.Add(this.dtpCheckIn);
            this.pnlDates.Controls.Add(this.lblCheckIn);
            this.pnlDates.Location = new System.Drawing.Point(43, 62);
            this.pnlDates.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(514, 61);
            this.pnlDates.TabIndex = 10;
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnCheckAvailability.FlatAppearance.BorderSize = 0;
            this.btnCheckAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAvailability.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheckAvailability.ForeColor = System.Drawing.Color.White;
            this.btnCheckAvailability.Location = new System.Drawing.Point(386, 18);
            this.btnCheckAvailability.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(112, 26);
            this.btnCheckAvailability.TabIndex = 4;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = false;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckOut.Location = new System.Drawing.Point(240, 18);
            this.dtpCheckOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(104, 23);
            this.dtpCheckOut.TabIndex = 3;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckOut.Location = new System.Drawing.Point(176, 21);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(66, 15);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "Check-out:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckIn.Location = new System.Drawing.Point(68, 18);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(104, 23);
            this.dtpCheckIn.TabIndex = 1;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckIn.Location = new System.Drawing.Point(17, 21);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(58, 15);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Check-in:";
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblStep3.Location = new System.Drawing.Point(17, 372);
            this.lblStep3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(173, 21);
            this.lblStep3.TabIndex = 5;
            this.lblStep3.Text = "Step 3 - Confirmation";
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblStep2.Location = new System.Drawing.Point(19, 134);
            this.lblStep2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(114, 21);
            this.lblStep2.TabIndex = 4;
            this.lblStep2.Text = "Step 2 - Guest";
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblStep1.Location = new System.Drawing.Point(17, 42);
            this.lblStep1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(114, 21);
            this.lblStep1.TabIndex = 3;
            this.lblStep1.Text = "Step 1 - Dates";
            // 
            // btnConfirmBooking
            // 
            this.btnConfirmBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnConfirmBooking.FlatAppearance.BorderSize = 0;
            this.btnConfirmBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmBooking.ForeColor = System.Drawing.Color.White;
            this.btnConfirmBooking.Location = new System.Drawing.Point(386, 486);
            this.btnConfirmBooking.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConfirmBooking.Name = "btnConfirmBooking";
            this.btnConfirmBooking.Size = new System.Drawing.Size(137, 34);
            this.btnConfirmBooking.TabIndex = 6;
            this.btnConfirmBooking.Text = "Confirm and Save\r\n";
            this.btnConfirmBooking.UseVisualStyleBackColor = false;
            this.btnConfirmBooking.Click += new System.EventHandler(this.btnConfirmBooking_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(240, 486);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(215, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Booking";
            // 
            // NewBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 524);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Booking";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlConfirmation.ResumeLayout(false);
            this.pnlConfirmation.PerformLayout();
            this.pnlGuestDetails.ResumeLayout(false);
            this.pnlGuestDetails.PerformLayout();
            this.pnlGuestSelection.ResumeLayout(false);
            this.pnlGuestSelection.PerformLayout();
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlConfirmation;
        private System.Windows.Forms.Label lblDepositRequired;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalNights;
        private System.Windows.Forms.Panel pnlGuestDetails;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Panel pnlGuestSelection;
        private System.Windows.Forms.Button btnFindGuest;
        private System.Windows.Forms.TextBox txtSelectedGuest;
        private System.Windows.Forms.Label lblSelectedGuest;
        private System.Windows.Forms.RadioButton rbNewGuest;
        private System.Windows.Forms.RadioButton rbExistingGuest;
        private System.Windows.Forms.Label lblGuestType;
        private System.Windows.Forms.Panel pnlDates;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Button btnConfirmBooking;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
    }
}