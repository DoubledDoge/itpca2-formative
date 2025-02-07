# ITPCA2-Assignment
My two formative projects of C# programming spread across two semesters of my university.

![Project Logo](img/placeholder.png)
*A visual representation of the project architecture (Coming Soon)*

## 📑 Table of Contents
- [Overview](#overview)
- [Repository Structure](#repository-structure)
- [Project Status](#project-status)
- [Setup Instructions](#setup-instructions)
- [Features](#features)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Notes](#notes)

## 🎯 Overview
This repository contains two C# projects developed as part of a formative assessment:
1. Hotel Reservation System (Q1)
2. Bakery Management System (Q2)

Both projects are built using .NET 9.0 and follow modern C# development practices.

## 📂 Repository Structure
```
📁 itpca2-formative/
├── 📁 .github/
│   └── 📁 workflows/
│       └── 📄 build.yml
├── 📁 .vscode/
│   ├── 📄 launch.json
│   ├── 📄 settings.json
│   └── 📄 tasks.json
├── 📁 docs/
├── 📁 img/
│   └── 📄 placeholder.png
└── 📁 src/
    ├── 📁 Project 1/
    │   ├── 📁 Hotel Reservation System (Q1)/
    │   │   ├── 📄 Program.cs
    │   │   └── 📄 Hotel Reservation System.csproj
    │   ├── 📁 Bakery Management System (Q2)/
    │   │   ├── 📄 Program.cs
    │   │   └── 📄 Bakery Management System.csproj
    │   └── 📄 Project1Solution.sln
    └── 📁 Project 2 (Unused)/
```

Key components:
- `.github/workflows/`: Contains CI/CD pipeline configuration
- `.vscode/`: VS Code editor settings and build/debug configurations
- `src/`: Source code for both projects
  - `Project 1/`: Contains both Q1 and Q2 solutions using .NET 9.0
  - `Project 2/`: Reserved for future development

## 📊 Project Status
### Completion Progress

#### Project 1
- 🏨 Hotel Reservation System

  [▓░░░░░░░░░] 10%

- 🥖 Bakery Management System

  [▓░░░░░░░░░] 10%

#### Project 2
- 📝 Status: Not Started

  [░░░░░░░░░░] 0%

## 🚀 Setup Instructions
1. Prerequisites:
   - .NET 9.0 SDK
   - Visual Studio Code or Visual Studio 2022+

2. Clone the repository:
```bash
git clone https://github.com/DoubledDoge/itpca2-formative.git
```

3. Navigate to the solution directory:
```bash
cd itpca2-formative/src/Project\ 1
```

4. Restore dependencies:
```bash
dotnet restore Project1Solution.sln
```

5. Build the solution:
```bash
dotnet build Project1Solution.sln
```

## ⭐ Features
### Implemented
- Basic project structure for both systems
- CI/CD pipeline with GitHub Actions
- .NET 9.0 configuration

### Planned
- Hotel Reservation System features (Coming Soon)
- Bakery Management System features (Coming Soon)

## 🗺️ Roadmap
### Short-term Goals
- Implement core business logic for both systems
- Add unit tests
- Enhance documentation

### Long-term Goals
- Add database integration
- Implement user interface
- Add reporting functionality
- Begin Project 2 development

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
