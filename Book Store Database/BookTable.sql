Create Table BookTable
(BookId bigint primary key identity(1,1), Book_Name varchar(100), 
Author_Name varchar(100), Price bigint, Description varchar(1000), Rating varchar(100))

ALTER Table BookTable add
Rating_Count bigint, Discount_Price bigint,
Book_Quantity bigint, Book_Image varchar(max) 

select * from BookTable