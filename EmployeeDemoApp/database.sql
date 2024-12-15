-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'cprg211mod9demo')
BEGIN
    CREATE DATABASE cprg211mod9demo;
END;

-- Use the database
USE cprg211mod9demo;

-- Create the table if it doesn't exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'employees')
BEGIN
    CREATE TABLE dbo.employees (
        id INT PRIMARY KEY,
        name NVARCHAR(255) NOT NULL,
        active TINYINT NOT NULL DEFAULT 0
    );
END;

-- Insert data into the table
INSERT INTO dbo.employees (id, name, active)
VALUES
    (1001, 'Mickey Mouse', 1),
    (1002, 'Donald Duck', 1),
    (1003, 'Goofy', 0),
    (1004, 'Pluto', 1),
    (1005, 'Cinderella', 0),
    (1006, 'Aladdin', 1),
    (1007, 'Snow White', 1),
    (1008, 'Belle', 1),
    (1009, 'Sleeping Beauty', 0),
    (1010, 'Peter Pan', 1);


-- Create the table if it doesn't exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'customers')
BEGIN
    CREATE TABLE dbo.customers (
        id INT PRIMARY KEY,
        name NVARCHAR(255) NOT NULL,
        service NVARCHAR(255) NOT NULL,
    );
END;

-- Insert data into the table
INSERT INTO dbo.customers (id, name, service)
VALUES
    (1001, 'Mickey Mouse', 1),
    (1002, 'Donald Duck', 1),
    (1003, 'Goofy', 0),
    (1004, 'Pluto', 1),
    (1005, 'Cinderella', 0),
    (1006, 'Aladdin', 1),
    (1007, 'Snow White', 1),
    (1008, 'Belle', 1),
    (1009, 'Sleeping Beauty', 0),
    (1010, 'Peter Pan', 1);