CREATE TABLE OrderItems (
    Id BIGINT IDENTITY (1, 1) CONSTRAINT PK_OrderItems_Id PRIMARY KEY,
    ProductId BIGINT NOT NULL,
    OrderId BIGINT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL (8, 3) NOT NULL,
    CONSTRAINT FK_OrderItems_Products_ProductId FOREIGN KEY (ProductId) REFERENCES [dbo].[Products] (Id),
    CONSTRAINT FK_OrderItems_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES [dbo].[Orders] (Id)
);  