CREATE or ALTER PROCEDURE Sp_GetWishList
  @UserId bigint
AS
	   select 
		BooksTable.BookId,BooksTable.Book_Name,BooksTable.Author_Name,BooksTable.Price,BooksTable.Description,
		BooksTable.Rating,WishlistTable.WishlistId,WishlistTable.UserId,WishlistTable.BookId
		FROM Books
		inner join WishlistTable
		on WishlistTable.BookId=BooksTable.BookId where WishlistTable.UserId=@UserId
		
go