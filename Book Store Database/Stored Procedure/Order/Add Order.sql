GO
CREATE OR ALTER PROCEDURE Sp_AddOrder
		@CartId bigint,
		@AddressId bigint,
		@OrderDate Varchar(100),
		@UserId bigint
AS
	BEGIN try
		
		DECLARE @Order_Quantity bigint = (SELECT Book_Quantity FROM CartTable WHERE  CartId = @CartId)
		Declare @Quantity bigint = (SELECT Book_Quantity FROM BookTable bt Inner Join CartTable ct ON bt.BookId = ct.BookId WHERE ct.CartId = @CartId)
		DECLARE @BookId bigint = (SELECT bt.BookId FROM BookTable bt Inner Join CartTable ct ON bt.BookId = ct.BookId WHERE ct.CartId = @CartId)
		DECLARE @TotalPrice bigint = (SELECT Price FROM BookTable WHERE BookId = @BookId)
		IF (@Order_Quantity <= @Quantity)
		BEGIN
			INSERT INTO OrderTable
			(
				Order_Quantity, OrderDate, TotalPrice, BookId, UserId, AddressId, CartId)
			VALUES
			(
				@Order_Quantity, @OrderDate, @TotalPrice * @Order_Quantity, @BookId, @UserId, @AddressId, @CartId
			)
	BEGIN
		UPDATE CartTable
		SET Book_Quantity = Book_Quantity - @Order_Quantity
		WHERE BookId = @BookId
	END
	BEGIN
		DELETE FROM CartTable WHERE BookId = @BookId
	END
	END
	END try
	BEGIN catch
	END catch
