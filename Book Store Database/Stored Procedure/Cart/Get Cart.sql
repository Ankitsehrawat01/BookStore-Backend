CREATE or ALTER procedure Sp_GetCart
@UserId bigint

as
select * from CartTable where UserId=@UserId;
go