Create or ALTER PROCEDURE Sp_AddOrder
	@UserId bigint,
	@AddressId bigint,
	@BookId bigint ,
	@BookQuantity bigint
AS
	Declare @TotPrice int
BEGIN
Select @TotPrice=Discount_Price from BookTable where BookId = @BookId;
	IF (EXISTS(SELECT * FROM BookTable WHERE bookId = @BookId))
	begin
		IF (EXISTS(SELECT * FROM UserTable WHERE UserId = @UserId))
		Begin
		Begin try
			Begin transaction			
				INSERT INTO OrderTable(UserId,AddressId,BookId,Totalprice,BookQuantity,OrderDate)
				VALUES ( @UserId,@AddressId,@BookId,@BookQuantity*@TotPrice,@BookQuantity,GETDATE())
				Update BookTable set Book_Quantity=Book_Quantity-@BookQuantity
				Delete from CartTable where BookId = @BookId and UserId = @UserId
				select * from OrderTable
			commit Transaction
		End try
		Begin catch
			Rollback transaction
		End catch
		end
		Else
		begin
			Select 1
		end
	end 
	Else
	begin
			Select 2
	end	
END
