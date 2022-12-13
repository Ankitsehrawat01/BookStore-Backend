CREATE OR ALTER PROCEDURE Sp_DeleteCart
@CartId bigint
as
	DELETE from CartTable where CartId = @CartId;
go