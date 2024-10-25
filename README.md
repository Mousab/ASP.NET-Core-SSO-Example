# ASP.NET Core SSO Example

This repository provides an example of implementing **Single Sign-On (SSO)** between two ASP.NET Core 8 applications using **cookie-based authentication**. The goal is to allow seamless user authentication between two separate applications.

## Applications in this Repository

### FirstApp
The **Primary Authentication Application** (FirstApp) is responsible for user authentication using ASP.NET Core Identity. It creates a shared cookie that is accessible to the secondary application, enabling SSO.

### SecondApp
The **Secondary Application** (SecondApp) is configured to recognize the shared cookie created by the Primary Application. When a user accesses the SecondApp and is not authenticated, they will be redirected to the login page in the FirstApp. After logging in, the user will be returned to the originally requested page in the SecondApp.

## Features
- **Cross-domain SSO with Cookie Authentication**: Secure user authentication across two applications.
- **ASP.NET Core Identity**: Used in FirstApp to manage user accounts and create shared cookies.
- **Seamless Redirection**: Users are redirected to the FirstApp login page when accessing protected routes in SecondApp, then returned to their original destination.

## Setup and Usage
### Prerequisites
- .NET Core SDK 8.0 or later
- SQL Server or other compatible database

### Setup
1. **Clone the Repository**: 
   ```bash
   git clone https://github.com/YourUsername/ASP.NET-Core-SSO-Example.git
   cd ASP.NET-Core-SSO-Example
