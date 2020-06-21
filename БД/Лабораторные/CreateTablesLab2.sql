CREATE TABLE ДОЛЖНОСТИ(
	Название_должности nvarchar(50) NOT NULL,
	Отдел nvarchar(50) NOT NULL,
	Льготы_по_должности nvarchar(50) NOT NULL,
	Срок_контракта int NOT NULL,
	PRIMARY KEY (Название_должности))
CREATE TABLE СОТРУДНИКИ(
	Фамилия nvarchar(50) NOT NULL,
	Имя nvarchar(50) NOT NULL,
	Отчество nvarchar(50) NOT NULL, 
	Дата_дождения date NOT NULL,
	Пол nvarchar(50) NOT NULL,
	Название_должности nvarchar(50) NOT NULL, 
	Дата_назначения date NOT NULL,
    PRIMARY KEY (Фамилия),
	FOREIGN KEY (Название_должности)  REFERENCES ДОЛЖНОСТИ (Название_должности))
CREATE TABLE ВАКАНСИИ(
	Название_должности nvarchar(50) NOT NULL,
	Требование_к_квалификации nvarchar(50) NOT NULL,
    PRIMARY KEY (Название_должности),
	FOREIGN KEY (Название_должности)  REFERENCES ДОЛЖНОСТИ (Название_должности))

insert into ДОЛЖНОСТИ values('Директор','Руководство','50% прибыли', 2)
insert into ДОЛЖНОСТИ values('Менеджер','Среднее звено','Отпуск 30 дней', 3)
insert into ДОЛЖНОСТИ values('Продавец','Низшее звено','Отпуск 25 дней', 5)
insert into ДОЛЖНОСТИ values('Грузчик','Низшее звено','Отпуск 25 дней', 1)
insert into ДОЛЖНОСТИ values('Уборщик','Низшее звено','Отпуск 25 дней', 2)

insert into ВАКАНСИИ values('Уборщик','Уборка')
insert into ВАКАНСИИ values('Менеджер','Работа с людьми')
insert into ВАКАНСИИ values('Продавец','Работа с деньгами')

insert into СОТРУДНИКИ values('Петров','Петр','Петрович','28.12.1970','Мужской','Менеджер', '13.05.2020')
insert into СОТРУДНИКИ values('Иванова','Галина','Сергеевна','12.06.1989','Женский', 'Уборщик', '3.10.2020')
insert into СОТРУДНИКИ values('Сидоров','Олег','Витальевич','09.03.1976','Мужской', 'Грузчик', '21.02.2020')