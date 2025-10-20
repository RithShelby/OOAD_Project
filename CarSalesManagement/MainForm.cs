using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarSalesManagement.Data;
using CarSalesManagement.Models;
using CarSalesManagement.Forms;

namespace CarSalesManagement
{
    public partial class MainForm : Form
    {
        private CarSalesContext context = CarSalesContext.Instance;

        public MainForm()
        {
            InitializeComponent();
            LoadCars();
            LoadStatistics();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Car Sales Management System - Main Dashboarddd";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;

            // Main menu
            var menuStrip = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("File");
            var exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += (s, e) => Application.Exit();
            fileMenu.DropDownItems.Add(exitItem);
            menuStrip.Items.Add(fileMenu);

            var managementMenu = new ToolStripMenuItem("Management");
            var salesItem = new ToolStripMenuItem("Sales Management");
            salesItem.Click += (s, e) => OpenSalesForm();
            var customersItem = new ToolStripMenuItem("Customer Management");
            customersItem.Click += (s, e) => OpenCustomersForm();
            managementMenu.DropDownItems.AddRange(new ToolStripItem[] { salesItem, customersItem });
            menuStrip.Items.Add(managementMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Title label
            var titleLabel = new Label();
            titleLabel.Text = "Car Sales Management System";
            titleLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            titleLabel.ForeColor = Color.DarkBlue;
            titleLabel.Location = new Point(350, 50);
            titleLabel.Size = new Size(500, 40);
            this.Controls.Add(titleLabel);

            // Statistics panel
            var statsPanel = new Panel();
            statsPanel.Location = new Point(50, 120);
            statsPanel.Size = new Size(1100, 100);
            statsPanel.BackColor = Color.White;
            statsPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(statsPanel);

            var totalCarsLabel = new Label();
            totalCarsLabel.Text = "Total Cars: 0";
            totalCarsLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            totalCarsLabel.Location = new Point(50, 20);
            totalCarsLabel.Size = new Size(200, 30);
            statsPanel.Controls.Add(totalCarsLabel);

            var totalCustomersLabel = new Label();
            totalCustomersLabel.Text = "Total Customers: 0";
            totalCustomersLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            totalCustomersLabel.Location = new Point(300, 20);
            totalCustomersLabel.Size = new Size(200, 30);
            statsPanel.Controls.Add(totalCustomersLabel);

            var totalSalesLabel = new Label();
            totalSalesLabel.Text = "Total Sales: 0";
            totalSalesLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            totalSalesLabel.Location = new Point(550, 20);
            totalSalesLabel.Size = new Size(200, 30);
            statsPanel.Controls.Add(totalSalesLabel);

            var revenueLabel = new Label();
            revenueLabel.Text = "Total Revenue: $0";
            revenueLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            revenueLabel.Location = new Point(800, 20);
            revenueLabel.Size = new Size(250, 30);
            statsPanel.Controls.Add(revenueLabel);

            // Car management section
            var carPanel = new Panel();
            carPanel.Location = new Point(50, 240);
            carPanel.Size = new Size(1100, 500);
            carPanel.BackColor = Color.White;
            carPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(carPanel);

            var carTitleLabel = new Label();
            carTitleLabel.Text = "Car Inventory Management";
            carTitleLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            carTitleLabel.Location = new Point(20, 10);
            carTitleLabel.Size = new Size(300, 30);
            carPanel.Controls.Add(carTitleLabel);

            // Search box
            var searchLabel = new Label();
            searchLabel.Text = "Search:";
            searchLabel.Location = new Point(20, 50);
            searchLabel.Size = new Size(60, 23);
            carPanel.Controls.Add(searchLabel);

            var searchTextBox = new TextBox();
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Location = new Point(90, 50);
            searchTextBox.Size = new Size(200, 23);
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            carPanel.Controls.Add(searchTextBox);

            // Buttons
            var addButton = new Button();
            addButton.Text = "Add Car";
            addButton.Location = new Point(320, 48);
            addButton.Size = new Size(100, 30);
            addButton.BackColor = Color.LightGreen;
            addButton.Click += AddButton_Click;
            carPanel.Controls.Add(addButton);

            var editButton = new Button();
            editButton.Text = "Edit Car";
            editButton.Location = new Point(430, 48);
            editButton.Size = new Size(100, 30);
            editButton.BackColor = Color.LightYellow;
            editButton.Click += EditButton_Click;
            carPanel.Controls.Add(editButton);

            var deleteButton = new Button();
            deleteButton.Text = "Delete Car";
            deleteButton.Location = new Point(540, 48);
            deleteButton.Size = new Size(100, 30);
            deleteButton.BackColor = Color.LightCoral;
            deleteButton.Click += DeleteButton_Click;
            carPanel.Controls.Add(deleteButton);

            var refreshButton = new Button();
            refreshButton.Text = "Refresh";
            refreshButton.Location = new Point(650, 48);
            refreshButton.Size = new Size(100, 30);
            refreshButton.BackColor = Color.LightBlue;
            refreshButton.Click += (s, e) => LoadCars();
            carPanel.Controls.Add(refreshButton);

            // DataGridView for cars
            var carsDataGridView = new DataGridView();
            carsDataGridView.Name = "carsDataGridView";
            carsDataGridView.Location = new Point(20, 90);
            carsDataGridView.Size = new Size(1050, 380);
            carsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            carsDataGridView.ReadOnly = true;
            carsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            carsDataGridView.MultiSelect = false;
            carPanel.Controls.Add(carsDataGridView);

            // Store controls for later access
            this.totalCarsLabel = totalCarsLabel;
            this.totalCustomersLabel = totalCustomersLabel;
            this.totalSalesLabel = totalSalesLabel;
            this.revenueLabel = revenueLabel;
            this.carsDataGridView = carsDataGridView;

            this.ResumeLayout(false);
        }

        private Label totalCarsLabel;
        private Label totalCustomersLabel;
        private Label totalSalesLabel;
        private Label revenueLabel;
        private DataGridView carsDataGridView;

        private void LoadCars()
        {
            var cars = context.Cars.ToList();
            carsDataGridView.DataSource = null;
            carsDataGridView.DataSource = cars.Select(c => new
            {
                ID = c.CarId,
                Make = c.Make,
                Model = c.Model,
                Year = c.Year,
                Price = $"${c.Price:N0}",
                Color = c.Color,
                Engine = c.EngineType,
                Transmission = c.Transmission,
                Stock = c.StockQuantity,
                Available = c.IsAvailable() ? "Yes" : "No"
            }).ToList();
        }

        private void LoadStatistics()
        {
            totalCarsLabel.Text = $"Total Cars: {context.Cars.Count}";
            totalCustomersLabel.Text = $"Total Customers: {context.Customers.Count}";
            totalSalesLabel.Text = $"Total Sales: {context.Sales.Count}";
            
            var totalRevenue = context.Sales.Where(s => s.SaleStatus == "Completed").Sum(s => s.TotalAmount);
            revenueLabel.Text = $"Total Revenue: ${totalRevenue:N0}";
        }

        private void SearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var searchTerm = textBox.Text.ToLower();
                var filteredCars = context.Cars
                    .Where(c => c.Make.ToLower().Contains(searchTerm) || 
                               c.Model.ToLower().Contains(searchTerm) ||
                               c.Color.ToLower().Contains(searchTerm))
                    .ToList();

                carsDataGridView.DataSource = null;
                carsDataGridView.DataSource = filteredCars.Select(c => new
                {
                    ID = c.CarId,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Price = $"${c.Price:N0}",
                    Color = c.Color,
                    Engine = c.EngineType,
                    Transmission = c.Transmission,
                    Stock = c.StockQuantity,
                    Available = c.IsAvailable() ? "Yes" : "No"
                }).ToList();
            }
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            var carForm = new CarForm();
            if (carForm.ShowDialog() == DialogResult.OK)
            {
                context.AddCar(carForm.CurrentCar);
                LoadCars();
                LoadStatistics();
                MessageBox.Show("Car added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditButton_Click(object? sender, EventArgs e)
        {
            if (carsDataGridView.SelectedRows.Count > 0)
            {
                var carId = Convert.ToInt32(carsDataGridView.SelectedRows[0].Cells["ID"].Value);
                var car = context.Cars.FirstOrDefault(c => c.CarId == carId);
                if (car != null)
                {
                    var carForm = new CarForm(car);
                    if (carForm.ShowDialog() == DialogResult.OK)
                    {
                        context.UpdateCar(carForm.CurrentCar);
                        LoadCars();
                        MessageBox.Show("Car updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (carsDataGridView.SelectedRows.Count > 0)
            {
                var carId = Convert.ToInt32(carsDataGridView.SelectedRows[0].Cells["ID"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    context.DeleteCar(carId);
                    LoadCars();
                    LoadStatistics();
                    MessageBox.Show("Car deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a car to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenSalesForm()
        {
            var salesForm = new SalesManagementForm();
            salesForm.ShowDialog();
            LoadStatistics();
        }

        private void OpenCustomersForm()
        {
            var customersForm = new CustomerManagementForm();
            customersForm.ShowDialog();
            LoadStatistics();
        }
    }
}