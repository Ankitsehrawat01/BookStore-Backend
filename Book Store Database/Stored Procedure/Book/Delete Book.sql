CREATE or ALTER procedure Sp_DeleteBook
@BookId bigint
as
--SQL Statement
DELETE FROM BookTable where BookId=@BookId
go