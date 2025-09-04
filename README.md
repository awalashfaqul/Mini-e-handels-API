# Mini Optimizely CMS + Commerce + Experimentation API

This project is a simplified **e-commerce API** inspired by **Optimizely CMS + Commerce + Experimentation**.
It demonstrates how to manage a **product catalog, categories, shopping carts, orders, customers, memberships, notifications**, while also supporting **A/B testing (experiments)** and **personalized content delivery**.

Built with **ASP.NET Core Web API** using **InMemory Repositories** for fast prototyping.

---

## Features

* **Stage 1: Product Catalog** → Manage products
* **Stage 2: Categories** → Organize products into categories
* **Stage 3: Cart & Orders** → Add to cart, checkout, and create orders
* **Stage 4: Experimentation & Personalization**

  * Run **A/B experiments** for product or feature testing
  * Serve **personalized content** by customer segment
* **Stage 5: Customer Management** → Manage customer profiles
* **Stage 6: Membership Management** → Assign roles, loyalty tiers, and customer groups
* **Stage 7: Notification Service** → Send order updates and personalized messages

---

## Tech Stack

* **Backend:** ASP.NET Core Web API
* **Repositories:** InMemory storage (easily swappable for SQL DB)
* **API Documentation:** Swagger (auto-enabled in development)

---

## Setup

1. Clone this repository

   ```bash
   git clone https://github.com/awalashfaqul/Mini-e-handels-API.git
   cd Mini-e-handels-API
   ```

2. Run the API

   ```bash
   dotnet run
   ```

3. Open Swagger UI in browser

   ```
   https://localhost:5246/swagger
   ```

---

## API Endpoints (via Swagger)

### 1️⃣ Products

* **GET** `/api/Product` → Get all products
* **POST** `/api/Product` → Create new product

---

### 2️⃣ Categories

* **GET** `/api/Category` → Get all categories
* **POST** `/api/Category` → Add new category

---

### 3️⃣ Cart

* **POST** `/api/Cart/add` → Add product to cart
* **GET** `/api/Cart/{cartId}` → View cart

---

### 4️⃣ Orders

* **POST** `/api/Order` → Place order
* **GET** `/api/Order/{id}` → Get order by ID

---

### 5️⃣ Experiments (A/B Testing)

* **POST** `/api/Experiment` → Create new experiment
* **GET** `/api/Experiment/{id}` → Get experiment details
* **GET** `/api/Experiment/{id}/variant` → Get random variant

---

### 6️⃣ Personalization

* **POST** `/api/Personalization` → Add personalized content
* **GET** `/api/Personalization/{segment}` → Get content for a customer segment

---

### 7️⃣ Customer Management

* **POST** `/api/Customer` → Add new customer
* **GET** `/api/Customer/{id}` → Get customer details

---

### 8️⃣ Membership Management

* **POST** `/api/Membership` → Assign membership tier or role
* **GET** `/api/Membership/{customerId}` → Get customer’s membership

---

### 9️⃣ Notification Service

* **POST** `/api/Notification` → Send notification (email/SMS/in-app)
* **GET** `/api/Notification/{customerId}` → Get all notifications for a customer

---

## 🗄️ Database Schema (SQL Migration Draft)

```sql
-- Products
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(255),
    ProductPrice DECIMAL(18,2),
    ProductCategory NVARCHAR(255)
);

-- Categories
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(255)
);

-- Cart
CREATE TABLE Carts (
    CartId INT PRIMARY KEY IDENTITY,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE CartItems (
    CartItemId INT PRIMARY KEY IDENTITY,
    CartId INT FOREIGN KEY REFERENCES Carts(CartId),
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity INT
);

-- Orders
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    CartId INT FOREIGN KEY REFERENCES Carts(CartId),
    OrderDate DATETIME DEFAULT GETDATE()
);

-- Customers
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY,
    CustomerName NVARCHAR(255),
    Email NVARCHAR(255),
    Phone NVARCHAR(50)
);

-- Memberships
CREATE TABLE Memberships (
    MembershipId INT PRIMARY KEY IDENTITY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    Tier NVARCHAR(100), -- e.g., Bronze, Silver, Gold
    Role NVARCHAR(100), -- e.g., User, Admin
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Notifications
CREATE TABLE Notifications (
    NotificationId INT PRIMARY KEY IDENTITY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    Message NVARCHAR(500),
    SentAt DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) -- Sent, Delivered, Read
);

-- Experiments
CREATE TABLE Experiments (
    ExperimentId INT PRIMARY KEY IDENTITY,
    ExperimentName NVARCHAR(255),
    ExperimentVariantA NVARCHAR(255),
    ExperimentVariantB NVARCHAR(255)
);

-- Personalization
CREATE TABLE PersonalizedContents (
    PcId INT PRIMARY KEY IDENTITY,
    PcSegment NVARCHAR(100),
    PcMessage NVARCHAR(500)
);
```

---

## 🔮 Next Steps

* Build frontend landing page with React + Tailwind CSS
* Connect personalization & experimentation features to frontend
* Replace InMemory repositories with SQL or NoSQL persistence

---

## 📜 License

MIT License – free to use and modify.

---