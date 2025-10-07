using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhumlaniKamnandi.Data;
using PhumlaniKamnandi.Business;
using PhumlaniKamnandi.Presentation.Infrastructure;

namespace PhumlaniKamnandi.Presentation
{
    public partial class EmployeeLogin : Form
    {
        private EmployeeController employeeController;
        private int loginAttempts = 0;
        private const int MAX_LOGIN_ATTEMPTS = 3;
        private const int MIN_USERNAME_LENGTH = 3;
        private const int MAX_USERNAME_LENGTH = 50;
        private const int MIN_PASSWORD_LENGTH = 6;

        public EmployeeLogin()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            try
            {
                employeeController = new EmployeeController();
                
                // Set focus to username field
                txtUsername.Focus();
                
                // Set password character
                txtPassword.UseSystemPasswordChar = true;
                
                // Set max length for inputs
                txtUsername.MaxLength = MAX_USERNAME_LENGTH;
                txtPassword.MaxLength = 100;
                
                // Set enter key behavior
                this.AcceptButton = btnLogin;
                this.CancelButton = btnCancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing login form: {ex.Message}", "Initialization Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (AuthenticateUser())
                {
                    // Successful login - clear sensitive data
                    txtPassword.Clear();
                    
                    this.Hide();
                    MainDashboard dashboard = new MainDashboard();
                    dashboard.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Failed login
                    loginAttempts++;
                    lblErrorMessage.Text = $"Invalid username or password. Attempts: {loginAttempts}/{MAX_LOGIN_ATTEMPTS}";
                    lblErrorMessage.Visible = true;
                    
                    // Clear password field for security
                    txtPassword.Clear();
                    txtPassword.Focus();
                    
                    // Lock out after max attempts
                    if (loginAttempts >= MAX_LOGIN_ATTEMPTS)
                    {
                        MessageBox.Show("Maximum login attempts exceeded. Application will close.", 
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            lblErrorMessage.Visible = false;
            
            // Validate username using ValidationHelper
            if (!ValidationHelper.IsValidUsername(txtUsername.Text))
            {
                ShowError("Please enter a valid username (3-50 characters, letters, numbers, dots, underscores only).");
                txtUsername.Focus();
                return false;
            }
            
            // Validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Please enter your password.");
                txtPassword.Focus();
                return false;
            }
            
            if (txtPassword.Text.Length < MIN_PASSWORD_LENGTH)
            {
                ShowError($"Password must be at least {MIN_PASSWORD_LENGTH} characters.");
                txtPassword.Focus();
                return false;
            }
            
            return true;
        }

        private void ShowError(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

        private bool AuthenticateUser()
        {
            try
            {
                if (employeeController == null)
                {
                    MessageBox.Show("System error. Please try again.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                string username = ValidationHelper.SanitizeInput(txtUsername.Text.Trim());
                string password = txtPassword.Text; // Don't trim password - spaces may be intentional
                
                // Use controller for authentication
                var employee = employeeController.AuthenticateUser(username, password);
                
                if (employee != null)
                {
                    // Start session using SessionManager
                    SessionManager.StartSession(employee);
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication error: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear sensitive data before closing
            txtPassword.Clear();
            txtUsername.Clear();
            Application.Exit();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Clear error message when user starts typing
            if (lblErrorMessage.Visible)
            {
                lblErrorMessage.Visible = false;
            }
            
            // Prevent invalid characters in username
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && 
                e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Clear error message when user starts typing
            if (lblErrorMessage.Visible)
            {
                lblErrorMessage.Visible = false;
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your system administrator to reset your password.\n\nEmail: admin@hotel.com\nPhone: (555) 123-4567", 
                          "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Clear sensitive data when form closes
            txtPassword.Clear();
            txtUsername.Clear();
            base.OnFormClosing(e);
        }
    }
}
