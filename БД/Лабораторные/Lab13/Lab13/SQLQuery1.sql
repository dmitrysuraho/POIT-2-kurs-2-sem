--task1
--drop procedure PSUBJECT;
create procedure PSUBJECT as
begin
	declare @k int = (select count(*) from SUBJECT);
	select SUBJECT[код],SUBJECT_NAME[дисциплина], PULPIT[кафедра] from SUBJECT;
	return @k;
end;

declare @p int = 0;
exec @p = PSUBJECT;
print 'количество предметов: ' + cast(@p as varchar(3));

--task2
GO
/****** Object:  StoredProcedure [dbo].[PSUBJECT]    Script Date: 17.05.2020 11:50:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[PSUBJECT]  @p varchar(20), @c int output as
begin
	declare @k int = (select count(*) from SUBJECT);
	select SUBJECT[код],SUBJECT_NAME[дисциплина], PULPIT[кафедра] from SUBJECT where PULPIT = @p;
	set @c = @@rowcount;
	return @k;
end;
go

declare @k int = 0, @r int = 0, @p varchar(20);
exec @k = PSUBJECT @p = 'ИСиТ', @c = @r output;
print 'количество предметов всего: ' + cast(@k as varchar(3));
print 'количество предметов кафедры ИСиТ: ' + cast(@r as varchar(3));
go

--task3
alter procedure PSUBJECT @p varchar(20)
as begin
	select SUBJECT[код],SUBJECT_NAME[дисциплина], PULPIT[кафедра] from SUBJECT where PULPIT = @p;
end;
go

create table #SUBJECT
(
	код varchar(10) primary key,
	дисциплина varchar(50),
	кафедра varchar(10)
);

insert #SUBJECT exec PSUBJECT @p = 'ИСиТ';
select * from #SUBJECT;
go

--task4

create procedure PAUDITORIUM_INSERT @a char(20), @t char(10), @c int, @n varchar(50) as
begin
	begin try
		insert into AUDITORIUM(AUDITORIUM, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY, AUDITORIUM_NAME)
							values(@a, @t, @c, @n);
		return 1;
	end try
	begin catch
		print error_number();
		print error_message();
		print error_severity();
		print error_state();
		print error_line();
		return -1;
	end catch;
end;
go

declare @rc int;
exec @rc = PAUDITORIUM_INSERT @a = '1-1', @t = 'ЛК', @c = 20, @n = '1-1';
print 'код: ' + cast(@rc as varchar(3));
go

--task5
--drop procedure SUBJECT_REPORT;
--deallocate CURSORS;
create procedure SUBJECT_REPORT @p varchar(20) as
begin
	declare @count int = 0;
	begin try
		declare @subj varchar(20), @pulp varchar(20), @t char(300) = '';
		declare CURSORS cursor for
			select SUBJECT, PULPIT from SUBJECT where PULPIT = @p;
		if not exists (select SUBJECT, PULPIT from SUBJECT where PULPIT = @p)
			raiserror('ошибка', 11, 1);
		else
			begin
				open CURSORS;
				fetch CURSORS into @subj, @pulp;
				print 'Предметы: ';
				while @@fetch_status = 0
				begin
					set @t = rtrim(@subj) + ',' + @t;
					set @count = @count + 1;
					fetch CURSORS into @subj, @pulp;
				end;
				print @t;
				close CURSORS;
				return @count;
			end;
	end try
	begin catch
		print 'ошибка в параметрах';
		print error_message();
		return @count;
	end catch;
end;
go

declare @count int;
exec @count = SUBJECT_REPORT @p = 'ИСиТ';
print 'количество предметов: ' + cast(@count as varchar(3));
go

--task6

create  procedure PAUDITORIUM_INSERTX @a char(20), @t char(10), @c int, @n varchar(50), @tn varchar(50)  
as declare @rc int;               
begin try 
    set transaction isolation level SERIALIZABLE;          
    begin tran
    insert into AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
                                values (@t, @tn);
    exec @rc = PAUDITORIUM_INSERT @a, @t, @c, @n;  
    commit tran; 
    return @rc;           
end try
begin catch 
    print 'номер ошибки  : ' + cast(error_number() as varchar(6));
    print 'сообщение     : ' + error_message();
    print 'уровень       : ' + cast(error_severity()  as varchar(6));
    print 'метка         : ' + cast(error_state()   as varchar(8));
    print 'номер строки  : ' + cast(error_line()  as varchar(8));
    if error_procedure() is not  null   
                     print 'имя процедуры : ' + error_procedure();
     if @@trancount > 0 rollback tran ; 
     return -1;	  
end catch;
go

declare @rc int;  
exec @rc =  PAUDITORIUM_INSERTX @a = '228-3', @t = 'ЛКNew', @c = 20, @n = '228-3', @tn = 'NewAudit';
print 'код: ' + cast(@rc as varchar(3));  
