using PhumlaniKamnandi.Business;
using PhumlaniKamnandi.Presentation.Infrastructure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhumlaniKamnandi.Presentation
{
    public partial class AddGuestDialog : Form
    {
        public Guest NewGuest { get; private set; }

        public AddGuestDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                NewGuest = new Guest
                {
                    Name = ValidationHelper.SanitizeInput(txtGuestName.Text.Trim()),
                    Telephone = txtTelephone.Text.Trim(),
                    AddressLine1 = ValidationHelper.SanitizeInput(txtAddress1.Text.Trim()),
                    AddressLine2 = ValidationHelper.SanitizeInput(txtAddress2.Text.Trim()),
                    PostalCode = txtPostalCode.Text.Trim(),
                    DateBooked = DateTime.Now
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (!ValidationHelper.IsValidName(txtGuestName.Text))
            {
                MessageBox.Show("Please enter a valid guest name.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestName.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhoneNumber(txtTelephone.Text))
            {
                MessageBox.Show("Please enter a valid telephone number.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && 
                !ValidationHelper.IsValidPostalCode(txtPostalCode.Text))
            {
                MessageBox.Show("Please enter a valid postal code.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPostalCode.Focus();
                return false;
            }

            return true;
        }
    }
}