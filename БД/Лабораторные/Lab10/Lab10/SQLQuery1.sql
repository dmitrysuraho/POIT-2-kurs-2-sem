--task1
use S_UNIVER
exec SP_HELPINDEX 'AUDITORIUM'
exec SP_HELPINDEX 'AUDITORIUM_TYPE'
exec SP_HELPINDEX 'FACULTY'
exec SP_HELPINDEX 'GROUPS'
exec SP_HELPINDEX 'PROFESSION'
exec SP_HELPINDEX 'PROGRESS'
exec SP_HELPINDEX 'PULPIT'
exec SP_HELPINDEX 'STUDENT'
exec SP_HELPINDEX 'SUBJECT'
exec SP_HELPINDEX 'TEACHER'

drop table #ex
create table #ex
( 
	tint int,
	tstring varchar(100)
);
set nocount on;
declare @i int = 0;
while @i < 1000
begin
	insert #ex(tint, tstring)
		values(1000*rand(), 'строка №' + cast((@i + 1) as varchar(5)));
	set @i = @i + 1;
end;
select * from #ex where tint between 100 and 500;

checkpoint; --фиксация БД
dbcc dropcleanbuffers; -- очистка кэша

create clustered index #ex_cl on #ex(tint asc);
--task2
drop table #ex2
create table #ex2
( 
	tint int,
	cc int identity(1,1),
	tstring varchar(100)
);
set nocount on;
declare @i2 int = 0;
while @i2 < 10000
begin
	insert #ex2(tint, tstring)
		values(1000*rand(), 'строка №' + cast((@i2 + 1) as varchar(5)));
	set @i2 = @i2 + 1;
end;

select * from #ex2;

create index #ex2_nonclu on #ex2(tint, cc);

select * from #ex2 where tint = 500;
--task3
create table #ex3
( 
	tint int,
	cc int identity(1,1),
	tstring varchar(100)
);
set nocount on;
declare @i3 int = 0;
while @i3 < 10000
begin
	insert #ex3(tint, tstring)
		values(1000*rand(), 'строка №' + cast((@i3 + 1) as varchar(5)));
	set @i3 = @i3 + 1;
end;

select cc from #ex3 where tint > 500;

create index #ex3_tint_x on #ex3(tint) include (cc);
--task4
create table #ex4
( 
	tint int,
	cc int identity(1,1),
	tstring varchar(100)
);
set nocount on;
declare @i4 int = 0;
while @i4 < 10000
begin
	insert #ex4(tint, tstring)
		values(1000*rand(), 'строка №' + cast((@i4 + 1) as varchar(5)));
	set @i4 = @i4 + 1;
end;

select tint from #ex4 where tint between 200 and 700;
select tint from #ex4 where tint >= 100 and tint <= 400;

create index #ex4_where on #ex4(tint) where (tint >= 100 and tint <= 400);
--task5
use S_UNIVER
create table newTable
( 
	tint int,
	cc int identity(1,1),
	tstring varchar(100)
);
set nocount on;
declare @i5 int = 0;
while @i5 < 10000
begin
	insert newTable(tint, tstring)
		values(1000*rand(), 'строка №' + cast((@i5 + 1) as varchar(5)));
	set @i5 = @i5 + 1;
end;
--drop table newTable;

select tint from newTable;

create index newTable_cl on newTable(tint);

select name[Индекс], avg_fragmentation_in_percent[Фрагментация(%)]
	from sys.dm_db_index_physical_stats(DB_ID(N'S_UNIVER'),
	OBJECT_ID(N'newTable'), NULL, NULL, NULL) ss
	JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
	where name is not null;

INSERT top(50000) newTable(tint, tstring) select tint, tstring from newTable;

alter index newTable_cl on newTable reorganize; --реорганизация
alter index newTable_cl on newTable rebuild; --перестройка
--task6

drop index newTable_cl on newTable;
create index newTable_cl on newTable(tint) with (fillfactor = 65);

INSERT top(50000) newTable(tint, tstring) select tint, tstring from newTable;
select name[Индекс], avg_fragmentation_in_percent[Фрагментация(%)]
	from sys.dm_db_index_physical_stats(DB_ID(N'S_UNIVER'),
	OBJECT_ID(N'newTable'), NULL, NULL, NULL) ss
	JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
	where name is not null;
