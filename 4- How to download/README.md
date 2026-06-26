# 🚀 Installation Guide

Follow the steps below to set up and run the project on your local machine.

### 📥 Step 1: Clone the Repository

```bash
git clone https://github.com/othman-turk-dev/Sales-Inventory-Management-System.git
```
### 🗄️ Step 2: Create the Database

Create or restore the SQL Server database using the provided SQL script.

### 💻 Step 3: Open the Solution

Open the project solution file (`.sln`) using Visual Studio.

### ⚙️ Step 4: Configure the Database Connection

Navigate to:

```text
Sales Project
└── Sales Management Project
    └── App.config
```

Update the SQL Server connection string with your local SQL Server configuration.

### ▶️ Step 5: Build and Run

Build the solution and run the project from Visual Studio.

---

# 📋 Requirements

Make sure the following software is installed before running the project:

- ✅ Visual Studio
- ✅ .NET Framework 4.8
- ✅ Microsoft SQL Server
- ✅ SAP Crystal Reports for Visual Studio: [Download SAP Crystal Reports](https://origin-az.softwaredownloads.sap.com/public/file/0025000000164882025)

## SAP Crystal Reports Installation

After downloading the SAP Crystal Reports package:

1. Extract the downloaded file.
2. You will get two folders:
   - `Package`
   - `Collaterals`
3. Open the `Package` folder.
4. You will find the following files:
   - ✅ `CRRuntime_32bit_13_0_39.msi` → **Install this file.**
   - ❌ `CrystalReportsForVisualStudio64.msi` → **No need to install this file.**