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

CREATE OR ALTER PROCEDURE [dbo].[Products_Update]
    @Id BIGINT,
	@Name NVARCHAR (256),
    @Description NVARCHAR (MAX),
    @Price DECIMAL (8, 3)
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        UPDATE [dbo].[Products]
        SET [Name] = @Name,
            [Description] = @Description,
            [Price] = @Price
            OUTPUT INSERTED.[Id],
            INSERTED.[Name],
            INSERTED.[Description],
            INSERTED.[Price]
        WHERE [Id] = @Id
    END
GO