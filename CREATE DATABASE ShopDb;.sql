--CREATE DATABASE ShopDb;
USE ShopDb;
/*
CREATE TABLE dbo.ShopProducts (
    ID BIGINT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(200),
    StartOfPrice DATETIME NOT NULL,
    [Image] NVARCHAR(200)
);
*/
SELECT * from dbo.ShopProducts;
/*
  INSERT INTO ShopProducts (Code, [Name], [Description], StartOfPrice, [Image])
    VALUES ('rtt', 'Name', 'Description', '2024-03-07', 'c:\tr|txt');
*/
GO
/*
CREATE PROCEDURE dbo.stp_GetAllProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ID, Code, [Name], [Description], StartOfPrice, [Image]
    FROM ShopProducts;
END;
*/
EXECUTE stp_GetAllProducts