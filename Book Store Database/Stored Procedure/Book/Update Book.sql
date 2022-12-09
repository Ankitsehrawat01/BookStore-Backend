CREATE or ALTER procedure Sp_UpdateBook
@BookId bigint, @Book_Name varchar(100), 
@Author_Name varchar(100), @Price bigint, @Description varchar(1000), @Rating varchar(100)
as
-- SQL statement
UPDATE BookTable set
Book_Name=@Book_Name, Author_Name=@Author_Name, Price=@Price, Description=@Description, Rating=@Rating
WHERE BookId=@BookId
go