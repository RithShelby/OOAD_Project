using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class SalesManagementForm : Form
    {
        private List<Sale> sales;
        private List<Car> cars;
        private List<Customer> customers;
        private DataGridView dgvSales;
        private TextBox txtSearch;
        private ComboBox cmbSearchBy;
        private Button btnSearch;
        private Button btnNewSale;
        private Button btnViewDetails;
        private Button btnCancelSale;
        private Button btnRefresh;
        
        public SalesManagementForm()
        {
            InitializeComponent();
            LoadSampleData();
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Sales Management";
            this.Size = new System.Drawing.Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Sales Management";
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
            cmbSearchBy.Items.AddRange(new string[] { "Sale ID", "Customer", "Car", "Sales Person", "Status", "Payment Method" });
            cmbSearchBy.SelectedIndex = 0;
            cmbSearchBy.Location = new System.Drawing.Point(80, 12);
            cmbSearchBy.Size = new System.Drawing.Size(140, 23);
            cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            
            txtSearch = new TextBox();
            txtSearch.Location = new System.Drawing.Point(230, 12);
            txtSearch.Size = new System.Drawing.Size(200, 23);
            txtSearch.Font = new System.Drawing.Font("Arial", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            
            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(440, 10);
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
            
            btnNewSale = new Button();
            btnNewSale.Text = "New Sale";
            btnNewSale.Location = new System.Drawing.Point(20, 10);
            btnNewSale.Size = new System.Drawing.Size(100, 40);
            btnNewSale.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnNewSale.ForeColor = System.Drawing.Color.White;
            btnNewSale.FlatStyle = FlatStyle.Flat;
            btnNewSale.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnNewSale.Click += BtnNewSale_Click;
            
            btnViewDetails = new Button();
            btnViewDetails.Text = "View Details";
            btnViewDetails.Location = new System.Drawing.Point(140, 10);
            btnViewDetails.Size = new System.Drawing.Size(120, 40);
            btnViewDetails.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            btnViewDetails.ForeColor = System.Drawing.Color.White;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnViewDetails.Click += BtnViewDetails_Click;
            
            btnCancelSale = new Button();
            btnCancelSale.Text = "Cancel Sale";
            btnCancelSale.Location = new System.Drawing.Point(280, 10);
            btnCancelSale.Size = new System.Drawing.Size(120, 40);
            btnCancelSale.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            btnCancelSale.ForeColor = System.Drawing.Color.Black;
            btnCancelSale.FlatStyle = FlatStyle.Flat;
            btnCancelSale.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnCancelSale.Click += BtnCancelSale_Click;
            
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new System.Drawing.Point(420, 10);
            btnRefresh.Size = new System.Drawing.Size(100, 40);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnRefresh.Click += BtnRefresh_Click;
            
            buttonsPanel.Controls.AddRange(new Control[] { btnNewSale, btnViewDetails, btnCancelSale, btnRefresh });
            
            // Summary Panel
            Panel summaryPanel = new Panel();
            summaryPanel.Height = 80;
            summaryPanel.Dock = DockStyle.Top;
            summaryPanel.Padding = new Padding(10);
            summaryPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            
            Label lblSummaryTitle = new Label();
            lblSummaryTitle.Text = "Sales Summary";
            lblSummaryTitle.Location = new System.Drawing.Point(10, 5);
            lblSummaryTitle.Size = new System.Drawing.Size(150, 20);
            lblSummaryTitle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            
            Label lblTotalSales = new Label();
            lblTotalSales.Text = "Total Sales: $0";
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Location = new System.Drawing.Point(10, 30);
            lblTotalSales.Size = new System.Drawing.Size(200, 20);
            lblTotalSales.Font = new System.Drawing.Font("Arial", 10);
            
            Label lblTotalTransactions = new Label();
            lblTotalTransactions.Text = "Total Transactions: 0";
            lblTotalTransactions.Name = "lblTotalTransactions";
            lblTotalTransactions.Location = new System.Drawing.Point(250, 30);
            lblTotalTransactions.Size = new System.Drawing.Size(200, 20);
            lblTotalTransactions.Font = new System.Drawing.Font("Arial", 10);
            
            summaryPanel.Controls.AddRange(new Control[] { lblSummaryTitle, lblTotalSales, lblTotalTransactions });
            
            // Data Grid View
            dgvSales = new DataGridView();
            dgvSales.Dock = DockStyle.Fill;
            dgvSales.BackgroundColor = System.Drawing.Color.White;
            dgvSales.BorderStyle = BorderStyle.FixedSingle;
            dgvSales.AllowUserToAddRows = false;
            dgvSales.AllowUserToDeleteRows = false;
            dgvSales.ReadOnly = true;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.MultiSelect = false;
            dgvSales.RowHeadersVisible = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Add columns to DataGridView
            dgvSales.Columns.Add("SaleId", "Sale ID");
            dgvSales.Columns.Add("CarInfo", "Car");
            dgvSales.Columns.Add("CustomerInfo", "Customer");
            dgvSales.Columns.Add("SaleDate", "Sale Date");
            dgvSales.Columns.Add("Quantity", "Quantity");
            dgvSales.Columns.Add("TotalAmount", "Total Amount");
            dgvSales.Columns.Add("PaymentMethod", "Payment");
            dgvSales.Columns.Add("SalesPerson", "Sales Person");
            dgvSales.Columns.Add("SaleStatus", "Status");
            
            // Format columns
            dgvSales.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            dgvSales.Columns["SaleDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            
            mainPanel.Controls.Add(dgvSales);
            mainPanel.Controls.Add(summaryPanel);
            mainPanel.Controls.Add(buttonsPanel);
            mainPanel.Controls.Add(searchPanel);
            mainPanel.Controls.Add(titleLabel);
            
            this.Controls.Add(mainPanel);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private void LoadSampleData()
        {
            // Load sample data
            cars = new List<Car>();
            cars.Add(new Car("Toyota", "Camry", 2023, 25000m, "Silver") { CarId = 1 });
            cars.Add(new Car("Honda", "Civic", 2023, 22000m, "Blue") { CarId = 2 });
            cars.Add(new Car("Tesla", "Model 3", 2023, 45000m, "Red") { CarId = 3 });
            
            customers = new List<Customer>();
            customers.Add(new Customer("John", "Doe", "john.doe@email.com", "555-0101") { CustomerId = 1 });
            customers.Add(new Customer("Jane", "Smith", "jane.smith@email.com", "555-0102") { CustomerId = 2 });
            customers.Add(new Customer("Robert", "Johnson", "robert.j@company.com", "555-0103") { CustomerId = 3 });
            
            sales = new List<Sale>();
            sales.Add(new Sale(1, 1, 25000m, 1, "Cash") { SaleId = 1, SaleDate = DateTime.Now.AddDays(-5), SalesPerson = "John Smith", SaleStatus = "Completed" });
            sales.Add(new Sale(2, 2, 22000m, 1, "Credit Card") { SaleId = 2, SaleDate = DateTime.Now.AddDays(-3), SalesPerson = "Sarah Johnson", SaleStatus = "Completed" });
            sales.Add(new Sale(3, 3, 45000m, 1, "Financing") { SaleId = 3, SaleDate = DateTime.Now.AddDays(-1), SalesPerson = "Mike Wilson", SaleStatus = "Pending" });
            
            RefreshDataGridView();
            UpdateSummary();
        }
        
        private void RefreshDataGridView()
        {
            dgvSales.Rows.Clear();
            
            foreach (var sale in sales)
            {
                var car = cars.FirstOrDefault(c => c.CarId == sale.CarId);
                var customer = customers.FirstOrDefault(c => c.CustomerId == sale.CustomerId);
                
                string carInfo = car != null ? $"{car.Year} {car.Make} {car.Model}" : "Unknown Car";
                string customerInfo = customer != null ? customer.GetFullName() : "Unknown Customer";
                
                dgvSales.Rows.Add(
                    sale.SaleId,
                    carInfo,
                    customerInfo,
                    sale.SaleDate,
                    sale.Quantity,
                    sale.TotalAmount,
                    sale.PaymentMethod,
                    sale.SalesPerson,
                    sale.SaleStatus
                );
            }
        }
        
        private void UpdateSummary()
        {
            var lblTotalSales = this.Controls.Find("lblTotalSales", true).FirstOrDefault() as Label;
            var lblTotalTransactions = this.Controls.Find("lblTotalTransactions", true).FirstOrDefault() as Label;
            
            if (lblTotalSales != null && lblTotalTransactions != null)
            {
                decimal totalSales = sales.Where(s => s.SaleStatus == "Completed").Sum(s => s.TotalAmount);
                int totalTransactions = sales.Where(s => s.SaleStatus == "Completed").Count();
                
                lblTotalSales.Text = $"Total Sales: {totalSales:C2}";
                lblTotalTransactions.Text = $"Total Transactions: {totalTransactions}";
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
            string searchBy = cmbSearchBy.SelectedItem?.ToString() ?? "Sale ID";
            
            var filteredSales = sales.Where(sale =>
            {
                var car = cars.FirstOrDefault(c => c.CarId == sale.CarId);
                var customer = customers.FirstOrDefault(c => c.CustomerId == sale.CustomerId);
                
                return searchBy switch
                {
                    "Sale ID" => sale.SaleId.ToString().Contains(searchTerm),
                    "Customer" => customer?.GetFullName().ToLower().Contains(searchTerm) ?? false,
                    "Car" => car != null ? $"{car.Make} {car.Model}".ToLower().Contains(searchTerm) : false,
                    "Sales Person" => sale.SalesPerson?.ToLower().Contains(searchTerm) ?? false,
                    "Status" => sale.SaleStatus.ToLower().Contains(searchTerm),
                    "Payment Method" => sale.PaymentMethod.ToLower().Contains(searchTerm),
                    _ => false
                };
            }).ToList();
            
            dgvSales.Rows.Clear();
            
            foreach (var sale in filteredSales)
            {
                var car = cars.FirstOrDefault(c => c.CarId == sale.CarId);
                var customer = customers.FirstOrDefault(c => c.CustomerId == sale.CustomerId);
                
                string carInfo = car != null ? $"{car.Year} {car.Make} {car.Model}" : "Unknown Car";
                string customerInfo = customer != null ? customer.GetFullName() : "Unknown Customer";
                
                dgvSales.Rows.Add(
                    sale.SaleId,
                    carInfo,
                    customerInfo,
                    sale.SaleDate,
                    sale.Quantity,
                    sale.TotalAmount,
                    sale.PaymentMethod,
                    sale.SalesPerson,
                    sale.SaleStatus
                );
            }
        }
        
        private void BtnNewSale_Click(object? sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm();
            saleForm.ShowDialog();
            // In a real application, you would refresh the data from the database
            RefreshDataGridView();
            UpdateSummary();
        }
        
        private void BtnViewDetails_Click(object? sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a sale to view details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int selectedSaleId = Convert.ToInt32(dgvSales.SelectedRows[0].Cells["SaleId"].Value);
            Sale? selectedSale = sales.FirstOrDefault(s => s.SaleId == selectedSaleId);
            
            if (selectedSale != null)
            {
                var car = cars.FirstOrDefault(c => c.CarId == selectedSale.CarId);
                var customer = customers.FirstOrDefault(c => c.CustomerId == selectedSale.CustomerId);
                
                string details = $"Sale Details\n\n" +
                               $"Sale ID: {selectedSale.SaleId}\n" +
                               $"Sale Date: {selectedSale.SaleDate:yyyy-MM-dd HH:mm}\n" +
                               $"Car: {car?.Year} {car?.Make} {car?.Model}\n" +
                               $"Customer: {customer?.GetFullName()}\n" +
                               $"Quantity: {selectedSale.Quantity}\n" +
                               $"Unit Price: {selectedSale.SalePrice:C2}\n" +
                               $"Total Amount: {selectedSale.TotalAmount:C2}\n" +
                               $"Payment Method: {selectedSale.PaymentMethod}\n" +
                               $"Sales Person: {selectedSale.SalesPerson}\n" +
                               $"Status: {selectedSale.SaleStatus}\n" +
                               $"Notes: {selectedSale.Notes ?? "N/A"}";
                
                MessageBox.Show(details, "Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void BtnCancelSale_Click(object? sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a sale to cancel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int selectedSaleId = Convert.ToInt32(dgvSales.SelectedRows[0].Cells["SaleId"].Value);
            Sale? selectedSale = sales.FirstOrDefault(s => s.SaleId == selectedSaleId);
            
            if (selectedSale != null)
            {
                if (selectedSale.SaleStatus == "Completed")
                {
                    MessageBox.Show("Cannot cancel a completed sale.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to cancel this sale?\n\nSale ID: {selectedSale.SaleId}\nTotal Amount: {selectedSale.TotalAmount:C2}",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                
                if (result == DialogResult.Yes)
                {
                    selectedSale.CancelSale();
                    RefreshDataGridView();
                    UpdateSummary();
                    MessageBox.Show("Sale cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshDataGridView();
            UpdateSummary();
        }
    }
}