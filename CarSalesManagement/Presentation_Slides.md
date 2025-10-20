# Car Sales Management System - Presentation Slides

## Slide 1: Title Slide
**Car Sales Management System**
- C# Windows Forms Application
- Object-Oriented Programming (OOP)
- Group Assignment Presentation

---

## Slide 2: គោលបំណង (Objectives)

### គោលបំណងចម្បង
- បង្កើតប្រព័ន្ធគ្រប់គ្រងលក់ឡានពេញលេញ
- អនុវត្តគោលការណ៍ OOP ក្នុង C# Programming
- គ្រប់គ្រងព័ត៌មានផ្សេងៗក្នុងក្រុមហ៊ុនលក់ឡាន

### មុខងារដែលអាចធ្វើបាន
- ✅ គ្រប់គ្រងស្តុកឡាន
- ✅ គ្រប់គ្រងព័ត៌មានអតិថិជន
- ✅ គ្រប់គ្រងការលក់
- ✅ គ្រប់គ្រងបុគ្គលិក
- ✅ បង្កើតរបាយការណ៍

---

## Slide 3: ស្ថាបត្យកម្មប្រព័ន្ធ (System Architecture)

### Technology Stack
- **Framework**: .NET 6.0 with C#
- **UI**: Windows Forms
- **Architecture**: Object-Oriented Programming
- **Database**: SQL Server (Ready for integration)

### System Components
```
Main Application
├── Data Models (OOP Classes)
├── User Interface (Windows Forms)
├── Business Logic (Methods)
└── Data Management (CRUD Operations)
```

---

## Slide 4: Form ទី១ - Main Form

### មុខងារនិងលក្ខណៈពិសេស
- **ចូលដំណើរការជាមេ** (Main Entry Point)
- **ម៉ឺនុយចម្បង** (Main Menu)
  - File Menu
  - Car Management
  - Customer Management
  - Sales Management
  - Reports
- **ប៊ូតុងចូលប្រើប្រាស់រហ័ស** (Quick Access Buttons)
- **ផ្ទាំងព័ត៌មានស្វាគមន៍** (Welcome Panel)

### ការអនុវត្តបច្ចេកទេស
- MenuStrip control
- Panel layout
- Button styling
- Event handling

---

## Slide 5: Form ទី២ - Car Management

### មុខងារដែលអាចធ្វើបាន
- **Add New Car**: បន្ថែមឡានថ្មី
- **Manage Cars**: គ្រប់គ្រងឡានទាំងអស់
- **Search**: ស្វែងរកឡានតាមលក្ខខណ្ឌផ្សេងៗ
- **Edit/Delete**: កែប្រែ/លុបព័ត៌មានឡាន

### លក្ខណៈពិសេសបច្ចេកទេស
- DataGridView for data display
- ComboBox for search options
- Input validation
- Real-time search
- Data binding

---

## Slide 6: Form ទីៃ - Customer Management

### មុខងារដែលអាចធ្វើបាន
- **Add New Customer**: បន្ថែមអតិថិជនថ្មី
- **Manage Customers**: គ្រប់គ្រងអតិថិជនទាំងអស់
- **Search**: ស្វែងរកអតិថិជន
- **Customer Types**: Regular, VIP, Corporate

### លក្ខណៈពិសេសពិសេស
- Email validation
- Age verification (18+)
- Phone number format
- Address management
- Customer categorization

---

## Slide 7: Form ទី៤ - Sales Management

### មុខងារដែលអាចធ្វើបាន
- **New Sale**: បង្កើតការលក់ថ្មី
- **Manage Sales**: គ្រប់គ្រងការលក់ទាំងអស់
- **View Details**: មើលព័ត៌មានលម្អិត
- **Cancel Sale**: បោះបង់ការលក់
- **Sales Summary**: សង្ខេបការលក់

### ការគណនាស្វ័យប្រវត្តិ
- Total amount calculation
- Stock update
- Commission calculation
- Payment processing

---

## Slide 8: Form ទី៥ - Reports & Analytics

### ប្រភេទរបាយការណ៍
- **Sales Summary**: សង្ខេបការលក់សរុប
- **Inventory Report**: របាយការណ៍ស្តុក
- **Customer Analysis**: វិភាគអតិថិជន
- **Sales by Period**: ការលក់តាមកាលកំណត់
- **Top Selling Cars**: ឡានលក់ដាច់ជាងគេ
- **Sales Performance**: ការសម្តែងលក្ខណៈលក់

### លក្ខណៈពិសេស
- Dynamic chart generation
- Export to CSV
- Real-time data
- Multiple view options

---

## Slide 9: OOP Implementation - UML Class Diagram

### Core Classes
```
Car (ឡាន)
├── Properties: CarId, Make, Model, Year, Price...
├── Methods: GetCarInfo(), IsAvailable(), SellCar()...

Customer (អតិថិជន)
├── Properties: CustomerId, FirstName, Email, Phone...
├── Methods: GetFullName(), IsValidEmail(), GetAge()...

Sale (ការលក់)
├── Properties: SaleId, CarId, CustomerId, TotalAmount...
├── Methods: CompleteSale(), CancelSale(), ApplyDiscount()...

Employee (បុគ្គលិក)
├── Properties: EmployeeId, FirstName, Position, Salary...
├── Methods: CalculateCommission(), AddSale(), Promote()...
```

### Relationships
- Car ↔ Sale (One-to-Many)
- Customer ↔ Sale (One-to-Many)
- Employee ↔ Sale (One-to-Many)

---

## Slide 10: OOP Principles Applied

### 1. Encapsulation (ការបិទបាំង)
```csharp
public class Car
{
    private int carId;
    public int CarId 
    { 
        get { return carId; } 
        private set { carId = value; } 
    }
}
```

### 2. Abstraction (ការសម្អាត)
```csharp
public string GetCarInfo()
{
    return $"{Year} {Make} {Model} - ${Price:N0}";
}
```

### 3. Inheritance (ការស្នងបន្ត)
- Base class functionality
- Derived class specialization
- Code reusability

### 4. Polymorphism (ពហុរូបធាតុ)
```csharp
public override string ToString()
{
    return GetCarInfo();
}
```

---

## Slide 11: Demo - Insert Operation

### បង្ហាញការបញ្ចូលទិន្នន័យឡានថ្មី
1. ចុច "Add New Car"
2. បញ្ចូលព័ត៌មានឡាន:
   - Make: Toyota
   - Model: Camry
   - Year: 2023
   - Price: $25,000
   - Color: Silver
3. ត្រួតពិនិត្យទិន្នន័យ
4. រក្សាទុកទិន្នន័យ
5. បង្ហាញសារជោគជ័យ

### លទ្ធផល
- ទិន្នន័យត្រូវបានរក្សាទុក
- បញ្ជីឡានត្រូវបានធ្វើបច្ចុប្បន្នភាព
- ស្តុកត្រូវបានធ្វើបច្ចុប្បន្នភាព

---

## Slide 12: Demo - Delete Operation

### បង្ហាញការលុបទិន្នន័យ
1. ជ្រើសរើសឡានពីបញ្ជី
2. ចុច "Delete Car"
3. បង្ហាញប្រអប់បញ្ជាក់:
   - "Are you sure you want to delete this car?"
   - បង្ហាញព័ត៌មានឡាន
4. ចុច "Yes" ដើម្បីលុប
5. បង្ហាញសារជោគជ័យ

### លទ្ធផល
- ទិន្នន័យត្រូវបានលុប
- បញ្ជីត្រូវបានធ្វើបច្ចុប្បន្នភាព
- គ្មានទិន្នន័យខូចខាត

---

## Slide 13: Demo - Update Operation

### បង្ហាញការកែប្រែទិន្នន័យ
1. ជ្រើសរើសឡានពីបញ្ជី
2. ចុច "Edit Car"
3. កែប្រែព័ត៌មាន:
   - Price: $25,000 → $24,500
   - Stock: 5 → 3
4. រក្សាទុកការកែប្រែ
5. បង្ហាញសារជោគជ័យ

### លទ្ធផល
- ទិន្នន័យត្រូវបានកែប្រែ
- បញ្ជីត្រូវបានធ្វើបច្ចុប្បន្នភាព
- ព័ត៌មានថ្មីត្រូវបានបង្ហាញ

---

## Slide 14: Demo - Search Operation

### បង្ហាញការស្វែងរកទិន្នន័យ
1. ជ្រើសរើសប្រភេទស្វែងរក: "Make"
2. បញ្ចូលពាក្យគន្លឹះ: "Toyota"
3. ចុច "Search"
4. បង្ហាញលទ្ធផល:
   - Toyota Camry 2023
   - Toyota Corolla 2022
   - Toyota RAV4 2023
5. ចុច "Refresh" ដើម្បីបង្ហាញទាំងអស់

### លក្ខណៈពិសេស
- Real-time search
- Multiple search criteria
- Case-insensitive
- Partial matching

---

## Slide 15: សន្និដ្ឋាន (Conclusion)

### អ្វីដែលយើងបានសម្រេច
- ✅ **Complete System**: ប្រព័ន្ធពេញលេញសម្រាប់គ្រប់គ្រងលក់ឡាន
- ✅ **OOP Implementation**: អនុវត្តគោលការណ៍ OOP ទាំងអស់
- ✅ **User-Friendly**: ងាយស្រួលប្រើប្រាស់
- ✅ **Professional Design**: រចនាបទអាជីវកម្ម
- ✅ **Scalable**: អាចពង្រីកបាន

### តម្រូវការអនាគត
- Web application version
- Mobile app integration
- Cloud database
- Advanced analytics

### អត្ថបទចម្បង
**"OOP principles provide a solid foundation for developing maintainable and scalable business applications."**

---

## Slide 16: Thank You

### សូមអរគុណដែលបានចូលរួម

**Car Sales Management System**
- C# Windows Forms Application
- Object-Oriented Programming
- Complete Business Solution

### សំណួរនិងចម្លើយ (Q&A)

**Ready for your questions!**