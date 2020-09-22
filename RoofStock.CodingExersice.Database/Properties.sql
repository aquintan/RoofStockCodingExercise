CREATE TABLE [dbo].[Properties]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Address] VARCHAR(200) NULL, 
    [YearBuilt] INT NULL, 
    [ListPrice] DECIMAL(18, 5) NULL, 
    [MonthlyRent] DECIMAL(18, 5) NULL 
)