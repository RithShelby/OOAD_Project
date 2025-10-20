using System;

namespace CarSalesManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public string CustomerType { get; set; } = "Regular"; // Regular, VIP, Corporate

        // Constructor
        public Customer()
        {
            RegistrationDate = DateTime.Now;
        }

        // Overloaded Constructor
        public Customer(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            RegistrationDate = DateTime.Now;
            CustomerType = "Regular";
        }

        // Method to get full name
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Method to get customer information
        public string GetCustomerInfo()
        {
            return $"{GetFullName()} - {Email} - {Phone} ({CustomerType})";
        }

        // Method to validate email
        public bool IsValidEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }

        // Method to calculate age
        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        // Method to upgrade customer type
        public void UpgradeCustomerType(string newType)
        {
            if (newType.Equals("VIP", StringComparison.OrdinalIgnoreCase) || 
                newType.Equals("Corporate", StringComparison.OrdinalIgnoreCase))
            {
                CustomerType = newType;
            }
        }

        // Override ToString method
        public override string ToString()
        {
            return GetCustomerInfo();
        }
    }
}