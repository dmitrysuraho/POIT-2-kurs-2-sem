CREATE TABLE ���������(
	��������_��������� nvarchar(50) NOT NULL,
	����� nvarchar(50) NOT NULL,
	������_��_��������� nvarchar(50) NOT NULL,
	����_��������� int NOT NULL,
	PRIMARY KEY (��������_���������))
CREATE TABLE ����������(
	������� nvarchar(50) NOT NULL,
	��� nvarchar(50) NOT NULL,
	�������� nvarchar(50) NOT NULL, 
	����_�������� date NOT NULL,
	��� nvarchar(50) NOT NULL,
	��������_��������� nvarchar(50) NOT NULL, 
	����_���������� date NOT NULL,
    PRIMARY KEY (�������),
	FOREIGN KEY (��������_���������)  REFERENCES ��������� (��������_���������))
CREATE TABLE ��������(
	��������_��������� nvarchar(50) NOT NULL,
	����������_�_������������ nvarchar(50) NOT NULL,
    PRIMARY KEY (��������_���������),
	FOREIGN KEY (��������_���������)  REFERENCES ��������� (��������_���������))

insert into ��������� values('��������','�����������','50% �������', 2)
insert into ��������� values('��������','������� �����','������ 30 ����', 3)
insert into ��������� values('��������','������ �����','������ 25 ����', 5)
insert into ��������� values('�������','������ �����','������ 25 ����', 1)
insert into ��������� values('�������','������ �����','������ 25 ����', 2)

insert into �������� values('�������','������')
insert into �������� values('��������','������ � ������')
insert into �������� values('��������','������ � ��������')

insert into ���������� values('������','����','��������','28.12.1970','�������','��������', '13.05.2020')
insert into ���������� values('�������','������','���������','12.06.1989','�������', '�������', '3.10.2020')
insert into ���������� values('�������','����','����������','09.03.1976','�������', '�������', '21.02.2020')