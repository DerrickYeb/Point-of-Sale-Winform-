CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[CustomerId] INT NOT NULL, 
	[Name] NVARCHAR(50) NOT NULL, 
	[Phone] NVARCHAR(50) NOT NULL, 
	[CeatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
	[CeatedBy] NVARCHAR(50) NOT NULL
)
