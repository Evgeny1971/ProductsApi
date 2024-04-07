CREATE DATABASE ShopDb;
GO;

CREATE TABLE dbo.ShopProducts (
    ID BIGINT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(200),
    StartOfPrice DATETIME NOT NULL,
    [Image] NVARCHAR(200)
);
 GO;
 CREATE PROCEDURE dbo.stp_CreateShopProduct
    @Code NVARCHAR(50),
    @Name NVARCHAR(100),
    @Description NVARCHAR(200),
    @StartOfPrice DATETIME,
    @Image NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ShopProducts (Code, [Name], [Description], StartOfPrice, [Image])
    VALUES (@Code, @Name, @Description, @StartOfPrice, @Image);

    SELECT SCOPE_IDENTITY() AS ID;
END;
GO;
CREATE PROCEDURE dbo.stp_GetAllProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ID, Code, [Name], [Description], StartOfPrice, [Image]
    FROM ShopProducts;
END;
GO;
CREATE PROCEDURE dbo.stp_GetShopProductById
    @ID BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ID, Code, [Name], [Description], StartOfPrice, [Image]
    FROM ShopProducts
    WHERE ID = @ID;
END;
GO;
CREATE PROCEDURE dbo.stp_UpdateShopProduct
    @ID BIGINT,
    @Code NVARCHAR(50),
    @Name NVARCHAR(100),
    @Description NVARCHAR(200),
    @StartOfPrice DATETIME,
    @Image NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ShopProducts
    SET
        Code = @Code,
        [Name] = @Name,
        [Description] = @Description,
        StartOfPrice = @StartOfPrice,
        [Image] = @Image
    WHERE ID = @ID;
END;
