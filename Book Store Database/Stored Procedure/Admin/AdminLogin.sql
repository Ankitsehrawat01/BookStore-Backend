CREATE OR ALTER PROCEDURE Sp_AdminLogin
@Email_Id VARCHAR(50), @Password VARCHAR (100)
as
--SQL Statement
SELECT Email_Id,Password FROM AdminTable WHERE Email_Id= @Email_Id AND Password=@Password
go