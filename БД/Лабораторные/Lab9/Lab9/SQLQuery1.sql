--task1
declare @a char = 'a',
		@b varchar(1) = 'b',
		@c datetime,
		@d time,
		@e int,
		@f smallint,
		@g tinyint,
		@h numeric(12, 5);
	set @c = '07.04.2020';
	set	@d = '16:30:30';
	select @e = count(*) from SUBJECT;
	select @f = 2,
		   @g = 3;
	select @a a, @b b, @c c, @e e,
		   @d d;
	print @e + @f + @g;
--task2
	declare @sum int = (select sum(AUDITORIUM_CAPACITY) from AUDITORIUM);
	declare @count int, @avg int, @countAvg int, @prc real;
	if @sum > 200
	begin
		select @count = (select count(*) from AUDITORIUM);
		   set @avg = @sum / @count;
		select @countAvg = (select count(*) from AUDITORIUM where AUDITORIUM_CAPACITY < @avg);
		   set @prc = (cast(@countAvg as real) / cast(@count as real)) * 100;
		select @count [Кол-во аудиторий],
		       @avg [Средняя вместимость],
			   @countAvg [Кол-во ауд. < средней],
			   @prc [%];
	end;
	else select @sum [Общая вместимость ауд.];
--task3
	print cast(@@ROWCOUNT as varchar(20)) + '(число обработанных строк)';
    print cast(@@VERSION as varchar(20)) + '(версия SQL Server)';
    print cast(@@SPID as varchar(20)) + '(возвращает системный идентификатор процесса, назначенный сервером текущему подключению)';
    print cast(@@ERROR as varchar(20)) + '(код последней ошибки)';
    print cast(@@SERVERNAME as varchar(20)) + '(имя сервера)';
    print cast(@@TRANCOUNT as varchar(20)) + '(возвращает уровень вложенности транзакции)';
    print cast(@@FETCH_STATUS as varchar(20)) + '(проверка результата считывания строк результирующего набора)'; 
    print cast(@@NESTLEVEL as varchar(20)) + '(уровень вложен-ности текущей процедуры)';
--task4
    --система уравнений
	declare @z float, @t float = 2.56, @x float = 11;
	if @t > @x set @z = power(sin(@t), 2);
	else if @t < @x set @z = 4*(@t + @x);
	else set @z = 1 - exp(@x - 2);
	select @z z;

	--ФИО
	declare @name varchar(30) = 'Сураго Дмитрий Александрович',
			@result varchar(15),  @promresult varchar(30), @position int,
			@secondName varchar(15);
	declare @strlen int = LEN(@name); 
	set @position = CHARINDEX(' ', @name);
	set @secondName = LEFT(@name, @position);
	set @promresult = SUBSTRING(@name, @position + 1,@strlen);
	set @result = LEFT(@promresult, 1) + '.';
	set @position = CHARINDEX(' ', @promresult);
	set @promresult = SUBSTRING(@promresult, @position + 1, @strlen);
	set @result += (LEFT(@promresult, 1) + '.');
	set @secondName += @result;
	select @secondName a;

	--ДР в след.месяце + возраст
	select NAME, BDAY, (floor(DATEDIFF(d, BDAY, GETDATE())/365))[AGE]
		from STUDENT
		where (month(BDAY) - month(GETDATE())) = 1

	--день недели экзамена СУБД
	declare @day int = (select TOP(1) (DATEPART(dw, PDATE) - 1) from PROGRESS where SUBJECT = 'СУБД');
	print 'День недели: ' + 
	(case 
		when @day = 1 then 'Пн'
		when @day = 2 then 'Вт'
		when @day = 3 then 'Ср'
		when @day = 4 then 'Чт'
		when @day = 5 then 'Пт'
		when @day = 6 then 'Сб'
		else 'Вс'
	end);
--task5
	declare @ccount int = (select count(*) from STUDENT);
	if (@ccount > 30)
	begin
		print 'Кол-во студентов больше 30';
		print 'Кол-во = ' + cast(@ccount as varchar(5));
	end;
	else
	begin
		print 'Кол-во студентов меньше 30';
		print 'Кол-во = ' + cast(@ccount as varchar(5));
	end;
--task6
	declare @aaavg float = (select avg(cast(NOTE as float)) from PROGRESS);
	print 'Средняя отметка студентов "' + 
		(
			case 
				when @aaavg > 6 then 'больше 6'
				when @aaavg < 6 then 'меньше 6'
				else 'равна 6'
			end
		)
	+ '"';
--task7
	create table #time(int_field int, string_field varchar(100), time_field time(7));
	set nocount off;
	declare @i int = 0;
	while @i < 10
	begin
		insert #time(int_field, string_field, time_field)
			values(1000 * rand(), 'Строка #' + cast((@i + 1) as varchar(5)), SYSDATETIME());
		set @i += 1;
	end;
	select * from #time;

	drop table #time
--task8
	print 'Шаг1';
	print 'Шаг2';
	return;
	print 'Шаг3'
--task9
	begin try
		print 'begin try';
		insert PROGRESS(SUBJECT, IDSTUDENT, PDATE, NOTE) values ('БД', '1014', '2001-12-12', 11);
		print 'end try';
	end try
	begin catch
		print 'begin catch';
		print ERROR_NUMBER();
		print ERROR_MESSAGE();
		print ERROR_LINE();
		print ERROR_PROCEDURE();
		print ERROR_SEVERITY();
		print ERROR_STATE();
		print 'end catch';
	end catch