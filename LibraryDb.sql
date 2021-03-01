create database LibraryDb;
use LibraryDb;

create table Books (
	Id int primary key not null,
	[Name] nvarchar(max) not null,
	Authors nvarchar(max) not null,
	[Status] bit not null
);

create table Authors (
	Id int primary key not null,
	[Name] nvarchar(max) not null,
	Books nvarchar(max) not null
);

create table Users (
	Id int primary key not null,
	[Name] nvarchar(max) not null,
	Books nvarchar(max) not null,
	IsDebtor bit not null
);

insert into Books(Id, [Name], Authors, [Status]) values (1, 'Мёртвые души', '1', 0);
insert into Books(Id, [Name], Authors, [Status]) values (2, 'Ревизор', '1', 0);
insert into Books(Id, [Name], Authors, [Status]) values (3, 'Язык программирования C# и платформы .NET и .NET Core', '2,3', 0);
insert into Books(Id, [Name], Authors, [Status]) values (4, 'Евгений Онегин', '4', 0);
insert into Books(Id, [Name], Authors, [Status]) values (5, 'Повести Белкина', '4', 1);

insert into Authors(Id, [Name], Books) values (1, 'Николай Гоголь', '1,2');
insert into Authors(Id, [Name], Books) values (2, 'Эндрю Троелсен', '3');
insert into Authors(Id, [Name], Books) values (3, 'Филипп Джепикс', '3');
insert into Authors(Id, [Name], Books) values (4, 'Александр Пушкин', '4,5');

insert into Users(Id, [Name], Books, IsDebtor) values (1, 'Горохов Михаил', '1,2', 1);
insert into Users(Id, [Name], Books, IsDebtor) values (2, 'Воробушкин Петр', '3', 0);
insert into Users(Id, [Name], Books, IsDebtor) values (3, 'Киркоров Филипп', '4', 1);

select * from Users
where IsDebtor = 1

Update Users
set IsDebtor = 0 where IsDebtor = 1