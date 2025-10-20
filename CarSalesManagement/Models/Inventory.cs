using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesManagement.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int CarId { get; set; }
        public int InitialStock { get; set; }
        public int CurrentStock { get; set; }
        public int SoldQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Location { get; set; } = string.Empty; // Showroom, Warehouse, etc.

        // Navigation Property
        public Car? Car { get; set; }

        // Constructor
        public Inventory()
        {
            LastUpdated = DateTime.Now;
        }

        // Overloaded Constructor
        public Inventory(int carId, int initialStock, string location)
        {
            CarId = carId;
            InitialStock = initialStock;
            CurrentStock = initialStock;
            SoldQuantity = 0;
            Location = location;
            LastUpdated = DateTime.Now;
        }

        // Method to add stock
        public bool AddStock(int quantity)
        {
            if (quantity > 0)
            {
                CurrentStock += quantity;
                InitialStock += quantity;
                LastUpdated = DateTime.Now;
                return true;
            }
            return false;
        }

        // Method to remove stock (when car is sold)
        public bool RemoveStock(int quantity)
        {
            if (quantity > 0 && CurrentStock >= quantity)
            {
                CurrentStock -= quantity;
                SoldQuantity += quantity;
                LastUpdated = DateTime.Now;
                return true;
            }
            return false;
        }

        // Method to get stock information
        public string GetStockInfo()
        {
            return $"Car ID: {CarId} - Current Stock: {CurrentStock}/{InitialStock} - Sold: {SoldQuantity} - Location: {Location}";
        }

        // Method to check if stock is available
        public bool IsStockAvailable(int requiredQuantity = 1)
        {
            return CurrentStock >= requiredQuantity;
        }

        // Method to get stock value
        public decimal GetStockValue(decimal carPrice)
        {
            return CurrentStock * carPrice;
        }

        // Method to get sales value
        public decimal GetSalesValue(decimal carPrice)
        {
            return SoldQuantity * carPrice;
        }

        // Method to calculate stock turnover rate
        public decimal GetTurnoverRate()
        {
            if (InitialStock == 0) return 0;
            return (decimal)SoldQuantity / InitialStock * 100;
        }

        // Override ToString method
        public override string ToString()
        {
            return GetStockInfo();
        }
    }

    // Inventory Manager Class to manage multiple inventories
    public class InventoryManager
    {
        private List<Inventory> inventories;

        public InventoryManager()
        {
            inventories = new List<Inventory>();
        }

        // Method to add inventory
        public void AddInventory(Inventory inventory)
        {
            inventories.Add(inventory);
        }

        // Method to get inventory by car ID
        public Inventory? GetInventoryByCarId(int carId)
        {
            return inventories.FirstOrDefault(i => i.CarId == carId);
        }

        // Method to get all inventories
        public List<Inventory> GetAllInventories()
        {
            return inventories;
        }

        // Method to get low stock items
        public List<Inventory> GetLowStockItems(int threshold = 5)
        {
            return inventories.Where(i => i.CurrentStock <= threshold).ToList();
        }

        // Method to get total inventory value
        public decimal GetTotalInventoryValue(Func<int, decimal> carPriceLookup)
        {
            decimal totalValue = 0;
            foreach (var inventory in inventories)
            {
                totalValue += inventory.GetStockValue(carPriceLookup(inventory.CarId));
            }
            return totalValue;
        }
    }
}