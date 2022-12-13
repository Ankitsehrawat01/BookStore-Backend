CREATE TABLE AddressTable
(
	AddressId bigint identity(1,1) primary key,
	Address varchar(Max),
	City varchar(100),
	State varchar(100),
	TypeId bigint foreign key (TypeId) references TypeTable(TypeId),
	UserId bigint foreign key (UserId) references UserTable(UserId)
)