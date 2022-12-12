create or alter procedure Sp_DeleteWishList
(
@WishListId bigint, @UserId bigint
)
as
--SQL Statement
delete from WishListTable where WishListId = @WishListId and UserId=@UserId;
go
