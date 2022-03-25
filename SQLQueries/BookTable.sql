create table BookTable(BookId int identity (1,1) primary key, BookName varchar(50) not null, AuthorName varchar(50) not null, DiscountPrice int not null, OriginalPrice int not null, BookDescription varchar(400) not null, Rating float not null, Image varchar(100) not null, ReviewCount int not null, BookCount int not null)

select * from BookTable