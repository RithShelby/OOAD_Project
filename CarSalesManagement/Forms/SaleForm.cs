using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class SaleForm : Form
    {
        private List<Car> availableCars;
        private List<Customer> customers;
        
        public SaleForm()
        {
            InitializeComponent();
            LoadSampleData();
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "New Sale";
            this.Size = new System.Drawing.Size(700, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(30);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Create New Sale";
            titleLabel.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 40;
            
            // Form Fields Panel
            Panel fieldsPanel = new Panel();
            fieldsPanel.Dock = DockStyle.Fill;
            
            // Create form fields
            int yPos = 20;
            int fieldHeight = 30;
            int spacing = 15;
            
            // Car Selection
            Label lblCar = CreateLabel("Select Car:", 20, yPos);
            ComboBox cmbCars = CreateComboBox(150, yPos, 300);
            yPos += fieldHeight + spacing;
            
            // Customer Selection
            Label lblCustomer = CreateLabel("Select Customer:", 20, yPos);
            ComboBox cmbCustomers = CreateComboBox(150, yPos, 300);
            yPos += fieldHeight + spacing;
            
            // Quantity
            Label lblQuantity = CreateLabel("Quantity:", 20, yPos);
            NumericUpDown numQuantity = CreateNumericUpDown(150, yPos, 100, 1, 10);
            yPos += fieldHeight + spacing;
            
            // Sale Price
            Label lblSalePrice = CreateLabel("Sale Price ($):", 20, yPos);
            NumericUpDown numSalePrice = CreateNumericUpDown(150, yPos, 150, 0, 1000000);
            numSalePrice.DecimalPlaces = 2;
            yPos += fieldHeight + spacing;
            
            // Payment Method
            Label lblPaymentMethod = CreateLabel("Payment Method:", 20, yPos);
            ComboBox cmbPaymentMethod = CreateComboBox(150, yPos, 200);
            cmbPaymentMethod.Items.AddRange(new string[] { "Cash", "Credit Card", "Bank Transfer", "Financing" });
            cmbPaymentMethod.SelectedIndex = 0;
            yPos += fieldHeight + spacing;
            
            // Sales Person
            Label lblSalesPerson = CreateLabel("Sales Person:", 20, yPos);
            TextBox txtSalesPerson = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Notes
            Label lblNotes = CreateLabel("Notes:", 20, yPos);
            TextBox txtNotes = CreateTextBox(150, yPos, 350);
            txtNotes.Multiline = true;
            txtNotes.Height = 80;
            yPos += 80 + spacing;
            
            // Summary Panel
            Panel summaryPanel = new Panel();
            summaryPanel.Location = new System.Drawing.Point(20, yPos);
            summaryPanel.Size = new System.Drawing.Size(500, 80);
            summaryPanel.BorderStyle = BorderStyle.FixedSingle;
            summaryPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            
            Label lblSummaryTitle = new Label();
            lblSummaryTitle.Text = "Sale Summary";
            lblSummaryTitle.Location = new System.Drawing.Point(10, 5);
            lblSummaryTitle.Size = new System.Drawing.Size(100, 20);
            lblSummaryTitle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            
            Label lblTotalAmount = new Label();
            lblTotalAmount.Text = "Total Amount: $0.00";
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Location = new System.Drawing.Point(10, 30);
            lblTotalAmount.Size = new System.Drawing.Size(200, 20);
            lblTotalAmount.Font = new System.Drawing.Font("Arial", 10);
            
            summaryPanel.Controls.AddRange(new Control[] { lblSummaryTitle, lblTotalAmount });
            
            // Buttons Panel
            Panel buttonsPanel = new Panel();
            buttonsPanel.Height = 60;
            buttonsPanel.Dock = DockStyle.Bottom;
            
            Button btnSave = new Button();
            btnSave.Text = "Complete Sale";
            btnSave.Size = new System.Drawing.Size(140, 40);
            btnSave.Location = new System.Drawing.Point(180, 10);
            btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnSave.Click += (sender, e) => SaveSale(cmbCars, cmbCustomers, numQuantity, numSalePrice, cmbPaymentMethod, txtSalesPerson, txtNotes, lblTotalAmount);
            
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new System.Drawing.Size(120, 40);
            btnCancel.Location = new System.Drawing.Point(340, 10);
            btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnCancel.Click += (sender, e) => this.Close();
            
            buttonsPanel.Controls.AddRange(new Control[] { btnSave, btnCancel });
            
            // Add controls to fields panel
            fieldsPanel.Controls.AddRange(new Control[] {
                lblCar, cmbCars, lblCustomer, cmbCustomers, lblQuantity, numQuantity,
                lblSalePrice, numSalePrice, lblPaymentMethod, cmbPaymentMethod,
                lblSalesPerson, txtSalesPerson, lblNotes, txtNotes, summaryPanel
            });
            
            mainPanel.Controls.Add(fieldsPanel);
            mainPanel.Controls.Add(buttonsPanel);
            mainPanel.Controls.Add(titleLabel);
            
            this.Controls.Add(mainPanel);
            
            // Event handlers for real-time updates
            cmbCars.SelectedIndexChanged += (sender, e) => UpdateSalePrice(cmbCars, numSalePrice);
            numQuantity.ValueChanged += (sender, e) => UpdateTotalAmount(numQuantity, numSalePrice, lblTotalAmount);
            numSalePrice.ValueChanged += (sender, e) => UpdateTotalAmount(numQuantity, numSalePrice, lblTotalAmount);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private Label CreateLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(120, 23);
            label.Font = new System.Drawing.Font("Arial", 10);
            label.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            return label;
        }
        
        private TextBox CreateTextBox(int x, int y, int width)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 23);
            textBox.Font = new System.Drawing.Font("Arial", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            return textBox;
        }
        
        private NumericUpDown CreateNumericUpDown(int x, int y, int width, decimal minimum, decimal maximum)
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Location = new System.Drawing.Point(x, y);
            numericUpDown.Size = new System.Drawing.Size(width, 23);
            numericUpDown.Font = new System.Drawing.Font("Arial", 10);
            numericUpDown.Minimum = minimum;
            numericUpDown.Maximum = maximum;
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            return numericUpDown;
        }
        
        private ComboBox CreateComboBox(int x, int y, int width)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(x, y);
            comboBox.Size = new System.Drawing.Size(width, 23);
            comboBox.Font = new System.Drawing.Font("Arial", 10);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            return comboBox;
        }
        
        private void LoadSampleData()
        {
            // Load sample cars
            availableCars = new List<Car>();
            availableCars.Add(new Car("Toyota", "Camry", 2023, 25000m, "Silver") { CarId = 1, StockQuantity = 5 });
            availableCars.Add(new Car("Honda", "Civic", 2023, 22000m, "Blue") { CarId = 2, StockQuantity = 3 });
            availableCars.Add(new Car("Tesla", "Model 3", 2023, 45000m, "Red") { CarId = 3, StockQuantity = 2 });
            availableCars.Add(new Car("Ford", "Mustang", 2023, 35000m, "Black") { CarId = 4, StockQuantity = 1 });
            availableCars.Add(new Car("BMW", "X5", 2023, 65000m, "White") { CarId = 5, StockQuantity = 4 });
            
            // Load sample customers
            customers = new List<Customer>();
            customers.Add(new Customer("John", "Doe", "john.doe@email.com", "555-0101") { CustomerId = 1 });
            customers.Add(new Customer("Jane", "Smith", "jane.smith@email.com", "555-0102") { CustomerId = 2 });
            customers.Add(new Customer("Robert", "Johnson", "robert.j@company.com", "555-0103") { CustomerId = 3 });
        }
        
        private void UpdateSalePrice(ComboBox cmbCars, NumericUpDown numSalePrice)
        {
            if (cmbCars.SelectedItem != null)
            {
                string selectedCarText = cmbCars.SelectedItem.ToString();
                var selectedCar = availableCars.FirstOrDefault(c => selectedCarText.Contains($"{c.Make} {c.Model}"));
                if (selectedCar != null)
                {
                    numSalePrice.Value = selectedCar.Price;
                }
            }
        }
        
        private void UpdateTotalAmount(NumericUpDown numQuantity, NumericUpDown numSalePrice, Label lblTotalAmount)
        {
            decimal total = numQuantity.Value * numSalePrice.Value;
            lblTotalAmount.Text = $"Total Amount: {total:C2}";
        }
        
        private void SaveSale(ComboBox cmbCars, ComboBox cmbCustomers, NumericUpDown numQuantity, 
                            NumericUpDown numSalePrice, ComboBox cmbPaymentMethod, TextBox txtSalesPerson, 
                            TextBox txtNotes, Label lblTotalAmount)
        {
            // Validation
            if (cmbCars.SelectedItem == null)
            {
                MessageBox.Show("Please select a car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCars.Focus();
                return;
            }
            
            if (cmbCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCustomers.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtSalesPerson.Text))
            {
                MessageBox.Show("Please enter the sales person name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalesPerson.Focus();
                return;
            }
            
            try
            {
                // Get selected car and customer
                string selectedCarText = cmbCars.SelectedItem.ToString();
                var selectedCar = availableCars.FirstOrDefault(c => selectedCarText.Contains($"{c.Make} {c.Model}"));
                
                string selectedCustomerText = cmbCustomers.SelectedItem.ToString();
                var selectedCustomer = customers.FirstOrDefault(c => selectedCustomerText.Contains($"{c.FirstName} {c.LastName}"));
                
                if (selectedCar != null && selectedCustomer != null)
                {
                    // Check if enough stock is available
                    if (selectedCar.StockQuantity < (int)numQuantity.Value)
                    {
                        MessageBox.Show($"Not enough stock available. Only {selectedCar.StockQuantity} units in stock.", 
                                      "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    // Create new sale object
                    Sale newSale = new Sale();
                    newSale.CarId = selectedCar.CarId;
                    newSale.CustomerId = selectedCustomer.CustomerId;
                    newSale.SalePrice = numSalePrice.Value;
                    newSale.Quantity = (int)numQuantity.Value;
                    newSale.PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";
                    newSale.SalesPerson = txtSalesPerson.Text.Trim();
                    newSale.Notes = txtNotes.Text.Trim();
                    newSale.CalculateTotalAmount();
                    
                    // Update car stock
                    selectedCar.SellCar((int)numQuantity.Value);
                    
                    // Complete the sale
                    newSale.CompleteSale();
                    
                    // Show success message
                    MessageBox.Show($"Sale completed successfully!\n\n" +
                                  $"Car: {selectedCar.GetCarInfo()}\n" +
                                  $"Customer: {selectedCustomer.GetFullName()}\n" +
                                  $"Quantity: {newSale.Quantity}\n" +
                                  $"Total Amount: {newSale.TotalAmount:C2}\n" +
                                  $"Payment Method: {newSale.PaymentMethod}\n" +
                                  $"Sales Person: {newSale.SalesPerson}", 
                                  "Sale Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the sale: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Override OnLoad to populate combo boxes
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Populate cars combo box
            var cmbCars = this.Controls.Find("cmbCars", true).FirstOrDefault() as ComboBox;
            if (cmbCars != null)
            {
                foreach (var car in availableCars.Where(c => c.IsAvailable()))
                {
                    cmbCars.Items.Add($"{car.Make} {car.Model} ({car.Year}) - ${car.Price:N0} - Stock: {car.StockQuantity}");
                }
                if (cmbCars.Items.Count > 0)
                    cmbCars.SelectedIndex = 0;
            }
            
            // Populate customers combo box
            var cmbCustomers = this.Controls.Find("cmbCustomers", true).FirstOrDefault() as ComboBox;
            if (cmbCustomers != null)
            {
                foreach (var customer in customers)
                {
                    cmbCustomers.Items.Add($"{customer.GetFullName()} - {customer.Email}");
                }
                if (cmbCustomers.Items.Count > 0)
                    cmbCustomers.SelectedIndex = 0;
            }
        }
    }
}