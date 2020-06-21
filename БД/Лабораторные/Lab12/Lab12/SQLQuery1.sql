--task1
set nocount on
if  exists (select * from  SYS.OBJECTS        -- ������� X ����?
	            where OBJECT_ID= object_id(N'DBO.X') )	            
	drop table X;           
declare @c int, @flag char = 'r';           -- commit ��� rollback?
SET IMPLICIT_TRANSACTIONS  ON   -- �����. ����� ������� ����������
CREATE table X(K int );                         -- ������ ���������� 
	INSERT X values (1),(2),(3);
	set @c = (select count(*) from X);
	print '���������� ����� � ������� X: ' + cast( @c as varchar(2));
	if @flag = 'c'  commit;                   -- ���������� ����������: �������� 
	else   rollback;                                 -- ���������� ����������: �����  
SET IMPLICIT_TRANSACTIONS  OFF   -- ������. ����� ������� ����������	
if  exists (select * from  SYS.OBJECTS       -- ������� X ����?
	            where OBJECT_ID= object_id(N'DBO.X') )
print '������� X ����';  
else print '������� X ���'

--task2
begin try
	begin tran
		delete TEACHER where TEACHER = '����';
		insert TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) values('���', '���', '�', '����');
	commit tran;
end try
begin catch
	print '������: ' + cast(error_number() as varchar(5)) + error_message();
	if @@TRANCOUNT > 0 rollback tran;
end catch;

--task3
declare @point varchar(32);
begin try
	begin tran
		delete TEACHER where TEACHER = '���';
		set @point = 'p1'; save tran @point;
		insert TEACHER values('New', 'New', '�', '����');
		set @point = 'p2'; save tran @point;
		insert TEACHER values('����', '����', '�', '����');
	commit tran;
end try
begin catch
	print '������: ' + cast(error_number() as varchar(5)) + error_message();
	if @@TRANCOUNT > 0
		begin
			print '����������� �����: ' + @point;
			rollback tran @point;
			commit tran;
		end;
end catch

--task4
-- A ---
set transaction isolation level READ UNCOMMITTED 
begin transaction 
-------------------------- t1 ------------------
select @@SPID,  * from SUBJECT where PULPIT = '����';
--rollback
commit; 
-------------------------- t2 -----------------
--- B ---	
begin transaction 
select @@SPID
insert SUBJECT values ('NewSubject', 'NS', '����');
-------------------------- t1 --------------------
-------------------------- t2 --------------------
rollback;

--task5
-- A ---
set transaction isolation level READ COMMITTED 
begin transaction 
-------------------------- t1 ------------------
-------------------------- t2 -----------------
select * from SUBJECT where PULPIT = '����';
commit;

--- B ---
set transaction isolation level READ COMMITTED 
begin transaction 
-------------------------- t1 --------------------
update SUBJECT set SUBJECT = 'Task' where SUBJECT = '��'
select  * from SUBJECT where PULPIT = '����';
-------------------------- t2 --------------------
commit;
--rollback

--task6
-- A ---
set transaction isolation level REPEATABLE READ
begin transaction 
select * from SUBJECT where PULPIT = '����';
-------------------------- t1 ------------------
-------------------------- t2 -----------------
select * from SUBJECT where SUBJECT = 'NewSubject';
commit; 

--- B ---	
begin transaction 
-------------------------- t1 --------------------
insert SUBJECT values ('NewSubject', 'NS', '����');
select  * from SUBJECT where PULPIT = '����';
-------------------------- t2 --------------------
rollback;

--task7
-- A ---
set transaction isolation level SERIALIZABLE 
begin transaction
select * from SUBJECT where PULPIT = '����';
-------------------------- t1 -----------------
select * from SUBJECT where PULPIT = '����';
-------------------------- t2 ------------------ 
commit; 	
	--- B ---	
begin transaction 	   
insert SUBJECT values ('NewSubject', 'NS', '����');
select * from SUBJECT where PULPIT = '����';
-------------------------- t1 --------------------
commit; 
select * from SUBJECT where PULPIT = '����';
     -------------------------- t2 --------------------

--task8
begin tran
	insert SUBJECT values('oldSubj', 'old', '����');
	begin tran
		select @@trancount '�����������';
		update SUBJECT set SUBJECT = 'old-->New' where SUBJECT = 'oldSubj';
	commit;
	if	@@trancount > 0 rollback;
	select @@trancount '�����������';
commit;
