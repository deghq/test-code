use test;

create table Users(
	Id integer not null primary key identity,
	Email varchar(255),
	Password varchar(255)
);