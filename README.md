# 🛒 Payment System API

A secure and scalable **ASP.NET Core Web API** for e-commerce operations, featuring:

- 🔐 JWT-based authentication
- 🛍️ Product & cart management
- 💳 Stripe-based payments
- ☁️ AWS S3 image storage
- 📄 Swagger UI documentation

🔗 **Live Demo**: [Swagger UI](https://payment.cavidhuseynov.me/swagger/index.html)

---

## 🚀 Features

- **User Authentication**: Secure login & registration using ASP.NET Core Identity + JWT.
- **Product Management**: CRUD operations with image upload to AWS S3.
- **Shopping Cart**: Add, remove, and calculate cart totals.
- **Stripe Payments**: Secure payments with 3D Secure support.
- **AWS S3 Integration**: Upload and manage product images efficiently.
- **Swagger UI**: Explore and test endpoints interactively.

---

## 🧰 Technologies Used

| Layer         | Technology                         |
|--------------|-------------------------------------|
| Backend       | ASP.NET Core 8.0                    |
| Database      | SQL Server + Entity Framework Core |
| Auth          | JWT + ASP.NET Core Identity         |
| Payments      | Stripe                              |
| File Storage  | AWS S3                              |
| Validation    | FluentValidation                    |
| Mapping       | AutoMapper                          |
| Documentation | Swashbuckle (Swagger)               |

---

## 📦 Key NuGet Packages

- `AutoMapper` (v14.0.0)
- `AWSSDK.S3` (v3.7.305.23)
- `FluentValidation` (v11.11.0)
- `Stripe.net` (v48.0.2)
- `Microsoft.EntityFrameworkCore` (v8.0.15)
- `Microsoft.AspNetCore.Authentication.JwtBearer` (v8.0.15)
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (v8.0.15)
- `Swashbuckle.AspNetCore` (v6.6.2)

---

## ⚙️ Setup Instructions

### ✅ Prerequisites

- .NET 8.0 SDK
- SQL Server
- AWS S3 Account
- Stripe Account

### 🛠️ Configuration

Create `appsettings.json`:

```json
  "ConnectionStrings": {
    "Default": "Server=your-local-server;Database=EcommerceDb;Trusted_Connection=True;TrustServerCertificate=True;",
    "Deploy": "Server=your-deploy-server;Database=Payment;User Id=your-user;Password=your-password;TrustServerCertificate=True;"
  },
  "JWT": {
    "Audience": "ecommerce.cavidhuseynov.me",
    "Issuer": "ecommerce.cavidhuseynov.me",
    "SecurityKey": "your-jwt-security-key"
  },
  "AWS": {
    "AccessKeyId": "your-aws-access-key",
    "SecretAccessKey": "your-aws-secret-key",
    "EndPointUrl": "https://your-bucket.s3.your-region.amazonaws.com/Uploads",
    "BucketName": "your-bucket-name",
    "Region": "your-aws-region"
  },
  "Stripe": {
    "PublishableKey": "your-stripe-publishable-key",
    "SecretKey": "your-stripe-secret-key"
  },
  "AllowedHosts": "*"
}
