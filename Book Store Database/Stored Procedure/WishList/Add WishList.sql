CREATE or ALTER PROCEDURE AddWishList
(@UserId bigint,@BookId bigint)
As
BEGIN
 INSERT INTO WishListTable (UserId, BookId)VALUES (@UserId,@BookId);
END;