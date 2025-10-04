using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PhumlaniKamnandi.Presentation
{
    public partial class Payment : Form
    {
        public decimal PaymentAmount { get; set; }
        public bool PaymentSuccessful { get; private set; } = false;

        public Payment(decimal amount = 0)
        {
            InitializeComponent();
            PaymentAmount = amount;
            InitializeForm();
        }

        private void InitializeForm()
        {
            lblPaymentAmount.Text = $"Amount Due: ${PaymentAmount:F2}";
            
            // Set focus to card number field
            txtCardNumber.Focus();
            
            // Set up date picker defaults
            dtpExpiryDate.Format = DateTimePickerFormat.Custom;
            dtpExpiryDate.CustomFormat = "MM/yyyy";
            dtpExpiryDate.MinDate = DateTime.Now;
            dtpExpiryDate.MaxDate = DateTime.Now.AddYears(10);
            
            // Set accept/cancel buttons
            this.AcceptButton = btnProcessPayment;
            this.CancelButton = btnCancel;
            
            // Initialize card type
            lblCardType.Text = "";
            picCardType.BackgroundImage = null;
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text.Replace(" ", "").Replace("-", "");
            
            // Format card number with spaces
            if (cardNumber.Length > 0)
            {
                string formatted = "";
                for (int i = 0; i < cardNumber.Length; i++)
                {
                    if (i > 0 && i % 4 == 0)
                        formatted += " ";
                    formatted += cardNumber[i];
                }
                
                if (formatted != txtCardNumber.Text)
                {
                    txtCardNumber.Text = formatted;
                    txtCardNumber.SelectionStart = txtCardNumber.Text.Length;
                }
            }
            
            // Detect card type
            DetectCardType(cardNumber);
            
            // Clear validation message
            lblValidationMessage.Visible = false;
        }

        private void DetectCardType(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                lblCardType.Text = "";
                picCardType.BackColor = Color.Transparent;
                return;
            }

            if (IsVisa(cardNumber))
            {
                lblCardType.Text = "VISA";
                lblCardType.ForeColor = Color.FromArgb(0, 51, 153);
                picCardType.BackColor = Color.FromArgb(0, 51, 153);
            }
            else if (IsMasterCard(cardNumber))
            {
                lblCardType.Text = "MASTERCARD";
                lblCardType.ForeColor = Color.FromArgb(235, 0, 27);
                picCardType.BackColor = Color.FromArgb(235, 0, 27);
            }
            else
            {
                lblCardType.Text = "UNKNOWN";
                lblCardType.ForeColor = Color.FromArgb(128, 128, 128);
                picCardType.BackColor = Color.FromArgb(128, 128, 128);
            }
        }

        private bool IsVisa(string cardNumber)
        {
            // Visa cards start with 4 and have 13, 16, or 19 digits
            return cardNumber.StartsWith("4") && 
                   (cardNumber.Length == 13 || cardNumber.Length == 16 || cardNumber.Length == 19);
        }

        private bool IsMasterCard(string cardNumber)
        {
            // MasterCard starts with 5 (51-55) or 2 (2221-2720) and has 16 digits
            if (cardNumber.Length != 16) return false;
            
            if (cardNumber.StartsWith("5"))
            {
                int secondDigit = int.Parse(cardNumber.Substring(1, 1));
                return secondDigit >= 1 && secondDigit <= 5;
            }
            
            if (cardNumber.StartsWith("2"))
            {
                int first4 = int.Parse(cardNumber.Substring(0, 4));
                return first4 >= 2221 && first4 <= 2720;
            }
            
            return false;
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (ValidatePaymentForm())
            {
                if (ProcessPayment())
                {
                    PaymentSuccessful = true;
                    MessageBox.Show("Payment processed successfully!", "Payment Complete", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool ValidatePaymentForm()
        {
            lblValidationMessage.Visible = false;
            
            // Validate payment amount
            if (PaymentAmount <= 0)
            {
                ShowValidationError("Invalid payment amount.");
                return false;
            }
            
            // Validate card number
            string cardNumber = txtCardNumber.Text.Replace(" ", "").Replace("-", "");
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                ShowValidationError("Please enter a card number.");
                txtCardNumber.Focus();
                return false;
            }
            
            if (!cardNumber.All(char.IsDigit))
            {
                ShowValidationError("Card number must contain only digits.");
                txtCardNumber.Focus();
                return false;
            }
            
            if (cardNumber.Length < 13 || cardNumber.Length > 19)
            {
                ShowValidationError("Card number must be between 13 and 19 digits.");
                txtCardNumber.Focus();
                return false;
            }
            
            if (!IsValidCardNumber(cardNumber))
            {
                ShowValidationError("Please enter a valid card number (failed Luhn check).");
                txtCardNumber.Focus();
                return false;
            }
            
            // Validate cardholder name
            if (string.IsNullOrWhiteSpace(txtCardholderName.Text))
            {
                ShowValidationError("Please enter the cardholder name.");
                txtCardholderName.Focus();
                return false;
            }
            
            string cardholderName = txtCardholderName.Text.Trim();
            if (cardholderName.Length < 2)
            {
                ShowValidationError("Cardholder name must be at least 2 characters.");
                txtCardholderName.Focus();
                return false;
            }
            
            if (!Regex.IsMatch(cardholderName, @"^[a-zA-Z\s\.\-']+$"))
            {
                ShowValidationError("Cardholder name contains invalid characters.");
                txtCardholderName.Focus();
                return false;
            }
            
            // Validate expiry date
            DateTime firstDayOfMonth = new DateTime(dtpExpiryDate.Value.Year, dtpExpiryDate.Value.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            
            if (lastDayOfMonth < DateTime.Now)
            {
                ShowValidationError("Card has expired.");
                dtpExpiryDate.Focus();
                return false;
            }
            
            // Validate CVV
            if (string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                ShowValidationError("Please enter the CVV.");
                txtCVV.Focus();
                return false;
            }
            
            if (!txtCVV.Text.All(char.IsDigit))
            {
                ShowValidationError("CVV must contain only digits.");
                txtCVV.Focus();
                return false;
            }
            
            if (txtCVV.Text.Length < 3 || txtCVV.Text.Length > 4)
            {
                ShowValidationError("CVV must be 3 or 4 digits.");
                txtCVV.Focus();
                return false;
            }
            
            return true;
        }

        private bool IsValidCardNumber(string cardNumber)
        {
            // Check if all characters are digits
            if (!cardNumber.All(char.IsDigit))
                return false;
                
            // Check if it's a recognized card type
            if (!IsVisa(cardNumber) && !IsMasterCard(cardNumber))
                return false;
                
            // Validate using Luhn algorithm
            return ValidateLuhnAlgorithm(cardNumber);
        }
        
        private bool ValidateLuhnAlgorithm(string cardNumber)
        {
            // Luhn algorithm for credit card validation
            int sum = 0;
            bool alternate = false;
            
            // Process digits from right to left
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';
                
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }
                
                sum += digit;
                alternate = !alternate;
            }
            
            return (sum % 10 == 0);
        }

        private void ShowValidationError(string message)
        {
            lblValidationMessage.Text = message;
            lblValidationMessage.Visible = true;
        }

        private bool ProcessPayment()
        {
            try
            {
                // Simulate payment processing
                using (var progressForm = new Form())
                {
                    progressForm.Text = "Processing Payment...";
                    progressForm.Size = new Size(300, 100);
                    progressForm.StartPosition = FormStartPosition.CenterParent;
                    progressForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    progressForm.MaximizeBox = false;
                    progressForm.MinimizeBox = false;
                    
                    var label = new Label
                    {
                        Text = "Processing payment, please wait...",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    progressForm.Controls.Add(label);
                    
                    progressForm.Show();
                    Application.DoEvents();
                    
                    // Simulate processing time
                    System.Threading.Thread.Sleep(2000);
                    
                    progressForm.Close();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment processing failed: {ex.Message}", "Payment Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear sensitive data before closing
            ClearSensitiveData();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
            
            // Clear validation message
            if (lblValidationMessage.Visible)
            {
                lblValidationMessage.Visible = false;
            }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
            
            // Clear validation message
            if (lblValidationMessage.Visible)
            {
                lblValidationMessage.Visible = false;
            }
        }

        private void txtCardholderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow letters, spaces, and common punctuation
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.' && 
                e.KeyChar != '-' && e.KeyChar != '\'' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            
            // Clear validation message
            if (lblValidationMessage.Visible)
            {
                lblValidationMessage.Visible = false;
            }
        }
        
        private void ClearSensitiveData()
        {
            // Clear all sensitive payment information
            txtCardNumber.Clear();
            txtCVV.Clear();
            txtCardholderName.Clear();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ensure sensitive data is cleared when form closes
            ClearSensitiveData();
            base.OnFormClosing(e);
        }
    }
}
