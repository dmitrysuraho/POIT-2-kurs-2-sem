--task4
--- B ---	
begin transaction 
select @@SPID
insert SUBJECT values ('NewSubject', 'NS', '����');
-------------------------- t1 --------------------
-------------------------- t2 --------------------
rollback;

--task5
--- B ---	
begin transaction 
-------------------------- t1 --------------------
update SUBJECT set SUBJECT = 'Task' where SUBJECT = '��'
select  * from SUBJECT where PULPIT = '����';
-------------------------- t2 --------------------
commit;
--rollback

--task6
--- B ---	
begin transaction 
-------------------------- t1 --------------------
update SUBJECT set SUBJECT = '��' where SUBJECT = 'Task'
insert SUBJECT values ('NewSubject', 'NS', '����');
select  * from SUBJECT where PULPIT = '����';
-------------------------- t2 --------------------
commit;

--task7
--- B ---	
begin transaction 	   
insert SUBJECT values ('NewSubject', 'NS', '����');
select * from SUBJECT where PULPIT = '����';
-------------------------- t1 --------------------
commit; 
select * from SUBJECT where PULPIT = '����';
     -------------------------- t2 --------------------