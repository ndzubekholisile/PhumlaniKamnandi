using PhumlaniKamnandi.Business;
using PhumlaniKamnandi.Data;
using PhumlaniKamnandi.Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhumlaniKamnandi.Presentation
{
    public partial class BookingDetails : Form
    {
        private ReservationController reservationController;
        private GuestController guestController;
        private BookerController bookerController;
        private Reservation currentReservation;
        private Guest currentGuest;
        private List<Guest> allGuests;
        private bool isEditMode = false;
        private bool isAddingGuest = false;

        public BookingDetails(int reservationId)
        {
            InitializeComponent();
            InitializeControllers();
            LoadBookingDetails(reservationId);
            SetReadOnlyMode(true);
        }

        private void InitializeControllers()
        {
            try
            {
                reservationController = new ReservationController();
                guestController = new GuestController();
                bookerController = new BookerController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing booking details: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadBookingDetails(int reservationId)
        {
            try
            {
                // Use controllers to load data
                currentReservation = reservationController.Find(reservationId);
                if (currentReservation != null)
                {
                    // Load all guests for this booking
                    allGuests = bookerController.GetGuestsByBookingId(currentReservation.BookingID);
                    currentGuest = allGuests.FirstOrDefault();

                    if (currentGuest != null)
                    {
                        // Populate primary guest details
                        txtGuestName.Text = currentGuest.Name;
                        txtTelephone.Text = currentGuest.Telephone;
                        txtAddress1.Text = currentGuest.AddressLine1;
                        txtAddress2.Text = currentGuest.AddressLine2;
                        txtPostalCode.Text = currentGuest.PostalCode;
                        lblDateBooked.Text = $"Date Booked: {currentGuest.DateBooked.ToShortDateString()}";

                        // Populate reservation details
                        dtpCheckIn.Value = currentReservation.CheckInDate;
                        dtpCheckOut.Value = currentReservation.CheckOutDate;
                        lblStatus.Text = $"Status: {currentReservation.Status}";
                        lblReservationID.Text = $"Reservation ID: {currentReservation.ReservationID}";
                        lblBookingID.Text = $"Booking ID: {currentReservation.BookingID}";

                        // Calculate costs using controller methods
                        var nights = (currentReservation.CheckOutDate - currentReservation.CheckInDate).Days;
                        var totalCost = reservationController.CalculateReservationCost(currentReservation);
                        var deposit = reservationController.CalculateDeposit(currentReservation);

                        lblTotalNights.Text = $"Total Nights: {nights}";
                        lblTotalCost.Text = $"Total Cost: ${totalCost:F2}";
                        lblDeposit.Text = $"Deposit Paid: ${deposit:F2}";

                        // Load guest list
                        LoadGuestList();
                    }
                }
                else
                {
                    MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGuestList()
        {
            try
            {
                var guestData = allGuests.Select((g, index) => new
                {
                    No = index + 1,
                    Name = g.Name,
                    Telephone = g.Telephone,
                    GuestID = g.GuestID,
                    IsPrimary = index == 0 ? "Yes" : "No"
                }).ToList();

                dgvGuests.DataSource = guestData;
                
                // Configure columns
                if (dgvGuests.Columns.Count > 0)
                {
                    dgvGuests.Columns["No"].HeaderText = "#";
                    dgvGuests.Columns["No"].Width = 30;
                    dgvGuests.Columns["Name"].HeaderText = "Guest Name";
                    dgvGuests.Columns["Name"].Width = 120;
                    dgvGuests.Columns["Telephone"].HeaderText = "Phone";
                    dgvGuests.Columns["Telephone"].Width = 100;
                    dgvGuests.Columns["IsPrimary"].HeaderText = "Primary";
                    dgvGuests.Columns["IsPrimary"].Width = 60;
                    dgvGuests.Columns["GuestID"].Visible = false;
                }

                lblGuestList.Text = $"All Guests ({allGuests.Count}):";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guest list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetReadOnlyMode(bool readOnly)
        {
            // Primary guest controls
            bool primaryGuestReadOnly = readOnly || isAddingGuest;
            txtGuestName.ReadOnly = primaryGuestReadOnly;
            txtTelephone.ReadOnly = primaryGuestReadOnly;
            txtAddress1.ReadOnly = primaryGuestReadOnly;
            txtAddress2.ReadOnly = primaryGuestReadOnly;
            txtPostalCode.ReadOnly = primaryGuestReadOnly;
            dtpCheckIn.Enabled = !readOnly && !isAddingGuest;
            dtpCheckOut.Enabled = !readOnly && !isAddingGuest;

            // Multi-guest controls
            btnAddGuest.Visible = !readOnly && !isAddingGuest;
            btnRemoveGuest.Visible = !readOnly && !isAddingGuest && allGuests != null && allGuests.Count > 1;

            // New guest entry controls
            SetNewGuestEntryVisibility(isAddingGuest);

            if (readOnly)
            {
                btnEdit.Text = "Edit";
                btnSaveChanges.Visible = false;
                btnCancelEdit.Visible = false;
                lblEditMode.Text = "View Mode";
                lblEditMode.ForeColor = Color.FromArgb(34, 197, 94);
            }
            else
            {
                btnEdit.Text = "Cancel Edit";
                btnSaveChanges.Visible = !isAddingGuest;
                btnCancelEdit.Visible = !isAddingGuest;
                lblEditMode.Text = isAddingGuest ? "Adding Guest" : "Edit Mode";
                lblEditMode.ForeColor = isAddingGuest ? Color.FromArgb(59, 130, 246) : Color.FromArgb(239, 68, 68);
            }
        }

        private void SetNewGuestEntryVisibility(bool visible)
        {
            pnlNewGuestEntry.Visible = visible;
            btnSaveNewGuest.Visible = visible;
            btnCancelNewGuest.Visible = visible;
            lblNewGuestTitle.Visible = visible;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // This will cancel edit mode
                SetReadOnlyMode(true);
                isEditMode = false;
                LoadBookingDetails(currentReservation.ReservationID); // Reload original data
            }
            else
            {
                // Thiss will be used to enter edit mode
                SetReadOnlyMode(false);
                isEditMode = true;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // Update guest details with sanitized input
                    currentGuest.Name = ValidationHelper.SanitizeInput(txtGuestName.Text.Trim());
                    currentGuest.Telephone = txtTelephone.Text.Trim();
                    currentGuest.AddressLine1 = ValidationHelper.SanitizeInput(txtAddress1.Text.Trim());
                    currentGuest.AddressLine2 = ValidationHelper.SanitizeInput(txtAddress2.Text.Trim());
                    currentGuest.PostalCode = txtPostalCode.Text.Trim();

                    // Update reservation details
                    currentReservation.CheckInDate = dtpCheckIn.Value;
                    currentReservation.CheckOutDate = dtpCheckOut.Value;

                    // Use booker controller for update transaction
                    if (bookerController.UpdateBooking(currentGuest, currentReservation))
                    {
                        MessageBox.Show("Booking details updated successfully!", "Success", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SetReadOnlyMode(true);
                        isEditMode = false;
                        LoadBookingDetails(currentReservation.ReservationID); // Refresh display
                    }
                    else
                    {
                        MessageBox.Show("Failed to update booking details. Please try again.", "Error", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            SetReadOnlyMode(true);
            isEditMode = false;
            LoadBookingDetails(currentReservation.ReservationID); // This will reload the original data
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

            if (!ValidationHelper.IsValidDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
            {
                MessageBox.Show("Please select valid dates. Check-out must be after check-in.", 
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            try
            {
                // Enter add guest mode
                isAddingGuest = true;
                SetReadOnlyMode(false);
                
                // Clear new guest entry fields
                ClearNewGuestFields();
                
                // Focus on the first field
                txtNewGuestName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error entering add guest mode: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearNewGuestFields()
        {
            txtNewGuestName.Clear();
            txtNewGuestTelephone.Clear();
            txtNewGuestAddress1.Clear();
            txtNewGuestAddress2.Clear();
            txtNewGuestPostalCode.Clear();
        }

        private void btnSaveNewGuest_Click(object sender, EventArgs e)
        {
            if (ValidateNewGuestInput())
            {
                try
                {
                    var newGuest = new Guest
                    {
                        Name = ValidationHelper.SanitizeInput(txtNewGuestName.Text.Trim()),
                        Telephone = txtNewGuestTelephone.Text.Trim(),
                        AddressLine1 = ValidationHelper.SanitizeInput(txtNewGuestAddress1.Text.Trim()),
                        AddressLine2 = ValidationHelper.SanitizeInput(txtNewGuestAddress2.Text.Trim()),
                        PostalCode = txtNewGuestPostalCode.Text.Trim(),
                        DateBooked = DateTime.Now
                    };

                    if (bookerController.AddGuestToExistingBooking(newGuest, currentReservation.BookingID))
                    {
                        // Exit add guest mode
                        isAddingGuest = false;
                        SetReadOnlyMode(false);
                        
                        // Reload the booking details to refresh the guest list
                        LoadBookingDetails(currentReservation.ReservationID);
                        MessageBox.Show("Guest added successfully!", "Success", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add guest. Please try again.", "Error", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding guest: {ex.Message}", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelNewGuest_Click(object sender, EventArgs e)
        {
            // Exit add guest mode without saving
            isAddingGuest = false;
            SetReadOnlyMode(false);
            ClearNewGuestFields();
        }

        private bool ValidateNewGuestInput()
        {
            if (!ValidationHelper.IsValidName(txtNewGuestName.Text))
            {
                MessageBox.Show("Please enter a valid guest name.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewGuestName.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhoneNumber(txtNewGuestTelephone.Text))
            {
                MessageBox.Show("Please enter a valid telephone number.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewGuestTelephone.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtNewGuestPostalCode.Text) && 
                !ValidationHelper.IsValidPostalCode(txtNewGuestPostalCode.Text))
            {
                MessageBox.Show("Please enter a valid postal code.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewGuestPostalCode.Focus();
                return false;
            }

            return true;
        }

        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuests.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a guest to remove.", "No Selection", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvGuests.SelectedRows[0];
                var guestId = (int)selectedRow.Cells["GuestID"].Value;
                var guestName = selectedRow.Cells["Name"].Value.ToString();
                var isPrimary = selectedRow.Cells["IsPrimary"].Value.ToString() == "Yes";

                if (isPrimary)
                {
                    MessageBox.Show("Cannot remove the primary guest. To change the primary guest, edit their details instead.", 
                                  "Cannot Remove Primary Guest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to remove {guestName} from this booking?", 
                                           "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (bookerController.RemoveGuestFromBooking(guestId))
                    {
                        // Reload the booking details to refresh the guest list
                        LoadBookingDetails(currentReservation.ReservationID);
                        MessageBox.Show("Guest removed successfully!", "Success", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove guest. Please try again.", "Error", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing guest: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
