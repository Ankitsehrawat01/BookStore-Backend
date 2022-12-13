CREATE OR ALTER PROCEDURE Sp_UpdateCart
(
	@CartId bigint, @Book_Quantity bigint 
)
as
UPDATE CartTable set Book_Quantity=@Book_Quantity where CartId=@CartId;
go
