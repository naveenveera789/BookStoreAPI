create table Wishlist(WishlistId int identity (1,1) primary key, UserId int foreign key (UserId) references UserRegister(UserId), BookId int foreign key (BookId) references BookTable(BookId))

select * from Wishlist

select * from UserRegister

select * from BookTable

create procedure AddBookToWishlist
(
 @UserId int,
 @BookId int
)
as
begin try
	if(Exists(select * from BookTable where BookId=@BookId))
	begin
		insert into Wishlist(UserId,BookId) values (@UserId,@BookId)
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


create procedure DeleteWishlist
(
 @WishlistId int
)
as
begin try
	delete from Wishlist where WishlistId=@WishlistId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


alter procedure GetWishlist
(
 @UserId int
)
as
begin try
	select Wishlist.WishlistId,Wishlist.UserId,Wishlist.BookId,BookTable.BookId,BookTable.BookName,BookTable.AuthorName,BookTable.DiscountPrice,BookTable.OriginalPrice,BookTable.BookDescription,BookTable.Rating,BookTable.Image,BookTable.ReviewCount,BookTable.BookCount from Wishlist inner join BookTable on Wishlist.BookId = BookTable.BookId where Wishlist.UserId = @UserId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch