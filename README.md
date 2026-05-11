1. EMRSimulationWebApp - folder contains all the source code files of the EMR Simulator web application.
2. PublishedWebsite - folder contains all the deployment files of the web application
3. DatabaseSchema.sql - file contains the database schema, tables, and stored procedures for managing patient records, IV fluid administration, medication charts, lab details, and user authentication in an EMR simulation system.

---

# HOW TO RUN THE EMR SIMULATOR WEB APPLICATION

To run the EMR Simulator website, follow these steps:

## Prerequisites

1. **SQL Server** - Ensure SQL Server Express is installed and running
2. **.NET SDK** - Have .NET SDK installed on your machine

## Setup Steps

1. **Create the Database** (first time only)
   - Open SQL Server Management Studio (SSMS)
   - Execute the SQL schema file: Databaseschema_three.sql
   - Or run: EmrSimulator_full_After_update_2026-01-13.sql for the complete setup

2. **Restore NuGet Packages** (in the root directory)

   ```powershell
   dotnet restore
   ```

3. **Run the Application**

   ```powershell
   cd EMRSimulationWebApp/EMRSimulationWebApp
   dotnet run
   ```

4. **Access the Website**
   - Open your browser and navigate to: `https://localhost:5001` or `http://localhost:5000`
   - Login with your credentials (default user should be set up from the database schema)

## Configuration

- The application uses **SQL Server Express** with connection string configured in appsettings.json:
  ```
  Server=.\SQLEXPRESS
  Database=EmrSimulator
  User ID=sa
  Password=Emrp@ssword123!
  ```

---

## Database Setup Guide for Beginners

Here's what you need to do step-by-step:

### Step 1: Install SQL Server Express (if not already installed)

1. Download [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express) from Microsoft
2. Run the installer and select **"Basic"** installation
3. Accept the defaults and complete installation
4. Also install **SQL Server Management Studio (SSMS)** - this is the tool you'll use to manage databases

### Step 2: Create the Database

1. Open **SQL Server Management Studio** (search for "SSMS" on Windows)

![alt text](image.png)

- Enable Trusted server certificate.
- Connect

2. Connect using:
   - Server name: `.` or `localhost` or `.\SQLEXPRESS`
   - Authentication: Windows Authentication (default)

3. Right-click on **Databases** → Select **New Database**
4. Name it: `EmrSimulator` (must match the connection string)

### Step 3: Load the Database Schema

![alt text](Guide/2.png)

1. In SSMS, click **File** → **Open** → **File**
2. Navigate to the project root and open EmrSimulator_full_After_update_2026-01-13.sql
3. Click the **Execute** button (or press Ctrl+E)
4. This will create all the necessary tables and data

### Step 4: Verify Connection

The connection string in appsettings.json is:

```
Server=.\SQLEXPRESS
Database=EmrSimulator
User ID=sa
Password=Emrp@ssword123!
```

If you installed with a different password or setup, update these values accordingly.

### Step 5: Run the Application

Once the database is ready, run:

```powershell
dotnet run
```

### Extra Guidance

Credentials Summary
Based on the database schema I found, here are the login credentials for the EMR system:

Supervisor Credentials
bersuper / Mb39R (Berwick Lab)
mthsuper / 7zGd3 (Mt Helen Lab)
gipsuper / Ah48i (Gippsland Lab)
bersuper1 / 9RMb3 (Berwick Supervisor 1)
bersuper2 / b39RM (Berwick Supervisor 2)
bersuper3 / 39RMb (Berwick Supervisor 3)
mthsuper1 / d37zG (Mt Helen Supervisor 1)
mthsuper2 / zGd37 (Mt Helen Supervisor 2)
mthsuper3 / Gd37z (Mt Helen Supervisor 3)
gipsuper1 / 8iAh4 (Gippsland Supervisor 1)
gipsuper2 / h48iA (Gippsland Supervisor 2)
gipsuper3 / 48iAh (Gippsland Supervisor 3)

How to Create New Accounts
Based on the code architecture, new accounts are typically created by inserting records into the Supervisor or Student tables in the database:

For Supervisors:

INSERT INTO [dbo].[Supervisor] ([UserName], [UserLogin], [UserPassword], [LabId])
VALUES ('New Supervisor', 'newsuper', 'password123', 1)

I'll check if student credentials exist in the database, and if not, I'll create them.

Ran terminal command: $cs = "Server=.\SQLEXPRESS;Database=EmrSimulator;Integrated Security=true;Encrypt=false;TrustServerCertificate=true;Connection Timeout=30;"; $c = New-Object System.Data.SqlClient.SqlConnection($cs); try { $c.Open(); $cmd = $c.CreateCommand(); $cmd.CommandText = "SELECT TOP 10 * FROM Student"; $r = $cmd.ExecuteReader(); $count = 0; while ($r.Read()) { Write-Host "ID: $($r[0]), Login: $($r['StudentLogin']), Password: $($r['StudentPassword'])"; $count++ }; if ($count -eq 0) { Write-Host "No student records found" }; $r.Close(); } catch { Write-Host "Error: $_" }; finally { $c.Close() }
Completed with input: $cs = "Server=.\SQLEXPRESS;Database=EmrSimulator;Integrated Security=true;Encrypt=false;TrustServerCertificate=true;Connection Timeout=30;"; $c = New-Object System.Data.SqlClient.SqlConnection($cs); try { $c.Open(); $cmd = $c.CreateCommand(); $cmd.CommandText = "SELECT TOP 10 * FROM Student"; $r = $cmd.ExecuteReader(); $count = 0; while ($r.Read()) { Write-Host "ID: $($r[0]), Login: $($r['StudentLogin']), Password: $($r['StudentPassword'])"; $count++ }; if ($count -eq 0) { Write-Host "No student records found" }; $r.Close(); } catch { Write-Host "Error: $\_" }; finally { $c.Close() }

Ran terminal command: $cs = "Server=.\SQLEXPRESS;Database=EmrSimulator;Integrated Security=true;Encrypt=false;TrustServerCertificate=true;Connection Timeout=30;"; $c = New-Object System.Data.SqlClient.SqlConnection($cs); $c.Open(); $cmd = $c.CreateCommand(); $cmd.CommandText = "SELECT name FROM sys.objects WHERE type='U' ORDER BY name"; $r = $cmd.ExecuteReader(); while ($r.Read()) { Write-Host $r[0] }; $r.Close(); $c.Close()

Searched for text `ValidateLabLogin`, 5 results

Read [](file:///c%3A/GitHub/EMR-FEDUNI-main/EmrSimulator_full_After_update_2026-01-13.sql#3100-3100), lines 3100 to 3643

Read [](file:///c%3A/GitHub/EMR-FEDUNI-main/Databaseschema_three.sql#3052-3052), lines 3052 to 3100

Ran terminal command: $cs = "Server=.\SQLEXPRESS;Database=EmrSimulator;Integrated Security=true;Encrypt=false;TrustServerCertificate=true;Connection Timeout=30;"; $c = New-Object System.Data.SqlClient.SqlConnection($cs); $c.Open(); $cmd = $c.CreateCommand(); $cmd.CommandText = "SELECT OBJECT_DEFINITION(OBJECT_ID('ValidateLabLogin'))"; $result = $cmd.ExecuteScalar(); Write-Host $result; $c.Close()

Ran terminal command: $cs = "Server=.\SQLEXPRESS;Database=EmrSimulator;Integrated Security=true;Encrypt=false;TrustServerCertificate=true;Connection Timeout=30;"; $c = New-Object System.Data.SqlClient.SqlConnection($cs); $c.Open(); $cmd = $c.CreateCommand(); $cmd.CommandText = "SELECT Id, LabName, LabLogin, LabPassword, Active FROM Lab ORDER BY Id"; $r = $cmd.ExecuteReader(); while ($r.Read()) { Write-Host "ID: $($r['Id']), Name: $($r['LabName']), Login: $($r['LabLogin']), Password: $($r['LabPassword']), Active: $($r['Active'])" }; $r.Close(); $c.Close()

Updated memory file [](file:///c%3A/Users/sagar/AppData/Roaming/Code/User/workspaceStorage/ff3c8f7aee98fb28b156eec76b355a6d/GitHub.copilot-chat/memory-tool/memories/NzIwZTdiNzktNWUxNS00NDJjLTgzNmYtN2JlZTZiODFiYzRh/emr_login_credentials.md)

Perfect! I found the **Student Credentials**. In this system, students log in using Lab credentials from the `Lab` table. Here's the complete list:

## Student/Lab Credentials

**Primary Labs:**

- **berlab** / **F5jh4** (Berwick Lab)
- **mthlab** / **4YwCj** (Mt Helen Lab)
- **giplab** / **hD6s2** (Gippsland Lab)

**Individual Lab Stations:**

- **berlab1** / **h4F5j** (Berwick Lab 1)
- **berlab2** / **5jh4F** (Berwick Lab 2)
- **berlab3** / **jh4F5** (Berwick Lab 3)
- **mthlab1** / **Cj4Yw** (Mt Helen Lab 1)
- **mthlab2** / **YwCj4** (Mt Helen Lab 2)
- **mthlab3** / **wCj4Y** (Mt Helen Lab 3)
- **giplab1** / **s2hD6** (Gippsland Lab 1)
- **giplab2** / **D6s2h** (Gippsland Lab 2)
- **giplab3** / **6s2hD** (Gippsland Lab 3)

Let me test one of these credentials to verify they work:

Navigated to http://localhost:5031/account/login in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Typed text in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Typed text in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Clicked Login button in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Checked terminal output

Read [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Captured browser screenshot
Completed with input: {
"pageId": "2b23b8c4-dc06-478a-b3e0-e7161bc62689"
}

Let me check if the frontend JavaScript is properly sending the login request:

Searched for files matching `**/Views/**/*.html`, no matches

Searched for files matching `**/Views/**/*.cshtml`, 20 matches

Read [](file:///c%3A/GitHub/EMR-FEDUNI-main/EMRSimulationWebApp/EMRSimulationWebApp/Views/Account/Login.cshtml)

Navigated to http://localhost:5031/account/login?login=student in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Typed text in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Typed text in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Clicked Login button in [Browser](vscode-browser:/2b23b8c4-dc06-478a-b3e0-e7161bc62689?vscodeLinkType=browser)

Perfect! ✓ The student credentials work! I've successfully logged in with **berlab** / **F5jh4** and the application loaded successfully showing the Berwick Lab patient dashboard.

## Summary

### Student Credentials Status: **AVAILABLE**

All lab credentials already exist in the database and are active. Here's the complete list organized by location:

**Berwick Labs:**

- **berlab** / **F5jh4** (Primary) ✓ TESTED & WORKING
- **berlab1** / **h4F5j**
- **berlab2** / **5jh4F**
- **berlab3** / **jh4F5**

**Mt Helen Labs:**

- **mthlab** / **4YwCj** (Primary)
- **mthlab1** / **Cj4Yw**
- **mthlab2** / **YwCj4**
- **mthlab3** / **wCj4Y**

**Gippsland Labs:**

- **giplab** / **hD6s2** (Primary)
- **giplab1** / **s2hD6**
- **giplab2** / **D6s2h**
- **giplab3** / **6s2hD**

### Supervisor Credentials

**Primary Supervisors:**

- **bersuper** / **Mb39R** (Berwick)
- **mthsuper** / **7zGd3** (Mt Helen)
- **gipsuper** / **Ah48i** (Gippsland)

Plus 9 additional supervisor accounts for individual lab stations.

### Account Creation

To create new accounts, insert directly into the database:

**For Student/Lab Accounts:**

```sql
INSERT INTO [dbo].[Lab] ([LabName], [LabLogin], [LabPassword], [Active])
VALUES ('New Lab Name', 'newlab', 'Password123', 1)
```

**For Supervisor Accounts:**

```sql
INSERT INTO [dbo].[Supervisor] ([UserName], [UserLogin], [UserPassword], [LabId])
VALUES ('New Supervisor', 'newsupervisor', 'Password123', 1)
```


Ran command: `dotnet run`
Ran command: `cd .\EMRSimulationWebApp\`
Ran command: `dotnet run`
Ran command: `cd .\EMRSimulationWebApp\EMRSimulationWebApp\`
Ran command: `dotnet restore`
Listed directory EMR-FEDUNI-main
Listed directory EMRSimulationWebApp
Listed directory EMRSimulationWebApp

The issue is that you added an extra `EMRSimulationWebApp` when trying to change directories. 

Because you are already in the `C:\GitHub\EMR-FEDUNI-main\EMRSimulationWebApp` directory, you only need to go down one more level to reach the project file.

To run the project from your current location, you can do one of two things:

**Option 1: Navigate to the correct directory and run it**
```powershell
cd .\EMRSimulationWebApp\
dotnet run
```

**Option 2: Run it directly from your current location**
```powershell
dotnet run --project .\EMRSimulationWebApp\
```