create database BookStore

use BookStore

create table UserRegister(UserId int identity (1,1) primary key, FullName varchar(40) not null, EmailId varchar(60) not null, Password varchar(20) not null, MobileNumber varchar(14) not null)

select * from UserRegister