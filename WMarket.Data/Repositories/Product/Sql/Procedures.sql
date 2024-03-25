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

CREATE OR ALTER PROCEDURE [dbo].[Products_SearchByName]
    @Name NVARCHAR (256),                      
    @Limit INT,
    @Offset INT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
        
        SELECT p.[Id],
               p.[Name],
               p.[Description],
               p.[Price]
        FROM [dbo].[Products] AS p
        WHERE @Name IS NULL OR p.[Name] LIKE '%' + @Name + '%'
        ORDER BY p.[Id]
        OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Products_Update]
    @Id BIGINT,
	@Name NVARCHAR (256) = NULL,
    @Description NVARCHAR (MAX) = NULL,
    @Price DECIMAL (8, 3) = NULL
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        UPDATE [dbo].[Products]
        SET [Name] = COALESCE(@Name, @Name, [Name]),
            [Description] = COALESCE(@Description, @Description, [Description]),
            [Price] = COALESCE(@Price, @Price, [Price])
        OUTPUT INSERTED.[Id],
               INSERTED.[Name],
               INSERTED.[Description],
               INSERTED.[Price]
        WHERE [Id] = @Id
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Products_Delete]
	@Id BIGINT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        DELETE
        FROM [dbo].[Products]
        OUTPUT DELETED.[Id]
        WHERE Id = @Id
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Products_GetById]
	@Id BIGINT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
        
        SELECT TOP (1)
            p.[Id],
                p.[Name],
               p.[Description],
               p.[Price]
        FROM [dbo].[Products] AS p
        WHERE p.[Id] = @Id
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Products_GetByIds]
	@Ids AS [dbo].[BigIntList] READONLY
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
        
        SELECT TOP (1)
                p.[Id],
                p.[Name],
                p.[Description],
                p.[Price]
        FROM [dbo].[Products] AS p
        INNER JOIN @Ids i ON i.[Value] = p.[Id]
    END
GO