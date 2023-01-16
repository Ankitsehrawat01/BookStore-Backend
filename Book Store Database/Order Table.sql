create table OrderTable(
OrderId bigint identity(1,1) not null primary key,
UserId bigint FOREIGN KEY (UserId) REFERENCES UserTable(UserId),
BookId bigint FOREIGN KEY (BookId) REFERENCES BookTable(bookId),
AddressId bigint FOREIGN KEY (AddressId) REFERENCES AddressTable(AddressId),
TotalPrice bigint,
BookQuantity bigint,
OrderDate Date);



