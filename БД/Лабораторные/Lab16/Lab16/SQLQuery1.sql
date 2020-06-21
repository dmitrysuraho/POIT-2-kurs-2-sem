--task1
select * from TEACHER
	where PULPIT = '����' for xml PATH, root('������_��������������_�������_����'), elements;

--task2
select AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME, AUDITORIUM.AUDITORIUM_CAPACITY
	from AUDITORIUM inner join AUDITORIUM_TYPE on AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
	where AUDITORIUM_TYPE.AUDITORIUM_TYPE = '��' for xml AUTO,
												root('������_��_���������'), elements;

--task3
go
select * from SUBJECT;

declare @h int = 0,
@x varchar(2000) = ' <?xml version="1.0" encoding="windows-1251" ?>
     <subjects> 
       <subject subj="NewSubj1" name="NewSubj1" pulpit="����" /> 
       <subject subj="NewSubj2" name="NewSubj2" pulpit="����" /> 
       <subject subj="NewSubj3" name="NewSubj3" pulpit="����"  />  
     </subjects>';
exec sp_xml_preparedocument @h output, @x;  -- ���������� ��������� 
insert SUBJECT select * from openxml(@h, '/subjects/subject', 0)
	with([subj] nvarchar(20), [name] nvarchar(100), [pulpit] nvarchar(20))       
exec sp_xml_removedocument @h;                          
go
                        
--task4
drop table StudentPass;
create table StudentPass(
	name varchar(50) primary key,
	passport xml
);
 
insert into StudentPass(name, passport)
		values('�������', '<�������>
								<�����_��������>MP</�����_��������>
								<�����_��������>12345678</�����_��������>
								<�����>
									<������>��������</������>
									<�����>�������</�����>
									<�����>�-� ������</�����>
								</�����>
						   </�������>');

insert into StudentPass(name, passport)
		values('���������', '<�������>
								<�����_��������>MC</�����_��������>
								<�����_��������>87654321</�����_��������>
								<�����>
									<������>��������</������>
									<�����>������</�����>
									<�����>��. ��������</�����>
								</�����>
						   </�������>');

update StudentPass 
        set passport = '<�������>
								<�����_��������>old</�����_��������>
								<�����_��������>old</�����_��������>
								<�����>
									<������>new</������>
									<�����>new</�����>
									<�����>new</�����>
								</�����>
						   </�������>' 
                where name = '���������';


select name, 
     passport.value('(/�������/�����_��������)[1]','varchar(10)') [����� ��������],
	 passport.value('(/�������/�����_��������)[1]','varchar(10)') [����� ��������],
     passport.query('/�������/�����') [�����]
             from  StudentPass;       

--task5
drop xml schema collection StudentPass
create xml schema collection StudentPass as 
N'<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="������" type="xs:string"/>
  <xs:element name="�����" type="xs:string"/>
  <xs:element name="�����" type="xs:string"/>
  <xs:element name="�����_��������" type="xs:string"/>
  <xs:element name="�����_��������" type="xs:string"/>
  <xs:element name="�����">
    <xs:complexType>
      <xs:sequence>
        <xs:element ref="������"/>
        <xs:element ref="�����"/>
        <xs:element ref="�����"/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name="�������">
    <xs:complexType>
      <xs:sequence>
        <xs:element ref="�����_��������"/>
        <xs:element ref="�����_��������"/>
        <xs:element ref="�����"/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>';

create table StudentPass(
	name varchar(50) primary key,
	passport xml(StudentPass)
);

insert into StudentPass(name, passport)
		values('�������', '<�������>
								<�����_��������>MP</�����_��������>
								<�����_��������>12345678</�����_��������>
								<�����>
									<������>��������</������>
									<�����>�������</�����>
									<�����>�-� ������</�����>
								</�����>
						   </�������>');

insert into StudentPass(name, passport)
		values('���������', '<�������>
								<�����_��������>MC</�����_��������>
								<�����_��������>87654321</�����_��������>
								<�����>
									<������>��������</������>
									<�����>������</�����>
									<�����>��. ��������</�����>
								</�����>
						   </�������>');

update StudentPass 
        set passport = '<�������>
								<�����_��������>old</�����_��������>
								<�����_��������>old</�����_��������>
								<�����>
									<������>new</������>
									<�����>new</�����>
									<�����>new</�����>
								</�����>
						   </�������>' 
                where name = '���������';


select name, 
     passport.value('(/�������/�����_��������)[1]','varchar(10)') [����� ��������],
	 passport.value('(/�������/�����_��������)[1]','varchar(10)') [����� ��������],
     passport.query('/�������/�����') [�����]
             from  StudentPass;    

