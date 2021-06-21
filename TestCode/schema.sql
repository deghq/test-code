use test;

create table tbl_Users(
	Id integer not null primary key identity,
	Email varchar(255),
	Password varchar(255),
	Phone varchar(50)
);