CREATE or ALTER PROCEDURE Sp_UpdateAddres
		@AddressId int,
		@Address varchar(Max),
		@City varchar(100),
		@State varchar(100)
as
UPDATE AddressTable SET Address = @Address,City = @City, State = @State
WHERE AddressId = @AddressId
go