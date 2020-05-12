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
------�������� ������� COURSE
create table COURSE
(
	COURSE integer primary key
);

------�������� ������� PROFESSION
create table PROFESSION
(   
    PROFESSION char(20) primary key
)

------�������� ������� GROUPS
create table GROUPS 
(   
	IDGROUP integer primary key,
	PROFESSION char(20) constraint GROUP_PROFESSION_FK foreign key references PROFESSION(PROFESSION)
)

------�������� � ���������� ������� STUDENT
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

------�������� ������� SUBJECT
create table SUBJECT
(   
    SUBJECT char(10) constraint SUBJECT_PK  primary key, 
    SUBJECT_NAME varchar(100) unique,
	COURSE int constraint SUBJECT_COURSE_FK foreign key references COURSE(COURSE)
)

------�������� � ���������� ������� TEACHER
create table TEACHER
(   
    TEACHER char(10) constraint TEACHER_PK primary key,
	TPASS char(100),
	SUBJECT char(10) constraint TEACHER_SUBJECT_FK foreign key references SUBJECT(SUBJECT), 
    TEACHER_NAME varchar(100)
)

------�������� � ���������� ������� PROGRESS
create table PROGRESS
(
    SUBJECT char(10) constraint PROGRESS_SUBJECT_FK foreign key references SUBJECT(SUBJECT),                
    IDSTUDENT integer constraint PROGRESS_IDSTUDENT_FK foreign key references STUDENT(RECORD),        
    NOTE integer check (NOTE between 1 and 10),
)

------�������� � ���������� ������� ADMIN
create table ADMIN
(
	LOGIN char(30) primary key,
	APASS char(100) 
)

------�������� ������� NEWS
create table NEWS
(
	NAME char(50) primary key,
	DESCRIPTION varchar(MAX),
	PICTURE varbinary(MAX)
)
ALTER TABLE NEWS ADD NAMEPICTURE nvarchar(30);
ALTER TABLE NEWS ADD DATE date;

------�������� ������� TESTS
create table TESTS
(
	SUBJECT char(10) constraint TESTS_SUBJECT_FK foreign key references SUBJECT(SUBJECT),
	QUESTION nvarchar(100),
	ANSWER nvarchar(100)
)

ALTER TABLE TESTS ADD NOANSWER1 nvarchar(100), NOANSWER2 nvarchar(100)

insert into TESTS(SUBJECT, QUESTION, ANSWER, NOANSWER1, NOANSWER2, NAMEQUESTION)
	values('����', '����� �� ������������ ��������� ����� ���� ������������ � �������� �������?', '(�<-3) ��� (�<>5)', 't*4-3', '�-�', '����1'),
		  ('����', '���������, �������������� ���������������� "�������" ������ �� �������� ���� � �� �����������', '����������', '�������������', '����������', '����2'),
		  ('����', '� ��������� ��������� ���������?', '����������, ������������, ����������������, �������������������', '������������, ����������, ������������, ���������������, ������������', '����������������, ������������, ����������', '����3'),
		  ('����', '�������� �������������� ��������� ��������:', '������� ����� �� ������� ���������', '����������� ���','���������� ���� � �������', '����4'),
		  ('����', '����� �� ������� ��������� ��������� ����������� ���������� ��������� � ������ ������ �����?', '����������', '����������','������������', '����5')

------�������� ������� LITERATURE
create table LITERATURE
(
	TITLE char(100) primary key,
	AUTHORS char(100), 
	SUBJECT char(10)  constraint LITERATURE_SUBJECT_FK foreign key references SUBJECT(SUBJECT),
	PICTURE varbinary(MAX)
);

insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE)
select '���� ���������������� C# 7 � ��������� .NET � .NET Core', '����� ��������, ������ �������', '���',
BulkColumn FROM Openrowset(Bulk N'C:\Users\Dmitry\Desktop\��������\AppDesktop\AppDesktop\Pictures\literatireC#1.jpg', Single_Blob) as image

insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE)
select 'C# ��� ��������', '���� ��� ������ ��� ������� ����� ������ � ���� �����', '���',
BulkColumn FROM Openrowset(Bulk N'C:\Users\Dmitry\Desktop\��������\AppDesktop\AppDesktop\Pictures\literatireC#2.jpg', Single_Blob) as image

insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE)
select '�������������� ������ ������������ �������', '�.�.��������, �.�.��������', '����',
BulkColumn FROM Openrowset(Bulk N'C:\Users\Dmitry\Desktop\��������\AppDesktop\AppDesktop\Pictures\literatireKGIG1.jpg', Single_Blob) as image


