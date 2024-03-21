﻿CREATE TABLE Products (
    Id BIGINT IDENTITY (1, 1) CONSTRAINT PK_Products_Id PRIMARY KEY,
    Name NVARCHAR(256) NOT NULL INDEX IX_Products_Name NONCLUSTERED,
    Description NVARCHAR(MAX) NOT NULL,
    Price DECIMAL (8, 3) NOT NULL,
    Created DATETIME2(2) NOT NULL CONSTRAINT DF_Products_Created DEFAULT GETDATE(),
    Updated DATETIME2(2) NOT NULL CONSTRAINT DF_Products_Updated DEFAULT GETDATE()
);