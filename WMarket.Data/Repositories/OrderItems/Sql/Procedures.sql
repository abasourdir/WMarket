CREATE OR ALTER PROCEDURE [dbo].[OrderItems_Insert]
	@ProductId BIGINT,
	@OrderId BIGINT,
	@Quantity INT,
	@Price DECIMAL (8, 3)
AS
    BEGIN
        SET NOCOUNT, XACT_ABORT ON;
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        
        INSERT INTO [dbo].[OrderItems] (ProductId, OrderId, Quantity, Price)
        VALUES (@ProductId, @OrderId, @Quantity, @Price)
    END
GO