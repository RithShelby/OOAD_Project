using System;
using System.Windows.Forms;
using CarSalesManagement.Models;

namespace CarSalesManagement.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Add New Customer";
            this.Size = new System.Drawing.Size(650, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            
            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(30);
            
            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = "Add New Customer";
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
            
            // First Name Field
            Label lblFirstName = CreateLabel("First Name:", 20, yPos);
            TextBox txtFirstName = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Last Name Field
            Label lblLastName = CreateLabel("Last Name:", 20, yPos);
            TextBox txtLastName = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Email Field
            Label lblEmail = CreateLabel("Email:", 20, yPos);
            TextBox txtEmail = CreateTextBox(150, yPos, 250);
            yPos += fieldHeight + spacing;
            
            // Phone Field
            Label lblPhone = CreateLabel("Phone:", 20, yPos);
            TextBox txtPhone = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Address Field
            Label lblAddress = CreateLabel("Address:", 20, yPos);
            TextBox txtAddress = CreateTextBox(150, yPos, 300);
            yPos += fieldHeight + spacing;
            
            // City Field
            Label lblCity = CreateLabel("City:", 20, yPos);
            TextBox txtCity = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Country Field
            Label lblCountry = CreateLabel("Country:", 20, yPos);
            TextBox txtCountry = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Date of Birth Field
            Label lblDateOfBirth = CreateLabel("Date of Birth:", 20, yPos);
            DateTimePicker dtpDateOfBirth = new DateTimePicker();
            dtpDateOfBirth.Location = new System.Drawing.Point(150, yPos);
            dtpDateOfBirth.Size = new System.Drawing.Size(200, 23);
            dtpDateOfBirth.Font = new System.Drawing.Font("Arial", 10);
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18); // Must be at least 18 years old
            yPos += fieldHeight + spacing;
            
            // License Number Field
            Label lblLicenseNumber = CreateLabel("License Number:", 20, yPos);
            TextBox txtLicenseNumber = CreateTextBox(150, yPos, 200);
            yPos += fieldHeight + spacing;
            
            // Customer Type Field
            Label lblCustomerType = CreateLabel("Customer Type:", 20, yPos);
            ComboBox cmbCustomerType = CreateComboBox(150, yPos, 200);
            cmbCustomerType.Items.AddRange(new string[] { "Regular", "VIP", "Corporate" });
            cmbCustomerType.SelectedIndex = 0;
            yPos += fieldHeight + spacing;
            
            // Buttons Panel
            Panel buttonsPanel = new Panel();
            buttonsPanel.Height = 60;
            buttonsPanel.Dock = DockStyle.Bottom;
            
            Button btnSave = new Button();
            btnSave.Text = "Save Customer";
            btnSave.Size = new System.Drawing.Size(140, 40);
            btnSave.Location = new System.Drawing.Point(180, 10);
            btnSave.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            btnSave.Click += (sender, e) => SaveCustomer(txtFirstName, txtLastName, txtEmail, txtPhone, txtAddress, txtCity, txtCountry, dtpDateOfBirth, txtLicenseNumber, cmbCustomerType);
            
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
                lblFirstName, txtFirstName, lblLastName, txtLastName, lblEmail, txtEmail,
                lblPhone, txtPhone, lblAddress, txtAddress, lblCity, txtCity,
                lblCountry, txtCountry, lblDateOfBirth, dtpDateOfBirth,
                lblLicenseNumber, txtLicenseNumber, lblCustomerType, cmbCustomerType
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
        
        private TextBox CreateTextBox(int x, int y, int width)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 23);
            textBox.Font = new System.Drawing.Font("Arial", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            return textBox;
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
        
        private void SaveCustomer(TextBox txtFirstName, TextBox txtLastName, TextBox txtEmail, TextBox txtPhone,
                                TextBox txtAddress, TextBox txtCity, TextBox txtCountry, DateTimePicker dtpDateOfBirth,
                                TextBox txtLicenseNumber, ComboBox cmbCustomerType)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter the first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter the last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter the email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter the phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("Please enter the license number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseNumber.Focus();
                return;
            }
            
            try
            {
                // Create new customer object
                Customer newCustomer = new Customer();
                newCustomer.FirstName = txtFirstName.Text.Trim();
                newCustomer.LastName = txtLastName.Text.Trim();
                newCustomer.Email = txtEmail.Text.Trim();
                newCustomer.Phone = txtPhone.Text.Trim();
                newCustomer.Address = txtAddress.Text.Trim();
                newCustomer.City = txtCity.Text.Trim();
                newCustomer.Country = txtCountry.Text.Trim();
                newCustomer.DateOfBirth = dtpDateOfBirth.Value;
                newCustomer.LicenseNumber = txtLicenseNumber.Text.Trim();
                newCustomer.CustomerType = cmbCustomerType.SelectedItem?.ToString() ?? "Regular";
                
                // Validate email format
                if (!newCustomer.IsValidEmail())
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                
                // Check age (must be at least 18)
                if (newCustomer.GetAge() < 18)
                {
                    MessageBox.Show("Customer must be at least 18 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDateOfBirth.Focus();
                    return;
                }
                
                // Here you would typically save to database
                // For now, we'll just show a success message
                MessageBox.Show($"Customer '{newCustomer.GetFullName()}' has been added successfully!\n\n" +
                              $"Email: {newCustomer.Email}\n" +
                              $"Phone: {newCustomer.Phone}\n" +
                              $"Customer Type: {newCustomer.CustomerType}", 
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear form for next entry
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
                txtCity.Clear();
                txtCountry.Clear();
                txtLicenseNumber.Clear();
                dtpDateOfBirth.Value = DateTime.Today.AddYears(-25);
                cmbCustomerType.SelectedIndex = 0;
                
                txtFirstName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the customer: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}