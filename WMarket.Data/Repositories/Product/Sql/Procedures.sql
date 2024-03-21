CREATE OR ALTER PROCEDURE [dbo].[Products_Insert]
    @Name NVARCHAR (256),
    @Description NVARCHAR (MAX),
    @Price DECIMAL (8, 3)
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        INSERT INTO [dbo].[Products] (Name, Description, Price)
        OUTPUT INSERTED.[Id]
        VALUES (@Name, @Description, @Price)
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Products_GetPaged]
    @Limit INT,
    @Offset INT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
        
        SELECT p.[Name],
               p.[Description],
               p.[Price]
        FROM [dbo].[Products] AS p
        ORDER BY p.[Id]
        OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
    END
GO