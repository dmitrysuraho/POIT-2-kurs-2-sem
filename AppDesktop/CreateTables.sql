drop table PROFESSION
drop table GROUPS
drop table STUDENT
drop table SUBJECT
drop table TEACHER
drop table PROGRESS
drop table TESTS
drop table ADMIN
drop table NEWS
drop table COURSE

use Desktop
------Создание таблицы COURSE
create table COURSE
(
	COURSE integer primary key
);

------Создание таблицы PROFESSION
create table PROFESSION
(   
    PROFESSION char(20) primary key
)

------Создание таблицы GROUPS
create table GROUPS 
(   
	IDGROUP integer primary key,
	PROFESSION char(20) constraint GROUP_PROFESSION_FK foreign key references PROFESSION(PROFESSION)
)

------Создание и заполнение таблицы STUDENT
create table STUDENT 
(    
    RECORD integer constraint STUDENT_PK primary key,
	SPASS char(100),        
    NAME nvarchar(50),
	PICTURE varbinary(MAX),
	IDGROUP integer constraint STUDENT_GROUP_FK foreign key references GROUPS(IDGROUP),
	COURSE integer constraint STUDENT_COURSE_FK foreign key references COURSE(COURSE)
)
ALTER TABLE STUDENT ADD NAMEPICTURE nvarchar(30);

------Создание таблицы SUBJECT
create table SUBJECT
(   
    SUBJECT char(10) constraint SUBJECT_PK  primary key, 
    SUBJECT_NAME varchar(100) unique,
	COURSE int constraint SUBJECT_COURSE_FK foreign key references COURSE(COURSE)
)

------Создание и заполнение таблицы TEACHER
create table TEACHER
(   
    TEACHER char(10) constraint TEACHER_PK primary key,
	TPASS char(100),
	SUBJECT char(10) constraint TEACHER_SUBJECT_FK foreign key references SUBJECT(SUBJECT), 
    TEACHER_NAME varchar(100)
)

------Создание и заполнение таблицы PROGRESS
create table PROGRESS
(
    SUBJECT char(10) constraint PROGRESS_SUBJECT_FK foreign key references SUBJECT(SUBJECT),                
    IDSTUDENT integer constraint PROGRESS_IDSTUDENT_FK foreign key references STUDENT(RECORD),        
    NOTE integer check (NOTE between 1 and 10),
)

------Создание и заполнение таблицы ADMIN
create table ADMIN
(
	LOGIN char(30) primary key,
	APASS char(100) 
)

------Создание таблица NEWS
create table NEWS
(
	NAME char(50) primary key,
	DESCRIPTION varchar(MAX),
	PICTURE varbinary(MAX)
)
ALTER TABLE NEWS ADD NAMEPICTURE nvarchar(30);
ALTER TABLE NEWS ADD DATE date;

------Создание таблицы TESTS
create table TESTS
(
	SUBJECT char(10) constraint TESTS_SUBJECT_FK foreign key references SUBJECT(SUBJECT),
	QUESTION nvarchar(100),
	ANSWER nvarchar(100)
)

ALTER TABLE TESTS ADD NOANSWER1 nvarchar(100), NOANSWER2 nvarchar(100)

insert into TESTS(SUBJECT, QUESTION, ANSWER, NOANSWER1, NOANSWER2, NAMEQUESTION)
	values('ОАиП', 'Какое из предложенных выражений может быть использовано в качестве условий?', '(х<-3) или (х<>5)', 't*4-3', 'х-у', 'ОАиП1'),
		  ('ОАиП', 'Программа, обеспечивающая последовательный "перевод" команд на машинный язык с их выполнением', 'компилятор', 'интерпретатор', 'компрессор', 'ОАиП2'),
		  ('ОАиП', 'К свойствам алгоритма относится?', 'массовость, дискретность, результативность, детерминированность', 'дискретность, массовость, абсолютность, информативность, формальность', 'результативность, дискретность, массовость', 'ОАиП3'),
		  ('ОАиП', 'Примером разветвленного алгоритма является:', 'переход улицы по сигналу светофора', 'заваривание чая','круговорот воды в природе', 'ОАиП4'),
		  ('ОАиП', 'Какое из свойств алгоритма описывает возможность применения алгоритма к целому классу задач?', 'массовость', 'конечность','дискретность', 'ОАиП5')

------Создание таблицы LITERATURE
create table LITERATURE
(
	TITLE char(100) primary key,
	AUTHORS char(100), 
	SUBJECT char(10)  constraint LITERATURE_SUBJECT_FK foreign key references SUBJECT(SUBJECT),
	PICTURE varbinary(MAX)
);

insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE)
select 'Язык программирования C# 7 и платформы .NET и .NET Core', 'Эндрю Троелсен, Филипп Джепикс', 'ООП',
BulkColumn FROM Openrowset(Bulk N'C:\Users\Dmitry\Desktop\Курсовой\AppDesktop\AppDesktop\Pictures\literatireC#1.jpg', Single_Blob) as image

insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE)
select 'C# для чайников', 'Джон Пол Мюллер при участии Билла Семпфа и Чака Сфера', 'ООП',
BulkColumn FROM Openrowset(Bulk N'C:\Users\Dmitry\Desktop\Курсовой\AppDesktop\AppDesktop\Pictures\literatireC#2.jpg', Single_Blob) as image

insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE)
select 'Геометрические основы компьютерной графики', 'Е.М.Вечтомов, Е.Н.Лубягина', 'КГИГ',
BulkColumn FROM Openrowset(Bulk N'C:\Users\Dmitry\Desktop\Курсовой\AppDesktop\AppDesktop\Pictures\literatireKGIG1.jpg', Single_Blob) as image


