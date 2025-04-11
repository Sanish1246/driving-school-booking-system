# driving-school-booking-system
 A project for a Driving lesson booking system, made entirely in C# .Net Version 8.0

## Getting Started

**1. Clone the repo**
```
git clone https://github.com/Sanish1246/driving-school-booking-system.git
```

**2. Delete Migrations folder**

**3. Open context folder, move into DrivingLessonBookingSystem.cs and comment out the following line of codes:**

```
// line 15
private readonly StreamWriter _logStream = new StreamWriter(GetPath(), append: true);

// line 26
// .ConfigureWarnings(
        //     b => b.Log(
        //         (RelationalEventId.ConnectionOpened, LogLevel.Information),
        //         (RelationalEventId.ConnectionClosed, LogLevel.Information)))
        // .LogTo(_logStream.WriteLine, LogLevel.Information, DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine);

NOTE: Add a semi-colon (;) before line 26, at the end of the code else, you will have that red squiggly line

//line 41
// public override void Dispose()
    // {
    //     base.Dispose();
    //     _logStream.Dispose();
    // }

//line 47
// private static string GetPath()
    // {
    //     var workingDirectory = Environment.CurrentDirectory;
    //     var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
    //     return(Path.Combine(projectDirectory, "Logs","logs.txt"));
    // }
```

**4. Run the following commands to create the database using code-first approach:**
**NOTE: VERY IMPORTANRT !! Before running the following code, make sure you change the connection string in the configuration settings.**
```
"DefaultConnection": "Server=LAPTOP-ILUK0PDF;Database=Driving Booking lesson system;Trusted_Connection=True;TrustServerCertificate=True;"
```
 Server value (LAPTOP-ILUK0PDF) should be changed to the one your machine uses, as shown in the following picture:
![Image](https://github.com/user-attachments/assets/6ebb7dae-f7f1-43df-a5b3-71aa4802ebb8)

Then proceed with the following steps:

```
dotnet ef migrations add InitialCreate -p MainProject

dotnet ef database update -p MainProject

```
**Verify if the database has been created using MSSQL or any other UI**

**5. Uncomment the code in step 3 (don't forget to remove the semi-colon added or you can just undo everythings in that file)**





