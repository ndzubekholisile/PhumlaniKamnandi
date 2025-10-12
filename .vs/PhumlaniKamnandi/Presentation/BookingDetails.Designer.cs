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
            this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnRemoveGuest = new System.Windows.Forms.Button();
            this.lblGuestList = new System.Windows.Forms.Label();
            this.pnlNewGuestEntry = new System.Windows.Forms.Panel();
            this.txtNewGuestPostalCode = new System.Windows.Forms.TextBox();
            this.lblNewGuestPostalCode = new System.Windows.Forms.Label();
            this.txtNewGuestAddress2 = new System.Windows.Forms.TextBox();
            this.lblNewGuestAddress2 = new System.Windows.Forms.Label();
            this.txtNewGuestAddress1 = new System.Windows.Forms.TextBox();
            this.lblNewGuestAddress1 = new System.Windows.Forms.Label();
            this.txtNewGuestTelephone = new System.Windows.Forms.TextBox();
            this.lblNewGuestTelephone = new System.Windows.Forms.Label();
            this.txtNewGuestName = new System.Windows.Forms.TextBox();
            this.lblNewGuestName = new System.Windows.Forms.Label();
            this.btnSaveNewGuest = new System.Windows.Forms.Button();
            this.btnCancelNewGuest = new System.Windows.Forms.Button();
            this.lblNewGuestTitle = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.pnlNewGuestEntry.SuspendLayout();
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
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(914, 804);
            this.pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(740, 749);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 42);
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
            this.btnCancelEdit.Location = new System.Drawing.Point(521, 749);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(137, 42);
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
            this.btnSaveChanges.Location = new System.Drawing.Point(275, 749);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(160, 42);
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
            this.btnEdit.Location = new System.Drawing.Point(54, 749);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 42);
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
            this.pnlCosts.Location = new System.Drawing.Point(54, 685);
            this.pnlCosts.Name = "pnlCosts";
            this.pnlCosts.Size = new System.Drawing.Size(800, 53);
            this.pnlCosts.TabIndex = 5;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(127)))));
            this.lblDeposit.Location = new System.Drawing.Point(514, 16);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(167, 23);
            this.lblDeposit.TabIndex = 2;
            this.lblDeposit.Text = "Deposit Paid: $0.00";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalCost.Location = new System.Drawing.Point(286, 16);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(144, 23);
            this.lblTotalCost.TabIndex = 1;
            this.lblTotalCost.Text = "Total Cost: $0.00";
            // 
            // lblTotalNights
            // 
            this.lblTotalNights.AutoSize = true;
            this.lblTotalNights.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalNights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTotalNights.Location = new System.Drawing.Point(23, 16);
            this.lblTotalNights.Name = "lblTotalNights";
            this.lblTotalNights.Size = new System.Drawing.Size(127, 23);
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
            this.pnlBookingInfo.Location = new System.Drawing.Point(54, 600);
            this.pnlBookingInfo.Name = "pnlBookingInfo";
            this.pnlBookingInfo.Size = new System.Drawing.Size(800, 75);
            this.pnlBookingInfo.TabIndex = 4;
            // 
            // lblDateBooked
            // 
            this.lblDateBooked.AutoSize = true;
            this.lblDateBooked.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateBooked.Location = new System.Drawing.Point(23, 42);
            this.lblDateBooked.Name = "lblDateBooked";
            this.lblDateBooked.Size = new System.Drawing.Size(203, 23);
            this.lblDateBooked.TabIndex = 3;
            this.lblDateBooked.Text = "Date Booked: 01/01/2024";
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookingID.Location = new System.Drawing.Point(23, 16);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(112, 23);
            this.lblBookingID.TabIndex = 1;
            this.lblBookingID.Text = "Booking ID: 0";
            // 
            // lblReservationID
            // 
            this.lblReservationID.AutoSize = true;
            this.lblReservationID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReservationID.Location = new System.Drawing.Point(171, 16);
            this.lblReservationID.Name = "lblReservationID";
            this.lblReservationID.Size = new System.Drawing.Size(147, 23);
            this.lblReservationID.TabIndex = 2;
            this.lblReservationID.Text = "Reservation ID: 0";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(343, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(153, 23);
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
            this.pnlGuestDetails.Controls.Add(this.dgvGuests);
            this.pnlGuestDetails.Controls.Add(this.btnAddGuest);
            this.pnlGuestDetails.Controls.Add(this.btnRemoveGuest);
            this.pnlGuestDetails.Controls.Add(this.lblGuestList);
            this.pnlGuestDetails.Controls.Add(this.pnlNewGuestEntry);
            this.pnlGuestDetails.Controls.Add(this.btnSaveNewGuest);
            this.pnlGuestDetails.Controls.Add(this.btnCancelNewGuest);
            this.pnlGuestDetails.Controls.Add(this.lblNewGuestTitle);
            this.pnlGuestDetails.Location = new System.Drawing.Point(54, 189);
            this.pnlGuestDetails.Name = "pnlGuestDetails";
            this.pnlGuestDetails.Size = new System.Drawing.Size(800, 405);
            this.pnlGuestDetails.TabIndex = 3;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.White;
            this.txtPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPostalCode.Location = new System.Drawing.Point(171, 160);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(228, 27);
            this.txtPostalCode.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPostalCode.Location = new System.Drawing.Point(23, 166);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(90, 20);
            this.lblPostalCode.TabIndex = 7;
            this.lblPostalCode.Text = "Postal Code:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.BackColor = System.Drawing.Color.White;
            this.txtAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress2.Location = new System.Drawing.Point(171, 128);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(228, 27);
            this.txtAddress2.TabIndex = 6;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress2.Location = new System.Drawing.Point(23, 134);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(108, 20);
            this.lblAddress2.TabIndex = 5;
            this.lblAddress2.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.BackColor = System.Drawing.Color.White;
            this.txtAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress1.Location = new System.Drawing.Point(171, 96);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(228, 27);
            this.txtAddress1.TabIndex = 4;
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress1.Location = new System.Drawing.Point(23, 102);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(108, 20);
            this.lblAddress1.TabIndex = 3;
            this.lblAddress1.Text = "Address Line 1:";
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.Color.White;
            this.txtTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelephone.Location = new System.Drawing.Point(171, 32);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(228, 27);
            this.txtTelephone.TabIndex = 2;
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelephone.Location = new System.Drawing.Point(23, 38);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(81, 20);
            this.lblTelephone.TabIndex = 1;
            this.lblTelephone.Text = "Telephone:";
            // 
            // txtGuestName
            // 
            this.txtGuestName.BackColor = System.Drawing.Color.White;
            this.txtGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGuestName.Location = new System.Drawing.Point(171, 64);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(228, 27);
            this.txtGuestName.TabIndex = 0;
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGuestName.Location = new System.Drawing.Point(23, 70);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(79, 20);
            this.lblGuestName.TabIndex = 9;
            this.lblGuestName.Text = "Full Name:";
            // 
            // dgvGuests
            // 
            this.dgvGuests.AllowUserToAddRows = false;
            this.dgvGuests.BackgroundColor = System.Drawing.Color.White;
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Location = new System.Drawing.Point(435, 64);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.ReadOnly = true;
            this.dgvGuests.RowHeadersWidth = 51;
            this.dgvGuests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGuests.Size = new System.Drawing.Size(340, 118);
            this.dgvGuests.TabIndex = 10;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnAddGuest.FlatAppearance.BorderSize = 0;
            this.btnAddGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddGuest.ForeColor = System.Drawing.Color.White;
            this.btnAddGuest.Location = new System.Drawing.Point(435, 192);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(100, 26);
            this.btnAddGuest.TabIndex = 11;
            this.btnAddGuest.Text = "Add Guest";
            this.btnAddGuest.UseVisualStyleBackColor = false;
            this.btnAddGuest.Visible = false;
            // 
            // btnRemoveGuest
            // 
            this.btnRemoveGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRemoveGuest.FlatAppearance.BorderSize = 0;
            this.btnRemoveGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveGuest.ForeColor = System.Drawing.Color.White;
            this.btnRemoveGuest.Location = new System.Drawing.Point(550, 192);
            this.btnRemoveGuest.Name = "btnRemoveGuest";
            this.btnRemoveGuest.Size = new System.Drawing.Size(120, 26);
            this.btnRemoveGuest.TabIndex = 12;
            this.btnRemoveGuest.Text = "Remove Guest";
            this.btnRemoveGuest.UseVisualStyleBackColor = false;
            this.btnRemoveGuest.Visible = false;
            // 
            // lblGuestList
            // 
            this.lblGuestList.AutoSize = true;
            this.lblGuestList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGuestList.Location = new System.Drawing.Point(435, 38);
            this.lblGuestList.Name = "lblGuestList";
            this.lblGuestList.Size = new System.Drawing.Size(109, 20);
            this.lblGuestList.TabIndex = 13;
            this.lblGuestList.Text = "All Guests (1):";
            // 
            // pnlNewGuestEntry
            // 
            this.pnlNewGuestEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlNewGuestEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNewGuestEntry.Controls.Add(this.txtNewGuestPostalCode);
            this.pnlNewGuestEntry.Controls.Add(this.lblNewGuestPostalCode);
            this.pnlNewGuestEntry.Controls.Add(this.txtNewGuestAddress2);
            this.pnlNewGuestEntry.Controls.Add(this.lblNewGuestAddress2);
            this.pnlNewGuestEntry.Controls.Add(this.txtNewGuestAddress1);
            this.pnlNewGuestEntry.Controls.Add(this.lblNewGuestAddress1);
            this.pnlNewGuestEntry.Controls.Add(this.txtNewGuestTelephone);
            this.pnlNewGuestEntry.Controls.Add(this.lblNewGuestTelephone);
            this.pnlNewGuestEntry.Controls.Add(this.txtNewGuestName);
            this.pnlNewGuestEntry.Controls.Add(this.lblNewGuestName);
            this.pnlNewGuestEntry.Location = new System.Drawing.Point(23, 240);
            this.pnlNewGuestEntry.Name = "pnlNewGuestEntry";
            this.pnlNewGuestEntry.Size = new System.Drawing.Size(750, 113);
            this.pnlNewGuestEntry.TabIndex = 14;
            this.pnlNewGuestEntry.Visible = false;
            // 
            // txtNewGuestPostalCode
            // 
            this.txtNewGuestPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewGuestPostalCode.Location = new System.Drawing.Point(620, 36);
            this.txtNewGuestPostalCode.Name = "txtNewGuestPostalCode";
            this.txtNewGuestPostalCode.Size = new System.Drawing.Size(100, 27);
            this.txtNewGuestPostalCode.TabIndex = 9;
            // 
            // lblNewGuestPostalCode
            // 
            this.lblNewGuestPostalCode.AutoSize = true;
            this.lblNewGuestPostalCode.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewGuestPostalCode.Location = new System.Drawing.Point(620, 20);
            this.lblNewGuestPostalCode.Name = "lblNewGuestPostalCode";
            this.lblNewGuestPostalCode.Size = new System.Drawing.Size(81, 19);
            this.lblNewGuestPostalCode.TabIndex = 8;
            this.lblNewGuestPostalCode.Text = "Postal Code";
            // 
            // txtNewGuestAddress2
            // 
            this.txtNewGuestAddress2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewGuestAddress2.Location = new System.Drawing.Point(470, 36);
            this.txtNewGuestAddress2.Name = "txtNewGuestAddress2";
            this.txtNewGuestAddress2.Size = new System.Drawing.Size(140, 27);
            this.txtNewGuestAddress2.TabIndex = 7;
            // 
            // lblNewGuestAddress2
            // 
            this.lblNewGuestAddress2.AutoSize = true;
            this.lblNewGuestAddress2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewGuestAddress2.Location = new System.Drawing.Point(470, 20);
            this.lblNewGuestAddress2.Name = "lblNewGuestAddress2";
            this.lblNewGuestAddress2.Size = new System.Drawing.Size(70, 19);
            this.lblNewGuestAddress2.TabIndex = 6;
            this.lblNewGuestAddress2.Text = "Address 2";
            // 
            // txtNewGuestAddress1
            // 
            this.txtNewGuestAddress1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewGuestAddress1.Location = new System.Drawing.Point(320, 36);
            this.txtNewGuestAddress1.Name = "txtNewGuestAddress1";
            this.txtNewGuestAddress1.Size = new System.Drawing.Size(140, 27);
            this.txtNewGuestAddress1.TabIndex = 5;
            // 
            // lblNewGuestAddress1
            // 
            this.lblNewGuestAddress1.AutoSize = true;
            this.lblNewGuestAddress1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewGuestAddress1.Location = new System.Drawing.Point(320, 20);
            this.lblNewGuestAddress1.Name = "lblNewGuestAddress1";
            this.lblNewGuestAddress1.Size = new System.Drawing.Size(70, 19);
            this.lblNewGuestAddress1.TabIndex = 4;
            this.lblNewGuestAddress1.Text = "Address 1";
            // 
            // txtNewGuestTelephone
            // 
            this.txtNewGuestTelephone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewGuestTelephone.Location = new System.Drawing.Point(170, 36);
            this.txtNewGuestTelephone.Name = "txtNewGuestTelephone";
            this.txtNewGuestTelephone.Size = new System.Drawing.Size(140, 27);
            this.txtNewGuestTelephone.TabIndex = 3;
            // 
            // lblNewGuestTelephone
            // 
            this.lblNewGuestTelephone.AutoSize = true;
            this.lblNewGuestTelephone.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewGuestTelephone.Location = new System.Drawing.Point(170, 20);
            this.lblNewGuestTelephone.Name = "lblNewGuestTelephone";
            this.lblNewGuestTelephone.Size = new System.Drawing.Size(71, 19);
            this.lblNewGuestTelephone.TabIndex = 2;
            this.lblNewGuestTelephone.Text = "Telephone";
            // 
            // txtNewGuestName
            // 
            this.txtNewGuestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewGuestName.Location = new System.Drawing.Point(20, 36);
            this.txtNewGuestName.Name = "txtNewGuestName";
            this.txtNewGuestName.Size = new System.Drawing.Size(140, 27);
            this.txtNewGuestName.TabIndex = 1;
            // 
            // lblNewGuestName
            // 
            this.lblNewGuestName.AutoSize = true;
            this.lblNewGuestName.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewGuestName.Location = new System.Drawing.Point(20, 20);
            this.lblNewGuestName.Name = "lblNewGuestName";
            this.lblNewGuestName.Size = new System.Drawing.Size(70, 19);
            this.lblNewGuestName.TabIndex = 0;
            this.lblNewGuestName.Text = "Full Name";
            // 
            // btnSaveNewGuest
            // 
            this.btnSaveNewGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnSaveNewGuest.FlatAppearance.BorderSize = 0;
            this.btnSaveNewGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveNewGuest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveNewGuest.ForeColor = System.Drawing.Color.White;
            this.btnSaveNewGuest.Location = new System.Drawing.Point(550, 359);
            this.btnSaveNewGuest.Name = "btnSaveNewGuest";
            this.btnSaveNewGuest.Size = new System.Drawing.Size(100, 26);
            this.btnSaveNewGuest.TabIndex = 15;
            this.btnSaveNewGuest.Text = "Save Guest";
            this.btnSaveNewGuest.UseVisualStyleBackColor = false;
            this.btnSaveNewGuest.Visible = false;
            // 
            // btnCancelNewGuest
            // 
            this.btnCancelNewGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelNewGuest.FlatAppearance.BorderSize = 0;
            this.btnCancelNewGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelNewGuest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelNewGuest.ForeColor = System.Drawing.Color.White;
            this.btnCancelNewGuest.Location = new System.Drawing.Point(660, 359);
            this.btnCancelNewGuest.Name = "btnCancelNewGuest";
            this.btnCancelNewGuest.Size = new System.Drawing.Size(100, 26);
            this.btnCancelNewGuest.TabIndex = 16;
            this.btnCancelNewGuest.Text = "Cancel";
            this.btnCancelNewGuest.UseVisualStyleBackColor = false;
            this.btnCancelNewGuest.Visible = false;
            // 
            // lblNewGuestTitle
            // 
            this.lblNewGuestTitle.AutoSize = true;
            this.lblNewGuestTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewGuestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblNewGuestTitle.Location = new System.Drawing.Point(23, 220);
            this.lblNewGuestTitle.Name = "lblNewGuestTitle";
            this.lblNewGuestTitle.Size = new System.Drawing.Size(140, 23);
            this.lblNewGuestTitle.TabIndex = 17;
            this.lblNewGuestTitle.Text = "Add New Guest:";
            this.lblNewGuestTitle.Visible = false;
            // 
            // pnlDates
            // 
            this.pnlDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlDates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDates.Controls.Add(this.dtpCheckOut);
            this.pnlDates.Controls.Add(this.lblCheckOut);
            this.pnlDates.Controls.Add(this.dtpCheckIn);
            this.pnlDates.Controls.Add(this.lblCheckIn);
            this.pnlDates.Location = new System.Drawing.Point(54, 82);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(800, 96);
            this.pnlDates.TabIndex = 2;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Enabled = false;
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckOut.Location = new System.Drawing.Point(320, 32);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(137, 27);
            this.dtpCheckOut.TabIndex = 3;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckOut.Location = new System.Drawing.Point(229, 38);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(79, 20);
            this.lblCheckOut.TabIndex = 2;
            this.lblCheckOut.Text = "Check-out:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Enabled = false;
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckIn.Location = new System.Drawing.Point(91, 32);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(137, 27);
            this.dtpCheckIn.TabIndex = 1;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckIn.Location = new System.Drawing.Point(23, 38);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(69, 20);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Check-in:";
            // 
            // lblEditMode
            // 
            this.lblEditMode.AutoSize = true;
            this.lblEditMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblEditMode.Location = new System.Drawing.Point(54, 50);
            this.lblEditMode.Name = "lblEditMode";
            this.lblEditMode.Size = new System.Drawing.Size(118, 28);
            this.lblEditMode.TabIndex = 1;
            this.lblEditMode.Text = "View Mode";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(313, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(241, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Booking Details";
            // 
            // BookingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 804);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.pnlNewGuestEntry.ResumeLayout(false);
            this.pnlNewGuestEntry.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.Button btnRemoveGuest;
        private System.Windows.Forms.Label lblGuestList;
        private System.Windows.Forms.Panel pnlNewGuestEntry;
        private System.Windows.Forms.TextBox txtNewGuestPostalCode;
        private System.Windows.Forms.Label lblNewGuestPostalCode;
        private System.Windows.Forms.TextBox txtNewGuestAddress2;
        private System.Windows.Forms.Label lblNewGuestAddress2;
        private System.Windows.Forms.TextBox txtNewGuestAddress1;
        private System.Windows.Forms.Label lblNewGuestAddress1;
        private System.Windows.Forms.TextBox txtNewGuestTelephone;
        private System.Windows.Forms.Label lblNewGuestTelephone;
        private System.Windows.Forms.TextBox txtNewGuestName;
        private System.Windows.Forms.Label lblNewGuestName;
        private System.Windows.Forms.Button btnSaveNewGuest;
        private System.Windows.Forms.Button btnCancelNewGuest;
        private System.Windows.Forms.Label lblNewGuestTitle;
    }
}