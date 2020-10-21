CREATE PROCEDURE [dbo].[spSettings]
	
AS
Begin
	Select [Name],LicensedNumber,DateLicensed,Renewed,Phone from Settings
End
