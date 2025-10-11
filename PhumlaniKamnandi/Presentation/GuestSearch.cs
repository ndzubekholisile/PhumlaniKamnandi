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
    public partial class GuestSearch : Form
    {
        private GuestController guestController;
        public Guest SelectedGuest { get; private set; }

        public GuestSearch(GuestController guestCtrl)
        {
            InitializeComponent();
            guestController = guestCtrl;
            LoadGuests();
        }

        private void LoadGuests()
        {
            try
            {
                var guests = guestController.AllGuests.ToList();
                DisplayGuests(guests);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayGuests(List<Guest> guests)
        {
            dgvGuests.DataSource = guests.Select(g => new
            {
                g.GuestID,
                g.Name,
                g.Telephone,
                g.AddressLine1,
                g.AddressLine2,
                g.PostalCode,
                DateBooked = g.DateBooked.ToShortDateString()
            }).ToList();

            // Configure DataGridView
            dgvGuests.Columns["GuestID"].HeaderText = "ID";
            dgvGuests.Columns["Name"].HeaderText = "Guest Name";
            dgvGuests.Columns["Telephone"].HeaderText = "Phone";
            dgvGuests.Columns["AddressLine1"].HeaderText = "Address";
            dgvGuests.Columns["AddressLine2"].Visible = false;
            dgvGuests.Columns["PostalCode"].Visible = false;
            dgvGuests.Columns["DateBooked"].HeaderText = "Date Booked";

            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.MultiSelect = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = ValidationHelper.SanitizeInput(txtSearch.Text);

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadGuests();
                return;
            }

            try
            {
                // Use controller search method
                var filteredGuests = guestController.SearchGuests(searchTerm);
                DisplayGuests(filteredGuests);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering guests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectGuest_Click(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count > 0)
            {
                var selectedRow = dgvGuests.SelectedRows[0];
                int guestId = (int)selectedRow.Cells["GuestID"].Value;

                // Use controller to find guest
                SelectedGuest = guestController.FindByGuestId(guestId);

                if (SelectedGuest != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error retrieving selected guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a guest from the list.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvGuests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelectGuest_Click(sender, e);
            }
        }
    }
}
