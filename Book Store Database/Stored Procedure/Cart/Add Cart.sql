CREATE or ALTER procedure Sp_AddtoCart
( 
  @Book_Quantity bigint, @UserId bigint, @BookId bigint
)
as
INSERT into CartTable(Book_Quantity,UserId,BookId) VALUES ( @Book_Quantity,@UserId, @BookId);
go
