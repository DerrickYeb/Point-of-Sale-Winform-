CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ProductCode] INT NOT NULL,
	[ProductName] NVARCHAR (100) NOT NULL,
	[Category] NVARCHAR (100) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[ProductUnit] INT NOT NULL,
	[CostPrice] MONEY NOT NULL,
	[RetailPrice] MONEY NOT NULL,
	[Supplier] NVARCHAR (100) NOT NULL,
	[CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
