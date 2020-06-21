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
		select @count [���-�� ���������],
		       @avg [������� �����������],
			   @countAvg [���-�� ���. < �������],
			   @prc [%];
	end;
	else select @sum [����� ����������� ���.];
--task3
	print cast(@@ROWCOUNT as varchar(20)) + '(����� ������������ �����)';
    print cast(@@VERSION as varchar(20)) + '(������ SQL Server)';
    print cast(@@SPID as varchar(20)) + '(���������� ��������� ������������� ��������, ����������� �������� �������� �����������)';
    print cast(@@ERROR as varchar(20)) + '(��� ��������� ������)';
    print cast(@@SERVERNAME as varchar(20)) + '(��� �������)';
    print cast(@@TRANCOUNT as varchar(20)) + '(���������� ������� ����������� ����������)';
    print cast(@@FETCH_STATUS as varchar(20)) + '(�������� ���������� ���������� ����� ��������������� ������)'; 
    print cast(@@NESTLEVEL as varchar(20)) + '(������� ������-����� ������� ���������)';
--task4
    --������� ���������
	declare @z float, @t float = 2.56, @x float = 11;
	if @t > @x set @z = power(sin(@t), 2);
	else if @t < @x set @z = 4*(@t + @x);
	else set @z = 1 - exp(@x - 2);
	select @z z;

	--���
	declare @name varchar(30) = '������ ������� �������������',
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

	--�� � ����.������ + �������
	select NAME, BDAY, (floor(DATEDIFF(d, BDAY, GETDATE())/365))[AGE]
		from STUDENT
		where (month(BDAY) - month(GETDATE())) = 1

	--���� ������ �������� ����
	declare @day int = (select TOP(1) (DATEPART(dw, PDATE) - 1) from PROGRESS where SUBJECT = '����');
	print '���� ������: ' + 
	(case 
		when @day = 1 then '��'
		when @day = 2 then '��'
		when @day = 3 then '��'
		when @day = 4 then '��'
		when @day = 5 then '��'
		when @day = 6 then '��'
		else '��'
	end);
--task5
	declare @ccount int = (select count(*) from STUDENT);
	if (@ccount > 30)
	begin
		print '���-�� ��������� ������ 30';
		print '���-�� = ' + cast(@ccount as varchar(5));
	end;
	else
	begin
		print '���-�� ��������� ������ 30';
		print '���-�� = ' + cast(@ccount as varchar(5));
	end;
--task6
	declare @aaavg float = (select avg(cast(NOTE as float)) from PROGRESS);
	print '������� ������� ��������� "' + 
		(
			case 
				when @aaavg > 6 then '������ 6'
				when @aaavg < 6 then '������ 6'
				else '����� 6'
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
			values(1000 * rand(), '������ #' + cast((@i + 1) as varchar(5)), SYSDATETIME());
		set @i += 1;
	end;
	select * from #time;

	drop table #time
--task8
	print '���1';
	print '���2';
	return;
	print '���3'
--task9
	begin try
		print 'begin try';
		insert PROGRESS(SUBJECT, IDSTUDENT, PDATE, NOTE) values ('��', '1014', '2001-12-12', 11);
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