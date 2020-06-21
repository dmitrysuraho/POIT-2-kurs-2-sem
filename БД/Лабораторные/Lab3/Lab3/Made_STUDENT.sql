use Suraho_UNIVER
CREATE TABLE STUDENT(
	Номер_зачетки int PRIMARY KEY NOT NULL,
	Фамилия_студента nvarchar(50) NOT NULL,
	Номер_группы int NOT NULL,
);

ALTER TABLE STUDENT ADD Дата_поступления date;
ALTER TABLE STUDENT DROP COLUMN Дата_поступления;

INSERT INTO STUDENT(Номер_зачетки, Фамилия_студента, Номер_группы)
	VALUES (1, 'Иванов', 5), (2, 'Сидоров', 10), (3, 'Петров', 3), (4, 'Ромашкин', 5);

SELECT * FROM STUDENT;
SELECT Номер_группы, Фамилия_студента FROM STUDENT;
SELECT count(*) FROM STUDENT; 
SELECT * FROM STUDENT WHERE Номер_зачетки >= 2;
SELECT DISTINCT TOP(2) * FROM STUDENT ORDER BY Номер_группы;

UPDATE STUDENT SET Номер_группы = 5;
DELETE FROM STUDENT WHERE Номер_зачетки = 3;
SELECT * FROM STUDENT;

SELECT * FROM STUDENT WHERE Номер_зачетки BETWEEN 2 AND 3;
SELECT * FROM STUDENT WHERE Фамилия_студента LIKE '%в';
SELECT * FROM STUDENT WHERE Номер_зачетки IN(1, 4);

DROP TABLE STUDENT;