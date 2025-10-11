using System.Windows.Forms;
using System.Drawing;

namespace PhumlaniKamnandi.Presentation
{
    partial class GuestSearch
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
            btnCancel = new Button();
            btnSelectGuest = new Button();
            dgvGuests = new DataGridView();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            lblSearch = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(btnSelectGuest);
            pnlMain.Controls.Add(dgvGuests);
            pnlMain.Controls.Add(pnlSearch);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(686, 600);
            pnlMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(239, 68, 68);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(514, 507);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 47);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelectGuest
            // 
            btnSelectGuest.BackColor = Color.FromArgb(34, 197, 94);
            btnSelectGuest.FlatAppearance.BorderSize = 0;
            btnSelectGuest.FlatStyle = FlatStyle.Flat;
            btnSelectGuest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSelectGuest.ForeColor = Color.White;
            btnSelectGuest.Location = new Point(366, 507);
            btnSelectGuest.Margin = new Padding(3, 4, 3, 4);
            btnSelectGuest.Name = "btnSelectGuest";
            btnSelectGuest.Size = new Size(137, 47);
            btnSelectGuest.TabIndex = 3;
            btnSelectGuest.Text = "Select Guest";
            btnSelectGuest.UseVisualStyleBackColor = false;
            btnSelectGuest.Click += btnSelectGuest_Click;
            // 
            // dgvGuests
            // 
            dgvGuests.AllowUserToAddRows = false;
            dgvGuests.AllowUserToDeleteRows = false;
            dgvGuests.AllowUserToResizeRows = false;
            dgvGuests.BackgroundColor = Color.White;
            dgvGuests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvGuests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuests.EnableHeadersVisualStyles = false;
            dgvGuests.GridColor = Color.FromArgb(226, 232, 240);
            dgvGuests.Location = new Point(34, 160);
            dgvGuests.Margin = new Padding(3, 4, 3, 4);
            dgvGuests.MultiSelect = false;
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersVisible = false;
            dgvGuests.RowHeadersWidth = 51;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(617, 320);
            dgvGuests.TabIndex = 2;
            dgvGuests.CellDoubleClick += dgvGuests_CellDoubleClick;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(255, 251, 235);
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(34, 93);
            pnlSearch.Margin = new Padding(3, 4, 3, 4);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(617, 59);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(203, 13);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(399, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(23, 17);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(174, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search by Last Name:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(34, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Find Guest";
            // 
            // GuestSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(686, 600);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GuestSearch";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Guest Search";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectGuest;
        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
    }
}