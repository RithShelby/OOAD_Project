using System;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class CarForm : Form
    {
        public Car CurrentCar { get; private set; }

        public CarForm()
        {
            InitializeComponent();
            CurrentCar = new Car();
        }

        public CarForm(Car car)
        {
            InitializeComponent();
            CurrentCar = car;
            LoadCarData();
        }

        private void LoadCarData()
        {
            // This is a bit tricky since we don't have direct access to the controls
            // by name. We'll have to find them.
            var txtMake = this.Controls.Find("txtMake", true).FirstOrDefault() as TextBox;
            var txtModel = this.Controls.Find("txtModel", true).FirstOrDefault() as TextBox;
            var numYear = this.Controls.Find("numYear", true).FirstOrDefault() as NumericUpDown;
            var numPrice = this.Controls.Find("numPrice", true).FirstOrDefault() as NumericUpDown;
            var txtColor = this.Controls.Find("txtColor", true).FirstOrDefault() as TextBox;
            var cmbEngine = this.Controls.Find("cmbEngine", true).FirstOrDefault() as ComboBox;
            var cmbTransmission = this.Controls.Find("cmbTransmission", true).FirstOrDefault() as ComboBox;
            var numStock = this.Controls.Find("numStock", true).FirstOrDefault() as NumericUpDown;
            var txtDescription = this.Controls.Find("txtDescription", true).FirstOrDefault() as TextBox;

            if (txtMake != null) txtMake.Text = CurrentCar.Make;
            if (txtModel != null) txtModel.Text = CurrentCar.Model;
            if (numYear != null) numYear.Value = CurrentCar.Year;
            if (numPrice != null) numPrice.Value = CurrentCar.Price;
            if (txtColor != null) txtColor.Text = CurrentCar.Color;
            if (cmbEngine != null) cmbEngine.SelectedItem = CurrentCar.EngineType;
            if (cmbTransmission != null) cmbTransmission.SelectedItem = CurrentCar.Transmission;
            if (numStock != null) numStock.Value = CurrentCar.StockQuantity;
            if (txtDescription != null) txtDescription.Text = CurrentCar.Description;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Add New Car";
            this.Size = new System.Drawing.Size(600, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(30);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Add New Car";
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
            
            // Make Field
            Label lblMake = CreateLabel("Make:", 20, yPos);
            TextBox txtMake = CreateTextBox("txtMake", 150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Model Field
            Label lblModel = CreateLabel("Model:", 20, yPos);
            TextBox txtModel = CreateTextBox("txtModel", 150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Year Field
            Label lblYear = CreateLabel("Year:", 20, yPos);
            NumericUpDown numYear = CreateNumericUpDown("numYear", 150, yPos, 100, 1900, DateTime.Now.Year + 1);
            yPos += fieldHeight + spacing;
            
            // Price Field
            Label lblPrice = CreateLabel("Price ($):", 20, yPos);
            NumericUpDown numPrice = CreateNumericUpDown("numPrice", 150, yPos, 150, 0, 1000000);
            numPrice.DecimalPlaces = 2;
            yPos += fieldHeight + spacing;
            
            // Color Field
            Label lblColor = CreateLabel("Color:", 20, yPos);
            TextBox txtColor = CreateTextBox("txtColor", 150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Engine Type Field
            Label lblEngine = CreateLabel("Engine Type:", 20, yPos);
            ComboBox cmbEngine = CreateComboBox("cmbEngine", 150, yPos, 200);
            cmbEngine.Items.AddRange(new string[] { "Gasoline", "Diesel", "Hybrid", "Electric", "Plug-in Hybrid" });
            cmbEngine.SelectedIndex = 0;
            yPos += fieldHeight + spacing;
            
            // Transmission Field
            Label lblTransmission = CreateLabel("Transmission:", 20, yPos);
            ComboBox cmbTransmission = CreateComboBox("cmbTransmission", 150, yPos, 200);
            cmbTransmission.Items.AddRange(new string[] { "Manual", "Automatic", "CVT", "Semi-Automatic" });
            cmbTransmission.SelectedIndex = 1;
            yPos += fieldHeight + spacing;
            
            // Stock Quantity Field
            Label lblStock = CreateLabel("Stock Quantity:", 20, yPos);
            NumericUpDown numStock = CreateNumericUpDown("numStock", 150, yPos, 100, 0, 1000);
            yPos += fieldHeight + spacing;
            
            // Description Field
            Label lblDescription = CreateLabel("Description:", 20, yPos);
            TextBox txtDescription = CreateTextBox("txtDescription", 150, yPos, 300);
            txtDescription.Multiline = true;
            txtDescription.Height = 80;
            yPos += 80 + spacing;
            
            // Buttons Panel
            Panel buttonsPanel = new Panel();
            buttonsPanel.Height = 60;
            buttonsPanel.Dock = DockStyle.Bottom;
            
            Button btnSave = new Button();
            btnSave.Text = "Save Car";
            btnSave.Size = new System.Drawing.Size(120, 40);
            btnSave.Location = new System.Drawing.Point(200, 10);
            btnSave.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnSave.Click += (sender, e) => SaveCar(txtMake, txtModel, numYear, numPrice, txtColor, cmbEngine, cmbTransmission, numStock, txtDescription);
            
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
                lblMake, txtMake, lblModel, txtModel, lblYear, numYear,
                lblPrice, numPrice, lblColor, txtColor, lblEngine, cmbEngine,
                lblTransmission, cmbTransmission, lblStock, numStock,
                lblDescription, txtDescription
            });
            
            mainPanel.Controls.Add(fieldsPanel);
            mainPanel.Controls.Add(buttonsPanel);
            mainPanel.Controls.Add(titleLabel);
            
            this.Controls.Add(mainPanel);
            
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
        
        private TextBox CreateTextBox(string name, int x, int y, int width)
        {
            TextBox textBox = new TextBox();
            textBox.Name = name;
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 23);
            textBox.Font = new System.Drawing.Font("Arial", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            return textBox;
        }
        
        private NumericUpDown CreateNumericUpDown(string name, int x, int y, int width, decimal minimum, decimal maximum)
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Name = name;
            numericUpDown.Location = new System.Drawing.Point(x, y);
            numericUpDown.Size = new System.Drawing.Size(width, 23);
            numericUpDown.Font = new System.Drawing.Font("Arial", 10);
            numericUpDown.Minimum = minimum;
            numericUpDown.Maximum = maximum;
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            return numericUpDown;
        }
        
        private ComboBox CreateComboBox(string name, int x, int y, int width)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = name;
            comboBox.Location = new System.Drawing.Point(x, y);
            comboBox.Size = new System.Drawing.Size(width, 23);
            comboBox.Font = new System.Drawing.Font("Arial", 10);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            return comboBox;
        }
        
        private void SaveCar(TextBox txtMake, TextBox txtModel, NumericUpDown numYear, NumericUpDown numPrice, 
                           TextBox txtColor, ComboBox cmbEngine, ComboBox cmbTransmission, 
                           NumericUpDown numStock, TextBox txtDescription)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtMake.Text))
            {
                MessageBox.Show("Please enter the car make.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMake.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Please enter the car model.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Please enter the car color.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtColor.Focus();
                return;
            }
            
            try
            {
                // Populate the CurrentCar object
                CurrentCar.Make = txtMake.Text.Trim();
                CurrentCar.Model = txtModel.Text.Trim();
                CurrentCar.Year = (int)numYear.Value;
                CurrentCar.Price = numPrice.Value;
                CurrentCar.Color = txtColor.Text.Trim();
                CurrentCar.EngineType = cmbEngine.SelectedItem?.ToString() ?? "Gasoline";
                CurrentCar.Transmission = cmbTransmission.SelectedItem?.ToString() ?? "Automatic";
                CurrentCar.StockQuantity = (int)numStock.Value;
                CurrentCar.Description = txtDescription.Text.Trim();
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the car: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}