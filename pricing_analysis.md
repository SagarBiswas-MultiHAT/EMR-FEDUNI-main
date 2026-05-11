# 💰 EMR Simulation Web App — Pricing Analysis

## Project Overview

This is an **Electronic Medical Record (EMR) Simulation Web Application** built for **Federation University Australia**. It's a teaching/training tool that simulates a hospital EMR system so nursing/health students can practice clinical documentation in a safe, simulated environment.

---

## 🏗️ Technology Stack

| Layer | Technology |
|---|---|
| **Backend Framework** | ASP.NET Core 8.0 (MVC + Web API) |
| **Frontend** | Razor Views (CSHTML) + jQuery + Bootstrap 5 |
| **Database** | Microsoft SQL Server (stored procedures) |
| **Architecture** | Clean Architecture (Domain → Application → Infrastructure → WebApp) |
| **Auth** | Cookie-based authentication with role-based access (Student / Supervisor) |
| **Libraries** | DataTables, jQuery UI Datepicker, Newtonsoft.Json |

---

## 📊 Codebase Metrics

| Metric | Value |
|---|---|
| **Total source files** (`.cs`, `.cshtml`, `.css`, `.js`) | **131 files** |
| **Total lines of code** | **~37,000 lines** |
| **Total source size** | **~1,663 KB** (1.6 MB) |
| **SQL schema files** | **2 files** (~530 KB combined) |
| **PDF documentation** | **2 files** (Developer Guide + Setup Guide) |
| **Image assets** | **9 files** |
| **Razor Views** (patient partials alone) | **51 views** |

---

## 🧩 Feature Inventory (Detailed Breakdown)

### 1. Authentication & Authorization
- EMR Login portal page
- Student Login (lab-based access)
- Supervisor Login (elevated privileges)
- Cookie-based persistent sessions
- Role-based menu visibility (student vs supervisor)
- Logout functionality

### 2. Patient Management
- Patient List (per lab)
- Add Patient (supervisor only)
- Delete Patient (supervisor only)
- Patient Record / Summary view

### 3. ADDS (Adult Deterioration Detection System) Chart
- Interactive vitals entry form (Respiratory Rate, Heart Rate, Temperature, Consciousness, O₂ Saturation, Blood Pressure)
- Scoring engine with color-coded alert thresholds
- ADDS Chart list with DataTables
- Insert + Update + Delete operations

### 4. IV Fluid Management
- IV Fluid Chart creation (supervisor)
- IV Fluid Chart viewing/listing
- IV Fluid Administration records (student)
- Delete administration records
- Member Order list view

### 5. Fluid Balance Chart
- Intake tracking (IV, Oral, Enteric, Other)
- Output tracking (Urine, Faecal, Vomitus, Drainage, Gastric, Bladder Scan, Other)
- Add / View / Delete fluid balance records
- Administration sub-records

### 6. Neurological Chart (Glasgow Coma Scale)
- Eye Opening, Verbal Response, Motor Response scoring
- Pupil Size & Reaction (Left/Right)
- Limb Response (all 4 limbs)
- Total Coma Scale calculation
- Add / View / Delete neurological records
- Administration sub-records

### 7. Medication Chart — PRN (As Needed)
- Medication selection from master list
- Dose, frequency, date/time, route, indication
- Prescriber & pharmacy details
- Administration records (student signs + co-sign)
- List / View / Delete

### 8. Medication Chart — Regular
- Same complexity as PRN with regular scheduling
- Full CRUD operations
- Administration tracking

### 9. Medication Master List (Supervisor)
- Add medication names
- List medications per lab
- Delete medications (with dependency checks)

### 10. Progress Notes
- Add progress notes (student or supervisor)
- Role-stamped notes (auto-detects who wrote it)
- List / Delete

### 11. Fall Risk Assessment (FRAT)
- Multi-factor risk scoring (Recent Falls, Medications, Psychological, Cognitive)
- Auto-override conditions (dizziness, anaesthetic, condition change)
- Risk level calculation (Low / Medium / High)
- Intervention notes
- FRAT list / delete
- Reference image display

### 12. Braden Scale Assessment
- Pressure injury risk assessment
- Initial assessment form
- Follow-up assessment form (with logic to check for prior initial)
- View assessment details
- List / Delete
- Dedicated CSS styling

### 13. Food Intake Charting
- Multi-meal tracking (Breakfast, Morning Tea, Lunch, Afternoon Tea, Dinner, Supper, Overnight)
- Each meal: food type, portion, fluid type, volume
- Special diet & assistance needed flags
- Add / View / Edit / Delete (full CRUD)
- Dedicated CSS styling

### 14. RISKMAN Incident Reporting
- Comprehensive incident form (~50+ fields)
- Print-friendly layout with dedicated print CSS
- View incident details
- List / Delete
- Global-level visibility (not patient-specific)

### 15. Supervisor Admin Panel
- Clear Student Data (per patient)
- Clear Lab Data (bulk reset)
- Patient management
- Lab management
- Use case setup (add chart orders for students)

### 16. Layout & Navigation
- Sidebar with nested collapsible menus
- Dynamic menu visibility based on context (patient selected vs global)
- Role-conditional menu items
- AJAX-driven SPA-like navigation (all content loads into `#content-area`)

---

## 🔧 Backend Complexity Assessment

| Component | Count | Complexity |
|---|---|---|
| **Controllers** | 6 | High (PatientController = 642 lines, SupervisorController = 339 lines) |
| **Service interfaces** | 3 | Medium |
| **Service implementations** | 3 | Medium (259 lines for PatientService alone) |
| **Repository interfaces** | 3 | High (IPatientRepository = 100+ methods) |
| **Repository implementations** | 3 | Very High (**PatientRepository = 2,823 lines** — the single largest file) |
| **DTOs** | 20 | Medium |
| **ViewModels** | 10 | Low–Medium |
| **Stored Procedures** (in SQL) | ~30+ | High (schema + data + logic) |
| **Database tables** | ~15+ | Medium |

---

## ⏱️ Effort Estimation

| Work Area | Estimated Hours |
|---|---|
| **Requirements analysis & understanding existing codebase** | 8–12 hrs |
| **Database design** (schema, tables, stored procedures, seed data) | 20–30 hrs |
| **Clean Architecture setup** (4-project solution structure) | 6–8 hrs |
| **Authentication system** (login pages, cookie auth, roles) | 10–14 hrs |
| **Patient CRUD** | 8–10 hrs |
| **ADDS Chart** (scoring logic + UI) | 12–16 hrs |
| **IV Fluid Chart** (chart + administration) | 10–14 hrs |
| **Fluid Balance Chart** (intake/output tracking) | 10–14 hrs |
| **Neurological Chart** (GCS scoring) | 12–16 hrs |
| **Medication PRN Chart** | 10–14 hrs |
| **Medication Regular Chart** | 10–14 hrs |
| **Medication Master List** | 4–6 hrs |
| **Progress Notes** | 6–8 hrs |
| **Fall Risk Assessment (FRAT)** | 10–14 hrs |
| **Braden Scale Assessment** (initial + follow-up) | 14–18 hrs |
| **Food Intake Charting** (full CRUD with meals) | 14–18 hrs |
| **RISKMAN Incident Reporting** (~50 fields + print) | 16–20 hrs |
| **Layout, sidebar navigation, AJAX routing** | 10–14 hrs |
| **CSS styling** (6 custom CSS files) | 8–12 hrs |
| **Supervisor admin features** (clear data, lab mgmt) | 6–8 hrs |
| **Testing, debugging, QA** | 16–24 hrs |
| **Documentation reading / setup guide compliance** | 4–6 hrs |
| **Deployment preparation** (published build) | 4–6 hrs |
| **||||**
| **TOTAL ESTIMATED EFFORT** | **~220–310 hours** |

> [!NOTE]
> The midpoint estimate is **~265 hours** of skilled developer work.

---

## 💵 Pricing Recommendation

### Hourly Rate Reference (Bangladesh Market)

| Developer Level | BDT/hr | USD/hr (approx) |
|---|---|---|
| Junior .NET Developer | ৳400–600 | $3.5–5.5 |
| Mid-level .NET Developer | ৳700–1,200 | $6.5–11 |
| Senior .NET Developer | ৳1,200–2,000 | $11–18 |

---

### 🎓 Friend / Student Price (Discounted)

Since this is a **student project** from a friend at Federation University:

| Parameter | Value |
|---|---|
| Estimated hours | ~265 hrs |
| Discounted rate | ৳500–700 / hr |
| **Total Range** | **৳132,500 – ৳185,500** |
| **Recommended Price** | **৳150,000** (~$1,380 USD) |

> [!TIP]
> **৳150,000 BDT** is a very fair friend price that values your work without overcharging a student. This works out to roughly ৳565/hr, which is below market rate but respects your time. You could round down to **৳130,000** if you want to be extra generous, but I wouldn't go lower than that.

---

### 🏢 Regular / Commercial Client Price

For a non-friend, commercial client requesting the same scope:

| Parameter | Value |
|---|---|
| Estimated hours | ~265 hrs |
| Market rate | ৳1,000–1,500 / hr |
| **Total Range** | **৳265,000 – ৳397,500** |
| **Recommended Price** | **৳300,000 – ৳350,000** (~$2,750–3,200 USD) |

> [!IMPORTANT]
> For international clients (Australian market), this same project would easily cost **AUD $8,000–15,000+** if outsourced to an Australian-based developer. Your friend is getting exceptional value regardless.

---

## 📋 Pricing Summary

| Scenario | Price (BDT) | Price (USD approx) |
|---|---|---|
| 🎓 **Friend/Student (minimum)** | ৳130,000 | ~$1,200 |
| 🎓 **Friend/Student (recommended)** | **৳150,000** | **~$1,380** |
| 🏢 **Regular Client (BD market)** | **৳300,000 – ৳350,000** | **~$2,750–3,200** |
| 🌏 **International Client (AU market)** | ৳900,000+ | ~AUD $10,000+ |

---

## 🧠 Key Justification Points

When discussing the price with your friend, you can highlight:

1. **37,000+ lines of code** across 131 source files — this is NOT a simple website
2. **Clean Architecture** with 4 separate .NET projects — proper enterprise-grade structure
3. **Complex SQL Server database** with 30+ stored procedures and seed data (530 KB of SQL)
4. **14+ distinct clinical modules** each with full CRUD operations
5. **Domain-specific knowledge** required — medical/nursing terminology, scoring systems (GCS, ADDS, FRAT, Braden)
6. **Two-role system** with different permissions and UI flows
7. **SPA-like AJAX navigation** — significant frontend JavaScript complexity
8. **Print-friendly views** (RISKMAN with dedicated print CSS)
9. **Deployment-ready** build with published artifacts
10. **Documentation provided** (Setup Guide + Developer Guide PDFs)

> [!CAUTION]
> Do NOT charge less than ৳100,000 even for the closest friend. At that point you'd be working for ৳375/hr — below junior developer rates in Bangladesh. Your skill and time have value.

---

## ❓ Questions to Clarify Before Finalizing

Before you commit to a final price, consider asking your friend:

1. **Is the SQL Server database already set up**, or do you need to configure/host it too?
2. **Is deployment included?** (hosting on IIS/Azure/cloud?) — that adds ৳10,000–30,000
3. **Are there any additional features** beyond what's in the codebase?
4. **Is ongoing maintenance/support expected?** If yes, charge separately (e.g., ৳5,000–10,000/month)
5. **What's the deadline?** Rush jobs warrant a 20–50% premium
6. **Will you need to make modifications** to the existing code or build from scratch?

> [!NOTE]
> If the task is only about **modifications/enhancements** to an already-working codebase (not building from scratch), the price could be lower — closer to **৳50,000–80,000** for friend rate depending on scope of changes needed.
