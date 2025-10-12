using System.Windows.Forms;
using System.Drawing;

namespace PhumlaniKamnandi.Presentation
{
    partial class AddGuestDialog
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
            btnCancel = new Button();
            btnOK = new Button();
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
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(btnOK);
            pnlMain.Controls.Add(txtPostalCode);
            pnlMain.Controls.Add(lblPostalCode);
            pnlMain.Controls.Add(txtAddress2);
            pnlMain.Controls.Add(lblAddress2);
            pnlMain.Controls.Add(txtAddress1);
            pnlMain.Controls.Add(lblAddress1);
            pnlMain.Controls.Add(txtTelephone);
            pnlMain.Controls.Add(lblTelephone);
            pnlMain.Controls.Add(txtGuestName);
            pnlMain.Controls.Add(lblGuestName);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(450, 350);
            pnlMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(239, 68, 68);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(240, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(34, 197, 94);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(120, 290);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 11;
            btnOK.Text = "Add Guest";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // txtPostalCode
            // 
            txtPostalCode.Font = new Font("Segoe UI", 9F);
            txtPostalCode.Location = new Point(150, 240);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(250, 27);
            txtPostalCode.TabIndex = 10;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Font = new Font("Segoe UI", 9F);
            lblPostalCode.Location = new Point(30, 243);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(90, 20);
            lblPostalCode.TabIndex = 9;
            lblPostalCode.Text = "Postal Code:";
            // 
            // txtAddress2
            // 
            txtAddress2.Font = new Font("Segoe UI", 9F);
            txtAddress2.Location = new Point(150, 200);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(250, 27);
            txtAddress2.TabIndex = 8;
            // 
            // lblAddress2
            // 
            lblAddress2.AutoSize = true;
            lblAddress2.Font = new Font("Segoe UI", 9F);
            lblAddress2.Location = new Point(30, 203);
            lblAddress2.Name = "lblAddress2";
            lblAddress2.Size = new Size(108, 20);
            lblAddress2.TabIndex = 7;
            lblAddress2.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            txtAddress1.Font = new Font("Segoe UI", 9F);
            txtAddress1.Location = new Point(150, 160);
            txtAddress1.Name = "txtAddress1";
            txtAddress1.Size = new Size(250, 27);
            txtAddress1.TabIndex = 6;
            // 
            // lblAddress1
            // 
            lblAddress1.AutoSize = true;
            lblAddress1.Font = new Font("Segoe UI", 9F);
            lblAddress1.Location = new Point(30, 163);
            lblAddress1.Name = "lblAddress1";
            lblAddress1.Size = new Size(108, 20);
            lblAddress1.TabIndex = 5;
            lblAddress1.Text = "Address Line 1:";
            // 
            // txtTelephone
            // 
            txtTelephone.Font = new Font("Segoe UI", 9F);
            txtTelephone.Location = new Point(150, 120);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(250, 27);
            txtTelephone.TabIndex = 4;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Font = new Font("Segoe UI", 9F);
            lblTelephone.Location = new Point(30, 123);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(81, 20);
            lblTelephone.TabIndex = 3;
            lblTelephone.Text = "Telephone:";
            // 
            // txtGuestName
            // 
            txtGuestName.Font = new Font("Segoe UI", 9F);
            txtGuestName.Location = new Point(150, 80);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(250, 27);
            txtGuestName.TabIndex = 2;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 9F);
            lblGuestName.Location = new Point(30, 83);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(79, 20);
            lblGuestName.TabIndex = 1;
            lblGuestName.Text = "Full Name:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 128);
            lblTitle.Location = new Point(150, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Guest";
            // 
            // AddGuestDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 350);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddGuestDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Guest";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Button btnCancel;
        private Button btnOK;
        private TextBox txtPostalCode;
        private Label lblPostalCode;
        private TextBox txtAddress2;
        private Label lblAddress2;
        private TextBox txtAddress1;
        private Label lblAddress1;
        private TextBox txtTelephone;
        private Label lblTelephone;
        private TextBox txtGuestName;
        private Label lblGuestName;
        private Label lblTitle;
    }
}