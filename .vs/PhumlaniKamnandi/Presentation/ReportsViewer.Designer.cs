using System.Windows.Forms;
using System.Drawing;

namespace PhumlaniKamnandi.Presentation
{
    partial class ReportsViewer
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.btnExport);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.dgvReport);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(720, 530);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 40);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export to CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(580, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvReport.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246))))),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                ForeColor = System.Drawing.Color.White,
                SelectionBackColor = System.Drawing.SystemColors.Highlight,
                SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                WrapMode = System.Windows.Forms.DataGridViewTriState.True
            };
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))),
                (int)System.Windows.Forms.DataGridViewTriState.True)
            };
            this.dgvReport.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dgvReport.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvReport.Location = new System.Drawing.Point(30, 120);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 29;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(840, 380);
            this.dgvReport.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblReportType);
            this.pnlHeader.Controls.Add(this.lblReportTitle);
            this.pnlHeader.Location = new System.Drawing.Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(840, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblReportType.Location = new System.Drawing.Point(20, 45);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(100, 21);
            this.lblReportType.TabIndex = 1;
            this.lblReportType.Text = "Report Type";
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblReportTitle.Location = new System.Drawing.Point(20, 15);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(120, 30);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "Report Title";
            // 
            // ReportsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportsViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Viewer";
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Label lblReportTitle;
    }
}