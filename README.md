# 🚗 Driving School Booking System

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![License](https://img.shields.io/badge/License-MIT-brightgreen)
![Contributions](https://img.shields.io/badge/Contributions-Welcome-ff69b4)

A simple and efficient Driving Lesson Booking System built entirely in **C# using .NET 8.0**.  
Includes support for students, instructors, and admins with full CRUD operations.

---

## 📑 Table of Contents

- [🚀 Features](#-features)
- [🛠 Getting Started](#-getting-started)
  - [1. Clone the Repo](#1-clone-the-repo)
  - [2. Installation](#2-installation)
- [🧪 Using the Program](#-using-the-program)
- [📁 Project Structure Note](#-project-structure-note)

---

## 🚀 Features

- ✅ Students can book and view their driving lessons  
- ✅ Instructors can view assigned lessons  
- ✅ Admins can manage Students, Instructors, Cars, and Lessons (CRUD support)

---

## 🛠 Getting Started

### 1. Clone the Repo

```bash
git clone https://github.com/Sanish1246/driving-school-booking-system.git
```

### 2. Installation

Before proceeding, make sure you have the following NuGuet Packages:

Use the **CLI** and run the following commands:

``` bash 
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.2
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.2
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.2
dotnet add package Microsoft.Extensions.Configuration --version 9.0.2
dotnet add package Microsoft.Extensions.Configuration.Json --version 9.0.2
dotnet add package CsvHelper --version 33.0.1
```

**Delete Migrations folder**

**Open context folder, go into DrivingLessonBookingSystem.cs and comment out the following line of codes:**

``` c#
// line 15

// private readonly StreamWriter _logStream = new StreamWriter(new FileStream(
    //     GetPath(),
    //     FileMode.Append,
    //     FileAccess.Write,
    //     FileShare.ReadWrite
    // ));

// line 31

// .ConfigureWarnings(
        //     b => b.Log(
        //         (RelationalEventId.ConnectionOpened, LogLevel.Information),
        //         (RelationalEventId.ConnectionClosed, LogLevel.Information)))
        // .LogTo(_logStream.WriteLine, LogLevel.Information, DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine);

```

**NOTE: Add a semi-colon (;) before line 26, at the end of the code else, you will have that red squiggly line**

```
//line 45

// public override void Dispose()
    // {
    //     base.Dispose();
    //     _logStream.Dispose();
    // }

//line 51

// private static string GetPath()
    // {
    //     var workingDirectory = Environment.CurrentDirectory;
    //     var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
    //     return(Path.Combine(projectDirectory, "Logs","logs.txt"));
    // }
```

**Run the following commands to create the database using code-first approach:**

**NOTE: VERY IMPORTANRT !! Before running the following code, make sure you change the connection string in the configuration settings (appsettings.json file).**

```
"DefaultConnection": "Server=LAPTOP-ILUK0PDF;Database=Driving Booking lesson system;Trusted_Connection=True;TrustServerCertificate=True;"
```

 Server value (LAPTOP-ILUK0PDF) should be changed to the one your machine uses, as shown in the following picture:
![Image](https://github.com/user-attachments/assets/6ebb7dae-f7f1-43df-a5b3-71aa4802ebb8)

Then proceed with the following steps:

```bash
dotnet ef migrations add InitialCreate -p MainProject

dotnet ef database update -p MainProject

```

**Verify if the database has been created using MSSQL or any other UI**

**Uncomment the code in step 3 (don't forget to remove the semi-colon added or you can just undo everythings in that file)**


## 🧪 Using the Program

Once the program is started, users can log in as one of the following roles:

1. **Student** – Can book lessons and view their upcoming sessions.  
2. **Instructor** – Can view lessons assigned to them.  
3. **Admin** – Has full control (CRUD operations) over students, instructors, cars, and lessons.

---

## 📁 Project Structure Note

There are **two project folders** in this repository:

- One folder contains the **GUI version** of the application, built with **Windows Forms (WinForms)**.  
- The other folder is a **Console Application**, used for **unit testing**.

### ❓ Why Two Projects?

This separation exists because one of the contributors was working on a **Mac**, and **WinForms is not supported on macOS**.

As a workaround, they created a **console-based project** to:

- Reuse the same core logic  
- Handle input/output via terminal  
- Apply **MSTest** effectively for unit testing

This structure improves **testability** and ensures **cross-platform compatibility** for all contributors.




