Create or alter PROC spGetFeedback
	@BookId bigint
AS
BEGIN
	select 
		FeedbackTable.FeedbackId,FeedbackTable.UserId,FeedbackTable.BookId,FeedbackTable.Comment,FeedbackTable.Rating,
		UserTable.FullName
		FROM UserTable
		inner join FeedbackTable
		on FeedbackTable.UserId=UserTable.UserId
		where BookId=@BookId
END
select * from FeedbackTable