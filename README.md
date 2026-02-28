# 🏦 Insurance Policy Management System

A console-based insurance management system built with C# following SOLID principles, layered architecture, and unit testing best practices.

---

 🚀 Features

- Create Car Insurance Policies
- Create Health Insurance Policies
- View All Policies
- Submit Insurance Claims
- Premium Calculation Logic
- Business Rule Validation
- Custom Exception Handling
- Unit Testing for Core Business Logic

---

 🏗 Architecture

The project follows a clean layered architecture:

### 📁 Layers

- **Models**  
  Business entities (Policy, CarInsurancePolicy, HealthInsurancePolicy, Claim, RiskLevel)

- **Services**  
  Business logic layer (PolicyService)

- **Data**  
  Generic Repository pattern for data abstraction

- **Exceptions**  
  Custom validation exceptions

- **Program.cs**  
  Presentation layer (Console UI)

- **Tests Project**  
  xUnit-based Unit Tests covering business rules and validations

---

## 🧪 Unit Testing

The project includes a dedicated test project using **xUnit**.

### Covered Scenarios:

- Premium calculation validation
- Invalid driver age handling
- Invalid health policy age handling
- Coverage validation
- Claim amount exceeding coverage
- Successful claim submission behavior

Unit tests ensure business rules remain stable and prevent regression bugs during future modifications.

---

## 🧠 SOLID Principles Applied

- **S – Single Responsibility Principle**  
  Each class has a clear and focused responsibility.

- **O – Open/Closed Principle**  
  Policies can be extended without modifying existing logic.

- **L – Liskov Substitution Principle**  
  Car and Health policies can be used through the base Policy abstraction.

- **I – Interface Segregation Principle**  
  Services depend on clear and focused interfaces.

- **D – Dependency Inversion Principle**  
  High-level modules depend on abstractions (IPolicyService).

---

## 🛠 Technologies Used

- C#
- .NET
- Object-Oriented Programming (OOP)
- Repository Pattern
- xUnit Testing Framework
- Custom Exception Handling

---

## ▶ How to Run

1. Clone the repository
2. Open in Visual Studio
3. Run the main project to start the Console application
4. Run the test project to execute all unit tests

---

## 📌 Future Improvements

- Add Database Integration
- Implement Dependency Injection Container
- Convert to ASP.NET Core Web API
- Add Integration Tests
- Implement Logging
- Increase Test Coverage
