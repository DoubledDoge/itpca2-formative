# ITPCA2-Assignment

## 📝 Project Overview
My two formative projects of C# programming spread across two semesters of my university.

<div align="center">
    <img src="img/csharp.png" alt="Project Logo" width="150" height="150"/>
    <p><em>C# Programming Language Logo</em></p>
</div>


## 📑 Table of Contents
- [Overview](#-overview)
- [Project Status](#-project-status)
- [Setup Instructions](#-setup-instructions)
- [Features](#-features)
- [Roadmap](#-roadmap)
- [Contributing](#-contributing)
- [License](#-license)
- [Notes](#-notes)

## 🎯 Overview
This repository contains two C# projects developed as part of a formative assessment:

### Project 1
1. Hotel Reservation System (Q1)
2. Bakery Management System (Q2)

### Project 2
1. Clinic Patient Management System (Q1+Q2)
2. Drone Racing System (Q3)
3. Student Course Enrollment System (Q4)

Both projects are built using .NET 9.0 and follow modern C# development practices.

## 📊 Project Status
### Completion Progress

#### Project 1
- Hotel Reservation System

  [▓▓▓▓▓▓▓▓▓] 100%

- Bakery Management System

  [▓▓▓▓▓▓▓▓▓] 100%

#### Project 2
-  Clinic Patient Management System

   [▓▓▓▓▓▓▓▓▓] 100%

- Drone Racing System

  [▓▓▓▓▓▓▓▓▓] 100%

- Student Course Enrollment System

  [▓▓▓▓▓▓▓▓▓] 100%

## 🚀 Setup Instructions
1. Prerequisites:
   - .NET 9.0 SDK
   - Visual Studio 2022+ or Visual Studio Code or Jetbrains Rider
   - SQL Server (for Bakery Management System)
   - C# Dev Kit extension/ReSharper (if using VS Code)

2. Clone the repository:
```bash
git clone https://github.com/DoubledDoge/itpca2-formative.git
cd itpca2-formative
```

3. Project Structure:
   - Project 1 contains:
     - Hotel Reservation System (Console Application)
     - Bakery Management System (Windows Forms Application)
   - Project 2 contains:
     - Clinic Patient Management System (Console Application)
     - Drone Racing System (Console Application)
     - Student Course Enrollment System (Console Application)

4. Opening the Projects:
   - For Project 1: Open `src/Project 1/Project1Solution.sln`
   - For Project 2: Open `src/Project 2/Project2Solution.sln`

5. Database Setup (for Bakery Management System):
   - Open SQL Server Management Studio
   - Execute the `DatabaseInitialization.sql` script located in the Bakery Management System folder
   - Optionally, run `ExampleData.sql` to populate with sample data

6. Building and Running:
   - Build the solutions using Visual Studio or run `dotnet build` in the terminal
   - Run the desired project from your IDE or use `dotnet run` in the project's directory

### Troubleshooting Notes
- **Windows Forms Designer**: When working with the Bakery Management System, if you encounter issues with the designer view in Visual Studio, try moving the Project 1 folder to a separate location and open it there.
- **Database Connection**: Ensure SQL Server is running and the connection string in `DatabaseManager.cs` matches your SQL Server instance for the Bakery Management System.

## ⭐ Features
### Implemented
- Basic project structure for both projects
- CI/CD pipeline with GitHub Actions
- .NET 9.0 configuration
- Project 1
- Project 2

## 🗺️ Roadmap
### Short-term Goals
- Final Refinements and private documentation

### Long-term Goals
- Complete! (Header will be removed soon)

## 🤝 Contributing
1. Clone the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## 📝 License
This project is licensed under the GNU GPL v3 License - see the LICENSE file for details.

## 📝 Notes
- Project uses .NET 9.0 preview features
- VS Code settings are configured for optimal C# development
- CI/CD pipeline runs on Windows latest

---
Last Updated: 2025
