CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR (128) NOT NULL PRIMARY KEY,
	[FirstName] VARCHAR (50) NOT NULL,
	[SurName] VARCHAR (50) NOT NULL,
	[Username] VARCHAR(256) NOT NULL ,
	[Role] VARCHAR (50) NOT NULL, 
	[Password] NVARCHAR(50) NOT NULL,
	[CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(),
	[LastActive] DATETIME2 NOT NULL DEFAUlT getutcdate()
   
)
