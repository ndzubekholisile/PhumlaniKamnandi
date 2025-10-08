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
        private int loginAttempts = 0;
        private const int MAX_LOGIN_ATTEMPTS = 3;
        private EmployeeController employeeController;

        public EmployeeLogin()
        {
            InitializeComponent();
            InitializeControllers();
            InitializeForm();
        }

        private void InitializeControllers()
        {
            try
            {
                employeeController = new EmployeeController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing login system: {ex.Message}\n\nPlease check database connection.", 
                              "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void InitializeForm()
        {
            try
            {
                // Set focus to username field for immediate typing
                txtUsername.Focus();
                
                // Hide password characters for security
                txtPassword.UseSystemPasswordChar = true;
                
                // Set max length for inputs
                txtUsername.MaxLength = 50;
                txtPassword.MaxLength = 100;
                
                // Set enter key behavior (Enter = Login, Escape = Cancel)
                this.AcceptButton = btnLogin;
                this.CancelButton = btnCancel;
                
                // Hide error message initially
                if (lblErrorMessage != null)
                {
                    lblErrorMessage.Visible = false;
                }
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
            // Step 1: Validate input fields
            if (!ValidateInput())
            {
                return; // Stop if validation fails
            }
            
            // Step 2: Disable login button to prevent multiple clicks
            btnLogin.Enabled = false;
            lblErrorMessage.Visible = false;
            
            try
            {
                // Step 3: Authenticate user
                if (AuthenticateUser())
                {
                    // Step 4: Successful login - clear sensitive data
                    txtPassword.Clear();
                    txtUsername.Clear();
                    
                    // Step 5: Show success message briefly
                    lblErrorMessage.ForeColor = Color.Green;
                    lblErrorMessage.Text = "Login successful! Opening dashboard...";
                    lblErrorMessage.Visible = true;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                    
                    // Step 6: Open Main Dashboard
                    this.Hide();
                    MainDashboard dashboard = new MainDashboard();
                    dashboard.ShowDialog();
                    
                    // Step 7: Close login form after dashboard closes
                    this.Close();
                }
                else
                {
                    // Failed login
                    loginAttempts++;
                    lblErrorMessage.ForeColor = Color.Red;
                    lblErrorMessage.Text = $"Invalid username or password. Attempts: {loginAttempts}/{MAX_LOGIN_ATTEMPTS}";
                    lblErrorMessage.Visible = true;
                    
                    // Clear password field for security
                    txtPassword.Clear();
                    txtPassword.Focus();
                    
                    // Re-enable login button
                    btnLogin.Enabled = true;
                    
                    // Lock out after max attempts
                    if (loginAttempts >= MAX_LOGIN_ATTEMPTS)
                    {
                        MessageBox.Show("Maximum login attempts exceeded. Application will close.", 
                                      "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Text = "An error occurred during login. Please try again.";
                lblErrorMessage.Visible = true;
                btnLogin.Enabled = true;
                
                MessageBox.Show($"Login error: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            lblErrorMessage.Visible = false;
            
            // Validate username - must not be empty
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Please enter your username.");
                txtUsername.Focus();
                return false;
            }
            
            // Validate password - must not be empty
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Please enter your password.");
                txtPassword.Focus();
                return false;
            }
            
            return true;
        }

        private void ShowError(string message)
        {
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

        private bool AuthenticateUser()
        {
            try
            {
                // Validate controller is initialized
                if (employeeController == null)
                {
                    MessageBox.Show("Authentication system not initialized. Please restart the application.", 
                                  "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Get credentials from input fields
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text; // Don't trim password - spaces may be intentional
                
                // Authenticate using EmployeeController
                var authenticatedEmployee = employeeController.AuthenticateUser(username, password);
                
                if (authenticatedEmployee != null)
                {
                    // Authentication successful - start session
                    SessionManager.StartSession(authenticatedEmployee);
                    return true;
                }
                
                // Authentication failed - invalid credentials
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication error: {ex.Message}\n\nPlease try again or contact support.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
