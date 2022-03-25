create procedure AddBook
(
 @BookName varchar(50),
 @AuthorName varchar(50),
 @DiscountPrice int,
 @OriginalPrice int,
 @BookDescription varchar(400),
 @Rating float,
 @Image varchar(100),
 @ReviewCount int,
 @BookCount int
)
as
begin try
     insert into BookTable values (@BookName,@AuthorName,@DiscountPrice,@OriginalPrice,@BookDescription,@Rating,@Image,@ReviewCount,@BookCount)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure UpdateBook
(
 @BookId int,
 @BookName varchar(50),
 @AuthorName varchar(50),
 @DiscountPrice int,
 @OriginalPrice int,
 @BookDescription varchar(400),
 @Rating float,
 @Image varchar(100),
 @ReviewCount int,
 @BookCount int
)
as
begin try
     update BookTable set BookName=@BookName,AuthorName=@AuthorName,DiscountPrice=@DiscountPrice,OriginalPrice=@OriginalPrice,BookDescription=@BookDescription,Rating=@Rating,Image=@Image,ReviewCount=@ReviewCount,BookCount=@BookCount where BookId=@BookId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure GetAllBooks
as
begin try
	select * from BookTable
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure DeleteBook
(
 @BookId int
)
as
begin try
	delete BookTable where BookId=@BookId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


select * from UserRegister


select * from BookTable