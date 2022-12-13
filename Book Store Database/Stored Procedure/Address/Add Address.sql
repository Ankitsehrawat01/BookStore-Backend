CREATE OR ALTER PROCEDURE Sp_AddAddress
		@Address varchar(max),
		@City varchar(100),
		@State varchar(100),
		@TypeId bigint,
		@UserId bigint
as
INSERT into AddressTable(Address,City,State,TypeId,UserId)values(@Address,@City,@State,@TypeId,@UserId)
go