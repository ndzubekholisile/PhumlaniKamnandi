using System.Windows.Forms;
using System.Drawing;

namespace PhumlaniKamnandi.Presentation
{
    partial class BookingDetails
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlCosts = new System.Windows.Forms.Panel();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalNights = new System.Windows.Forms.Label();
            this.pnlBookingInfo = new System.Windows.Forms.Panel();
            this.lblDateBooked = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.lblReservationID = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
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
            this.pnlDates = new System.Windows.Forms.Panel();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblEditMode = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlCosts.SuspendLayout();
            this.pnlBookingInfo.SuspendLayout();
            this.pnlGuestDetails.SuspendLayout();
            this.pnlDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.btnCancelEdit);
            this.pnlMain.Controls.Add(this.btnSaveChanges);
            this.pnlMain.Controls.Add(this.btnEdit);
            this.pnlMain.Controls.Add(this.pnlCosts);
            this.pnlMain.Controls.Add(this.pnlBookingInfo);
            this.pnlMain.Controls.Add(this.pnlGuestDetails);
            this.pnlMain.Controls.Add(this.pnlDates);
            this.pnlMain.Controls.Add(this.lblEditMode);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(686, 487);
            this.pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(555, 448);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 34);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.Location = new System.Drawing.Point(391, 448);
            this.btnCancelEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(103, 34);
            this.btnCancelEdit.TabIndex = 8;
            this.btnCancelEdit.Text = "Cancel Edit";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Visible = false;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(206, 448);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(120, 34);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(40, 448);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 34);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // pnlCosts
            // 
            this.pnlCosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlCosts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCosts.Controls.Add(this.lblDeposit);
            this.pnlCosts.Controls.Add(this.lblTotalCost);
            this.pnlCosts.Controls.Add(this.lblTotalNights);
            this.pnlCosts.Location = new System.Drawing.Point(40, 396);
            this.pnlCosts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlCosts.Name = "pnlCosts";
            this.pnlCosts.Size = new System.Drawing.Size(600, 44);
            this.pnlCosts.TabIndex = 5;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(127)))));
            this.lblDeposit.Location = new System.Drawing.Point(386, 13);
            this.lblDeposit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(139, 19);
            this.lblDeposit.TabIndex = 2;
            this.lblDeposit.Text = "Deposit Paid: R0.00";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalCost.Location = new System.Drawing.Point(214, 13);
            this.lblTotalCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(120, 19);
            this.lblTotalCost.TabIndex = 1;
            this.lblTotalCost.Text = "Total Cost: R0.00";
            // 
            // lblTotalNights
            // 
            this.lblTotalNights.AutoSize = true;
            this.lblTotalNights.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalNights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTotalNights.Location = new System.Drawing.Point(17, 13);
            this.lblTotalNights.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalNights.Name = "lblTotalNights";
            this.lblTotalNights.Size = new System.Drawing.Size(105, 19);
            this.lblTotalNights.TabIndex = 0;
            this.lblTotalNights.Text = "Total Nights: 0";
            // 
            // pnlBookingInfo
            // 
            this.pnlBookingInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlBookingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBookingInfo.Controls.Add(this.lblDateBooked);
            this.pnlBookingInfo.Controls.Add(this.lblBookingID);
            this.pnlBookingInfo.Controls.Add(this.lblReservationID);
            this.pnlBookingInfo.Controls.Add(this.lblStatus);
            this.pnlBookingInfo.Location = new System.Drawing.Point(40, 327);
            this.pnlBookingInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlBookingInfo.Name = "pnlBookingInfo";
            this.pnlBookingInfo.Size = new System.Drawing.Size(600, 61);
            this.pnlBookingInfo.TabIndex = 4;
            // 
            // lblDateBooked
            // 
            this.lblDateBooked.AutoSize = true;
            this.lblDateBooked.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateBooked.Location = new System.Drawing.Point(17, 34);
            this.lblDateBooked.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateBooked.Name = "lblDateBooked";
            this.lblDateBooked.Size = new System.Drawing.Size(169, 19);
            this.lblDateBooked.TabIndex = 3;
            this.lblDateBooked.Text = "Date Booked: 01/01/2024";
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookingID.Location = new System.Drawing.Point(17, 13);
            this.lblBookingID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(92, 19);
            this.lblBookingID.TabIndex = 1;
            this.lblBookingID.Text = "Booking ID: 0";
            // 
            // lblReservationID
            // 
            this.lblReservationID.AutoSize = true;
            this.lblReservationID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReservationID.Location = new System.Drawing.Point(128, 13);
            this.lblReservationID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReservationID.Name = "lblReservationID";
            this.lblReservationID.Size = new System.Drawing.Size(123, 19);
            this.lblReservationID.TabIndex = 2;
            this.lblReservationID.Text = "Reservation ID: 0";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(257, 13);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status: confirmed";
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
            this.pnlGuestDetails.Location = new System.Drawing.Point(40, 153);
            this.pnlGuestDetails.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlGuestDetails.Name = "pnlGuestDetails";
            this.pnlGuestDetails.Size = new System.Drawing.Size(600, 165);
            this.pnlGuestDetails.TabIndex = 3;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.White;
            this.txtPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPostalCode.Location = new System.Drawing.Point(128, 130);
            this.txtPostalCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(172, 23);
            this.txtPostalCode.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPostalCode.Location = new System.Drawing.Point(17, 135);
            this.lblPostalCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(73, 15);
            this.lblPostalCode.TabIndex = 7;
            this.lblPostalCode.Text = "Postal Code:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.BackColor = System.Drawing.Color.White;
            this.txtAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress2.Location = new System.Drawing.Point(128, 104);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(172, 23);
            this.txtAddress2.TabIndex = 6;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress2.Location = new System.Drawing.Point(17, 109);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(86, 15);
            this.lblAddress2.TabIndex = 5;
            this.lblAddress2.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.BackColor = System.Drawing.Color.White;
            this.txtAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress1.Location = new System.Drawing.Point(128, 78);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(172, 23);
            this.txtAddress1.TabIndex = 4;
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress1.Location = new System.Drawing.Point(17, 83);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(86, 15);
            this.lblAddress1.TabIndex = 3;
            this.lblAddress1.Text = "Address Line 1:";
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.Color.White;
            this.txtTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelephone.Location = new System.Drawing.Point(128, 26);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(172, 23);
            this.txtTelephone.TabIndex = 2;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelephone.Location = new System.Drawing.Point(17, 31);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(65, 15);
            this.lblTelephone.TabIndex = 1;
            this.lblTelephone.Text = "Telephone:";
            // 
            // txtGuestName
            // 
            this.txtGuestName.BackColor = System.Drawing.Color.White;
            this.txtGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGuestName.Location = new System.Drawing.Point(128, 52);
            this.txtGuestName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(172, 23);
            this.txtGuestName.TabIndex = 0;
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGuestName.Location = new System.Drawing.Point(17, 57);
            this.lblGuestName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(64, 15);
            this.lblGuestName.TabIndex = 9;
            this.lblGuestName.Text = "Full Name:";
            // 
            // pnlDates
            // 
            this.pnlDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlDates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDates.Controls.Add(this.dtpCheckOut);
            this.pnlDates.Controls.Add(this.lblCheckOut);
            this.pnlDates.Controls.Add(this.dtpCheckIn);
            this.pnlDates.Controls.Add(this.lblCheckIn);
            this.pnlDates.Location = new System.Drawing.Point(40, 67);
            this.pnlDates.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(600, 78);
            this.pnlDates.TabIndex = 2;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Enabled = false;
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckOut.Location = new System.Drawing.Point(240, 26);
            this.dtpCheckOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(104, 23);
            this.dtpCheckOut.TabIndex = 3;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckOut.Location = new System.Drawing.Point(172, 31);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(66, 15);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "Check-out:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Enabled = false;
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckIn.Location = new System.Drawing.Point(68, 26);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(104, 23);
            this.dtpCheckIn.TabIndex = 1;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckIn.Location = new System.Drawing.Point(17, 31);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(58, 15);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Check-in:";
            // 
            // lblEditMode
            // 
            this.lblEditMode.AutoSize = true;
            this.lblEditMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblEditMode.Location = new System.Drawing.Point(40, 41);
            this.lblEditMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEditMode.Name = "lblEditMode";
            this.lblEditMode.Size = new System.Drawing.Size(96, 21);
            this.lblEditMode.TabIndex = 1;
            this.lblEditMode.Text = "View Mode";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(235, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Booking Details";
            // 
            // BookingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(686, 487);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookingDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Booking Details";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCosts.ResumeLayout(false);
            this.pnlCosts.PerformLayout();
            this.pnlBookingInfo.ResumeLayout(false);
            this.pnlBookingInfo.PerformLayout();
            this.pnlGuestDetails.ResumeLayout(false);
            this.pnlGuestDetails.PerformLayout();
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlCosts;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalNights;
        private System.Windows.Forms.Panel pnlBookingInfo;
        private System.Windows.Forms.Label lblDateBooked;
        private System.Windows.Forms.Label lblBookingID;
        private System.Windows.Forms.Label lblReservationID;
        private System.Windows.Forms.Label lblStatus;
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
        private System.Windows.Forms.Panel pnlDates;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblEditMode;
        private System.Windows.Forms.Label lblTitle;
    }
}