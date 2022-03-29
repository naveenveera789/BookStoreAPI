create table OrderTable(OrderId int identity (1,1) primary key, UserId int foreign key (UserId) references UserRegister(UserId), AddressId int foreign key (AddressId) references AddressTable(AddressId), BookId int foreign key (BookId) references BookTable(BookId), TotalPrice int not null, QuantityToBuy int not null, OrderPlaced datetime)

select * from OrderTable

select * from UserRegister

select * from AddressTable

select * from BookTable

select * from CartTable

alter procedure AddOrder
(
 @UserId int,
 @AddressId int,
 @BookId int,
 @QuantityToBuy int
)
as
	declare @Price int
begin try
	select @Price=DiscountPrice from BookTable where BookId=@BookId
	if(Exists(select * from BookTable where BookId=@BookId))
	begin
		if(Exists(select * from UserRegister where UserId=@UserId))
		begin
			begin try
				begin transaction
					insert into OrderTable (UserId,AddressId,BookId,TotalPrice,QuantityToBuy,OrderPlaced) values (@UserId,@AddressId,@BookId,@QuantityToBuy*@Price,@QuantityToBuy,getdate())
					update BookTable set BookCount=BookCount-@QuantityToBuy where BookId=@BookId
					delete from CartTable where BookId=@BookId and UserId=@UserId
				commit transaction
			end try
			begin catch
				rollback transaction
			end catch
		end
		else
		begin
			select 1
		end
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


create procedure GetAllOrders
(
 @UserId int
)
as
begin try
	select BookTable.BookId,BookTable.BookName,BookTable.AuthorName,BookTable.DiscountPrice,BookTable.OriginalPrice,BookTable.Image,OrderTable.OrderId,OrderTable.OrderPlaced from BookTable inner join OrderTable on OrderTable.BookId = BookTable.BookId where OrderTable.UserId = @UserId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


alter procedure DeleteOrder
(
 @OrderId int
)
as
	declare @Quantity int,@BookId int
begin try
	if(Exists(select * from OrderTable where OrderId=@OrderId))
	begin
		begin try
			begin transaction
				select @Quantity=QuantityToBuy,@BookId=BookId from OrderTable where OrderId=@OrderId
				update BookTable set BookCount=BookCount+@Quantity where BookId=@BookId			
				delete from OrderTable where OrderId=@OrderId
			commit Transaction
		end try
		begin catch
			rollback transaction
		end catch
		end
		else
		begin
			Select 1
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