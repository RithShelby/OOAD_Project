using System;

namespace CarSalesManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty; // Sales Manager, Sales Representative, Admin
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; } = "Active"; // Active, Inactive, On Leave
        public string Department { get; set; } = "Sales";
        public int TotalSales { get; set; }
        public decimal CommissionRate { get; set; } = 0.05m; // 5% default commission

        // Constructor
        public Employee()
        {
            HireDate = DateTime.Now;
            Status = "Active";
        }

        // Overloaded Constructor
        public Employee(string firstName, string lastName, string email, string position, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Position = position;
            Salary = salary;
            HireDate = DateTime.Now;
            Status = "Active";
            Department = "Sales";
        }

        // Method to get full name
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Method to get employee information
        public string GetEmployeeInfo()
        {
            return $"{GetFullName()} - {Position} - {Department} ({Status})";
        }

        // Method to calculate commission
        public decimal CalculateCommission(decimal saleAmount)
        {
            return saleAmount * CommissionRate;
        }

        // Method to add sale
        public void AddSale(decimal saleAmount)
        {
            TotalSales++;
            // Additional logic can be added here for tracking performance
        }

        // Method to promote employee
        public void Promote(string newPosition, decimal newSalary)
        {
            Position = newPosition;
            Salary = newSalary;
        }

        // Method to check if employee is active
        public bool IsActive()
        {
            return Status.Equals("Active", StringComparison.OrdinalIgnoreCase);
        }

        // Method to calculate years of service
        public int GetYearsOfService()
        {
            return DateTime.Now.Year - HireDate.Year;
        }

        // Override ToString method
        public override string ToString()
        {
            return GetEmployeeInfo();
        }
    }
}