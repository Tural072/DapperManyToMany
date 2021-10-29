CREATE database MyLib

use MyLib

create table Authors(
[AuthorId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Firstname] NVARCHAR(30) NOT NULL,
[Lastname] NVARCHAR(30) NOT NULL
)

insert into Authors([Firstname],[Lastname])
values('Eli','Eliyev'),('Ruslan','Camalli')

create table Books(
[BookId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Title] NVARCHAR(30) NOT NULL,
Price float not null
)

insert into Books([Title],[Price])
values('A',100),('B',200),('C',300),('D',400)

create table AuthorAndBooks(
AuthorId int foreign key references Authors(AuthorId) not null,
BookId int foreign key references Books(BookId) not null
)

insert into AuthorAndBooks([AuthorId],[BookId])
values(1,1),(1,2),(2,3),(2,4)