use S_UNIVER
--task1
declare @tv char(20), @t char(300) = '';
declare KSubjects cursor 
				for select SUBJECT from SUBJECT where PULPIT = 'ИСиТ';
open KSubjects;
fetch KSubjects into @tv;
print 'Предметы кафедры ИСиТ: ';
while @@fetch_status = 0
	begin
		set @t = rtrim(@tv) + ', ' + @t;
		fetch KSubjects into @tv;
	end;
print @t;
close KSubjects;

--task2
--local
declare @a char(20), @b char(20);
declare KSubjects1 cursor local
				for select SUBJECT, PULPIT from SUBJECT where PULPIT = 'ИСиТ';
open KSubjects1;
fetch KSubjects1 into @a, @b;
print '1: ' + rtrim(@a) + ' ' + @b;
go
declare @a char(20), @b char(20);
fetch KSubjects1 into @a, @b;
print '2: ' + rtrim(@a) + ' ' + @b;
go
--global
declare @a char(20), @b char(20);
declare KSubjects12 cursor global
				for select SUBJECT, PULPIT from SUBJECT where PULPIT = 'ИСиТ';
open KSubjects12;
fetch KSubjects12 into @a, @b;
print '1: ' + rtrim(@a) + ' ' + @b;
go
declare @a char(20), @b char(20);
fetch KSubjects12 into @a, @b;
print '2: ' + rtrim(@a) + ' ' + @b;
close KSubjects12;
DEALLOCATE KSubjects12;
go

--task3
declare @tnm char(10);
declare SubjectK cursor local dynamic
	for select SUBJECT from SUBJECT where PULPIT = 'ИСиТ';
open SubjectK;
--update SUBJECT set SUBJECT = 'NewSubj' where SUBJECT = 'ВТЛ';
--delete SUBJECT where PULPIT = 'ЛЗиДВ';
insert SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
				values('222221', '2222', 'ИСиТ');
fetch SubjectK into @tnm;
while @@fetch_status = 0
begin 
	print @tnm;
	fetch SubjectK into @tnm;
end;
close SubjectK;

--task4
declare @tc int, @rn char(50);
declare Task4 cursor local dynamic SCROLL
	for select row_number() over (order by SUBJECT) N,
			SUBJECT from SUBJECT where PULPIT = 'ИСиТ';
open Task4;
fetch Task4 into @tc, @rn;
print 'Текущая строка: ' +  cast(@tc as varchar(3)) + ' ' + rtrim(@rn);
fetch last from Task4 into @tc, @rn;
print 'Последняя строка: ' +  cast(@tc as varchar(3)) + ' ' + rtrim(@rn);
fetch first from Task4 into @tc, @rn;
print 'Первая строка: ' +  cast(@tc as varchar(3)) + ' ' + rtrim(@rn);
fetch absolute 3 from Task4 into @tc, @rn;
print 'Третья строка от начала: ' +  cast(@tc as varchar(3)) + ' ' + rtrim(@rn);
fetch relative 3 from Task4 into @tc, @rn;
print 'Третья строка вперед от текущей: ' +  cast(@tc as varchar(3)) + ' ' + rtrim(@rn);
close Task4;

--task5
declare @tn char(20), @tsn char(20);
declare Task5 cursor local dynamic
	for select SUBJECT, SUBJECT_NAME from SUBJECT for update;
open Task5;
fetch Task5 into @tn, @tsn;
delete SUBJECT where current of Task5;
fetch Task5 into @tn, @tsn;
update SUBJECT set SUBJECT_NAME = 'undate field' where current of Task5;
close Task5;

--task6
declare @sb char(10), @nt int, @nm char(50), @fc char(10), @prf char(15), @crs int;
declare Task61 cursor local dynamic 
					for select SUBJECT, NOTE, NAME, FACULTY, PROFESSION, COURSE from PROGRESS inner join STUDENT on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
						inner join GROUPS on GROUPS.IDGROUP = STUDENT.IDGROUP;
open Task61;
fetch Task61 into @sb, @nt, @nm, @fc, @prf, @crs;
while @@fetch_status = 0
begin
	if @nt < 6
		begin
			delete PROGRESS where current of task61;		
		end;
	fetch Task61 into @sb, @nt, @nm, @fc, @prf, @crs;
end;
close Task61;
go

declare @sb char(10), @id int, @pd date, @nt int;
declare Task62 cursor local dynamic 
					for select * from PROGRESS;
open Task62;
fetch Task62 into @sb, @id, @pd, @nt;
while @@fetch_status = 0
begin
	if @id = 1015
		begin
			update PROGRESS set NOTE = NOTE + 1 where current of task62;		
		end;
	fetch Task62 into @sb, @id, @pd, @nt;
end;
close Task62;
go
