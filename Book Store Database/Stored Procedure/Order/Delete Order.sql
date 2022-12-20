GO
CREATE or ALTER PROCEDURE Sp_DeleteOrder
		@OrderId bigint
AS
	BEGIN
	DECLARE @Order_Quantity bigint = (SELECT Order_Quantity FROM OrderTable WHERE OrderId = @OrderId)
	DECLARE @BookId bigint = (SELECT BookId FROM OrderTable WHERE OrderId = @OrderId)
		BEGIN
			UPDATE CartTable
			SET Book_Quantity = Book_Quantity + @Order_Quantity
			WHERE BookId = @BookId
		END
		BEGIN
			DELETE FROM OrderTable
			WHERE OrderId = @OrderId
		END
	END