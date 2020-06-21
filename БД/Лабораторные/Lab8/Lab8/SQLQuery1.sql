--task1
CREATE VIEW [Преподаватель]
	as SELECT	TEACHER[код],
				TEACHER_NAME[имя преподавателя],
				GENDER[пол],
				PULPIT[код кафедры]
	FROM TEACHER
SELECT * FROM [Преподаватель]

--task2
CREATE VIEW [Количество кафедр]
	as SELECT	FACULTY.FACULTY_NAME[факультет],
				count(*)[Кол-во кафедр]
	FROM FACULTY INNER JOIN PULPIT
	ON FACULTY.FACULTY = PULPIT.FACULTY
	GROUP BY FACULTY.FACULTY_NAME
SELECT * FROM [Количество кафедр]

--task3
CREATE VIEW [Аудитории]
	as SELECT	AUDITORIUM[код],
				AUDITORIUM_TYPE[наименование аудитории]
	FROM AUDITORIUM
	WHERE AUDITORIUM_TYPE LIKE '%ЛК%'
SELECT * FROM [Аудитории]
INSERT [Аудитории] VALUES('221-3', 'ЛК')

--task4
CREATE VIEW [Лекционные аудитории]
	as SELECT	AUDITORIUM[код],
				AUDITORIUM_TYPE[наименование аудитории]
	FROM AUDITORIUM
	WHERE AUDITORIUM_TYPE LIKE '%ЛК%' WITH CHECK OPTION
SELECT * FROM [Лекционные аудитории]
INSERT [Лекционные аудитории] VALUES('222-1', 'ЛК-К')

--task5
CREATE VIEW [Дисциплины]
	as SELECT TOP 50 SUBJECT[код],
					 SUBJECT_NAME[наименование дисциплины],
					 PULPIT[код кафедры]
	FROM SUBJECT
	ORDER BY SUBJECT_NAME
SELECT * FROM [Дисциплины]

--task6
ALTER VIEW [Количество кафедр] WITH SCHEMABINDING
	as SELECT	z1.FACULTY_NAME[факультет],
				count(*)[Кол-во кафедр]
	FROM dbo.FACULTY z1 INNER JOIN dbo.PULPIT z2
	ON z1.FACULTY = z2.FACULTY
	GROUP BY z1.FACULTY_NAME
SELECT * FROM [Количество кафедр]