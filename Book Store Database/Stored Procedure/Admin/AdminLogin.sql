CREATE OR ALTER PROCEDURE Sp_AdminLogin
@EmailId VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT Email_Id,Password FROM AdminTable WHERE Email_Id= @EmailId AND Password=@Password
END