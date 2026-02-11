

# 📌 Playwright Automation Framework

### (.NET 8 + Playwright + Reqnroll + NUnit + Extent Reports)

---

## 🚀 Overview

This is a scalable and maintainable UI automation framework built using:

* **.NET 8**
* **Microsoft Playwright**
* **Reqnroll (BDD)**
* **NUnit**
* **FluentAssertions**
* **ExtentReports**
* **Page Object Model (POM)**

The framework supports:

* BDD feature files
* Parallel-ready structure
* Screenshot after every step
* Extent HTML reporting
* Config-driven setup
* Random test data generation
* Clean GitHub-ready structure

---

# 🛠 Prerequisites

Install the following:

### 1️⃣ .NET 8 SDK

Download:
[https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

Verify:

```
dotnet --version
```

---

### 2️⃣ Playwright Browsers (VERY IMPORTANT)

After cloning the project, run:

```
pwsh bin/Debug/net8.0/playwright.ps1 install
```

OR

```
dotnet build
pwsh bin/Debug/net8.0/playwright.ps1 install
```

This installs:

* Chromium
* Firefox
* WebKit

⚠ This must be done once after cloning.

---

### 3️⃣ Visual Studio 2022/2026 (Recommended)

Install:

* .NET desktop development
* NUnit Test Adapter (comes via NuGet)

---

# 📂 Project Structure

```
Config/          → appsettings.json
Drivers/         → PlaywrightDriver
Hooks/           → Test lifecycle hooks
Pages/           → Page Object Model classes
Steps/           → Step Definitions
Utilities/       → Random data generator
Reporting/       → ExtentReports manager
Features/        → .feature files
```

---

# ⚙ Configuration

Browser and settings are controlled via:

```
Config/appsettings.json
```

Example:

```json
{
  "Browser": "chromium",
  "Headless": false
}
```

You can change:

* chromium
* firefox
* webkit

---

# ▶ How to Run Tests

## Option 1 — From Visual Studio

1. Open solution
2. Build project
3. Open **Test Explorer**
4. Click **Run All**

---

## Option 2 — From Command Line

Navigate to project root:

```
dotnet test
```

---

## Option 3 — Run Specific Test

```
dotnet test --filter "FullyQualifiedName~CreateNewUserAndVerifyLogin"
```

---

# 📸 Screenshots

Screenshots are automatically captured:

After every step:

```
TestResults/StepScreenshots/
```

After scenario:

```
TestResults/Screenshots/
```

---

# 📊 Extent HTML Report

Generated at:

```
TestResults/ExtentReport.html
```

Open this file in browser after execution.

Report includes:

* Step logs
* Screenshots
* Pass/Fail status
* Execution time

---

# 🧪 BDD Example

Feature file:

```
Feature: User Signup and Login

Scenario: Create new user and verify login
    Given User navigates to signup page
    When User enters name and email
    And User completes account registration
    Then User should be logged in successfully
```

---

# 🔥 Framework Features

* ✔ Page Object Model
* ✔ Centralized browser driver
* ✔ Scenario hooks
* ✔ Thread-safe reporting
* ✔ Automatic screenshots
* ✔ Fluent assertions
* ✔ Config-driven browser selection
* ✔ Random test data utility
* ✔ Clean GitHub-ready structure
* ✔ Build artifacts excluded via .gitignore

---

# 🧼 Git Best Practices Used

Ignored:

```
bin/
obj/
.vs/
TestResults/
.playwright/
```

Ensures clean repository.

---

# 🚀 Future Improvements (Optional)

* Parallel execution
* Docker container support
* GitHub Actions CI/CD
* Azure DevOps pipeline
* Allure reporting integration
* API automation integration

---

# 👨‍💻 Author

Sai Chaitanya
Automation Engineer

---

# ⭐ How to Clone & Setup

```
git clone https://github.com/saichaitanya292/PlaywrightAutomationFramework.git
cd PlaywrightAutomationFramework
dotnet build
pwsh bin/Debug/net8.0/playwright.ps1 install
dotnet test
```

