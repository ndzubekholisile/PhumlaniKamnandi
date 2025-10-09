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
            pnlMain = new Panel();
            btnClose = new Button();
            btnCancelEdit = new Button();
            btnSaveChanges = new Button();
            btnEdit = new Button();
            pnlCosts = new Panel();
            lblDeposit = new Label();
            lblTotalCost = new Label();
            lblTotalNights = new Label();
            pnlBookingInfo = new Panel();
            lblDateBooked = new Label();
            lblBookingID = new Label();
            lblReservationID = new Label();
            lblStatus = new Label();
            pnlGuestDetails = new Panel();
            txtPostalCode = new TextBox();
            lblPostalCode = new Label();
            txtAddress2 = new TextBox();
            lblAddress2 = new Label();
            txtAddress1 = new TextBox();
            lblAddress1 = new Label();
            txtTelephone = new TextBox();
            lblTelephone = new Label();
            txtGuestName = new TextBox();
            lblGuestName = new Label();
            pnlDates = new Panel();
            dtpCheckOut = new DateTimePicker();
            lblCheckOut = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckIn = new Label();
            lblEditMode = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlCosts.SuspendLayout();
            pnlBookingInfo.SuspendLayout();
            pnlGuestDetails.SuspendLayout();
            pnlDates.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Controls.Add(btnCancelEdit);
            pnlMain.Controls.Add(btnSaveChanges);
            pnlMain.Controls.Add(btnEdit);
            pnlMain.Controls.Add(pnlCosts);
            pnlMain.Controls.Add(pnlBookingInfo);
            pnlMain.Controls.Add(pnlGuestDetails);
            pnlMain.Controls.Add(pnlDates);
            pnlMain.Controls.Add(lblEditMode);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(914, 933);
            pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(156, 163, 175);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(740, 689);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 53);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelEdit.FlatAppearance.BorderSize = 0;
            btnCancelEdit.FlatStyle = FlatStyle.Flat;
            btnCancelEdit.Font = new Font("Segoe UI", 10F);
            btnCancelEdit.ForeColor = Color.White;
            btnCancelEdit.Location = new Point(521, 689);
            btnCancelEdit.Margin = new Padding(3, 4, 3, 4);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(137, 53);
            btnCancelEdit.TabIndex = 8;
            btnCancelEdit.Text = "Cancel Edit";
            btnCancelEdit.UseVisualStyleBackColor = false;
            btnCancelEdit.Visible = false;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = Color.FromArgb(34, 197, 94);
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(275, 689);
            btnSaveChanges.Margin = new Padding(3, 4, 3, 4);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(160, 53);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Visible = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(59, 130, 246);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(54, 689);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(137, 53);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // pnlCosts
            // 
            pnlCosts.BackColor = Color.FromArgb(240, 253, 244);
            pnlCosts.BorderStyle = BorderStyle.FixedSingle;
            pnlCosts.Controls.Add(lblDeposit);
            pnlCosts.Controls.Add(lblTotalCost);
            pnlCosts.Controls.Add(lblTotalNights);
            pnlCosts.Location = new Point(54, 609);
            pnlCosts.Margin = new Padding(3, 4, 3, 4);
            pnlCosts.Name = "pnlCosts";
            pnlCosts.Size = new Size(800, 66);
            pnlCosts.TabIndex = 5;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDeposit.ForeColor = Color.FromArgb(220, 38, 127);
            lblDeposit.Location = new Point(514, 20);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(167, 23);
            lblDeposit.TabIndex = 2;
            lblDeposit.Text = "Deposit Paid: $0.00";
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalCost.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalCost.Location = new Point(286, 20);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(144, 23);
            lblTotalCost.TabIndex = 1;
            lblTotalCost.Text = "Total Cost: $0.00";
            // 
            // lblTotalNights
            // 
            lblTotalNights.AutoSize = true;
            lblTotalNights.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalNights.ForeColor = Color.FromArgb(59, 130, 246);
            lblTotalNights.Location = new Point(23, 20);
            lblTotalNights.Name = "lblTotalNights";
            lblTotalNights.Size = new Size(127, 23);
            lblTotalNights.TabIndex = 0;
            lblTotalNights.Text = "Total Nights: 0";
            // 
            // pnlBookingInfo
            // 
            pnlBookingInfo.BackColor = Color.FromArgb(255, 251, 235);
            pnlBookingInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlBookingInfo.Controls.Add(lblDateBooked);
            pnlBookingInfo.Controls.Add(lblBookingID);
            pnlBookingInfo.Controls.Add(lblReservationID);
            pnlBookingInfo.Controls.Add(lblStatus);
            pnlBookingInfo.Location = new Point(54, 503);
            pnlBookingInfo.Margin = new Padding(3, 4, 3, 4);
            pnlBookingInfo.Name = "pnlBookingInfo";
            pnlBookingInfo.Size = new Size(800, 93);
            pnlBookingInfo.TabIndex = 4;
            // 
            // lblDateBooked
            // 
            lblDateBooked.AutoSize = true;
            lblDateBooked.Font = new Font("Segoe UI", 10F);
            lblDateBooked.Location = new Point(23, 53);
            lblDateBooked.Name = "lblDateBooked";
            lblDateBooked.Size = new Size(203, 23);
            lblDateBooked.TabIndex = 3;
            lblDateBooked.Text = "Date Booked: 01/01/2024";
            // 
            // lblBookingID
            // 
            lblBookingID.AutoSize = true;
            lblBookingID.Font = new Font("Segoe UI", 10F);
            lblBookingID.Location = new Point(23, 20);
            lblBookingID.Name = "lblBookingID";
            lblBookingID.Size = new Size(112, 23);
            lblBookingID.TabIndex = 1;
            lblBookingID.Text = "Booking ID: 0";
            // 
            // lblReservationID
            // 
            lblReservationID.AutoSize = true;
            lblReservationID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReservationID.Location = new Point(171, 20);
            lblReservationID.Name = "lblReservationID";
            lblReservationID.Size = new Size(147, 23);
            lblReservationID.TabIndex = 2;
            lblReservationID.Text = "Reservation ID: 0";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(343, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(153, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status: confirmed";
            // 
            // pnlGuestDetails
            // 
            pnlGuestDetails.BackColor = Color.FromArgb(255, 251, 235);
            pnlGuestDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlGuestDetails.Controls.Add(txtPostalCode);
            pnlGuestDetails.Controls.Add(lblPostalCode);
            pnlGuestDetails.Controls.Add(txtAddress2);
            pnlGuestDetails.Controls.Add(lblAddress2);
            pnlGuestDetails.Controls.Add(txtAddress1);
            pnlGuestDetails.Controls.Add(lblAddress1);
            pnlGuestDetails.Controls.Add(txtTelephone);
            pnlGuestDetails.Controls.Add(lblTelephone);
            pnlGuestDetails.Controls.Add(txtGuestName);
            pnlGuestDetails.Controls.Add(lblGuestName);
            pnlGuestDetails.Location = new Point(54, 236);
            pnlGuestDetails.Margin = new Padding(3, 4, 3, 4);
            pnlGuestDetails.Name = "pnlGuestDetails";
            pnlGuestDetails.Size = new Size(800, 253);
            pnlGuestDetails.TabIndex = 3;
            // 
            // txtPostalCode
            // 
            txtPostalCode.BackColor = Color.White;
            txtPostalCode.Font = new Font("Segoe UI", 9F);
            txtPostalCode.Location = new Point(171, 200);
            txtPostalCode.Margin = new Padding(3, 4, 3, 4);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(228, 27);
            txtPostalCode.TabIndex = 8;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Font = new Font("Segoe UI", 9F);
            lblPostalCode.Location = new Point(23, 207);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(90, 20);
            lblPostalCode.TabIndex = 7;
            lblPostalCode.Text = "Postal Code:";
            // 
            // txtAddress2
            // 
            txtAddress2.BackColor = Color.White;
            txtAddress2.Font = new Font("Segoe UI", 9F);
            txtAddress2.Location = new Point(171, 160);
            txtAddress2.Margin = new Padding(3, 4, 3, 4);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(228, 27);
            txtAddress2.TabIndex = 6;
            // 
            // lblAddress2
            // 
            lblAddress2.AutoSize = true;
            lblAddress2.Font = new Font("Segoe UI", 9F);
            lblAddress2.Location = new Point(23, 167);
            lblAddress2.Name = "lblAddress2";
            lblAddress2.Size = new Size(108, 20);
            lblAddress2.TabIndex = 5;
            lblAddress2.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            txtAddress1.BackColor = Color.White;
            txtAddress1.Font = new Font("Segoe UI", 9F);
            txtAddress1.Location = new Point(171, 120);
            txtAddress1.Margin = new Padding(3, 4, 3, 4);
            txtAddress1.Name = "txtAddress1";
            txtAddress1.Size = new Size(228, 27);
            txtAddress1.TabIndex = 4;
            // 
            // lblAddress1
            // 
            lblAddress1.AutoSize = true;
            lblAddress1.Font = new Font("Segoe UI", 9F);
            lblAddress1.Location = new Point(23, 127);
            lblAddress1.Name = "lblAddress1";
            lblAddress1.Size = new Size(108, 20);
            lblAddress1.TabIndex = 3;
            lblAddress1.Text = "Address Line 1:";
            // 
            // txtTelephone
            // 
            txtTelephone.BackColor = Color.White;
            txtTelephone.Font = new Font("Segoe UI", 9F);
            txtTelephone.Location = new Point(171, 40);
            txtTelephone.Margin = new Padding(3, 4, 3, 4);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(228, 27);
            txtTelephone.TabIndex = 2;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Font = new Font("Segoe UI", 9F);
            lblTelephone.Location = new Point(23, 47);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(81, 20);
            lblTelephone.TabIndex = 1;
            lblTelephone.Text = "Telephone:";
            // 
            // txtGuestName
            // 
            txtGuestName.BackColor = Color.White;
            txtGuestName.Font = new Font("Segoe UI", 9F);
            txtGuestName.Location = new Point(171, 80);
            txtGuestName.Margin = new Padding(3, 4, 3, 4);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(228, 27);
            txtGuestName.TabIndex = 0;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 9F);
            lblGuestName.Location = new Point(23, 87);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(79, 20);
            lblGuestName.TabIndex = 9;
            lblGuestName.Text = "Full Name:";
            // 
            // pnlDates
            // 
            pnlDates.BackColor = Color.FromArgb(255, 251, 235);
            pnlDates.BorderStyle = BorderStyle.FixedSingle;
            pnlDates.Controls.Add(dtpCheckOut);
            pnlDates.Controls.Add(lblCheckOut);
            pnlDates.Controls.Add(dtpCheckIn);
            pnlDates.Controls.Add(lblCheckIn);
            pnlDates.Location = new Point(54, 103);
            pnlDates.Margin = new Padding(3, 4, 3, 4);
            pnlDates.Name = "pnlDates";
            pnlDates.Size = new Size(800, 119);
            pnlDates.TabIndex = 2;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Enabled = false;
            dtpCheckOut.Font = new Font("Segoe UI", 9F);
            dtpCheckOut.Location = new Point(320, 40);
            dtpCheckOut.Margin = new Padding(3, 4, 3, 4);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(137, 27);
            dtpCheckOut.TabIndex = 3;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 9F);
            lblCheckOut.Location = new Point(229, 47);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(79, 20);
            lblCheckOut.TabIndex = 2;
            lblCheckOut.Text = "Check-out:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Enabled = false;
            dtpCheckIn.Font = new Font("Segoe UI", 9F);
            dtpCheckIn.Location = new Point(91, 40);
            dtpCheckIn.Margin = new Padding(3, 4, 3, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(137, 27);
            dtpCheckIn.TabIndex = 1;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 9F);
            lblCheckIn.Location = new Point(23, 47);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(69, 20);
            lblCheckIn.TabIndex = 0;
            lblCheckIn.Text = "Check-in:";
            // 
            // lblEditMode
            // 
            lblEditMode.AutoSize = true;
            lblEditMode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEditMode.ForeColor = Color.FromArgb(34, 197, 94);
            lblEditMode.Location = new Point(54, 63);
            lblEditMode.Name = "lblEditMode";
            lblEditMode.Size = new Size(118, 28);
            lblEditMode.TabIndex = 1;
            lblEditMode.Text = "View Mode";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(313, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(241, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Booking Details";
            // 
            // BookingDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 933);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingDetails";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Booking Details";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlCosts.ResumeLayout(false);
            pnlCosts.PerformLayout();
            pnlBookingInfo.ResumeLayout(false);
            pnlBookingInfo.PerformLayout();
            pnlGuestDetails.ResumeLayout(false);
            pnlGuestDetails.PerformLayout();
            pnlDates.ResumeLayout(false);
            pnlDates.PerformLayout();
            ResumeLayout(false);

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