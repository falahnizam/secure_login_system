
# Secure Login System

A full-featured secure login application built in C# using the .NET Framework (WinForms). This project includes both the frontend (modern animated UI) and backend (authentication logic and SQL Server database), all implemented from scratch in Visual Studio.

--- 

## Features

- Role-based access control (Admin, User)
- Secure password hashing using PBKDF2
- Animated gradient panels and custom buttons for a unique UI
- Modular architecture inspired by MVC
- Built-in loading animations and design enhancements
- Admin dashboard to manage users (expandable)

---

## Architecture Overview

This project includes both frontend and backend logic:

- **Frontend**:
  - Developed with **Windows Forms (WinForms)**
  - Gradient backgrounds, animated controls, and custom-shaped buttons
  - Responsive layout and smooth UI transitions using double-buffering and timers

- **Backend**:
  - Secure login system with hashed password storage
  - Connects to **SQL Server (LocalDB)** using ADO.NET
  - Handles access control, session checks, and database queries

- **Structure**:
  - Structured using an **MVC-inspired pattern**, manually separating:
    - `Views/` – UI Forms
    - `Controllers/` – Interaction and flow control
    - `Models/` – Data access and logic
  - Promotes modularity, testability, and easier maintenance

>  All functionality is embedded within a single project — no external backend required.
---

## Technologies Used

- **C#**
- **.NET Framework 4.8.1**
- **WinForms**
- **SQL Server (LocalDB)**
- **Visual Studio**
---

## External Libraries

Installed via NuGet:

- **ReaLTaiizor** – UI control library for enhanced design
- **AdvancedDataGridView (ADGV)** – Improved DataGridView with sorting/filtering
- **Newtonsoft.Json** – (Reserved for JSON config or API expansion)

---
# Folder Structure
secure_login_system/
├── Controllers/ # Logic and flow control
├── Models/ # DB-related operations
├── Views/ # WinForms (UI)
├── Program.cs
├── Login.mdf # LocalDB database file
├── App.config # Connection strings (excluded from repo)
└── README.md

---

# Setup Instruction
- **Clone the repository**
  bash 
  ```git clone https://github.com/falahnizam/secure_login_system.git```

- **Open the project**
  launch login.sln

- **Restore NuGet Packages**
  Visual Studio may auto-restore, if not from solution right click Restore NuGet Packages

- **Configure the Database**
  Ensure that Login.mdf is attached in SQL Server Object Explorer
  If needed, update the connection string in App.config

- **Run**
  To Run Press F5 in visual Studio

## Key Classes and Their Functionalities

1. **CustomButton.cs**  (UI Enhancements & Custom Controls)  
   This is a custom Windows Forms control that replaces the standard button with a modern, animated version.  
   It enhances the application's user interface and provides several customizable properties. Features include:

   - Gradient Background: Uses two colors (Color0 and Color1) to create a rotating linear gradient effect.
   - Rounded Corners: The BorderRadius property controls how rounded the button edges are.
   - Icon + Text Support: Displays an optional icon to the left of the text, improving visual clarity.
   - Live Animation: A Timer rotates the gradient angle smoothly in real time by updating every 60ms.
   - Design-Time Support: Properties are grouped under "Appearance" in the Visual Studio designer for easy customization.
   - Optimized Rendering: Uses double buffering and high-quality smoothing to prevent flickering.

   The class overrides the OnPaint method to custom draw the button using GDI+ (Graphics Device Interface),
   including the background, icon, and text. It’s used across various forms for a more interactive and aesthetic UI.

2. **DBconnection.cs** (Database Connection Handler)  
   Manages all database interactions using a singleton pattern to ensure a single connection manager throughout the app.

  - Singleton Pattern:  
    The constructor is private to prevent external instantiation.  
    getInstanceOfDBconnection() ensures only one instance exists and is reused throughout the app.  

  - ```ExecuteQuery()```:  
    Executes SELECT queries and returns a DataSet.  
    Accepts optional SqlParameter[] to prevent SQL injection.  
    Uses using blocks for automatic connection disposal.

  - ```ExecuteNonQuery()```:  
    Executes non-query SQL commands like INSERT, UPDATE, and DELETE.  
    Returns the number of affected rows to confirm success.

  - ```ExecuteScalar()```:  
    Efficiently retrieves a single value (e.g., SELECT COUNT(*)).  
    Returns the first column of the first row from the result set.

3. **AccountService.cs** (User Management & Authentication)  
   Handles all account-related operations including registration, login, role updates, and status checks.  
   - ```CreateAccount()```  
     Registers a new user with a default `"Pending"` role.  
     Inserts into both `UserDetails` and `Login` tables.  
     Hashes passwords using `PasswordHash`.  
     Returns `true` on successful registration.

   - ```AuthenticateUser()``` 
     Authenticates user credentials during login.  
     Retrieves hashed password, verifies it, and returns a `UserAuthenticationResult` (includes `RoleID` and `UserID`).

   - ```AuthorizeUser()``` / ```UpdateUserRole()```
     Updates a user's role in the database (e.g., approve or promote a user). Used by Admin.

   - ```GetPendingUsers()```
     Fetches all users with the `"Pending"` role for admin review.

   - ```RejectUser()``` 
     Marks a user as rejected (sets `RoleID = 3`) and logs the reason in the `RejectedUsers` table.

   - ```CheckEmailExists()``` / ```CheckUserNameExists()```
     Validates uniqueness of email and username during registration using `ExecuteScalar()`.

4. **PasswordHash.cs** (Password Security & Verification)  
   Implements password hashing and verification using PBKDF2 with salt to securely store passwords.  
   - Generates a random 16-byte salt per password.  
   - Uses 10,000 iterations and a 20-byte hash size.  
   - Combines salt and hash into a single byte array for storage.  
   - Verifies passwords by re-hashing input and comparing bytes.  
   - Protects against rainbow and brute force attacks.

5. **mdiProperties.cs** (UI Window Styling Helper)  
   Provides an extension method to toggle the 3D bevel border effect on MDI client areas in WinForms.  
   - Uses P/Invoke to call native Win32 API functions (`GetWindowLong`, `SetWindowLong`, `SetWindowPos`).  
   - Adjusts the extended window style flags to add or remove the `WS_EX_CLIENTEDGE` style.  
   - Ensures updated window appearance by refreshing style flags.  
   - Used to enhance visual styling of MDI child forms dynamically.
  
## Development Environment:
This project is built using a full-featured IDE that supports Windows Forms and SQL Server LocalDB. While the source code can be edited with any code editor that supports C#, using an IDE with integrated form design and debugging tools is strongly recommended to fully utilize all development features.

**Runtime Requirements:**
To run the compiled application, only the .NET Framework 4.8.1 runtime and SQL Server LocalDB need to be installed on the target machine.

## Work Flow
Login Screen
![Login UI](assets/)


