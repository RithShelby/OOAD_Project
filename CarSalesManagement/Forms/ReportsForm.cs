using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class ReportsForm : Form
    {
        private List<Sale> sales;
        private List<Car> cars;
        private List<Customer> customers;
        private DataGridView dgvReports;
        private ComboBox cmbReportType;
        private Button btnGenerate;
        private Button btnExport;
        private Label lblReportTitle;
        private Panel chartPanel;
        
        public ReportsForm()
        {
            InitializeComponent();
            LoadSampleData();
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Reports and Analytics";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Reports and Analytics";
            titleLabel.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 40;
            
            // Control Panel
            Panel controlPanel = new Panel();
            controlPanel.Height = 80;
            controlPanel.Dock = DockStyle.Top;
            controlPanel.Padding = new Padding(0, 20, 0, 20);
            
            Label lblReportType = new Label();
            lblReportType.Text = "Report Type:";
            lblReportType.Location = new System.Drawing.Point(20, 25);
            lblReportType.Size = new System.Drawing.Size(100, 23);
            lblReportType.Font = new System.Drawing.Font("Arial", 10);
            
            cmbReportType = new ComboBox();
            cmbReportType.Items.AddRange(new string[] { 
                "Sales Summary", 
                "Inventory Report", 
                "Customer Analysis", 
                "Sales by Period",
                "Top Selling Cars",
                "Sales Performance"
            });
            cmbReportType.SelectedIndex = 0;
            cmbReportType.Location = new System.Drawing.Point(130, 22);
            cmbReportType.Size = new System.Drawing.Size(200, 23);
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;
            
            btnGenerate = new Button();
            btnGenerate.Text = "Generate Report";
            btnGenerate.Location = new System.Drawing.Point(350, 20);
            btnGenerate.Size = new System.Drawing.Size(120, 40);
            btnGenerate.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            btnGenerate.ForeColor = System.Drawing.Color.White;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnGenerate.Click += BtnGenerate_Click;
            
            btnExport = new Button();
            btnExport.Text = "Export to Excel";
            btnExport.Location = new System.Drawing.Point(490, 20);
            btnExport.Size = new System.Drawing.Size(120, 40);
            btnExport.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnExport.Click += BtnExport_Click;
            
            controlPanel.Controls.AddRange(new Control[] { lblReportType, cmbReportType, btnGenerate, btnExport });
            
            // Report Title Label
            lblReportTitle = new Label();
            lblReportTitle.Text = "Sales Summary Report";
            lblReportTitle.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblReportTitle.Dock = DockStyle.Top;
            lblReportTitle.Height = 30;
            
            // Chart Panel
            chartPanel = new Panel();
            chartPanel.Height = 250;
            chartPanel.Dock = DockStyle.Top;
            chartPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            chartPanel.BorderStyle = BorderStyle.FixedSingle;
            chartPanel.Padding = new Padding(20);
            
            // Data Grid View
            dgvReports = new DataGridView();
            dgvReports.Dock = DockStyle.Fill;
            dgvReports.BackgroundColor = System.Drawing.Color.White;
            dgvReports.BorderStyle = BorderStyle.FixedSingle;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.ReadOnly = true;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.MultiSelect = false;
            dgvReports.RowHeadersVisible = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            mainPanel.Controls.Add(dgvReports);
            mainPanel.Controls.Add(chartPanel);
            mainPanel.Controls.Add(lblReportTitle);
            mainPanel.Controls.Add(controlPanel);
            mainPanel.Controls.Add(titleLabel);
            
            this.Controls.Add(mainPanel);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private void LoadSampleData()
        {
            // Load sample data
            cars = new List<Car>();
            cars.Add(new Car("Toyota", "Camry", 2023, 25000m, "Silver") { CarId = 1, StockQuantity = 5 });
            cars.Add(new Car("Honda", "Civic", 2023, 22000m, "Blue") { CarId = 2, StockQuantity = 3 });
            cars.Add(new Car("Tesla", "Model 3", 2023, 45000m, "Red") { CarId = 3, StockQuantity = 2 });
            cars.Add(new Car("Ford", "Mustang", 2023, 35000m, "Black") { CarId = 4, StockQuantity = 1 });
            cars.Add(new Car("BMW", "X5", 2023, 65000m, "White") { CarId = 5, StockQuantity = 4 });
            
            customers = new List<Customer>();
            customers.Add(new Customer("John", "Doe", "john.doe@email.com", "555-0101") { CustomerId = 1 });
            customers.Add(new Customer("Jane", "Smith", "jane.smith@email.com", "555-0102") { CustomerId = 2 });
            customers.Add(new Customer("Robert", "Johnson", "robert.j@company.com", "555-0103") { CustomerId = 3 });
            
            sales = new List<Sale>();
            sales.Add(new Sale(1, 1, 25000m, 1, "Cash") { SaleId = 1, SaleDate = DateTime.Now.AddDays(-30), SalesPerson = "John Smith", SaleStatus = "Completed" });
            sales.Add(new Sale(2, 2, 22000m, 1, "Credit Card") { SaleId = 2, SaleDate = DateTime.Now.AddDays(-25), SalesPerson = "Sarah Johnson", SaleStatus = "Completed" });
            sales.Add(new Sale(3, 3, 45000m, 1, "Financing") { SaleId = 3, SaleDate = DateTime.Now.AddDays(-20), SalesPerson = "Mike Wilson", SaleStatus = "Completed" });
            sales.Add(new Sale(1, 2, 25000m, 1, "Bank Transfer") { SaleId = 4, SaleDate = DateTime.Now.AddDays(-15), SalesPerson = "John Smith", SaleStatus = "Completed" });
            sales.Add(new Sale(4, 1, 35000m, 1, "Cash") { SaleId = 5, SaleDate = DateTime.Now.AddDays(-10), SalesPerson = "Sarah Johnson", SaleStatus = "Completed" });
            sales.Add(new Sale(5, 3, 65000m, 1, "Financing") { SaleId = 6, SaleDate = DateTime.Now.AddDays(-5), SalesPerson = "Mike Wilson", SaleStatus = "Completed" });
            
            // Generate initial report
            GenerateSalesSummaryReport();
        }
        
        private void CmbReportType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Sales Summary";
            lblReportTitle.Text = $"{reportType} Report";
        }
        
        private void BtnGenerate_Click(object? sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Sales Summary";
            
            switch (reportType)
            {
                case "Sales Summary":
                    GenerateSalesSummaryReport();
                    break;
                case "Inventory Report":
                    GenerateInventoryReport();
                    break;
                case "Customer Analysis":
                    GenerateCustomerAnalysisReport();
                    break;
                case "Sales by Period":
                    GenerateSalesByPeriodReport();
                    break;
                case "Top Selling Cars":
                    GenerateTopSellingCarsReport();
                    break;
                case "Sales Performance":
                    GenerateSalesPerformanceReport();
                    break;
            }
        }
        
        private void GenerateSalesSummaryReport()
        {
            dgvReports.Rows.Clear();
            dgvReports.Columns.Clear();
            
            // Add columns
            dgvReports.Columns.Add("Metric", "Metric");
            dgvReports.Columns.Add("Value", "Value");
            
            // Calculate metrics
            var completedSales = sales.Where(s => s.SaleStatus == "Completed").ToList();
            decimal totalRevenue = completedSales.Sum(s => s.TotalAmount);
            int totalTransactions = completedSales.Count;
            decimal averageSaleAmount = totalTransactions > 0 ? totalRevenue / totalTransactions : 0;
            
            // Add rows
            dgvReports.Rows.Add("Total Revenue", totalRevenue.ToString("C2"));
            dgvReports.Rows.Add("Total Transactions", totalTransactions.ToString());
            dgvReports.Rows.Add("Average Sale Amount", averageSaleAmount.ToString("C2"));
            dgvReports.Rows.Add("Total Cars Sold", completedSales.Sum(s => s.Quantity).ToString());
            dgvReports.Rows.Add("Unique Customers", completedSales.Select(s => s.CustomerId).Distinct().Count().ToString());
            
            // Create simple chart
            CreateSimpleChart("Sales Overview", new string[] { "Revenue", "Transactions" }, 
                            new decimal[] { totalRevenue, totalTransactions });
        }
        
        private void GenerateInventoryReport()
        {
            dgvReports.Rows.Clear();
            dgvReports.Columns.Clear();
            
            // Add columns
            dgvReports.Columns.Add("CarId", "Car ID");
            dgvReports.Columns.Add("Make", "Make");
            dgvReports.Columns.Add("Model", "Model");
            dgvReports.Columns.Add("Year", "Year");
            dgvReports.Columns.Add("Price", "Price");
            dgvReports.Columns.Add("Stock", "Stock");
            dgvReports.Columns.Add("StockValue", "Stock Value");
            dgvReports.Columns.Add("Status", "Status");
            
            // Format columns
            dgvReports.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvReports.Columns["StockValue"].DefaultCellStyle.Format = "C2";
            
            foreach (var car in cars)
            {
                decimal stockValue = car.Price * car.StockQuantity;
                dgvReports.Rows.Add(
                    car.CarId,
                    car.Make,
                    car.Model,
                    car.Year,
                    car.Price,
                    car.StockQuantity,
                    stockValue,
                    car.Status
                );
            }
            
            // Create chart
            var carNames = cars.Select(c => $"{c.Make} {c.Model}").ToArray();
            var stockValues = cars.Select(c => c.Price * c.StockQuantity).ToArray();
            CreateSimpleChart("Inventory Value by Car", carNames, stockValues);
        }
        
        private void GenerateCustomerAnalysisReport()
        {
            dgvReports.Rows.Clear();
            dgvReports.Columns.Clear();
            
            // Add columns
            dgvReports.Columns.Add("CustomerId", "Customer ID");
            dgvReports.Columns.Add("Name", "Name");
            dgvReports.Columns.Add("Email", "Email");
            dgvReports.Columns.Add("Phone", "Phone");
            dgvReports.Columns.Add("CustomerType", "Type");
            dgvReports.Columns.Add("TotalPurchases", "Total Purchases");
            dgvReports.Columns.Add("TotalSpent", "Total Spent");
            
            // Format columns
            dgvReports.Columns["TotalSpent"].DefaultCellStyle.Format = "C2";
            
            foreach (var customer in customers)
            {
                var customerSales = sales.Where(s => s.CustomerId == customer.CustomerId && s.SaleStatus == "Completed").ToList();
                int totalPurchases = customerSales.Count;
                decimal totalSpent = customerSales.Sum(s => s.TotalAmount);
                
                dgvReports.Rows.Add(
                    customer.CustomerId,
                    customer.GetFullName(),
                    customer.Email,
                    customer.Phone,
                    customer.CustomerType,
                    totalPurchases,
                    totalSpent
                );
            }
            
            // Create chart
            var customerNames = customers.Select(c => c.GetFullName()).ToArray();
            var customerSpending = customers.Select(c => sales.Where(s => s.CustomerId == c.CustomerId && s.SaleStatus == "Completed").Sum(s => s.TotalAmount)).ToArray();
            CreateSimpleChart("Customer Spending", customerNames, customerSpending);
        }
        
        private void GenerateSalesByPeriodReport()
        {
            dgvReports.Rows.Clear();
            dgvReports.Columns.Clear();
            
            // Add columns
            dgvReports.Columns.Add("Period", "Period");
            dgvReports.Columns.Add("SalesCount", "Sales Count");
            dgvReports.Columns.Add("Revenue", "Revenue");
            dgvReports.Columns.Add("AverageSale", "Average Sale");
            
            // Format columns
            dgvReports.Columns["Revenue"].DefaultCellStyle.Format = "C2";
            dgvReports.Columns["AverageSale"].DefaultCellStyle.Format = "C2";
            
            // Group sales by month
            var monthlySales = sales.Where(s => s.SaleStatus == "Completed")
                .GroupBy(s => new { s.SaleDate.Year, s.SaleDate.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .ToList();
            
            foreach (var month in monthlySales)
            {
                int salesCount = month.Count();
                decimal revenue = month.Sum(s => s.TotalAmount);
                decimal averageSale = salesCount > 0 ? revenue / salesCount : 0;
                
                string period = $"{month.Key.Year}-{month.Key.Month:D2}";
                dgvReports.Rows.Add(period, salesCount, revenue, averageSale);
            }
            
            // Create chart
            var periods = monthlySales.Select(m => $"{m.Key.Year}-{m.Key.Month:D2}").ToArray();
            var revenues = monthlySales.Select(m => m.Sum(s => s.TotalAmount)).ToArray();
            CreateSimpleChart("Monthly Revenue", periods, revenues);
        }
        
        private void GenerateTopSellingCarsReport()
        {
            dgvReports.Rows.Clear();
            dgvReports.Columns.Clear();
            
            // Add columns
            dgvReports.Columns.Add("Car", "Car");
            dgvReports.Columns.Add("UnitsSold", "Units Sold");
            dgvReports.Columns.Add("Revenue", "Revenue");
            dgvReports.Columns.Add("AveragePrice", "Average Price");
            
            // Format columns
            dgvReports.Columns["Revenue"].DefaultCellStyle.Format = "C2";
            dgvReports.Columns["AveragePrice"].DefaultCellStyle.Format = "C2";
            
            var carSales = sales.Where(s => s.SaleStatus == "Completed")
                .GroupBy(s => s.CarId)
                .Select(g => new
                {
                    CarId = g.Key,
                    UnitsSold = g.Sum(s => s.Quantity),
                    Revenue = g.Sum(s => s.TotalAmount),
                    AveragePrice = g.Average(s => s.SalePrice)
                })
                .OrderByDescending(x => x.UnitsSold)
                .ToList();
            
            foreach (var carSale in carSales)
            {
                var car = cars.FirstOrDefault(c => c.CarId == carSale.CarId);
                string carName = car != null ? $"{car.Year} {car.Make} {car.Model}" : $"Car ID {carSale.CarId}";
                
                dgvReports.Rows.Add(
                    carName,
                    carSale.UnitsSold,
                    carSale.Revenue,
                    carSale.AveragePrice
                );
            }
            
            // Create chart
            var carNames = carSales.Select(cs => 
            {
                var car = cars.FirstOrDefault(c => c.CarId == cs.CarId);
                return car != null ? $"{car.Make} {car.Model}" : $"Car {cs.CarId}";
            }).ToArray();
            var unitsSold = carSales.Select(cs => (decimal)cs.UnitsSold).ToArray();
            CreateSimpleChart("Units Sold by Car Model", carNames, unitsSold);
        }
        
        private void GenerateSalesPerformanceReport()
        {
            dgvReports.Rows.Clear();
            dgvReports.Columns.Clear();
            
            // Add columns
            dgvReports.Columns.Add("SalesPerson", "Sales Person");
            dgvReports.Columns.Add("SalesCount", "Sales Count");
            dgvReports.Columns.Add("TotalRevenue", "Total Revenue");
            dgvReports.Columns.Add("AverageSale", "Average Sale");
            dgvReports.Columns.Add("Commission", "Commission (5%)");
            
            // Format columns
            dgvReports.Columns["TotalRevenue"].DefaultCellStyle.Format = "C2";
            dgvReports.Columns["AverageSale"].DefaultCellStyle.Format = "C2";
            dgvReports.Columns["Commission"].DefaultCellStyle.Format = "C2";
            
            var salesPersonPerformance = sales.Where(s => s.SaleStatus == "Completed" && !string.IsNullOrEmpty(s.SalesPerson))
                .GroupBy(s => s.SalesPerson)
                .Select(g => new
                {
                    SalesPerson = g.Key,
                    SalesCount = g.Count(),
                    TotalRevenue = g.Sum(s => s.TotalAmount),
                    AverageSale = g.Average(s => s.TotalAmount),
                    Commission = g.Sum(s => s.TotalAmount) * 0.05m
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToList();
            
            foreach (var performance in salesPersonPerformance)
            {
                dgvReports.Rows.Add(
                    performance.SalesPerson,
                    performance.SalesCount,
                    performance.TotalRevenue,
                    performance.AverageSale,
                    performance.Commission
                );
            }
            
            // Create chart
            var salesPersons = salesPersonPerformance.Select(sp => sp.SalesPerson).ToArray();
            var revenues = salesPersonPerformance.Select(sp => sp.TotalRevenue).ToArray();
            CreateSimpleChart("Sales Performance by Person", salesPersons, revenues);
        }
        
        private void CreateSimpleChart(string title, string[] labels, decimal[] values)
        {
            chartPanel.Controls.Clear();
            
            Label chartTitle = new Label();
            chartTitle.Text = title;
            chartTitle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            chartTitle.Location = new System.Drawing.Point(10, 10);
            chartTitle.Size = new System.Drawing.Size(300, 20);
            
            // Create a simple bar chart using labels
            int yPos = 40;
            int maxHeight = 150;
            decimal maxValue = values.Length > 0 ? values.Max() : 1;
            
            for (int i = 0; i < Math.Min(labels.Length, 5); i++) // Show max 5 items
            {
                // Label
                Label label = new Label();
                label.Text = labels[i];
                label.Location = new System.Drawing.Point(10, yPos);
                label.Size = new System.Drawing.Size(150, 20);
                label.Font = new System.Drawing.Font("Arial", 9);
                
                // Value bar
                Panel barPanel = new Panel();
                barPanel.Location = new System.Drawing.Point(170, yPos);
                barPanel.Size = new System.Drawing.Size((int)(values[i] / maxValue * 300), 20);
                barPanel.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
                
                // Value label
                Label valueLabel = new Label();
                valueLabel.Text = values[i].ToString("N0");
                valueLabel.Location = new System.Drawing.Point(480, yPos);
                valueLabel.Size = new System.Drawing.Size(100, 20);
                valueLabel.Font = new System.Drawing.Font("Arial", 9);
                
                chartPanel.Controls.AddRange(new Control[] { label, barPanel, valueLabel });
                yPos += 30;
            }
            
            chartPanel.Controls.Add(chartTitle);
        }
        
        private void BtnExport_Click(object? sender, EventArgs e)
        {
            // Simple export functionality
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Write headers
                        for (int i = 0; i < dgvReports.Columns.Count; i++)
                        {
                            writer.Write(dgvReports.Columns[i].HeaderText);
                            if (i < dgvReports.Columns.Count - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();
                        
                        // Write data
                        for (int row = 0; row < dgvReports.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvReports.Columns.Count; col++)
                            {
                                writer.Write(dgvReports.Rows[row].Cells[col].Value?.ToString() ?? "");
                                if (col < dgvReports.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }
                    
                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}