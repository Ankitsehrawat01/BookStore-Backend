CREATE or ALTER procedure Sp_AddtoCart
--( 
--  @Book_Quantity bigint, @UserId bigint, @BookId bigint
--)
--as
--INSERT into CartTable(Book_Quantity,UserId,BookId) VALUES ( @Book_Quantity,@UserId, @BookId);
--go

(
@UserId bigint,@BookId bigint,@Book_Quantity bigint
)
as
begin
IF (EXISTS(SELECT * FROM BookTable WHERE BookId=@BookId))		
	begin
		INSERT INTO CartTable(UserId,BookId)
		VALUES (@UserId,@BookId)
	end
	else
	begin 
		select 2
	end
SET NOCOUNT ON;
END
