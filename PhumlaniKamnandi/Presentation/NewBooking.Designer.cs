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
            pnlMain = new Panel();
            pnlConfirmation = new Panel();
            lblDepositRequired = new Label();
            lblTotalCost = new Label();
            lblTotalNights = new Label();
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
            pnlGuestSelection = new Panel();
            btnFindGuest = new Button();
            txtSelectedGuest = new TextBox();
            lblSelectedGuest = new Label();
            rbNewGuest = new RadioButton();
            rbExistingGuest = new RadioButton();
            lblGuestType = new Label();
            pnlDates = new Panel();
            btnCheckAvailability = new Button();
            dtpCheckOut = new DateTimePicker();
            lblCheckOut = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckIn = new Label();
            lblStep3 = new Label();
            lblStep2 = new Label();
            lblStep1 = new Label();
            btnConfirmBooking = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlConfirmation.SuspendLayout();
            pnlGuestDetails.SuspendLayout();
            pnlGuestSelection.SuspendLayout();
            pnlDates.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(pnlConfirmation);
            pnlMain.Controls.Add(pnlGuestDetails);
            pnlMain.Controls.Add(pnlGuestSelection);
            pnlMain.Controls.Add(pnlDates);
            pnlMain.Controls.Add(lblStep3);
            pnlMain.Controls.Add(lblStep2);
            pnlMain.Controls.Add(lblStep1);
            pnlMain.Controls.Add(btnConfirmBooking);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(800, 867);
            pnlMain.TabIndex = 0;
            // 
            // pnlConfirmation
            // 
            pnlConfirmation.BackColor = Color.FromArgb(240, 253, 244);
            pnlConfirmation.BorderStyle = BorderStyle.FixedSingle;
            pnlConfirmation.Controls.Add(lblDepositRequired);
            pnlConfirmation.Controls.Add(lblTotalCost);
            pnlConfirmation.Controls.Add(lblTotalNights);
            pnlConfirmation.Location = new Point(57, 605);
            pnlConfirmation.Margin = new Padding(3, 4, 3, 4);
            pnlConfirmation.Name = "pnlConfirmation";
            pnlConfirmation.Size = new Size(685, 106);
            pnlConfirmation.TabIndex = 13;
            // 
            // lblDepositRequired
            // 
            lblDepositRequired.AutoSize = true;
            lblDepositRequired.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDepositRequired.ForeColor = Color.FromArgb(220, 38, 127);
            lblDepositRequired.Location = new Point(400, 60);
            lblDepositRequired.Name = "lblDepositRequired";
            lblDepositRequired.Size = new Size(205, 23);
            lblDepositRequired.TabIndex = 2;
            lblDepositRequired.Text = "Deposit Required: $0.00";
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalCost.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotalCost.Location = new Point(400, 27);
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
            lblTotalNights.Location = new Point(23, 27);
            lblTotalNights.Name = "lblTotalNights";
            lblTotalNights.Size = new Size(127, 23);
            lblTotalNights.TabIndex = 0;
            lblTotalNights.Text = "Total Nights: 0";
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
            pnlGuestDetails.Location = new Point(57, 373);
            pnlGuestDetails.Margin = new Padding(3, 4, 3, 4);
            pnlGuestDetails.Name = "pnlGuestDetails";
            pnlGuestDetails.Size = new Size(685, 199);
            pnlGuestDetails.TabIndex = 12;
            // 
            // txtPostalCode
            // 
            txtPostalCode.Font = new Font("Segoe UI", 9F);
            txtPostalCode.Location = new Point(171, 147);
            txtPostalCode.Margin = new Padding(3, 4, 3, 4);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(228, 27);
            txtPostalCode.TabIndex = 8;
            txtPostalCode.TextChanged += txtGuestName_TextChanged;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Font = new Font("Segoe UI", 9F);
            lblPostalCode.Location = new Point(23, 153);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(90, 20);
            lblPostalCode.TabIndex = 7;
            lblPostalCode.Text = "Postal Code:";
            // 
            // txtAddress2
            // 
            txtAddress2.Font = new Font("Segoe UI", 9F);
            txtAddress2.Location = new Point(171, 107);
            txtAddress2.Margin = new Padding(3, 4, 3, 4);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(228, 27);
            txtAddress2.TabIndex = 6;
            // 
            // lblAddress2
            // 
            lblAddress2.AutoSize = true;
            lblAddress2.Font = new Font("Segoe UI", 9F);
            lblAddress2.Location = new Point(23, 113);
            lblAddress2.Name = "lblAddress2";
            lblAddress2.Size = new Size(108, 20);
            lblAddress2.TabIndex = 5;
            lblAddress2.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            txtAddress1.Font = new Font("Segoe UI", 9F);
            txtAddress1.Location = new Point(171, 67);
            txtAddress1.Margin = new Padding(3, 4, 3, 4);
            txtAddress1.Name = "txtAddress1";
            txtAddress1.Size = new Size(228, 27);
            txtAddress1.TabIndex = 4;
            // 
            // lblAddress1
            // 
            lblAddress1.AutoSize = true;
            lblAddress1.Font = new Font("Segoe UI", 9F);
            lblAddress1.Location = new Point(23, 73);
            lblAddress1.Name = "lblAddress1";
            lblAddress1.Size = new Size(108, 20);
            lblAddress1.TabIndex = 3;
            lblAddress1.Text = "Address Line 1:";
            // 
            // txtTelephone
            // 
            txtTelephone.Font = new Font("Segoe UI", 9F);
            txtTelephone.Location = new Point(171, 27);
            txtTelephone.Margin = new Padding(3, 4, 3, 4);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(228, 27);
            txtTelephone.TabIndex = 2;
            txtTelephone.TextChanged += txtTelephone_TextChanged;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Font = new Font("Segoe UI", 9F);
            lblTelephone.Location = new Point(23, 33);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(81, 20);
            lblTelephone.TabIndex = 1;
            lblTelephone.Text = "Telephone:";
            // 
            // txtGuestName
            // 
            txtGuestName.Font = new Font("Segoe UI", 9F);
            txtGuestName.Location = new Point(514, 27);
            txtGuestName.Margin = new Padding(3, 4, 3, 4);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(137, 27);
            txtGuestName.TabIndex = 0;
            txtGuestName.TextChanged += txtGuestName_TextChanged;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 9F);
            lblGuestName.Location = new Point(434, 33);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(79, 20);
            lblGuestName.TabIndex = 9;
            lblGuestName.Text = "Full Name:";
            // 
            // pnlGuestSelection
            // 
            pnlGuestSelection.BackColor = Color.FromArgb(255, 251, 235);
            pnlGuestSelection.BorderStyle = BorderStyle.FixedSingle;
            pnlGuestSelection.Controls.Add(btnFindGuest);
            pnlGuestSelection.Controls.Add(txtSelectedGuest);
            pnlGuestSelection.Controls.Add(lblSelectedGuest);
            pnlGuestSelection.Controls.Add(rbNewGuest);
            pnlGuestSelection.Controls.Add(rbExistingGuest);
            pnlGuestSelection.Controls.Add(lblGuestType);
            pnlGuestSelection.Location = new Point(57, 240);
            pnlGuestSelection.Margin = new Padding(3, 4, 3, 4);
            pnlGuestSelection.Name = "pnlGuestSelection";
            pnlGuestSelection.Size = new Size(685, 119);
            pnlGuestSelection.TabIndex = 11;
            // 
            // btnFindGuest
            // 
            btnFindGuest.BackColor = Color.FromArgb(59, 130, 246);
            btnFindGuest.FlatAppearance.BorderSize = 0;
            btnFindGuest.FlatStyle = FlatStyle.Flat;
            btnFindGuest.Font = new Font("Segoe UI", 9F);
            btnFindGuest.ForeColor = Color.White;
            btnFindGuest.Location = new Point(514, 60);
            btnFindGuest.Margin = new Padding(3, 4, 3, 4);
            btnFindGuest.Name = "btnFindGuest";
            btnFindGuest.Size = new Size(137, 40);
            btnFindGuest.TabIndex = 5;
            btnFindGuest.Text = "Find Guest";
            btnFindGuest.UseVisualStyleBackColor = false;
            btnFindGuest.Click += btnFindGuest_Click;
            // 
            // txtSelectedGuest
            // 
            txtSelectedGuest.BackColor = Color.FromArgb(249, 250, 251);
            txtSelectedGuest.Font = new Font("Segoe UI", 9F);
            txtSelectedGuest.Location = new Point(171, 60);
            txtSelectedGuest.Margin = new Padding(3, 4, 3, 4);
            txtSelectedGuest.Name = "txtSelectedGuest";
            txtSelectedGuest.ReadOnly = true;
            txtSelectedGuest.Size = new Size(331, 27);
            txtSelectedGuest.TabIndex = 4;
            // 
            // lblSelectedGuest
            // 
            lblSelectedGuest.AutoSize = true;
            lblSelectedGuest.Font = new Font("Segoe UI", 9F);
            lblSelectedGuest.Location = new Point(23, 67);
            lblSelectedGuest.Name = "lblSelectedGuest";
            lblSelectedGuest.Size = new Size(110, 20);
            lblSelectedGuest.TabIndex = 3;
            lblSelectedGuest.Text = "Selected Guest:";
            // 
            // rbNewGuest
            // 
            rbNewGuest.AutoSize = true;
            rbNewGuest.Font = new Font("Segoe UI", 9F);
            rbNewGuest.Location = new Point(171, 20);
            rbNewGuest.Margin = new Padding(3, 4, 3, 4);
            rbNewGuest.Name = "rbNewGuest";
            rbNewGuest.Size = new Size(101, 24);
            rbNewGuest.TabIndex = 2;
            rbNewGuest.Text = "New Guest";
            rbNewGuest.UseVisualStyleBackColor = true;
            rbNewGuest.CheckedChanged += rbNewGuest_CheckedChanged;
            // 
            // rbExistingGuest
            // 
            rbExistingGuest.AutoSize = true;
            rbExistingGuest.Font = new Font("Segoe UI", 9F);
            rbExistingGuest.Location = new Point(23, 20);
            rbExistingGuest.Margin = new Padding(3, 4, 3, 4);
            rbExistingGuest.Name = "rbExistingGuest";
            rbExistingGuest.Size = new Size(122, 24);
            rbExistingGuest.TabIndex = 1;
            rbExistingGuest.Text = "Existing Guest";
            rbExistingGuest.UseVisualStyleBackColor = true;
            rbExistingGuest.CheckedChanged += rbExistingGuest_CheckedChanged;
            // 
            // lblGuestType
            // 
            lblGuestType.AutoSize = true;
            lblGuestType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuestType.Location = new Point(17, -7);
            lblGuestType.Name = "lblGuestType";
            lblGuestType.Size = new Size(0, 23);
            lblGuestType.TabIndex = 0;
            // 
            // pnlDates
            // 
            pnlDates.BackColor = Color.FromArgb(255, 251, 235);
            pnlDates.BorderStyle = BorderStyle.FixedSingle;
            pnlDates.Controls.Add(btnCheckAvailability);
            pnlDates.Controls.Add(dtpCheckOut);
            pnlDates.Controls.Add(lblCheckOut);
            pnlDates.Controls.Add(dtpCheckIn);
            pnlDates.Controls.Add(lblCheckIn);
            pnlDates.Location = new Point(57, 96);
            pnlDates.Margin = new Padding(3, 4, 3, 4);
            pnlDates.Name = "pnlDates";
            pnlDates.Size = new Size(685, 93);
            pnlDates.TabIndex = 10;
            // 
            // btnCheckAvailability
            // 
            btnCheckAvailability.BackColor = Color.FromArgb(34, 197, 94);
            btnCheckAvailability.FlatAppearance.BorderSize = 0;
            btnCheckAvailability.FlatStyle = FlatStyle.Flat;
            btnCheckAvailability.Font = new Font("Segoe UI", 9F);
            btnCheckAvailability.ForeColor = Color.White;
            btnCheckAvailability.Location = new Point(514, 27);
            btnCheckAvailability.Margin = new Padding(3, 4, 3, 4);
            btnCheckAvailability.Name = "btnCheckAvailability";
            btnCheckAvailability.Size = new Size(149, 40);
            btnCheckAvailability.TabIndex = 4;
            btnCheckAvailability.Text = "Check Availability";
            btnCheckAvailability.UseVisualStyleBackColor = false;
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Font = new Font("Segoe UI", 9F);
            dtpCheckOut.Location = new Point(320, 27);
            dtpCheckOut.Margin = new Padding(3, 4, 3, 4);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(137, 27);
            dtpCheckOut.TabIndex = 3;
            dtpCheckOut.ValueChanged += dtpCheckOut_ValueChanged;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 9F);
            lblCheckOut.Location = new Point(235, 33);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(79, 20);
            lblCheckOut.TabIndex = 2;
            lblCheckOut.Text = "Check-out:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI", 9F);
            dtpCheckIn.Location = new Point(91, 27);
            dtpCheckIn.Margin = new Padding(3, 4, 3, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(137, 27);
            dtpCheckIn.TabIndex = 1;
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 9F);
            lblCheckIn.Location = new Point(23, 33);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(69, 20);
            lblCheckIn.TabIndex = 0;
            lblCheckIn.Text = "Check-in:";
            // 
            // lblStep3
            // 
            lblStep3.AutoSize = true;
            lblStep3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStep3.ForeColor = Color.FromArgb(59, 130, 246);
            lblStep3.Location = new Point(23, 573);
            lblStep3.Name = "lblStep3";
            lblStep3.Size = new Size(217, 28);
            lblStep3.TabIndex = 5;
            lblStep3.Text = "Step 3 - Confirmation";
            // 
            // lblStep2
            // 
            lblStep2.AutoSize = true;
            lblStep2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStep2.ForeColor = Color.FromArgb(59, 130, 246);
            lblStep2.Location = new Point(25, 206);
            lblStep2.Name = "lblStep2";
            lblStep2.Size = new Size(146, 28);
            lblStep2.TabIndex = 4;
            lblStep2.Text = "Step 2 - Guest";
            // 
            // lblStep1
            // 
            lblStep1.AutoSize = true;
            lblStep1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStep1.ForeColor = Color.FromArgb(59, 130, 246);
            lblStep1.Location = new Point(23, 64);
            lblStep1.Name = "lblStep1";
            lblStep1.Size = new Size(146, 28);
            lblStep1.TabIndex = 3;
            lblStep1.Text = "Step 1 - Dates";
            // 
            // btnConfirmBooking
            // 
            btnConfirmBooking.BackColor = Color.FromArgb(34, 197, 94);
            btnConfirmBooking.FlatAppearance.BorderSize = 0;
            btnConfirmBooking.FlatStyle = FlatStyle.Flat;
            btnConfirmBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmBooking.ForeColor = Color.White;
            btnConfirmBooking.Location = new Point(514, 747);
            btnConfirmBooking.Margin = new Padding(3, 4, 3, 4);
            btnConfirmBooking.Name = "btnConfirmBooking";
            btnConfirmBooking.Size = new Size(183, 53);
            btnConfirmBooking.TabIndex = 6;
            btnConfirmBooking.Text = "Confirm and Save\r\n";
            btnConfirmBooking.UseVisualStyleBackColor = false;
            btnConfirmBooking.Click += btnConfirmBooking_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(239, 68, 68);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(320, 747);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 53);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(287, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(208, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "New Booking";
            // 
            // NewBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 867);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewBooking";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Booking";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlConfirmation.ResumeLayout(false);
            pnlConfirmation.PerformLayout();
            pnlGuestDetails.ResumeLayout(false);
            pnlGuestDetails.PerformLayout();
            pnlGuestSelection.ResumeLayout(false);
            pnlGuestSelection.PerformLayout();
            pnlDates.ResumeLayout(false);
            pnlDates.PerformLayout();
            ResumeLayout(false);

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