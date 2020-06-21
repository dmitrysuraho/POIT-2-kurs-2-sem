--task1
set nocount on
if  exists (select * from  SYS.OBJECTS        -- таблица X есть?
	            where OBJECT_ID= object_id(N'DBO.X') )	            
	drop table X;           
declare @c int, @flag char = 'r';           -- commit или rollback?
SET IMPLICIT_TRANSACTIONS  ON   -- включ. режим неявной транзакции
CREATE table X(K int );                         -- начало транзакции 
	INSERT X values (1),(2),(3);
	set @c = (select count(*) from X);
	print 'количество строк в таблице X: ' + cast( @c as varchar(2));
	if @flag = 'c'  commit;                   -- завершение транзакции: фиксация 
	else   rollback;                                 -- завершение транзакции: откат  
SET IMPLICIT_TRANSACTIONS  OFF   -- выключ. режим неявной транзакции	
if  exists (select * from  SYS.OBJECTS       -- таблица X есть?
	            where OBJECT_ID= object_id(N'DBO.X') )
print 'таблица X есть';  
else print 'таблицы X нет'

--task2
begin try
	begin tran
		delete TEACHER where TEACHER = 'СМЛВ';
		insert TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) values('СДА', 'СДА', 'м', 'ИСиТ');
	commit tran;
end try
begin catch
	print 'Ошибка: ' + cast(error_number() as varchar(5)) + error_message();
	if @@TRANCOUNT > 0 rollback tran;
end catch;

--task3
declare @point varchar(32);
begin try
	begin tran
		delete TEACHER where TEACHER = 'СДА';
		set @point = 'p1'; save tran @point;
		insert TEACHER values('New', 'New', 'м', 'ИСиТ');
		set @point = 'p2'; save tran @point;
		insert TEACHER values('СМЛВ', 'СМЛВ', 'м', 'ИСиТ');
	commit tran;
end try
begin catch
	print 'Ошибка: ' + cast(error_number() as varchar(5)) + error_message();
	if @@TRANCOUNT > 0
		begin
			print 'Контрольная точки: ' + @point;
			rollback tran @point;
			commit tran;
		end;
end catch

--task4
-- A ---
set transaction isolation level READ UNCOMMITTED 
begin transaction 
-------------------------- t1 ------------------
select @@SPID,  * from SUBJECT where PULPIT = 'ИСиТ';
--rollback
commit; 
-------------------------- t2 -----------------
--- B ---	
begin transaction 
select @@SPID
insert SUBJECT values ('NewSubject', 'NS', 'ИСиТ');
-------------------------- t1 --------------------
-------------------------- t2 --------------------
rollback;

--task5
-- A ---
set transaction isolation level READ COMMITTED 
begin transaction 
-------------------------- t1 ------------------
-------------------------- t2 -----------------
select * from SUBJECT where PULPIT = 'ИСиТ';
commit;

--- B ---
set transaction isolation level READ COMMITTED 
begin transaction 
-------------------------- t1 --------------------
update SUBJECT set SUBJECT = 'Task' where SUBJECT = 'ПЗ'
select  * from SUBJECT where PULPIT = 'ИСиТ';
-------------------------- t2 --------------------
commit;
--rollback

--task6
-- A ---
set transaction isolation level REPEATABLE READ
begin transaction 
select * from SUBJECT where PULPIT = 'ИСиТ';
-------------------------- t1 ------------------
-------------------------- t2 -----------------
select * from SUBJECT where SUBJECT = 'NewSubject';
commit; 

--- B ---	
begin transaction 
-------------------------- t1 --------------------
insert SUBJECT values ('NewSubject', 'NS', 'ИСиТ');
select  * from SUBJECT where PULPIT = 'ИСиТ';
-------------------------- t2 --------------------
rollback;

--task7
-- A ---
set transaction isolation level SERIALIZABLE 
begin transaction
select * from SUBJECT where PULPIT = 'ИСиТ';
-------------------------- t1 -----------------
select * from SUBJECT where PULPIT = 'ИСиТ';
-------------------------- t2 ------------------ 
commit; 	
	--- B ---	
begin transaction 	   
insert SUBJECT values ('NewSubject', 'NS', 'ИСиТ');
select * from SUBJECT where PULPIT = 'ИСиТ';
-------------------------- t1 --------------------
commit; 
select * from SUBJECT where PULPIT = 'ИСиТ';
     -------------------------- t2 --------------------

--task8
begin tran
	insert SUBJECT values('oldSubj', 'old', 'ИСиТ');
	begin tran
		select @@trancount 'Вложенность';
		update SUBJECT set SUBJECT = 'old-->New' where SUBJECT = 'oldSubj';
	commit;
	if	@@trancount > 0 rollback;
	select @@trancount 'Вложенность';
commit;
