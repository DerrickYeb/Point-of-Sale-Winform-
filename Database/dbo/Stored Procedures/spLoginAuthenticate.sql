CREATE PROCEDURE [dbo].[spLoginAuthenticate]
	@id nvarchar(128)
	
AS
Begin
	SELECT FirstName,SurName,Username,[Role],LastActive
	from [dbo].[User]
	where Id =@id
end
