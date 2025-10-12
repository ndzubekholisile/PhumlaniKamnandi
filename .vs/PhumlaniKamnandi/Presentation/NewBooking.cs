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
    public partial class NewBooking : Form
    {
        private GuestController guestController;
        private ReservationController reservationController;
        private RoomController roomController;
        private BookerController bookerController;
        private Guest selectedGuest;
        private List<Guest> bookingGuests;
        private bool isAvailabilityChecked = false;

        public NewBooking()
        {
            InitializeComponent();
            InitializeControllers();
            InitializeForm();
        }

        private void InitializeControllers()
        {
            try
            {
                guestController = new GuestController();
                reservationController = new ReservationController();
                roomController = new RoomController();
                bookerController = new BookerController();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing booking form: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void InitializeForm()
        {
            // This will set default dates
            dtpCheckIn.Value = DateTime.Today.AddDays(1);
            dtpCheckOut.Value = DateTime.Today.AddDays(2);

            // Initialize guest list
            bookingGuests = new List<Guest>();

            // This will initially hide the guest details section
            pnlGuestDetails.Visible = false;
            pnlConfirmation.Visible = false;

            // This will disable the confirm button initially
            btnConfirmBooking.Enabled = false;

            UpdateTotalCost();
        }

        private void UpdateTotalCost()
        {
            if (isAvailabilityChecked)
            {
                var nights = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                var totalCost = nights * 150.00m; // Assuming $150 per night
                var deposit = totalCost * 0.20m; // The 20% deposit

                lblTotalNights.Text = $"Total Nights: {nights}";
                lblTotalCost.Text = $"Total Cost: ${totalCost:F2}";
                lblDepositRequired.Text = $"Deposit Required: ${deposit:F2}";
            }
        }

        private void rbExistingGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExistingGuest.Checked)
            {
                pnlGuestDetails.Visible = false;
                txtSelectedGuest.Text = "";
                selectedGuest = null;
                btnFindGuest.Enabled = true;
                
                // Clear existing guest list when switching to existing guest mode
                bookingGuests.Clear();
                UpdateGuestList();
                CheckBookingReadiness();
            }
        }

        private void rbNewGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNewGuest.Checked)
            {
                pnlGuestDetails.Visible = true;
                txtSelectedGuest.Text = "";
                selectedGuest = null;
                btnFindGuest.Enabled = false;
                
                // Clear existing guest list when switching to new guest mode
                bookingGuests.Clear();
                UpdateGuestList();
                CheckBookingReadiness();
            }
        }

        private void btnFindGuest_Click(object sender, EventArgs e)
        {
            var guestSearchForm = new GuestSearch(guestController);
            if (guestSearchForm.ShowDialog() == DialogResult.OK)
            {
                selectedGuest = guestSearchForm.SelectedGuest;
                if (selectedGuest != null)
                {
                    txtSelectedGuest.Text = $"{selectedGuest.Name} - {selectedGuest.Telephone}";
                    
                    // Add selected guest to the booking guests list
                    if (!bookingGuests.Any(g => g.GuestID == selectedGuest.GuestID))
                    {
                        bookingGuests.Add(selectedGuest);
                        UpdateGuestList();
                    }
                }
            }
            CheckBookingReadiness();
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            // Validate date range using ValidationHelper
            if (!ValidationHelper.IsValidDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
            {
                MessageBox.Show("Please select valid dates. Check-in must be today or later, and check-out must be after check-in.", 
                              "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Use room controller for availability check
                var availableRooms = roomController.GetAvailableRoomCount();

                if (availableRooms > 0)
                {
                    MessageBox.Show($"Rooms are available! {availableRooms} rooms currently free.", 
                                  "Availability Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAvailabilityChecked = true;
                    pnlConfirmation.Visible = true;
                    UpdateTotalCost();
                }
                else
                {
                    MessageBox.Show("No rooms available for the selected dates.", 
                                  "No Availability", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isAvailabilityChecked = false;
                    pnlConfirmation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking availability: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CheckBookingReadiness();
        }

        private void CheckBookingReadiness()
        {
            bool isGuestSelected = false;

            if (rbExistingGuest.Checked)
            {
                isGuestSelected = selectedGuest != null || bookingGuests.Count > 0;
            }
            else if (rbNewGuest.Checked)
            {
                // Check if we have at least one guest in the list or valid current guest data
                isGuestSelected = bookingGuests.Count > 0 || 
                                (ValidationHelper.IsValidName(txtGuestName.Text) &&
                                 ValidationHelper.IsValidPhoneNumber(txtTelephone.Text));
            }

            btnConfirmBooking.Enabled = isAvailabilityChecked && isGuestSelected;
        }

        private void UpdateGuestList()
        {
            try
            {
                var guestData = bookingGuests.Select((g, index) => new
                {
                    No = index + 1,
                    Name = g.Name,
                    Telephone = g.Telephone,
                    IsPrimary = index == 0 ? "Yes" : "No"
                }).ToList();

                dgvBookingGuests.DataSource = guestData;
                
                // Configure columns
                if (dgvBookingGuests.Columns.Count > 0)
                {
                    dgvBookingGuests.Columns["No"].HeaderText = "#";
                    dgvBookingGuests.Columns["No"].Width = 30;
                    dgvBookingGuests.Columns["Name"].HeaderText = "Name";
                    dgvBookingGuests.Columns["Name"].Width = 100;
                    dgvBookingGuests.Columns["Telephone"].HeaderText = "Phone";
                    dgvBookingGuests.Columns["Telephone"].Width = 80;
                    dgvBookingGuests.Columns["IsPrimary"].HeaderText = "Primary";
                    dgvBookingGuests.Columns["IsPrimary"].Width = 60;
                }

                lblGuestCount.Text = $"Total Guests: {bookingGuests.Count}";
                btnRemoveSelectedGuest.Enabled = bookingGuests.Count > 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating guest list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateBookingInput())
                return;

            try
            {
                List<Guest> guestsToBook = new List<Guest>();

                if (rbNewGuest.Checked)
                {
                    // Add current guest form data if valid
                    if (ValidationHelper.IsValidName(txtGuestName.Text) && 
                        ValidationHelper.IsValidPhoneNumber(txtTelephone.Text))
                    {
                        var currentGuest = new Guest
                        {
                            Name = ValidationHelper.SanitizeInput(txtGuestName.Text.Trim()),
                            Telephone = txtTelephone.Text.Trim(),
                            AddressLine1 = ValidationHelper.SanitizeInput(txtAddress1.Text.Trim()),
                            AddressLine2 = ValidationHelper.SanitizeInput(txtAddress2.Text.Trim()),
                            PostalCode = txtPostalCode.Text.Trim(),
                            DateBooked = DateTime.Now
                        };
                        
                        // Check if this guest is not already in the list
                        if (!bookingGuests.Any(g => g.Name == currentGuest.Name && g.Telephone == currentGuest.Telephone))
                        {
                            bookingGuests.Insert(0, currentGuest); // Make it the primary guest
                        }
                    }
                    
                    guestsToBook = bookingGuests;
                }
                else
                {
                    // Use existing guests
                    guestsToBook = bookingGuests.Count > 0 ? bookingGuests : new List<Guest> { selectedGuest };
                }

                if (guestsToBook.Count == 0)
                {
                    MessageBox.Show("Please add at least one guest to the booking.", "No Guests", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create reservation
                var reservation = new Reservation
                {
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Status = "confirmed",
                    DateBooked = DateTime.Now
                };

                // Use booker controller for multi-guest transaction
                bool success;
                if (guestsToBook.Count == 1)
                {
                    success = bookerController.CreateBooking(guestsToBook[0], reservation);
                }
                else
                {
                    success = bookerController.CreateBookingWithMultipleGuests(guestsToBook, reservation);
                }

                if (success)
                {
                    MessageBox.Show($"Booking confirmed successfully with {guestsToBook.Count} guest(s)!", "Success", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create booking. Please try again.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBookingInput()
        {
            if (rbNewGuest.Checked)
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
                    MessageBox.Show("Please enter a valid phone number.", "Validation Error", 
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
            }

            if (!ValidationHelper.IsValidDateRange(dtpCheckIn.Value, dtpCheckOut.Value))
            {
                MessageBox.Show("Please select valid dates.", "Validation Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtGuestName_TextChanged(object sender, EventArgs e)
        {
            CheckBookingReadiness();
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            CheckBookingReadiness();
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            isAvailabilityChecked = false;
            pnlConfirmation.Visible = false;
            CheckBookingReadiness();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            isAvailabilityChecked = false;
            pnlConfirmation.Visible = false;
            CheckBookingReadiness();
        }

        private void btnAddAnotherGuest_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate current guest form data
                if (!ValidationHelper.IsValidName(txtGuestName.Text))
                {
                    MessageBox.Show("Please enter a valid guest name before adding another guest.", "Validation Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGuestName.Focus();
                    return;
                }

                if (!ValidationHelper.IsValidPhoneNumber(txtTelephone.Text))
                {
                    MessageBox.Show("Please enter a valid telephone number before adding another guest.", "Validation Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelephone.Focus();
                    return;
                }

                // Create guest from current form data
                var newGuest = new Guest
                {
                    Name = ValidationHelper.SanitizeInput(txtGuestName.Text.Trim()),
                    Telephone = txtTelephone.Text.Trim(),
                    AddressLine1 = ValidationHelper.SanitizeInput(txtAddress1.Text.Trim()),
                    AddressLine2 = ValidationHelper.SanitizeInput(txtAddress2.Text.Trim()),
                    PostalCode = txtPostalCode.Text.Trim(),
                    DateBooked = DateTime.Now
                };

                // Check for duplicates
                if (bookingGuests.Any(g => g.Name == newGuest.Name && g.Telephone == newGuest.Telephone))
                {
                    MessageBox.Show("This guest is already in the booking list.", "Duplicate Guest", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add to guest list
                bookingGuests.Add(newGuest);
                UpdateGuestList();

                // Clear form for next guest
                txtGuestName.Clear();
                txtTelephone.Clear();
                txtAddress1.Clear();
                txtAddress2.Clear();
                txtPostalCode.Clear();
                txtGuestName.Focus();

                CheckBookingReadiness();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding guest: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveSelectedGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBookingGuests.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a guest to remove.", "No Selection", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (bookingGuests.Count <= 1)
                {
                    MessageBox.Show("Cannot remove the last guest. At least one guest is required for booking.", 
                                  "Cannot Remove", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedIndex = dgvBookingGuests.SelectedRows[0].Index;
                var guestName = bookingGuests[selectedIndex].Name;

                var result = MessageBox.Show($"Are you sure you want to remove {guestName} from this booking?", 
                                           "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bookingGuests.RemoveAt(selectedIndex);
                    UpdateGuestList();
                    CheckBookingReadiness();
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
