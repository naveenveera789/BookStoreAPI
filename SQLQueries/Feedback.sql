create table Feedback(FeedbackId int identity (1,1) primary key, UserId int foreign key (UserId) references UserRegister(UserId), BookId int foreign key (BookId) references BookTable(BookId), Comments varchar(600) not null, OverallRating int null)

select * from UserRegister

select * from BookTable

select * from Feedback

create procedure AddFeedback
(
 @UserId int,
 @BookId int,
 @Comments varchar(600),
 @OverallRating int
)
as
	declare @AverageRating int
begin try
	if(Exists(select * from Feedback where BookId=@BookId and UserId=@UserId))
	begin
		select 1
	end
	else
	begin
		if(Exists(select * from BookTable where BookId=@BookId))
		begin
			begin try
				begin transaction
					insert into Feedback (UserId,BookId,Comments,OverallRating) values (@UserId,@BookId,@Comments,@OverallRating)
					select @AverageRating=avg(@OverallRating) from Feedback where BookId=@BookId
					update BookTable set Rating=@AverageRating,ReviewCount=ReviewCount+1 where BookId=@BookId
				commit transaction
			end try
			begin catch
				rollback transaction
			end catch
		end
		else
		begin
			select 2
		end
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


alter procedure GetFeedback
(
 @BookId int
)
as
begin try
	select Feedback.FeedbackId,Feedback.UserId,Feedback.BookId,Feedback.Comments,Feedback.OverallRating,UserRegister.FullName,UserRegister.EmailId from UserRegister inner join Feedback on Feedback.UserId = UserRegister.UserId where BookId=@BookId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch