# Currency Converter API

A simple ASP.NET Core Web API that converts currency amounts using exchange rates stored in a local JSON file with optional environment variable overrides.

---

## 🚀 Features

- Convert currency using predefined exchange rates  
- Supports environment variable overrides for rates  
- Reads exchange rates from JSON file  
- 🔄 Dynamic Configuration: Exchange rates can be updated without restarting the application (changes in JSON file are reflected immediately on next API request)  
- Swagger UI for easy testing  
- Structured logging using ILogger  

---

## ✨ Key Highlight

### 🔄 Dynamic Configuration
The application supports dynamic updates of exchange rates. Any changes made to the `exchangeRate.json` file are immediately reflected in the API response without requiring an application restart.

---

## 🛠️ Tech Stack

- ASP.NET Core Web API (.NET 6/7/8)  
- C#  
- Swagger (Swashbuckle)  
- System.Text.Json  

---

## 📦 Prerequisites

Make sure you have installed:

- .NET SDK (6.0 or later)  
- Visual Studio 2022 / VS Code  
- Git (optional)  

Check .NET version:

```bash
dotnet --version