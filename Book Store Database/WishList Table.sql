Create table WishListTable
(
	WishListId bigint identity(1,1) not null primary key,
	UserId bigint foreign key references UserTable(UserId),
	BookId bigint foreign key references BookTable(BookId)
);

select * from UserTable