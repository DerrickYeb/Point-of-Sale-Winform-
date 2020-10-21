CREATE TABLE [dbo].[Settings]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [LicensedNumber] NVARCHAR(MAX) NOT NULL, 
    [DateLicensed] DATE NOT NULL, 
    [Renewed] DATE NOT NULL, 
    [Phone] NVARCHAR(50) NOT NULL, 
    [Location] NCHAR(10) NOT NULL
)
