CREATE or ALTER PROCEDURE Sp_AddWishList
(@UserId bigint,@BookId bigint)
as
--SQL Statement
 INSERT into WishListTable values (@UserId,@BookId);
go