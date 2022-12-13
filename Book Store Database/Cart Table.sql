Create Table CartTable
(
CartId bigint identity(1,1) primary key,
Book_Quantity bigint default 1,
UserId bigint foreign key (UserId) references UserTable(UserId),
BookId bigint Foreign key (BookId) references BookTable(BookId)
);