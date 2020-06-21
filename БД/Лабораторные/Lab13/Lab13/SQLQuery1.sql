--task1
--drop procedure PSUBJECT;
create procedure PSUBJECT as
begin
	declare @k int = (select count(*) from SUBJECT);
	select SUBJECT[���],SUBJECT_NAME[����������], PULPIT[�������] from SUBJECT;
	return @k;
end;

declare @p int = 0;
exec @p = PSUBJECT;
print '���������� ���������: ' + cast(@p as varchar(3));

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
	select SUBJECT[���],SUBJECT_NAME[����������], PULPIT[�������] from SUBJECT where PULPIT = @p;
	set @c = @@rowcount;
	return @k;
end;
go

declare @k int = 0, @r int = 0, @p varchar(20);
exec @k = PSUBJECT @p = '����', @c = @r output;
print '���������� ��������� �����: ' + cast(@k as varchar(3));
print '���������� ��������� ������� ����: ' + cast(@r as varchar(3));
go

--task3
alter procedure PSUBJECT @p varchar(20)
as begin
	select SUBJECT[���],SUBJECT_NAME[����������], PULPIT[�������] from SUBJECT where PULPIT = @p;
end;
go

create table #SUBJECT
(
	��� varchar(10) primary key,
	���������� varchar(50),
	������� varchar(10)
);

insert #SUBJECT exec PSUBJECT @p = '����';
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
exec @rc = PAUDITORIUM_INSERT @a = '1-1', @t = '��', @c = 20, @n = '1-1';
print '���: ' + cast(@rc as varchar(3));
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
			raiserror('������', 11, 1);
		else
			begin
				open CURSORS;
				fetch CURSORS into @subj, @pulp;
				print '��������: ';
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
		print '������ � ����������';
		print error_message();
		return @count;
	end catch;
end;
go

declare @count int;
exec @count = SUBJECT_REPORT @p = '����';
print '���������� ���������: ' + cast(@count as varchar(3));
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
    print '����� ������  : ' + cast(error_number() as varchar(6));
    print '���������     : ' + error_message();
    print '�������       : ' + cast(error_severity()  as varchar(6));
    print '�����         : ' + cast(error_state()   as varchar(8));
    print '����� ������  : ' + cast(error_line()  as varchar(8));
    if error_procedure() is not  null   
                     print '��� ��������� : ' + error_procedure();
     if @@trancount > 0 rollback tran ; 
     return -1;	  
end catch;
go

declare @rc int;  
exec @rc =  PAUDITORIUM_INSERTX @a = '228-3', @t = '��New', @c = 20, @n = '228-3', @tn = 'NewAudit';
print '���: ' + cast(@rc as varchar(3));  
