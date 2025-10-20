using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class CarManagementForm : Form
    {
        private List<Car> cars;
        private DataGridView dgvCars;
        private TextBox txtSearch;
        private ComboBox cmbSearchBy;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        
        public CarManagementForm()
        {
            InitializeComponent();
            LoadSampleData();
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Car Management";
            this.Size = new System.Drawing.Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Car Management";
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
            cmbSearchBy.Items.AddRange(new string[] { "Make", "Model", "Year", "Price", "Color", "Status" });
            cmbSearchBy.SelectedIndex = 0;
            cmbSearchBy.Location = new System.Drawing.Point(80, 12);
            cmbSearchBy.Size = new System.Drawing.Size(100, 23);
            cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            
            txtSearch = new TextBox();
            txtSearch.Location = new System.Drawing.Point(190, 12);
            txtSearch.Size = new System.Drawing.Size(200, 23);
            txtSearch.Font = new System.Drawing.Font("Arial", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            
            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(400, 10);
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
            btnAdd.Text = "Add Car";
            btnAdd.Location = new System.Drawing.Point(20, 10);
            btnAdd.Size = new System.Drawing.Size(100, 40);
            btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnAdd.Click += BtnAdd_Click;
            
            btnEdit = new Button();
            btnEdit.Text = "Edit Car";
            btnEdit.Location = new System.Drawing.Point(140, 10);
            btnEdit.Size = new System.Drawing.Size(100, 40);
            btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            btnEdit.ForeColor = System.Drawing.Color.Black;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnEdit.Click += BtnEdit_Click;
            
            btnDelete = new Button();
            btnDelete.Text = "Delete Car";
            btnDelete.Location = new System.Drawing.Point(260, 10);
            btnDelete.Size = new System.Drawing.Size(100, 40);
            btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnDelete.Click += BtnDelete_Click;
            
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new System.Drawing.Point(380, 10);
            btnRefresh.Size = new System.Drawing.Size(100, 40);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnRefresh.Click += BtnRefresh_Click;
            
            buttonsPanel.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete, btnRefresh });
            
            // Data Grid View
            dgvCars = new DataGridView();
            dgvCars.Dock = DockStyle.Fill;
            dgvCars.BackgroundColor = System.Drawing.Color.White;
            dgvCars.BorderStyle = BorderStyle.FixedSingle;
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.ReadOnly = true;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.MultiSelect = false;
            dgvCars.RowHeadersVisible = false;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Add columns to DataGridView
            dgvCars.Columns.Add("CarId", "ID");
            dgvCars.Columns.Add("Make", "Make");
            dgvCars.Columns.Add("Model", "Model");
            dgvCars.Columns.Add("Year", "Year");
            dgvCars.Columns.Add("Price", "Price");
            dgvCars.Columns.Add("Color", "Color");
            dgvCars.Columns.Add("EngineType", "Engine");
            dgvCars.Columns.Add("Transmission", "Transmission");
            dgvCars.Columns.Add("StockQuantity", "Stock");
            dgvCars.Columns.Add("Status", "Status");
            
            // Format Price column
            dgvCars.Columns["Price"].DefaultCellStyle.Format = "C2";
            
            mainPanel.Controls.Add(dgvCars);
            mainPanel.Controls.Add(buttonsPanel);
            mainPanel.Controls.Add(searchPanel);
            mainPanel.Controls.Add(titleLabel);
            
            this.Controls.Add(mainPanel);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private void LoadSampleData()
        {
            cars = new List<Car>();
            
            // Add sample cars
            cars.Add(new Car("Toyota", "Camry", 2023, 25000m, "Silver") { CarId = 1, EngineType = "Gasoline", Transmission = "Automatic", StockQuantity = 5 });
            cars.Add(new Car("Honda", "Civic", 2023, 22000m, "Blue") { CarId = 2, EngineType = "Gasoline", Transmission = "CVT", StockQuantity = 3 });
            cars.Add(new Car("Tesla", "Model 3", 2023, 45000m, "Red") { CarId = 3, EngineType = "Electric", Transmission = "Automatic", StockQuantity = 2 });
            cars.Add(new Car("Ford", "Mustang", 2023, 35000m, "Black") { CarId = 4, EngineType = "Gasoline", Transmission = "Manual", StockQuantity = 1 });
            cars.Add(new Car("BMW", "X5", 2023, 65000m, "White") { CarId = 5, EngineType = "Gasoline", Transmission = "Automatic", StockQuantity = 4 });
            
            RefreshDataGridView();
        }
        
        private void RefreshDataGridView()
        {
            dgvCars.Rows.Clear();
            
            foreach (var car in cars)
            {
                dgvCars.Rows.Add(
                    car.CarId,
                    car.Make,
                    car.Model,
                    car.Year,
                    car.Price,
                    car.Color,
                    car.EngineType,
                    car.Transmission,
                    car.StockQuantity,
                    car.Status
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
            string searchBy = cmbSearchBy.SelectedItem?.ToString() ?? "Make";
            
            var filteredCars = cars.Where(car =>
            {
                return searchBy switch
                {
                    "Make" => car.Make.ToLower().Contains(searchTerm),
                    "Model" => car.Model.ToLower().Contains(searchTerm),
                    "Year" => car.Year.ToString().Contains(searchTerm),
                    "Price" => car.Price.ToString().Contains(searchTerm),
                    "Color" => car.Color.ToLower().Contains(searchTerm),
                    "Status" => car.Status.ToLower().Contains(searchTerm),
                    _ => false
                };
            }).ToList();
            
            dgvCars.Rows.Clear();
            
            foreach (var car in filteredCars)
            {
                dgvCars.Rows.Add(
                    car.CarId,
                    car.Make,
                    car.Model,
                    car.Year,
                    car.Price,
                    car.Color,
                    car.EngineType,
                    car.Transmission,
                    car.StockQuantity,
                    car.Status
                );
            }
        }
        
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            CarForm carForm = new CarForm();
            carForm.ShowDialog();
            // In a real application, you would refresh the data from the database
            RefreshDataGridView();
        }
        
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int selectedCarId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["CarId"].Value);
            Car? selectedCar = cars.FirstOrDefault(c => c.CarId == selectedCarId);
            
            if (selectedCar != null)
            {
                // For now, we'll show a message. In a real application, you would open an edit form
                MessageBox.Show($"Edit functionality for car: {selectedCar.GetCarInfo()}", "Edit Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int selectedCarId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["CarId"].Value);
            Car? selectedCar = cars.FirstOrDefault(c => c.CarId == selectedCarId);
            
            if (selectedCar != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete this car?\n\n{selectedCar.GetCarInfo()}",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                
                if (result == DialogResult.Yes)
                {
                    cars.Remove(selectedCar);
                    RefreshDataGridView();
                    MessageBox.Show("Car deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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