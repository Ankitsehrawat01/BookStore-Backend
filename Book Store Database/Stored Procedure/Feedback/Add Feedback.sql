CREATE or ALTER PROCEDURE Sp_Addfeedback
( 
  @Rating bigint, @Comment varchar(max), @UserId bigint, @BookId bigint
)
as
INSERT into FeedbackTable (Rating, Comment, UserId, BookId) VALUES ( @Rating,@Comment, @UserId, @BookId);
go