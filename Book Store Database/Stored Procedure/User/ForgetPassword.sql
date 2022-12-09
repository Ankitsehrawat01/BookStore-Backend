CREATE or ALTER PROCEDURE Sp_ForgetPassword
@Email_Id varchar(50)
AS
BEGIN
	SELECT * from UserTable where Email_Id=@Email_Id
END