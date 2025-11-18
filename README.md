```markdown
# Name Sorter – Installation & Quick Start Guide

This repository contains a .NET console application that reads a list of names, sorts them by surname (then by given names), prints the results to the console, and writes them to `sorted-names-list.txt`.

The full Dye & Durham Coding Assessment specification is included in:

`/Documents/Assessment-Specification.pdf`

This README focuses on helping the reviewer **build, install, and run the tool quickly**.

---

## 📦 Prerequisites

- .NET 8 SDK  
  https://dotnet.microsoft.com/download

---

## 🚀 1. Build the solution

```bash
dotnet build
```

---

## 🛠️ 2. Install the tool (recommended)

This project is packaged as a **.NET Global Tool**, allowing it to be executed exactly as the assessment requires:

```bash
name-sorter ./unsorted-names-list.txt
```

### **Option A — Automatic installation (recommended)**

From the repository root:

#### **Windows**
```powershell
.\install-tool.ps1
```

#### **macOS / Linux**
```bash
./install-tool.sh
```

These scripts will:

- Build the solution  
- Pack the console app as a local NuGet tool  
- Install (or update) the global tool named `name-sorter`  
- Make it available everywhere on your system  

---

### **Option B — Manual installation**

```bash
dotnet pack NameSorter.ConsoleApp -c Release
dotnet tool install --global name-sorter --add-source ./NameSorter.ConsoleApp/bin/Release
```

---

## ▶️ 3. Run the tool

After installation, execute from *any* folder:

```bash
name-sorter ./unsorted-names-list.txt
```

This will:

- Print sorted names to the console  
- Write `sorted-names-list.txt` to the current working directory  

---

## 🧪 4. Unit Tests

Run tests:

```bash
dotnet test
```

All parsing and sorting logic is fully tested using **xUnit**.

---

## 📁 Project Structure

```
NameSorter/
│
├── NameSorter.ConsoleApp/      # Console application + entry point
├── NameSorter.Core/            # Models, services, business logic (SOLID)
├── NameSorter.Tests/           # Unit tests (xUnit)
├── Documents/                  # Assessment specification
├── install-tool.ps1            # Windows install helper
└── install-tool.sh             # macOS/Linux install helper
```

---

## 🎯 What This Project Demonstrates

- Clean, maintainable architecture (SOLID)
- Separation of parsing, sorting & IO concerns  
- Unit-tested core logic  
- Dependency Injection  
- XML-documented public API  
- CI-ready structure  
- Global tool packaging for frictionless execution  

---
```
