CREATE OR ALTER PROCEDURE Sp_DeleteAddress
@AddressId bigint
as
	DELETE from AddressTable where AddressId = @AddressId;
go