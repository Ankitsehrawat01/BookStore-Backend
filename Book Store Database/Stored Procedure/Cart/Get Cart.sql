CREATE or ALTER procedure Sp_GetCart
@UserId bigint
as
begin
SELECT p.Book_Name, p.Author_Name,p.Price,p.Discount_Price,p.Book_Image,p.bookId,
       s.Book_Quantity,s.CartId,s.UserId
FROM BookTable AS p
INNER JOIN CartTable AS s ON p.bookId=s.BookId
WHERE UserId=@UserId;
SET NOCOUNT ON;
END