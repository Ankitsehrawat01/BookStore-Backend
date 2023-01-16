CREATE or ALTER PROCEDURE Sp_GetWishList
@UserId bigint
As
Begin

SELECT WishListId,UserId,b.BookId,b.Book_Name,b.Author_Name,
	b.Price, b.Discount_Price, b.Book_Image from WishListTable c join BookTable b on c.BookId=b.BookId 
WHERE UserId=@UserId;
END;

