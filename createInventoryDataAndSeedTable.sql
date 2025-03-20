-- Create the Inventory database
CREATE DATABASE Inventory;
GO

USE Inventory;
GO

-- Create InventoryItems table
CREATE TABLE InventoryItems (
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    Quantity INT NOT NULL DEFAULT 0,
    Price DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    ProductCategory NVARCHAR(50) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Insert seed data into InventoryItems table
INSERT INTO InventoryItems (Name, Description, Quantity, Price, ProductCategory)
VALUES
    ('Laptop', 'Dell XPS 15 - High Performance Laptop', 10, 1500.00, 'Electronics'),
    ('Desk Chair', 'Ergonomic office chair with lumbar support', 20, 200.00, 'Furniture'),
    ('Notebook', 'College-ruled notebook - 200 pages', 50, 5.99, 'Stationery'),
    ('Smartphone', 'Samsung Galaxy S22 - 128GB Storage', 15, 899.99, 'Electronics'),
    ('Desk Lamp', 'LED desk lamp with adjustable brightness', 25, 29.99, 'Furniture'),
    ('Printer', 'HP LaserJet Pro - Wireless Printer', 8, 250.00, 'Electronics'),
    ('Whiteboard', 'Magnetic whiteboard - 3ft x 4ft', 12, 79.99, 'Office Supplies'),
    ('Backpack', 'Laptop backpack with USB charging port', 30, 49.99, 'Accessories');
GO