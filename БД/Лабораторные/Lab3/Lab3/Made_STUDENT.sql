use Suraho_UNIVER
CREATE TABLE STUDENT(
	�����_������� int PRIMARY KEY NOT NULL,
	�������_�������� nvarchar(50) NOT NULL,
	�����_������ int NOT NULL,
);

ALTER TABLE STUDENT ADD ����_����������� date;
ALTER TABLE STUDENT DROP COLUMN ����_�����������;

INSERT INTO STUDENT(�����_�������, �������_��������, �����_������)
	VALUES (1, '������', 5), (2, '�������', 10), (3, '������', 3), (4, '��������', 5);

SELECT * FROM STUDENT;
SELECT �����_������, �������_�������� FROM STUDENT;
SELECT count(*) FROM STUDENT; 
SELECT * FROM STUDENT WHERE �����_������� >= 2;
SELECT DISTINCT TOP(2) * FROM STUDENT ORDER BY �����_������;

UPDATE STUDENT SET �����_������ = 5;
DELETE FROM STUDENT WHERE �����_������� = 3;
SELECT * FROM STUDENT;

SELECT * FROM STUDENT WHERE �����_������� BETWEEN 2 AND 3;
SELECT * FROM STUDENT WHERE �������_�������� LIKE '%�';
SELECT * FROM STUDENT WHERE �����_������� IN(1, 4);

DROP TABLE STUDENT;