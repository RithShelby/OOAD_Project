using System.Collections.Generic;
using System.Linq;
using CarSalesManagement.Models;

namespace CarSalesManagement.Data
{
    public class CarSalesContext
    {
        private static CarSalesContext? _instance;
        private static readonly object _lock = new object();

        public List<Car> Cars { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Employee> Employees { get; set; }

        private CarSalesContext()
        {
            Cars = new List<Car>();
            Customers = new List<Customer>();
            Sales = new List<Sale>();
            Employees = new List<Employee>();
            SeedData();
        }

        public static CarSalesContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CarSalesContext();
                        }
                    }
                }
                return _instance;
            }
        }

        private void SeedData()
        {
            // Add sample employees
            Employees.Add(new Employee("John", "Smith", "john.smith@cardealership.com", "Sales Manager", 50000m) { Phone = "555-0101" });
            Employees.Add(new Employee("Sarah", "Johnson", "sarah.johnson@cardealership.com", "Sales Representative", 35000m) { Phone = "555-0102" });
            Employees.Add(new Employee("Mike", "Wilson", "mike.wilson@cardealership.com", "Sales Representative", 35000m) { Phone = "555-0103" });

            // Add sample cars
            Cars.Add(new Car("Toyota", "Camry", 2023, 25000m, "Silver") { CarId = 1, StockQuantity = 5, EngineType = "V6", Transmission = "Automatic" });
            Cars.Add(new Car("Honda", "Civic", 2023, 22000m, "Blue") { CarId = 2, StockQuantity = 3, EngineType = "4-Cylinder", Transmission = "Manual" });
            Cars.Add(new Car("Ford", "Mustang", 2023, 35000m, "Red") { CarId = 3, StockQuantity = 2, EngineType = "V8", Transmission = "Automatic" });
            Cars.Add(new Car("Tesla", "Model 3", 2023, 45000m, "White") { CarId = 4, StockQuantity = 1, EngineType = "Electric", Transmission = "Automatic" });

            // Add sample customers
            Customers.Add(new Customer("Alice", "Brown", "alice.brown@email.com", "555-0201") { CustomerId = 1, Address = "123 Main St", DateOfBirth = new DateTime(1985, 5, 15), LicenseNumber = "DL123456" });
            Customers.Add(new Customer("Bob", "Davis", "bob.davis@email.com", "555-0202") { CustomerId = 2, Address = "456 Oak Ave", DateOfBirth = new DateTime(1990, 8, 22), LicenseNumber = "DL789012" });
        }

        // Car operations
        public void AddCar(Car car)
        {
            car.CarId = Cars.Count > 0 ? Cars.Max(c => c.CarId) + 1 : 1;
            Cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            var existingCar = Cars.FirstOrDefault(c => c.CarId == car.CarId);
            if (existingCar != null)
            {
                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Price = car.Price;
                existingCar.Color = car.Color;
                existingCar.EngineType = car.EngineType;
                existingCar.Transmission = car.Transmission;
                existingCar.StockQuantity = car.StockQuantity;
                existingCar.Status = car.Status;
            }
        }

        public void DeleteCar(int carId)
        {
            var car = Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                Cars.Remove(car);
            }
        }

        // Customer operations
        public void AddCustomer(Customer customer)
        {
            customer.CustomerId = Customers.Count > 0 ? Customers.Max(c => c.CustomerId) + 1 : 1;
            Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
                existingCustomer.DateOfBirth = customer.DateOfBirth;
                existingCustomer.LicenseNumber = customer.LicenseNumber;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
            {
                Customers.Remove(customer);
            }
        }

        // Sale operations
        public void AddSale(Sale sale)
        {
            sale.SaleId = Sales.Count > 0 ? Sales.Max(s => s.SaleId) + 1 : 1;
            Sales.Add(sale);
        }

        public void UpdateSale(Sale sale)
        {
            var existingSale = Sales.FirstOrDefault(s => s.SaleId == sale.SaleId);
            if (existingSale != null)
            {
                existingSale.SalePrice = sale.SalePrice;
                existingSale.PaymentMethod = sale.PaymentMethod;
                existingSale.SaleStatus = sale.SaleStatus;
                existingSale.Notes = sale.Notes;
                existingSale.CalculateTotalAmount();
            }
        }

        public void DeleteSale(int saleId)
        {
            var sale = Sales.FirstOrDefault(s => s.SaleId == saleId);
            if (sale != null)
            {
                Sales.Remove(sale);
            }
        }
    }
}