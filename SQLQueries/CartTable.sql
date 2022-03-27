create table CartTable(CartId int identity (1,1) primary key, UserId int foreign key (UserId) references UserRegister(UserId), BookId int foreign key (BookId) references BookTable(BookId), OrderQuantity int default 1)

select * from CartTable

select * from BookTable

select * from UserRegister


create procedure AddBookToCart
(
 @UserId int,
 @BookId int,
 @OrderQuantity int
)
as
begin try
	if(Exists(select * from BookTable where BookId=@BookId))
	begin
		insert into CartTable (UserId,BookId,OrderQuantity) values (@UserId,@BookId,@OrderQuantity)
	end
	else
	begin
		select 2
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


create procedure UpdateCart
(
 @CartId int,
 @OrderQuantity int
)
as
begin try
	if(Exists(select * from CartTable where CartId=@CartId))
	begin
		update CartTable set OrderQuantity=@OrderQuantity where CartId=@CartId
	end
	else
	begin
		select 2
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


create procedure DeleteCart
(
 @CartId int
)
as
begin try
	if(Exists(select * from CartTable where CartId=@CartId))
	begin
		delete from CartTable where CartId=@CartId
	end
	else
	begin
		select 2
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


create procedure GetCart
(
 @UserId int
)
as
begin try
	select CartTable.CartId,CartTable.BookId,CartTable.UserId,CartTable.OrderQuantity,BookTable.BookName,BookTable.AuthorName,BookTable.DiscountPrice,BookTable.OriginalPrice,BookTable.BookDescription,BookTable.Rating,BookTable.Image,BookTable.ReviewCount,BookTable.BookCount from CartTable inner join BookTable on CartTable.BookId = BookTable.BookId where CartTable.UserId = @UserId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch
