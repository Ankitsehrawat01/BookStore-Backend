CREATE or ALTER procedure Sp_AddBook
@Book_Name varchar(100), 
@Author_Name varchar(100), @Price bigint, @Description varchar(1000), @Rating varchar(100), @Rating_Count bigint,
@Discount_Price bigint, @Book_Quantity bigint, @Book_Image varchar(max)
as
-- SQL statement
insert into BookTable values (@Book_Name, @Author_Name, @Price, @Description, @Rating, @Rating_Count, @Discount_Price, @Book_Quantity,
@Book_Image)
go

exec Sp_AddBook  "React Material-UI", "Steve Krug", 2500, "Its a good Book", "4.1", 10, 1500, 10, "vree"
