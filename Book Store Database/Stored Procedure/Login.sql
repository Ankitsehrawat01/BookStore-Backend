CREATE or ALTER procedure Sp_Login
@Email_Id varchar(50), @Password varchar(100)
as
begin
select * from UserTable where Email_Id=@Email_Id and Password=@Password
END