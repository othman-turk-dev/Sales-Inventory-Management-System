# Sales & Inventory Management System
A desktop Sales & Inventory Management System developed using C# (.NET Framework 4.8) and SQL Server. The system manages products, categories, customers, sales orders, users, and inventory operations while providing reporting, printing, backup, and database maintenance features.

## Architecture
- Presentation Layer (WinForms)
- Business Logic Layer (BLL)
- Data Access Layer (DAL)

## Features
### Authentication
The system includes a default administrator account stored in database for initial access and testing purposes:

Username: `Othman` / Password: `Admin`

- Secure login system
- Remember Me functionality using Windows Registry
- User access control

---

### Database Administration
- Database backup
- Database restore
- Error log management
- Logout functionality

---

### Product Management
- Full CRUD operations for products
- Search by product ID, name, or category
- Product inventory tracking
- Export to Excel
- Product printing

---

### Category Management
- Full CRUD operations for categories
- Print category information
- Export category data to PDF

---

### Sales Management
- Create sales orders
- Customer information management during sales
- Product selection and order processing
- Quantity, discount, and total calculations
- Order printing
- Sales history management

---

### Customer Management
- Full CRUD operations for customers
- Search using customer information
- Data validation

---

### User Management
- CRUD operations for users
- Activate / deactivate users
- Permission-based access control

## Technologies
- C#
- .NET Framework 4.8
- WinForms
- SQL Server
- ADO.NET
- Stored Procedures
- Microsoft Report Viewer
- 3-Tier Architecture

## Concepts Practiced
- Sales & Inventory Management
- Database Design
- Master-Detail Relationships
- Stored Procedures
- Reporting & Printing
- Backup & Restore Operations
- Error Handling & Logging
- User Management
- Data Validation
- Layered Architecture

## Purpose
This project was developed to practice building a complete business management system that combines sales operations, inventory control, customer management, reporting, and SQL Server database administration using a structured 3-Tier Architecture.

## Demo
Watch the system demo: https://youtu.be/2SH80N3NVsE
