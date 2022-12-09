create Table UserTable 
(UserId bigint primary key identity(1,1), FullName varchar(100), 
Email_Id varchar(50), Password varchar(100), Mobile_Number bigint)

select * from UserTable
