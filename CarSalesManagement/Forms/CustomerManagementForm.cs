using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class CustomerManagementForm : Form
    {
        private List<Customer> customers;
        private DataGridView dgvCustomers;
        private TextBox txtSearch;
        private ComboBox cmbSearchBy;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        
        public CustomerManagementForm()
        {
            InitializeComponent();
            LoadSampleData();
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Customer Management";
            this.Size = new System.Drawing.Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Customer Management";
            titleLabel.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 40;
            
            // Search Panel
            Panel searchPanel = new Panel();
            searchPanel.Height = 60;
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Padding = new Padding(0, 10, 0, 10);
            
            Label lblSearch = new Label();
            lblSearch.Text = "Search:";
            lblSearch.Location = new System.Drawing.Point(20, 15);
            lblSearch.Size = new System.Drawing.Size(50, 23);
            lblSearch.Font = new System.Drawing.Font("Arial", 10);
            
            cmbSearchBy = new ComboBox();
            cmbSearchBy.Items.AddRange(new string[] { "Name", "Email", "Phone", "City", "Customer Type" });
            cmbSearchBy.SelectedIndex = 0;
            cmbSearchBy.Location = new System.Drawing.Point(80, 12);
            cmbSearchBy.Size = new System.Drawing.Size(120, 23);
            cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            
            txtSearch = new TextBox();
            txtSearch.Location = new System.Drawing.Point(210, 12);
            txtSearch.Size = new System.Drawing.Size(200, 23);
            txtSearch.Font = new System.Drawing.Font("Arial", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            
            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(420, 10);
            btnSearch.Size = new System.Drawing.Size(80, 30);
            btnSearch.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Click += BtnSearch_Click;
            
            searchPanel.Controls.AddRange(new Control[] { lblSearch, cmbSearchBy, txtSearch, btnSearch });
            
            // Buttons Panel
            Panel buttonsPanel = new Panel();
            buttonsPanel.Height = 60;
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.Padding = new Padding(0, 10, 0, 10);
            
            btnAdd = new Button();
            btnAdd.Text = "Add Customer";
            btnAdd.Location = new System.Drawing.Point(20, 10);
            btnAdd.Size = new System.Drawing.Size(120, 40);
            btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnAdd.Click += BtnAdd_Click;
            
            btnEdit = new Button();
            btnEdit.Text = "Edit Customer";
            btnEdit.Location = new System.Drawing.Point(160, 10);
            btnEdit.Size = new System.Drawing.Size(120, 40);
            btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            btnEdit.ForeColor = System.Drawing.Color.Black;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnEdit.Click += BtnEdit_Click;
            
            btnDelete = new Button();
            btnDelete.Text = "Delete Customer";
            btnDelete.Location = new System.Drawing.Point(300, 10);
            btnDelete.Size = new System.Drawing.Size(120, 40);
            btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnDelete.Click += BtnDelete_Click;
            
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new System.Drawing.Point(440, 10);
            btnRefresh.Size = new System.Drawing.Size(100, 40);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnRefresh.Click += BtnRefresh_Click;
            
            buttonsPanel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh });
            
            // Data Grid View
            dgvCustomers = new DataGridView();
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            dgvCustomers.BorderStyle = BorderStyle.FixedSingle;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Add columns to DataGridView
            dgvCustomers.Columns.Add("CustomerId", "ID");
            dgvCustomers.Columns.Add("FirstName", "First Name");
            dgvCustomers.Columns.Add("LastName", "Last Name");
            dgvCustomers.Columns.Add("Email", "Email");
            dgvCustomers.Columns.Add("Phone", "Phone");
            dgvCustomers.Columns.Add("City", "City");
            dgvCustomers.Columns.Add("Country", "Country");
            dgvCustomers.Columns.Add("DateOfBirth", "Date of Birth");
            dgvCustomers.Columns.Add("CustomerType", "Type");
            dgvCustomers.Columns.Add("RegistrationDate", "Registration Date");
            
            // Format date columns
            dgvCustomers.Columns["DateOfBirth"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvCustomers.Columns["RegistrationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            
            mainPanel.Controls.Add(dgvCustomers);
            mainPanel.Controls.Add(buttonsPanel);
            mainPanel.Controls.Add(searchPanel);
            mainPanel.Controls.Add(titleLabel);
            
            this.Controls.Add(mainPanel);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private void LoadSampleData()
        {
            customers = new List<Customer>();
            
            // Add sample customers
            customers.Add(new Customer("John", "Doe", "john.doe@email.com", "555-0101") { CustomerId = 1, City = "New York", Country = "USA", DateOfBirth = new DateTime(1985, 5, 15), LicenseNumber = "DL123456", CustomerType = "Regular" });
            customers.Add(new Customer("Jane", "Smith", "jane.smith@email.com", "555-0102") { CustomerId = 2, City = "Los Angeles", Country = "USA", DateOfBirth = new DateTime(1990, 8, 22), LicenseNumber = "DL789012", CustomerType = "VIP" });
            customers.Add(new Customer("Robert", "Johnson", "robert.j@company.com", "555-0103") { CustomerId = 3, City = "Chicago", Country = "USA", DateOfBirth = new DateTime(1978, 3, 10), LicenseNumber = "DL345678", CustomerType = "Corporate" });
            customers.Add(new Customer("Emily", "Brown", "emily.brown@email.com", "555-0104") { CustomerId = 4, City = "Houston", Country = "USA", DateOfBirth = new DateTime(1992, 11, 30), LicenseNumber = "DL901234", CustomerType = "Regular" });
            customers.Add(new Customer("Michael", "Davis", "michael.davis@email.com", "555-0105") { CustomerId = 5, City = "Phoenix", Country = "USA", DateOfBirth = new DateTime(1988, 7, 18), LicenseNumber = "DL567890", CustomerType = "VIP" });
            
            RefreshDataGridView();
        }
        
        private void RefreshDataGridView()
        {
            dgvCustomers.Rows.Clear();
            
            foreach (var customer in customers)
            {
                dgvCustomers.Rows.Add(
                    customer.CustomerId,
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.Phone,
                    customer.City,
                    customer.Country,
                    customer.DateOfBirth,
                    customer.CustomerType,
                    customer.RegistrationDate
                );
            }
        }
        
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                RefreshDataGridView();
                return;
            }
            
            string searchTerm = txtSearch.Text.ToLower();
            string searchBy = cmbSearchBy.SelectedItem?.ToString() ?? "Name";
            
            var filteredCustomers = customers.Where(customer =>
            {
                return searchBy switch
                {
                    "Name" => customer.GetFullName().ToLower().Contains(searchTerm),
                    "Email" => customer.Email.ToLower().Contains(searchTerm),
                    "Phone" => customer.Phone.ToLower().Contains(searchTerm),
                    "City" => customer.City.ToLower().Contains(searchTerm),
                    "Customer Type" => customer.CustomerType.ToLower().Contains(searchTerm),
                    _ => false
                };
            }).ToList();
            
            dgvCustomers.Rows.Clear();
            
            foreach (var customer in filteredCustomers)
            {
                dgvCustomers.Rows.Add(
                    customer.CustomerId,
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.Phone,
                    customer.City,
                    customer.Country,
                    customer.DateOfBirth,
                    customer.CustomerType,
                    customer.RegistrationDate
                );
            }
        }
        
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
            // In a real application, you would refresh the data from the database
            RefreshDataGridView();
        }
        
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int selectedCustomerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);
            Customer? selectedCustomer = customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
            
            if (selectedCustomer != null)
            {
                // For now, we'll show a message. In a real application, you would open an edit form
                MessageBox.Show($"Edit functionality for customer: {selectedCustomer.GetCustomerInfo()}", "Edit Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int selectedCustomerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);
            Customer? selectedCustomer = customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId);
            
            if (selectedCustomer != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete this customer?\n\n{selectedCustomer.GetCustomerInfo()}",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                
                if (result == DialogResult.Yes)
                {
                    customers.Remove(selectedCustomer);
                    RefreshDataGridView();
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshDataGridView();
        }
    }
}