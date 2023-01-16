select * from FeedBackTable

Create or Alter Procedure Sp_GetfeedbackbyId
@FeedbackId bigint
as
select * from FeedbackTable where FeedbackId=@FeedbackId
go

execute procedure Sp_GetfeedbackbyId  FeedbackId=1



select * from OrderTable