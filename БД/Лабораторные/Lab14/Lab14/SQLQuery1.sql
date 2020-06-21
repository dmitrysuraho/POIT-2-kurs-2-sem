--task1
drop function COUNT_STUDENTS
create function COUNT_STUDENTS(@faculty varchar(20)) returns int
as begin declare @rc int = 0;
set @rc = (select count(*) from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
										inner join FACULTY on FACULTY.FACULTY = GROUPS.FACULTY
										where FACULTY.FACULTY = @faculty);
return @rc;
end;

declare @f int = dbo.COUNT_STUDENTS('ТОВ');
print 'количество студентов на факультете ТОВ: ' + cast(@f as varchar(5));
go

alter function COUNT_STUDENTS(@faculty varchar(20), @prof varchar(20)) returns int
as begin declare @rc int = 0;
set @rc = (select count(*) from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
										inner join FACULTY on FACULTY.FACULTY = GROUPS.FACULTY
										where FACULTY.FACULTY = @faculty and GROUPS.PROFESSION = @prof);
return @rc;
end;

declare @f int = dbo.COUNT_STUDENTS('ТОВ', '1-48 01 02');
print 'количество студентов на факультете ТОВ и спец.1-48 01 02: ' + cast(@f as varchar(5));

select FACULTY, PROFESSION, dbo.COUNT_STUDENTS(FACULTY, PROFESSION) from GROUPS;
go

--task2
drop function FSUBJECTS;
create function FSUBJECTS(@p varchar(20)) returns varchar(300)
as begin
declare @tv char(20);  
declare @t varchar(300) = 'Предметы: ';  
declare ZkSubj CURSOR LOCAL 
for select SUBJECT from SUBJECT where PULPIT = @p;
open ZkSubj;	  
fetch  ZkSubj into @tv;   	 
while @@fetch_status = 0                                     
 begin 
     set @t = @t + ', ' + rtrim(@tv);         
     FETCH  ZkSubj into @tv; 
 end;    
return @t;
end;

select PULPIT, dbo.FSUBJECTS(PULPIT) from PULPIT;
go

--task3
drop function FFACPUL;
create function FFACPUL(@faculty varchar(20), @pulpit varchar(20)) returns table 
as return
select FACULTY.FACULTY, PULPIT.PULPIT from FACULTY left outer join PULPIT on FACULTY.FACULTY = PULPIT.FACULTY 
		where FACULTY.FACULTY = ISNULL(@faculty, FACULTY.FACULTY) 
		and PULPIT.PULPIT = ISNULL(@pulpit, PULPIT.PULPIT);

select * from dbo.FFACPUL(NULL, NULL);
select * from dbo.FFACPUL('ЛХФ', NULL);
select * from dbo.FFACPUL(NULL, 'ИСиТ');
select * from dbo.FFACPUL('ТОВ', 'ОХ');
go

--task4
drop function FCTEACHER;
create function FCTEACHER(@pulpit varchar(20)) returns int
as begin
declare @rc int = (select count(*) from TEACHER 
					where PULPIT = isnull(@pulpit, PULPIT));
return @rc;
end;

select PULPIT, dbo.FCTEACHER(PULPIT) from PULPIT;
select dbo.FCTEACHER(null);