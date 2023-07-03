create database ChuyenBayDB 
go

use ChuyenBayDB  
go

create table ChuyenBay
(
	macb int primary key identity,
	tencb varchar(250),
	ngaydi date default getdate(),
	sogheloai1 int,
	giagheloai1 decimal(10,0),
	sogheloai2 int,
	giagheloai2 decimal(10,0)
)
go

create table Ve
(
	mave int primary key identity,
	hotenhanhkhach varchar(250),
	cmnd varchar(20),
	macb int,
	loaighe int,
	giaghe decimal(10,0)
)
go
select * from Ve