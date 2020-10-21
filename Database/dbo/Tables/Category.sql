CREATE TABLE [dbo].[Category]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] NVARCHAR(50) NOT NULL, 
    [CeatedAt] DATETIME2 NOT NULL  DEFAULT getutcdate()
)