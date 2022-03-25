create procedure UserSignUp
(
 @FullName varchar(40),
 @EmailId varchar(60),
 @Password varchar(20),
 @MobileNumber varchar(14)
)
as
begin try
     insert into UserRegister (FullName,EmailId,Password,MobileNumber) values (@FullName,@EmailId,@Password,@MobileNumber)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


alter procedure UserLogIn
(
 @EmailId varchar(60),
 @Password varchar(20)
)
as
begin try
	select * from UserRegister where (EmailId=@EmailId and Password=@Password)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


alter procedure ForgotPassword
(
   @EmailId varchar(60)
)
as
begin try
	update UserRegister set Password=NULL where @EmailId=EmailId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure ResetPassword
(
 @EmailId varchar(60),
 @Password varchar(20)
)
as
begin try
	update UserRegister set Password=@Password where EmailId=@EmailId
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