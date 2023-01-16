CREATE or ALTER procedure Sp_UpdateBook
@BookId bigint, @Book_Name varchar(100), 
@Author_Name varchar(100), @Price bigint, @Description varchar(1000), @Rating varchar(100), @Rating_Count bigint,
@Discount_Price bigint, @Book_Quantity bigint, @Book_Image varchar(max)
as
-- SQL statement
UPDATE BookTable set
Book_Name=@Book_Name, Author_Name=@Author_Name, Price=@Price, Description=@Description, Rating=@Rating,
Rating_Count =@Rating_Count, Discount_Price = @Discount_Price, Book_Quantity = @Book_Quantity, Book_Image = @Book_Image
WHERE BookId=@BookId
go