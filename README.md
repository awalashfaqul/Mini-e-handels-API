# Mini Optimizely CMS + Commerce + Experimentation API

This project is a simplified **e-commerce API** inspired by **Optimizely CMS + Commerce + Experimentation**. It demonstrates how to manage a product catalog, categories, shopping carts, and orders, while also supporting **A/B testing (experiments)** and **personalized content** delivery.

Built with **ASP.NET Core Web API** using **InMemory Repositories** for fast prototyping.

---

## Features

* **Stage 1: Product Catalog** → Manage products
* **Stage 2: Categories** → Organize products into categories
* **Stage 3: Cart & Orders** → Add to cart, checkout, and create orders
* **Stage 4: Experimentation & Personalization**

  * Run **A/B experiments** for product or feature testing
  * Serve **personalized content** by customer segment

---

## 🛠️ Tech Stack

* **Backend:** ASP.NET Core Web API
* **Repositories:** InMemory storage (easily swappable for DB)
* **API Documentation:** Swagger (auto-enabled in development)

---

## ⚙️ Setup

1. Clone this repository

   ```
   git clone https://github.com/awalashfaqul/Mini-e-handels-API.git
   cd Mini-e-handels-API
   ```

2. Run the API

   ```
   dotnet run
   ```

3. Open Swagger UI in browser

   ```
   https://localhost:5246/swagger
   ```
   or
   ```
   https://localhost:5001/swagger
   ```

---

## 📌 API Endpoints (via Swagger)

### 1️⃣ Products

* **GET** `/api/Product` → Get all products
* **POST** `/api/Product` → Create new product

**Swagger Example (POST)**

```json
{
  "productName": "Laptop",
  "productPrice": 1200,
  "productCategory": "Electronics"
}
```

---

### 2️⃣ Categories

* **GET** `/api/Category` → Get all categories
* **POST** `/api/Category` → Add new category

**Swagger Example (POST)**

```json
{
  "categoryName": "Electronics"
}
```

---

### 3️⃣ Cart

* **POST** `/api/Cart/add` → Add product to cart
* **GET** `/api/Cart/{cartId}` → View cart

**Swagger Example (POST)**

```json
{
  "cartId": 1,
  "productId": 101,
  "quantity": 2
}
```

---

### 4️⃣ Orders

* **POST** `/api/Order` → Place order
* **GET** `/api/Order/{id}` → Get order by ID

**Swagger Example (POST)**

```json
{
  "orderId": 1,
  "customerName": "Alice",
  "cartId": 1
}
```

---

### 5️⃣ Experiments (A/B Testing)

* **POST** `/api/Experiment` → Create new experiment
* **GET** `/api/Experiment/{id}` → Get experiment details
* **GET** `/api/Experiment/{id}/variant` → Get random variant (A or B)

**Swagger Example (POST)**

```json
{
  "experimentName": "Homepage Banner Test",
  "experimentVariantA": "Blue Banner",
  "experimentVariantB": "Red Banner"
}
```

---

### 6️⃣ Personalization

* **POST** `/api/Personalization` → Add personalized content
* **GET** `/api/Personalization/{segment}` → Get content for a customer segment

**Swagger Example (POST)**

```json
{
  "pcSegment": "VIP",
  "pcMessage": "Welcome back VIP! Enjoy 10% discount"
}
```

---

## Database Schema (Draft for SQL Migration)

When moving away from InMemory, a **SQL schema** could look like this:

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
    CustomerName NVARCHAR(255),
    CartId INT FOREIGN KEY REFERENCES Carts(CartId),
    OrderDate DATETIME DEFAULT GETDATE()
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

## 🔮 Next Steps (Planned)
* Add persistent database (SQL or NoSQL) instead of InMemory repositories.
* Build frontend landing page with:
** React + Tailwind CSS (primary)
** Bootstrap (optional if needed)
* Pages: Home, Products, Category, Shopping Cart, Order.
* Connect personalization & experimentation features to frontend.

---

## License

MIT License – free to use and modify.

---
