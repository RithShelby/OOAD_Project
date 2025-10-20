using System;

namespace CarSalesManagement.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Credit, Bank Transfer, Financing
        public string SaleStatus { get; set; } = "Completed"; // Pending, Completed, Cancelled
        public string? SalesPerson { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties (for relationships)
        public Car? Car { get; set; }
        public Customer? Customer { get; set; }

        // Constructor
        public Sale()
        {
            SaleDate = DateTime.Now;
            SaleStatus = "Pending";
        }

        // Overloaded Constructor
        public Sale(int carId, int customerId, decimal salePrice, int quantity, string paymentMethod)
        {
            CarId = carId;
            CustomerId = customerId;
            SalePrice = salePrice;
            Quantity = quantity;
            PaymentMethod = paymentMethod;
            SaleDate = DateTime.Now;
            CalculateTotalAmount();
            SaleStatus = "Pending";
        }

        // Method to calculate total amount
        public void CalculateTotalAmount()
        {
            TotalAmount = SalePrice * Quantity;
        }

        // Method to complete sale
        public bool CompleteSale()
        {
            if (SaleStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                SaleStatus = "Completed";
                return true;
            }
            return false;
        }

        // Method to cancel sale
        public bool CancelSale()
        {
            if (SaleStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                SaleStatus = "Cancelled";
                return true;
            }
            return false;
        }

        // Method to get sale information
        public string GetSaleInfo()
        {
            return $"Sale #{SaleId}: {Quantity} car(s) - ${TotalAmount:N0} - {SaleStatus} ({SaleDate:yyyy-MM-dd})";
        }

        // Method to apply discount
        public void ApplyDiscount(decimal discountPercentage)
        {
            if (discountPercentage > 0 && discountPercentage <= 100)
            {
                decimal discountAmount = TotalAmount * (discountPercentage / 100);
                TotalAmount -= discountAmount;
            }
        }

        // Method to check if sale is valid
        public bool IsValidSale()
        {
            return CarId > 0 && CustomerId > 0 && SalePrice > 0 && Quantity > 0 && 
                   !string.IsNullOrEmpty(PaymentMethod);
        }

        // Override ToString method
        public override string ToString()
        {
            return GetSaleInfo();
        }
    }
}