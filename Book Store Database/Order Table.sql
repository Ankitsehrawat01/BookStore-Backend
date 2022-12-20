CREATE TABLE OrderTable
(OrderId bigint primary key identity(1,1),
Order_Quantity bigint, 
OrderDate Varchar(100), TotalPrice bigint,
BookId bigint foreign key (BookId ) references BookTable(BookId),
UserId bigint foreign key (UserId) references UserTable(UserId),
AddressId bigint foreign key references AddressTable(AddressId),
CartId bigint foreign key references CartTable(CartId) )

