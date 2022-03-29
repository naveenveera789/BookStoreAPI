create table AddressType(TypeId int identity (1,1) primary key, Type varchar(10))

insert into AddressType (Type) values ('Home')
insert into AddressType (Type) values ('Work')
insert into AddressType (Type) values ('Other')

select * from AddressType

create table AddressTable(AddressId int identity (1,1) primary key, UserId int foreign key (UserId) references UserRegister(UserId), Address varchar(700) not null, City varchar(50) not null, State varchar(50) not null, TypeId int foreign key (TypeId) references AddressType(TypeId))

select * from AddressTable

select * from UserRegister

create procedure AddAddress
(
 @UserId int,
 @Address varchar(700),
 @City varchar(50),
 @State varchar(50),
 @TypeId int
)
as
begin try
	if(Exists(select * from UserRegister where UserId=@UserId))
	begin
		insert into AddressTable(UserId,Address,City,State,TypeId) values (@UserId,@Address,@City,@State,@TypeId)
	end
	else
	begin
		select 1
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


create procedure UpdateAddress
(
 @AddressId int,
 @Address varchar(700),
 @City varchar(50),
 @State varchar(50),
 @TypeId int
)
as
begin try
	if(Exists(select * from AddressTable where AddressId=@AddressId))
	begin
		update AddressTable set Address=@Address,City=@City,State=@State,TypeId=@TypeId where AddressId=@AddressId
	end
	else
	begin
		select 1
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


create procedure GetAddressById
(
 @UserId int
)
as
begin try
	if(Exists(select * from AddressTable where UserId=@UserId))
	begin
		select * from AddressTable where UserId=@UserId
	end
	else
	begin
		select 1
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


create procedure GetAllAddress
as
begin try
	select * from AddressTable
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure DeleteAddress
(
 @AddressId int
)
as
begin try
	delete from AddressTable where AddressId=@AddressId
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch