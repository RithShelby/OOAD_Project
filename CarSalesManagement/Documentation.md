# Car Sales Management System - Documentation

## គោលបំណង (Objectives)

ប្រព័ន្ធគ្រប់គ្រងលក់ឡាននេះត្រូវបានរចនាឡើងដើម្បីជួយក្រុមហ៊ុនលក់ឡានក្នុងការគ្រប់គ្រងព័ត៌មានផ្សេងៗដូចជា៖

1. **គ្រប់គ្រងស្តុកឡាន** (Car Inventory Management)
2. **គ្រប់គ្រងព័ត៌មានអតិថិជន** (Customer Information Management)
3. **គ្រប់គ្រងការលក់** (Sales Management)
4. **គ្រប់គ្រងបុគ្គលិក** (Employee Management)
5. **របាយការណ៍និងវិភាគ** (Reporting and Analytics)

## ការងារដែលអាចធ្វើបាន (Available Functions)

### Form ទី១: Main Form (ទម្រង់មេ)
- **មុខងារ**: ចូលដំណើរការជាមេរបស់ប្រព័ន្ធ
- **លក្ខណៈពិសេស**:
  - ម៉ឺនុយចម្បងសម្រាប់ចូលទៅកាន់មុខងារផ្សេងៗ
  - ប៊ូតុងចូលប្រើប្រាស់រហ័ស (Quick Access)
  - ព័ត៌មានស្វាគមន៍និងការណែនាំ

### Form ទី២: Car Management (គ្រប់គ្រងឡាន)
- **មុខងារ**: គ្រប់គ្រងព័ត៌មានឡានទាំងអស់
- **លក្ខណៈពិសេស**:
  - បន្ថែមឡានថ្មី (Add Car)
  - កែប្រែព័ត៌មានឡាន (Edit Car)
  - លុបឡាន (Delete Car)
  - ស្វែងរកឡាន (Search Car)
  - បង្ហាញបញ្ជីឡានទាំងអស់ (View All Cars)

### Form ទីៃ: Customer Management (គ្រប់គ្រងអតិថិជន)
- **មុខងារ**: គ្រប់គ្រងព័ត៌មានអតិថិជន
- **លក្ខណៈពិសេស**:
  - បន្ថែមអតិថិជនថ្មី (Add Customer)
  - កែប្រែព័ត៌មានអតិថិជន (Edit Customer)
  - លុបអតិថិជន (Delete Customer)
  - ស្វែងរកអតិថិជន (Search Customer)
  - តម្រៀបអតិថិជនតាមប្រភេទ (Sort by Type)

### Form ទី៤: Sales Management (គ្រប់គ្រងការលក់)
- **មុខងារ**: គ្រប់គ្រងប្រតិបត្តិការលក់
- **លក្ខណៈពិសេស**:
  - បង្កើតការលក់ថ្មី (New Sale)
  - មើលព័ត៌មានលម្អិតការលក់ (View Sale Details)
  - បោះបង់ការលក់ (Cancel Sale)
  - ស្វែងរកការលក់ (Search Sales)
  - សង្ខេបការលក់ (Sales Summary)

### Form ទី៥: Reports (របាយការណ៍)
- **មុខងារ**: បង្កើតរបាយការណ៍និងវិភាគ
- **លក្ខណៈពិសេស**:
  - របាយការណ៍លក់សរុប (Sales Summary)
  - របាយការណ៍ស្តុក (Inventory Report)
  - វិភាគអតិថិជន (Customer Analysis)
  - របាយការណ៍តាមកាលកំណត់ (Sales by Period)
  - ឡានលក់ដាច់ជាងគេ (Top Selling Cars)
  - ការសម្តែងលក្ខណៈលក់ (Sales Performance)

## ការអនុវត្តលក្ខណៈ OOP

### 1. Encapsulation (ការបិទបាំង)
- **Private Fields**: ទិន្នន័យត្រូវបានការពារដោយ private
- **Public Properties**: ផ្តល់ឱ្យអាចចូលដំណើរការតាមរយៈ properties
- **Method Validation**: ការត្រួតពិនិត្យទិន្នន័យនៅក្នុង class

### 2. Abstraction (ការសម្អាត)
- **Public Interfaces**: បង្ហាញតែ method ដែលចាំបាច់
- **Hidden Implementation**: លាក់ការអនុវត្តស្មុគស្មាញ
- **Simplified Usage**: ធ្វើឱ្យងាយស្រួលក្នុងការប្រើប្រាស់

### 3. Inheritance (ការស្នងបន្ត)
- **Base Classes**: មាន class មូលដ្ឋានសម្រាប់លក្ខណៈទូទៅ
- **Derived Classes**: Class កូនអាចបន្ថែមលក្ខណៈពិសេស
- **Code Reusability**: កាត់បន្ថយការសរសេរកូដដដែល

### 4. Polymorphism (ពហុរូបធាតុ)
- **Method Overriding**: Override method ដូចជា `ToString()`
- **Method Overloading**: មាន constructor ច្រើន
- **Interface Implementation**: អនុវត្ត interface ដូចគ្នា

## ស្ថាបត្យកម្មប្រព័ន្ធ

### Database Structure
```
Cars Table
- CarId (PK)
- Make, Model, Year, Price, Color
- EngineType, Transmission, StockQuantity
- Status, DateAdded, Description

Customers Table
- CustomerId (PK)
- FirstName, LastName, Email, Phone
- Address, City, Country
- DateOfBirth, LicenseNumber
- RegistrationDate, CustomerType

Sales Table
- SaleId (PK)
- CarId (FK), CustomerId (FK)
- SaleDate, SalePrice, Quantity
- TotalAmount, PaymentMethod
- SaleStatus, SalesPerson, Notes

Employees Table
- EmployeeId (PK)
- FirstName, LastName, Email, Phone
- Position, Salary, HireDate
- Status, Department
- TotalSales, CommissionRate

Inventory Table
- InventoryId (PK)
- CarId (FK), InitialStock, CurrentStock
- SoldQuantity, LastUpdated, Location
```

### Class Hierarchy
```
Main System
├── Models
│   ├── Car
│   ├── Customer
│   ├── Sale
│   ├── Employee
│   ├── Inventory
│   └── InventoryManager
└── Forms
    ├── MainForm
    ├── CarForm
    ├── CarManagementForm
    ├── CustomerForm
    ├── CustomerManagementForm
    ├── SaleForm
    ├── SalesManagementForm
    └── ReportsForm
```

## លក្ខណៈពិសេសបច្ចេកទេស

### 1. User Interface
- **Windows Forms**: ប្រើ C# Windows Forms
- **Responsive Design**: អាចប្តូរទំហំបាន
- **Professional Layout**: រចនាបទសម្រប់អាជីវកម្ម
- **Easy Navigation**: ម៉ឺនុយងាយស្រួលប្រើ

### 2. Data Management
- **CRUD Operations**: Create, Read, Update, Delete
- **Data Validation**: ការត្រួតពិនិត្យទិន្នន័យ
- **Error Handling**: គ្រប់គ្រងកំហុស
- **Search Functionality**: ស្វែងរកបានលឿន

### 3. Business Logic
- **Stock Management**: គ្រប់គ្រងស្តុកឡាន
- **Sales Processing**: ដំណើរការការលក់
- **Commission Calculation**: គណនាគម្រាប់បុគ្គលិក
- **Report Generation**: បង្កើតរបាយការណ៍

## ការដំឡើងប្រព័ន្ធ

### Requirements
- **.NET 6.0** ឬខ្ពស់ជាងនេះ
- **Windows OS** (Windows 10 ឬខ្ពស់ជាងនេះ)
- **Visual Studio 2022** ឬ Visual Studio Code
- **SQL Server** សម្រាប់ database (ជម្រើស)

### Installation Steps
1. ទាញយក source code
2. បើកដោយ Visual Studio
3. Restore NuGet packages
4. កំណត់រចនាសម្ព័ន្ធបណ្ណាល័យ
5. ដំណើរការកម្មវិធី

## សន្និដ្ឋាន (Conclusion)

ប្រព័ន្ធគ្រប់គ្រងលក់ឡាននេះត្រូវបានអភិវឌ្ឍន៍ដោយប្រើប្រាស់ **C# Programming** ជាមួយ **Windows Forms** និង **Object-Oriented Programming (OOP)** principles។ ប្រព័ន្ធនេះផ្តល់នូវដំណោះស្រាយពេញលេញសម្រាប់ការគ្រប់គ្រងអាជីវកម្មលក់ឡានដោយរួមមាន៖

### គុណសម្បត្តិសំខាន់ៗ
- **ងាយស្រួលប្រើប្រាស់**: ចំណុចប្រើប្រាស់ងាយស្រួល
- **មុខងារពេញលេញ**: គ្របដណ្តប់តម្រូវការទាំងអស់
- **សុវត្ថិភាព**: ការពារទិន្នន័យឱ្យបានល្អ
- **លឿនរហ័ស**: ដំណើរការរហ័សនិងមានប្រសិទ្ធិភាព
- **អាចពង្រីក**: អាចបន្ថែមមុខងារថ្មីបាន

### តម្រូវការអនាគត
- **Web Version**: អាចអភិវឌ្ឍជា web application
- **Mobile App**: អាចបង្កើត mobile application
- **Cloud Integration**: ភ្ជាប់ជាមួយ cloud services
- **Advanced Analytics**: បន្ថែមមុខងារវិភាគកម្រិតខ្ពស់

ប្រព័ន្ធនេះជាឧទាហរណ៍ល្អសម្រាប់ការអនុវត្ត **OOP principles** ក្នុងការអភិវឌ្ឍន៍ software ពិតប្រាកដ និងអាចយកទៅប្រើប្រាស់ក្នុងអាជីវកម្មពិតបាន។