CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[Supplier] NVARCHAR(50) NOT NULL, 
	[Product] Nvarchar(50) not null,
	[Phone] NVARCHAR(50) NOT NULL, 
	[Location] NVARCHAR(50) NOT NULL, 
	[CeatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
	[CeatedBy] NVARCHAR(50) NOT NULL
)