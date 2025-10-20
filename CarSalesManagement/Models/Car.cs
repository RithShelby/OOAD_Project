using System;

namespace CarSalesManagement.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public string EngineType { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public string Status { get; set; } = "Available"; // Available, Sold, Reserved
        public DateTime DateAdded { get; set; }
        public string? Description { get; set; }

        // Constructor
        public Car()
        {
            DateAdded = DateTime.Now;
        }

        // Overloaded Constructor
        public Car(string make, string model, int year, decimal price, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            Color = color;
            DateAdded = DateTime.Now;
            Status = "Available";
        }

        // Method to display car information
        public string GetCarInfo()
        {
            return $"{Year} {Make} {Model} - ${Price:N0} ({Color}) - {Status}";
        }

        // Method to check if car is available
        public bool IsAvailable()
        {
            return Status.Equals("Available", StringComparison.OrdinalIgnoreCase) && StockQuantity > 0;
        }

        // Method to sell a car
        public bool SellCar(int quantity = 1)
        {
            if (IsAvailable() && StockQuantity >= quantity)
            {
                StockQuantity -= quantity;
                if (StockQuantity == 0)
                {
                    Status = "Sold";
                }
                return true;
            }
            return false;
        }

        // Method to reserve a car
        public bool ReserveCar()
        {
            if (IsAvailable())
            {
                Status = "Reserved";
                return true;
            }
            return false;
        }

        // Method to cancel reservation
        public void CancelReservation()
        {
            if (Status.Equals("Reserved", StringComparison.OrdinalIgnoreCase))
            {
                Status = "Available";
            }
        }

        // Override ToString method
        public override string ToString()
        {
            return GetCarInfo();
        }
    }
}