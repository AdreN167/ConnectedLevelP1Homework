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

insert into Books(Id, [Name], Authors, [Status]) values (1, '̸����� ����', '1', 0);
insert into Books(Id, [Name], Authors, [Status]) values (2, '�������', '1', 0);
insert into Books(Id, [Name], Authors, [Status]) values (3, '���� ���������������� C# � ��������� .NET � .NET Core', '2,3', 0);
insert into Books(Id, [Name], Authors, [Status]) values (4, '������� ������', '4', 0);
insert into Books(Id, [Name], Authors, [Status]) values (5, '������� �������', '4', 1);

insert into Authors(Id, [Name], Books) values (1, '������� ������', '1,2');
insert into Authors(Id, [Name], Books) values (2, '����� ��������', '3');
insert into Authors(Id, [Name], Books) values (3, '������ �������', '3');
insert into Authors(Id, [Name], Books) values (4, '��������� ������', '4,5');

insert into Users(Id, [Name], Books, IsDebtor) values (1, '������� ������', '1,2', 1);
insert into Users(Id, [Name], Books, IsDebtor) values (2, '���������� ����', '3', 0);
insert into Users(Id, [Name], Books, IsDebtor) values (3, '�������� ������', '4', 1);

select * from Users
where IsDebtor = 1

Update Users
set IsDebtor = 0 where IsDebtor = 1