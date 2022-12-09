CREATE or ALTER procedure Sp_GetBookbyId
@BookId bigint
as
-- SQL statement
SELECT *FROM BookTable where BookId=@BookId
go