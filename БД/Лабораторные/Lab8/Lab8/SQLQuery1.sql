--task1
CREATE VIEW [�������������]
	as SELECT	TEACHER[���],
				TEACHER_NAME[��� �������������],
				GENDER[���],
				PULPIT[��� �������]
	FROM TEACHER
SELECT * FROM [�������������]

--task2
CREATE VIEW [���������� ������]
	as SELECT	FACULTY.FACULTY_NAME[���������],
				count(*)[���-�� ������]
	FROM FACULTY INNER JOIN PULPIT
	ON FACULTY.FACULTY = PULPIT.FACULTY
	GROUP BY FACULTY.FACULTY_NAME
SELECT * FROM [���������� ������]

--task3
CREATE VIEW [���������]
	as SELECT	AUDITORIUM[���],
				AUDITORIUM_TYPE[������������ ���������]
	FROM AUDITORIUM
	WHERE AUDITORIUM_TYPE LIKE '%��%'
SELECT * FROM [���������]
INSERT [���������] VALUES('221-3', '��')

--task4
CREATE VIEW [���������� ���������]
	as SELECT	AUDITORIUM[���],
				AUDITORIUM_TYPE[������������ ���������]
	FROM AUDITORIUM
	WHERE AUDITORIUM_TYPE LIKE '%��%' WITH CHECK OPTION
SELECT * FROM [���������� ���������]
INSERT [���������� ���������] VALUES('222-1', '��-�')

--task5
CREATE VIEW [����������]
	as SELECT TOP 50 SUBJECT[���],
					 SUBJECT_NAME[������������ ����������],
					 PULPIT[��� �������]
	FROM SUBJECT
	ORDER BY SUBJECT_NAME
SELECT * FROM [����������]

--task6
ALTER VIEW [���������� ������] WITH SCHEMABINDING
	as SELECT	z1.FACULTY_NAME[���������],
				count(*)[���-�� ������]
	FROM dbo.FACULTY z1 INNER JOIN dbo.PULPIT z2
	ON z1.FACULTY = z2.FACULTY
	GROUP BY z1.FACULTY_NAME
SELECT * FROM [���������� ������]