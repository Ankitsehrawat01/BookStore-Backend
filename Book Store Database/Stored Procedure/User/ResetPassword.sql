CREATE or ALTER procedure Sp_ResetPassword
@Email_Id varchar(50),
@Password varchar(100)
AS
BEGIN
	Update UserTable Set Password=@Password where Email_Id=@Email_Id
END