CREATE or ALTER procedure Sp_AddBook
@Book_Name varchar(100), 
@Author_Name varchar(100), @Price bigint, @Description varchar(1000), @Rating varchar(100)
as
-- SQL statement
insert into BookTable values (@Book_Name, @Author_Name, @Price, @Description, @Rating )
go