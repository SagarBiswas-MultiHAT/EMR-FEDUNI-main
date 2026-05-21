# EMR Simulator - Electronic Medical Records System

## What is This Project?

This is an **Electronic Medical Records (EMR) Simulator** - a training application that simulates a real hospital/lab management system. It allows students and supervisors to practice managing patient records, medications, lab work, and assessments in a safe, controlled environment.

**Think of it like:** A practice simulator for hospital staff, similar to flight simulators for pilots.

## Project Folder Structure

1. **EMRSimulationWebApp** - Contains all the website code and application files
2. **PublishedWebsite** - Contains files ready for deployment/publishing to a server
3. **DatabaseSchema.sql** - Instructions for creating the database (tables, data, etc.)
4. **EmrSimulator_full_After_update_2026-01-13.sql** - Complete database setup with sample data

---

# QUICK START GUIDE: HOW TO RUN THE EMR SIMULATOR

This guide is designed for everyone, whether you're technical or not. Follow these steps in order.

## Prerequisites (What You Need to Install First)

Before you can run the application, you need two main tools:

### 1. SQL Server Express (The Database)

**What is it?** A database is like a filing cabinet that stores all the patient records, user accounts, and other information.

- **Download:** [SQL Server Express 2022](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
- **How to install:**
  1. Run the downloaded installer
  2. Choose **"Basic"** installation (it's the easiest)
  3. Accept all default settings and click through to finish
  4. You'll be prompted to restart - do that
  5. **After installation:** Also install **SQL Server Management Studio (SSMS)** - it's the tool to manage your database
     - Search for "SQL Server Management Studio" in Windows
     - Download and install it

### 2. .NET SDK (The Framework)

**What is it?** This is the software framework needed to run the application code.

- **Download:** [.NET 6.0 SDK or higher](https://dotnet.microsoft.com/download)
- **How to install:**
  1. Run the installer
  2. Click through the installation wizard with default settings
  3. When complete, restart your computer
  4. **Verify installation:** Open Command Prompt/PowerShell and type:
     ```
     dotnet --version
     ```
     You should see a version number (like 6.0 or higher)

---

## Step-by-Step Setup Instructions

### STEP 1: Create the Database (Do This Once)

A database is where all the information is stored. Follow these sub-steps:

#### Step 1a: Connect to SQL Server

1. Open **SQL Server Management Studio (SSMS)** - search for it in Windows Start menu
2. A window will appear asking you to connect. Fill in:
   - **Server name:** `.\SQLEXPRESS` (the dot and backslash mean "this computer")
   - **Authentication:** Windows Authentication (should already be selected)
3. Click **Connect**
4. If a certificate warning appears, click **Yes** or **Trust**

#### Step 1b: Create an Empty Database

1. In SSMS, on the left side, right-click on **"Databases"** folder
2. Select **"New Database..."**
3. Name it: `EmrSimulator` (exactly as shown - capitals matter)
4. Click **OK**
5. You should now see "EmrSimulator" in your Databases list

#### Step 1c: Load Sample Data

1. In SSMS, click **File** → **Open** → **File**
2. Navigate to your project folder: `C:\GitHub\EMR-FEDUNI-main-fahim\`
3. Open the file: **`EmrSimulator_full_After_update_2026-01-13.sql`**
   - This file contains all the tables, patient records, and user accounts
4. You'll see SQL code in the editor window
5. Click the **Execute** button (green play button) or press **Ctrl+E**
6. Wait for it to complete (this might take a minute)
7. You should see messages saying "Commands completed successfully"

**What just happened?** You've loaded:

- All database tables (containers for data)
- Sample patient records (for practice)
- User accounts (student and supervisor logins)
- All the application logic

---

### STEP 2: Download Project Files

1. Open **File Explorer** (Windows key + E)
2. Navigate to: `C:\GitHub\EMR-FEDUNI-main-fahim\EMRSimulationWebApp\`
3. You should see a folder called `EMRSimulationWebApp`
4. Remember this location - you'll need it in the next step

---

### STEP 3: Run the Application

Now you're ready to start the application. Follow these steps:

1. Open **Command Prompt** or **PowerShell**
   - Right-click on your desktop or in a folder
   - Select "Open Windows Terminal here" or "Open PowerShell here"
   - Or search for "PowerShell" in Windows Start menu

2. Navigate to the project folder:

   ```powershell
   cd "EMR-FEDUNI-main-fahim\EMRSimulationWebApp\EMRSimulationWebApp"
   ```

---

The issue is that you're in the parent EMRSimulationWebApp folder, but the actual project file `EMRSimulationWebApp.csproj` is nested one level deeper in EMRSimulationWebApp.

You can fix this by running:

```powershell
dotnet run --project .\EMRSimulationWebApp\EMRSimulationWebApp.csproj
```

Or navigate into the actual project directory:

```powershell
cd .\EMRSimulationWebApp
dotnet run
```

The second approach is cleaner. Try navigating to the nested directory where the `.csproj` file is located, then running `dotnet run`.

---

3. Start the application:

   ```powershell
   dotnet run
   ```

4. **Wait for this message to appear:**

   ```
   Now listening on: http://localhost:5031
   Application started. Press Ctrl+C to shut down.
   ```

5. **Do NOT close this window** - this window keeps the application running

---

### STEP 4: Access the Website

1. Open your web browser (Chrome, Edge, Firefox, etc.)
2. Go to the address bar and type: `http://localhost:5031`
3. You should see: **"Welcome to Fed Uni EMR Simulator"** with login options
4. You're ready to login!

---

## Login Credentials

The application has two types of users: **Students** (who manage patients) and **Supervisors** (who oversee and manage the lab).

### STUDENT / LAB TECHNICIAN Credentials

These are for students practicing to manage patient care:

| Location                | Username   | Password  | Status         |
| ----------------------- | ---------- | --------- | -------------- |
| Berwick Lab (Primary)   | **berlab** | **F5jh4** | ✓ Ready to Use |
| Mt Helen Lab (Primary)  | **mthlab** | **4YwCj** | ✓ Ready to Use |
| Gippsland Lab (Primary) | **giplab** | **hD6s2** | ✓ Ready to Use |
| Berwick Lab 1           | berlab1    | h4F5j     | ✓ Ready to Use |
| Berwick Lab 2           | berlab2    | 5jh4F     | ✓ Ready to Use |
| Berwick Lab 3           | berlab3    | jh4F5     | ✓ Ready to Use |
| Mt Helen Lab 1          | mthlab1    | Cj4Yw     | ✓ Ready to Use |
| Mt Helen Lab 2          | mthlab2    | YwCj4     | ✓ Ready to Use |
| Mt Helen Lab 3          | mthlab3    | wCj4Y     | ✓ Ready to Use |
| Gippsland Lab 1         | giplab1    | s2hD6     | ✓ Ready to Use |
| Gippsland Lab 2         | giplab2    | D6s2h     | ✓ Ready to Use |
| Gippsland Lab 3         | giplab3    | 6s2hD     | ✓ Ready to Use |

**How to login as a Student:**

1. On the login page, click **"Student Login"**
2. Enter any username from the table above
3. Enter the corresponding password
4. Click **Login**
5. You'll see a list of patients to manage

### SUPERVISOR Credentials

These are for supervisors/instructors who oversee the system:

| Location               | Username     | Password  |
| ---------------------- | ------------ | --------- |
| Berwick (Primary)      | **bersuper** | **Mb39R** |
| Mt Helen (Primary)     | **mthsuper** | **7zGd3** |
| Gippsland (Primary)    | **gipsuper** | **Ah48i** |
| Berwick Supervisor 1   | bersuper1    | 9RMb3     |
| Berwick Supervisor 2   | bersuper2    | b39RM     |
| Berwick Supervisor 3   | bersuper3    | 39RMb     |
| Mt Helen Supervisor 1  | mthsuper1    | d37zG     |
| Mt Helen Supervisor 2  | mthsuper2    | zGd37     |
| Mt Helen Supervisor 3  | mthsuper3    | Gd37z     |
| Gippsland Supervisor 1 | gipsuper1    | 8iAh4     |
| Gippsland Supervisor 2 | gipsuper2    | h48iA     |
| Gippsland Supervisor 3 | gipsuper3    | 48iAh     |

**How to login as a Supervisor:**

1. On the login page, click **"Supervisor Login"**
2. Enter any username from the table above
3. Enter the corresponding password
4. Click **Login**
5. You'll see supervisor dashboard and analytics

---

## Configuration

The application uses **SQL Server Express** as the database and is configured to connect automatically. The connection is set up in the file: `appsettings.Development.json` in the EMRSimulationWebApp folder.

**For non-technical users:** You don't need to change anything here - it's already configured correctly!

**For technical users:** The connection string uses Windows Authentication to `.\SQLEXPRESS` with the `EmrSimulator` database.

---

## How to Create New User Accounts

If you need to add more student or supervisor accounts, you can do this directly in the database:

### Adding a New Student/Lab Account

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your database
3. Click **File** → **New** → **Query with Current Connection**
4. Copy and paste this code:
   ```sql
   INSERT INTO [dbo].[Lab] ([LabName], [LabLogin], [LabPassword], [Active])
   VALUES ('My New Lab', 'mylab', 'password123', 1)
   ```
5. Change:
   - `'My New Lab'` - to your lab name
   - `'mylab'` - to your login username
   - `'password123'` - to your password
6. Click **Execute** (green play button)
7. The new account is ready to use immediately

### Adding a New Supervisor Account

1. Follow steps 1-3 above
2. Copy and paste this code:
   ```sql
   INSERT INTO [dbo].[Supervisor] ([UserName], [UserLogin], [UserPassword], [LabId])
   VALUES ('Dr. Smith', 'dsmith', 'password123', 1)
   ```
3. Change:
   - `'Dr. Smith'` - to the supervisor's name
   - `'dsmith'` - to the login username
   - `'password123'` - to the password
   - `1` - to the Lab ID (1=Berwick, 2=Mt Helen, 3=Gippsland, etc.)
4. Click **Execute**
5. The new supervisor account is ready to use

---

## Troubleshooting Guide

### Problem: "Cannot connect to database" or "Login failed"

**Solution:**

1. Make sure SQL Server is running
2. In Windows, search for **"SQL Server Configuration Manager"**
3. Look for **"SQL Server (SQLEXPRESS)"** and make sure it shows green circle (Running)
4. If it's not running, right-click it and select **"Start"**

### Problem: "The application won't start" or shows errors

**Solution:**

1. Make sure you're in the correct folder: `C:\GitHub\EMR-FEDUNI-main-fahim\EMRSimulationWebApp\EMRSimulationWebApp`
2. Try these commands in order:
   ```powershell
   dotnet clean
   dotnet build
   dotnet run
   ```
3. If it still doesn't work, close the terminal window completely and start fresh

### Problem: "Port 5031 is already in use"

**Solution:**

1. The application is already running on your computer
2. Either use it in another browser window
3. Or, find the PowerShell window running it and close it (Ctrl+C)
4. Then start it again with `dotnet run`

### Problem: "Page shows 'Error occurred' when trying to login"

**Solution:**

1. Make sure you typed the username and password correctly (they're case-sensitive)
2. Make sure you're using the correct login type (Student vs Supervisor)
3. Check the credentials table above to verify the username and password

### Problem: "I can't see any patients after logging in"

**Solution:**

1. This might be normal - different labs might have different patient records
2. Try logging in with **"berlab"** / **"F5jh4"** - this lab definitely has sample patients
3. If still no patients appear, contact your instructor

---

## What Can You Do in This Application?

Once you log in, you can:

### As a Student:

- View a list of patients assigned to your lab
- Access and update patient records
- Track patient vitals and assessments
- Manage medications and IV fluids
- Record progress notes
- View risk assessments (falls, pressure ulcers, etc.)
- Practice proper EMR documentation

### As a Supervisor:

- View all patient data across your lab
- Monitor student activities
- Generate reports and analytics
- Manage user accounts
- Oversee student performance

---

## Technical Details (For Developers)

**Technology Stack:**

- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Backend:** ASP.NET Core (C#)
- **Database:** SQL Server Express
- **Architecture:** Multi-layered (Application, Domain, Infrastructure, Web layers)

**Port:** http://localhost:5031 (HTTP)

**Database Tables Include:**

- Patient, Supervisor, Lab information
- Medical assessments (Braden, Fall Risk)
- Medication charts and administration logs
- IV fluid administration
- Progress notes
- Fluid balance records

---

## Support and Contact

If you encounter issues or need help:

1. Check the **Troubleshooting Guide** section above
2. Review the credentials to ensure they're correct
3. Contact your instructor or IT support

---

**Version:** 0.0.0  
**Last Updated:** January 2026  
**Institution:** Federation University
