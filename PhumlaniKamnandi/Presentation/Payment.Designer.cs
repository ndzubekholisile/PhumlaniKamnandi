using System.Drawing;
using System.Windows.Forms;

namespace PhumlaniKamnandi.Presentation
{
    partial class Payment
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
            this.pnlPaymentDetails = new System.Windows.Forms.Panel();
            this.lblValidationMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.pnlCardInfo = new System.Windows.Forms.Panel();
            this.picCardType = new System.Windows.Forms.Panel();
            this.lblCardType = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.lblCVV = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtCardholderName = new System.Windows.Forms.TextBox();
            this.lblCardholderName = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlPaymentDetails.SuspendLayout();
            this.pnlCardInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.pnlPaymentDetails);
            this.pnlMain.Controls.Add(this.lblPaymentAmount);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(550, 417);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlPaymentDetails
            // 
            this.pnlPaymentDetails.BackColor = System.Drawing.Color.White;
            this.pnlPaymentDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaymentDetails.Controls.Add(this.lblValidationMessage);
            this.pnlPaymentDetails.Controls.Add(this.btnCancel);
            this.pnlPaymentDetails.Controls.Add(this.btnProcessPayment);
            this.pnlPaymentDetails.Controls.Add(this.pnlCardInfo);
            this.pnlPaymentDetails.Location = new System.Drawing.Point(50, 96);
            this.pnlPaymentDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPaymentDetails.Name = "pnlPaymentDetails";
            this.pnlPaymentDetails.Size = new System.Drawing.Size(450, 280);
            this.pnlPaymentDetails.TabIndex = 2;
            // 
            // lblValidationMessage
            // 
            this.lblValidationMessage.AutoSize = true;
            this.lblValidationMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValidationMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblValidationMessage.Location = new System.Drawing.Point(25, 200);
            this.lblValidationMessage.Name = "lblValidationMessage";
            this.lblValidationMessage.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessage.TabIndex = 8;
            this.lblValidationMessage.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(240, 232);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnProcessPayment.FlatAppearance.BorderSize = 0;
            this.btnProcessPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessPayment.ForeColor = System.Drawing.Color.White;
            this.btnProcessPayment.Location = new System.Drawing.Point(90, 232);
            this.btnProcessPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(120, 32);
            this.btnProcessPayment.TabIndex = 6;
            this.btnProcessPayment.Text = "Process Payment";
            this.btnProcessPayment.UseVisualStyleBackColor = false;
            // 
            // pnlCardInfo
            // 
            this.pnlCardInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlCardInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardInfo.Controls.Add(this.picCardType);
            this.pnlCardInfo.Controls.Add(this.lblCardType);
            this.pnlCardInfo.Controls.Add(this.txtCVV);
            this.pnlCardInfo.Controls.Add(this.lblCVV);
            this.pnlCardInfo.Controls.Add(this.dtpExpiryDate);
            this.pnlCardInfo.Controls.Add(this.lblExpiryDate);
            this.pnlCardInfo.Controls.Add(this.txtCardholderName);
            this.pnlCardInfo.Controls.Add(this.lblCardholderName);
            this.pnlCardInfo.Controls.Add(this.txtCardNumber);
            this.pnlCardInfo.Controls.Add(this.lblCardNumber);
            this.pnlCardInfo.Location = new System.Drawing.Point(25, 16);
            this.pnlCardInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCardInfo.Name = "pnlCardInfo";
            this.pnlCardInfo.Size = new System.Drawing.Size(400, 176);
            this.pnlCardInfo.TabIndex = 0;
            // 
            // picCardType
            // 
            this.picCardType.BackColor = System.Drawing.Color.Transparent;
            this.picCardType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCardType.Location = new System.Drawing.Point(320, 24);
            this.picCardType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCardType.Name = "picCardType";
            this.picCardType.Size = new System.Drawing.Size(50, 24);
            this.picCardType.TabIndex = 9;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCardType.Location = new System.Drawing.Point(320, 8);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(0, 19);
            this.lblCardType.TabIndex = 8;
            // 
            // txtCVV
            // 
            this.txtCVV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCVV.Location = new System.Drawing.Point(320, 131);
            this.txtCVV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCVV.MaxLength = 4;
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(60, 30);
            this.txtCVV.TabIndex = 7;
            // 
            // lblCVV
            // 
            this.lblCVV.AutoSize = true;
            this.lblCVV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCVV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCVV.Location = new System.Drawing.Point(320, 96);
            this.lblCVV.Name = "lblCVV";
            this.lblCVV.Size = new System.Drawing.Size(47, 23);
            this.lblCVV.TabIndex = 6;
            this.lblCVV.Text = "CVV:";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpExpiryDate.Location = new System.Drawing.Point(150, 131);
            this.dtpExpiryDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(150, 30);
            this.dtpExpiryDate.TabIndex = 5;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExpiryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblExpiryDate.Location = new System.Drawing.Point(146, 106);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(100, 23);
            this.lblExpiryDate.TabIndex = 4;
            this.lblExpiryDate.Text = "Expiry Date:";
            // 
            // txtCardholderName
            // 
            this.txtCardholderName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardholderName.Location = new System.Drawing.Point(150, 64);
            this.txtCardholderName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCardholderName.Name = "txtCardholderName";
            this.txtCardholderName.Size = new System.Drawing.Size(220, 30);
            this.txtCardholderName.TabIndex = 3;
            // 
            // lblCardholderName
            // 
            this.lblCardholderName.AutoSize = true;
            this.lblCardholderName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardholderName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCardholderName.Location = new System.Drawing.Point(3, 69);
            this.lblCardholderName.Name = "lblCardholderName";
            this.lblCardholderName.Size = new System.Drawing.Size(150, 23);
            this.lblCardholderName.TabIndex = 2;
            this.lblCardholderName.Text = "Cardholder Name:";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCardNumber.Location = new System.Drawing.Point(150, 24);
            this.txtCardNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCardNumber.MaxLength = 23;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(160, 30);
            this.txtCardNumber.TabIndex = 1;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCardNumber.Location = new System.Drawing.Point(3, 27);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(118, 23);
            this.lblCardNumber.TabIndex = 0;
            this.lblCardNumber.Text = "Card Number:";
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPaymentAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblPaymentAmount.Location = new System.Drawing.Point(175, 64);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(237, 32);
            this.lblPaymentAmount.TabIndex = 1;
            this.lblPaymentAmount.Text = "Amount Due: $0.00";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(175, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payment Form";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 417);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Processing";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlPaymentDetails.ResumeLayout(false);
            this.pnlPaymentDetails.PerformLayout();
            this.pnlCardInfo.ResumeLayout(false);
            this.pnlCardInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlMain;
        private Panel pnlPaymentDetails;
        private Label lblValidationMessage;
        private Button btnCancel;
        private Button btnProcessPayment;
        private Panel pnlCardInfo;
        private Panel picCardType;
        private Label lblCardType;
        private TextBox txtCVV;
        private Label lblCVV;
        private DateTimePicker dtpExpiryDate;
        private Label lblExpiryDate;
        private TextBox txtCardholderName;
        private Label lblCardholderName;
        private TextBox txtCardNumber;
        private Label lblCardNumber;
        private Label lblPaymentAmount;
        private Label lblTitle;
    }
}