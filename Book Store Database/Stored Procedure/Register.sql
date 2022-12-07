CREATE or ALTER procedure Sp_Register
@FullName varchar(100), @Email_Id varchar(50), @Password varchar(100), @Mobile_Number bigint
as
-- SQL statement
insert into UserTable values (@FullName, @Email_Id, @Password, @Mobile_Number)
go