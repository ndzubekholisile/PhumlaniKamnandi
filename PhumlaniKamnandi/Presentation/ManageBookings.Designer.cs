namespace PhumlaniKamnandi.Presentation
{
    partial class ManageBookings
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlMain = new Panel();
            btnClose = new Button();
            btnCancelBooking = new Button();
            btnViewDetails = new Button();
            dgvBookings = new DataGridView();
            pnlSearch = new Panel();
            txtSearchBookingID = new TextBox();
            lblSearchBookingID = new Label();
            txtSearchGuest = new TextBox();
            lblSearchGuest = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Controls.Add(btnCancelBooking);
            pnlMain.Controls.Add(btnViewDetails);
            pnlMain.Controls.Add(dgvBookings);
            pnlMain.Controls.Add(pnlSearch);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1029, 800);
            pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(156, 163, 175);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(857, 687);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 73);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelBooking.Enabled = false;
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.FlatStyle = FlatStyle.Flat;
            btnCancelBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelBooking.ForeColor = Color.White;
            btnCancelBooking.Location = new Point(669, 687);
            btnCancelBooking.Margin = new Padding(3, 4, 3, 4);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(160, 73);
            btnCancelBooking.TabIndex = 4;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = false;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = Color.FromArgb(59, 130, 246);
            btnViewDetails.Enabled = false;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.Location = new Point(480, 687);
            btnViewDetails.Margin = new Padding(3, 4, 3, 4);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(160, 73);
            btnViewDetails.TabIndex = 3;
            btnViewDetails.Text = "View / Edit \r\nDetails";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += btnViewDetails_Click;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToResizeRows = false;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.GridColor = Color.FromArgb(226, 232, 240);
            dgvBookings.Location = new Point(34, 187);
            dgvBookings.Margin = new Padding(3, 4, 3, 4);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(960, 467);
            dgvBookings.TabIndex = 2;
            dgvBookings.CellDoubleClick += dgvBookings_CellDoubleClick;
            dgvBookings.SelectionChanged += dgvBookings_SelectionChanged;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(255, 251, 235);
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(txtSearchBookingID);
            pnlSearch.Controls.Add(lblSearchBookingID);
            pnlSearch.Controls.Add(txtSearchGuest);
            pnlSearch.Controls.Add(lblSearchGuest);
            pnlSearch.Location = new Point(34, 93);
            pnlSearch.Margin = new Padding(3, 4, 3, 4);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(960, 79);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearchBookingID
            // 
            txtSearchBookingID.Font = new Font("Segoe UI", 9F);
            txtSearchBookingID.Location = new Point(492, 28);
            txtSearchBookingID.Margin = new Padding(3, 4, 3, 4);
            txtSearchBookingID.Name = "txtSearchBookingID";
            txtSearchBookingID.Size = new Size(171, 27);
            txtSearchBookingID.TabIndex = 3;
            txtSearchBookingID.TextChanged += txtSearchBookingID_TextChanged;
            // 
            // lblSearchBookingID
            // 
            lblSearchBookingID.AutoSize = true;
            lblSearchBookingID.Font = new Font("Segoe UI", 9F);
            lblSearchBookingID.Location = new Point(400, 31);
            lblSearchBookingID.Name = "lblSearchBookingID";
            lblSearchBookingID.Size = new Size(86, 20);
            lblSearchBookingID.TabIndex = 2;
            lblSearchBookingID.Text = "Booking ID:";
            // 
            // txtSearchGuest
            // 
            txtSearchGuest.Font = new Font("Segoe UI", 9F);
            txtSearchGuest.Location = new Point(190, 27);
            txtSearchGuest.Margin = new Padding(3, 4, 3, 4);
            txtSearchGuest.Name = "txtSearchGuest";
            txtSearchGuest.Size = new Size(171, 27);
            txtSearchGuest.TabIndex = 1;
            txtSearchGuest.TextChanged += txtSearchGuest_TextChanged;
            // 
            // lblSearchGuest
            // 
            lblSearchGuest.AutoSize = true;
            lblSearchGuest.Font = new Font("Segoe UI", 9F);
            lblSearchGuest.Location = new Point(23, 31);
            lblSearchGuest.Name = "lblSearchGuest";
            lblSearchGuest.Size = new Size(161, 20);
            lblSearchGuest.TabIndex = 0;
            lblSearchGuest.Text = "Search by Guest Name:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(34, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Bookings";
            // 
            // ManageBookings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 800);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageBookings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Bookings";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearchBookingID;
        private System.Windows.Forms.Label lblSearchBookingID;
        private System.Windows.Forms.TextBox txtSearchGuest;
        private System.Windows.Forms.Label lblSearchGuest;
        private System.Windows.Forms.Label lblTitle;
    }
}