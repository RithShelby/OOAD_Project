# UML Class Diagram - Car Sales Management System

## Class Relationships Overview

```
┌─────────────────┐       ┌─────────────────┐       ┌─────────────────┐
│      Car        │◄──────�│      Sale       │──────►│    Customer     │
├─────────────────┤       ├─────────────────┤       ├─────────────────┤
│ - CarId: int    │       │ - SaleId: int   │       │ - CustomerId: int│
│ - Make: string  │       │ - CarId: int    │       │ - FirstName: str│
│ - Model: string │       │ - CustomerId: int│      │ - LastName: str │
│ - Year: int     │       │ - SaleDate: Date│      │ - Email: string │
│ - Price: decimal│       │ - SalePrice: dec│      │ - Phone: string │
│ - Color: string │       │ - Quantity: int │       │ - Address: str  │
│ - EngineType: str│      │ - TotalAmount:de│       │ - City: string  │
│ - Transmission: str│    │ - PaymentMethod:│       │ - Country: str  │
│ - StockQuantity: int│   │ - SaleStatus: st│       │ - DateOfBirth: D│
│ - Status: string│       │ - SalesPerson: s│       │ - LicenseNum: st│
│ - DateAdded:Date│       │ - Notes: string │       │ - RegDate: Date │
│ - Description:st│       │                 │       │ - CustomerType: │
├─────────────────┤       ├─────────────────┤       ├─────────────────┤
│ + Car()         │       │ + Sale()        │       │ + Customer()    │
│ + Car(...)      │       │ + Sale(...)     │       │ + Customer(...) │
│ + GetCarInfo()  │       │ + CalcTotalAmt()│       │ + GetFullName() │
│ + IsAvailable() │       │ + CompleteSale()│       │ + GetCustInfo() │
│ + SellCar()     │       │ + CancelSale()  │       │ + IsValidEmail()│
│ + ReserveCar()  │       │ + GetSaleInfo() │       │ + GetAge()      │
│ + CancelReserv()│       │ + ApplyDiscount()│       │ + UpgradeType() │
│ + ToString()    │       │ + IsValidSale() │       │ + ToString()    │
└─────────────────┘       └─────────────────┘       └─────────────────┘
         │                         │                         │
         │                         │                         │
         ▼                         ▼                         ▼
┌─────────────────┐       ┌─────────────────┐       ┌─────────────────┐
│    Inventory    │       │    Employee     │       │InventoryManager │
├─────────────────┤       ├─────────────────┤       ├─────────────────┤
│ - InventoryId:int│      │ - EmployeeId:int│       │ - inventories:  │
│ - CarId: int    │       │ - FirstName: st│       │   List<Inventory>│
│ - InitialStock:int│     │ - LastName: str │       ├─────────────────┤
│ - CurrentStock:int│     │ - Email: string │       │ + InventoryMgr() │
│ - SoldQuantity:int│     │ - Phone: string │       │ + AddInventory()│
│ - LastUpdated: D│       │ - Position: str │       │ + GetInvByCarId()│
│ - Location: str │       │ - Salary: dec   │       │ + GetAllInv()   │
│ - Car: Car      │       │ - HireDate: Date│       │ + GetLowStock() │
├─────────────────┤       │ - Status: string│       │ + GetTotalValue()│
│ + Inventory()   │       │ - Department: st│       └─────────────────┘
│ + Inventory(...)│       │ - TotalSales: i │
│ + AddStock()    │       │ - CommissionRate│
│ + RemoveStock() │       ├─────────────────┤
│ + GetStockInfo()│       │ + Employee()    │
│ + IsStockAvail()│       │ + Employee(...) │
│ + GetStockValue()│      │ + GetFullName() │
│ + GetSalesValue()│      │ + CalcCommission│
│ + GetTurnoverRate()│    │ + AddSale()     │
│ + ToString()    │       │ + Promote()     │
└─────────────────┘       │ + IsActive()    │
                         │ + GetYearsOfSvc()│
                         │ + ToString()    │
                         └─────────────────┘
```

## OOP Principles Implemented

### 1. Encapsulation (ការបិទបាំង)
- **Private Fields**: All classes have private fields with public properties
- **Methods**: Business logic is encapsulated within methods
- **Data Validation**: Input validation is performed within class methods

### 2. Abstraction (ការសម្អាត)
- **Public Interfaces**: Classes expose only necessary methods
- **Hidden Implementation**: Complex logic is hidden from users
- **Simplified Usage**: Easy-to-use methods like `GetCarInfo()`, `GetFullName()`

### 3. Inheritance (ការស្នងបន្ត)
- **Base Functionality**: Common properties and methods in base classes
- **Specialized Classes**: Derived classes can extend functionality
- **Code Reusability**: Shared functionality reduces code duplication

### 4. Polymorphism (ពហុរូបធាតុ)
- **Method Overriding**: `ToString()` method overridden in all classes
- **Method Overloading**: Multiple constructors for different use cases
- **Interface Implementation**: Classes implement consistent interfaces

## Class Relationships

### Association (ទំនាក់ទំនង)
- **Car ↔ Sale**: One car can have many sales
- **Customer ↔ Sale**: One customer can have many sales
- **Employee ↔ Sale**: One employee can handle many sales

### Composition (ការបង្កើត)
- **Inventory → Car**: Inventory contains a Car object
- **Sale → Car**: Sale references a Car object
- **Sale → Customer**: Sale references a Customer object

### Aggregation (ការបូម)
- **InventoryManager → Inventory**: Manager manages multiple inventories
- **CarSalesManagement → All Classes**: Main system aggregates all components

## Key Features Demonstrated

### 1. Data Management
- **CRUD Operations**: Create, Read, Update, Delete for all entities
- **Data Validation**: Input validation and business rules
- **Error Handling**: Exception handling and user feedback

### 2. Business Logic
- **Stock Management**: Track inventory levels and availability
- **Sales Processing**: Complete sales transactions
- **Customer Management**: Handle customer information and relationships

### 3. Reporting
- **Data Analysis**: Generate various reports and analytics
- **Export Functionality**: Export data to external formats
- **Visual Representation**: Charts and summaries

## Technical Implementation

### 1. Properties
- **Auto-implemented Properties**: Simple getters and setters
- **Computed Properties**: Derived values (e.g., `TotalAmount`)
- **Validation Logic**: Property setters with validation

### 2. Methods
- **Constructors**: Default and parameterized constructors
- **Business Methods**: Domain-specific operations
- **Utility Methods**: Helper functions and formatting

### 3. Collections
- **List<T>**: Generic collections for type safety
- **LINQ**: Query operations and data manipulation
- **Data Binding**: Integration with UI components

This UML diagram demonstrates a well-structured OOP design that follows SOLID principles and provides a robust foundation for the car sales management system.