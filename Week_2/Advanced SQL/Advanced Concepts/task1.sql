CREATE TABLE Products (
    ProductID INT,
    ProductName VARCHAR(50),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO Products VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 800.00),
(4, 'TV', 'Electronics', 600.00),
(5, 'Sofa', 'Furniture', 700.00),
(6, 'Chair', 'Furniture', 150.00),
(7, 'Desk', 'Furniture', 300.00),
(8, 'Bed', 'Furniture', 700.00);

# Using ROW_NUMBER()
SELECT * FROM (
    SELECT 
        ProductID, 
        ProductName, 
        Category, 
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS RowNum
    FROM Products
) AS ranked
WHERE RowNum <= 3;

# Using RANK()
SELECT * FROM (
    SELECT 
        ProductID, 
        ProductName, 
        Category, 
        Price,
        RANK() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS RankNum
    FROM Products
) AS ranked
WHERE RankNum <= 3;

# Using DENSE_RANK()
SELECT * FROM (
    SELECT 
        ProductID, 
        ProductName, 
        Category, 
        Price,
        DENSE_RANK() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS DenseRankNum
    FROM Products
) AS ranked
WHERE DenseRankNum <= 3;
