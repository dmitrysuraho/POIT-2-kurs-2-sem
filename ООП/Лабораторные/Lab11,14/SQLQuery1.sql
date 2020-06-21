drop table Plane;
drop table Crew;
create table Plane
(
	idPlane int identity(1,1) primary key,
	type char(20) not null,
	model char(20) not null,
	places int not null,
	picture varbinary(MAX),
	namePicture char(20)
);
insert into Plane(type, model, places) values('Пассажирский', 'Ли-28', 28),
						('Грузовой', 'СуБ-134', 50),
						('Военный', 'МКт', 10);

create table Crew
(
	idCrew int identity(1,1) primary key,
	idPlane int constraint Crew_Plane_FK foreign key references Plane(idPlane) not null,
	name char(30) not null,
	age int not null,
	post char(10) not null
);
insert into Crew values(4, 'Дмитрий', 19, 'Пилот'),
					   (4, 'Елена', 23, 'Стюардесса'),
					   (5, 'Александр', 33, 'Пилот'),
					   (6, 'Виктория', 24, 'Пилот'),
					   (6, 'Евгений', 25, 'Пом.пилота');