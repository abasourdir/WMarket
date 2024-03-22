CREATE OR ALTER PROCEDURE [dbo].[Orders_Insert]
	@DeliveryDate DATETIME2(2),
	@Status TINYINT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        INSERT INTO [dbo].[Orders] (DeliveryDate, Status)
        OUTPUT INSERTED.[Id]
        VALUES (@DeliveryDate, @Status)
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Orders_SetStatus]
	@Id BIGINT,
	@Status TINYINT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        UPDATE [dbo].[Orders]
        SET [Status] = @Status
        WHERE [Id] = @Id
    END
GO

CREATE OR ALTER PROCEDURE [dbo].[Orders_GetById]
	@Id BIGINT
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
        
        SELECT TOP (1)
            o.[Id],
                o.[DeliveryDate],
               o.[Status]
        FROM [dbo].[Orders] AS o
        WHERE o.[Id] = @Id
    END
GO