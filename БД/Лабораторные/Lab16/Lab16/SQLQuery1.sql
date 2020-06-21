--task1
select * from TEACHER
	where PULPIT = 'ИСиТ' for xml PATH, root('Список_преподавателей_кафедры_ИСиТ'), elements;

--task2
select AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME, AUDITORIUM.AUDITORIUM_CAPACITY
	from AUDITORIUM inner join AUDITORIUM_TYPE on AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE
	where AUDITORIUM_TYPE.AUDITORIUM_TYPE = 'ЛК' for xml AUTO,
												root('Список_ЛК_аудиторий'), elements;

--task3
go
select * from SUBJECT;

declare @h int = 0,
@x varchar(2000) = ' <?xml version="1.0" encoding="windows-1251" ?>
     <subjects> 
       <subject subj="NewSubj1" name="NewSubj1" pulpit="ИСиТ" /> 
       <subject subj="NewSubj2" name="NewSubj2" pulpit="ИСиТ" /> 
       <subject subj="NewSubj3" name="NewSubj3" pulpit="ИСиТ"  />  
     </subjects>';
exec sp_xml_preparedocument @h output, @x;  -- подготовка документа 
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
		values('Дмитрий', '<паспорт>
								<серия_паспорта>MP</серия_паспорта>
								<номер_паспорта>12345678</номер_паспорта>
								<адрес>
									<страна>Беларусь</страна>
									<город>Борисов</город>
									<улица>б-р Гречко</улица>
								</адрес>
						   </паспорт>');

insert into StudentPass(name, passport)
		values('Александр', '<паспорт>
								<серия_паспорта>MC</серия_паспорта>
								<номер_паспорта>87654321</номер_паспорта>
								<адрес>
									<страна>Беларусь</страна>
									<город>Гродно</город>
									<улица>ул. Гагарина</улица>
								</адрес>
						   </паспорт>');

update StudentPass 
        set passport = '<паспорт>
								<серия_паспорта>old</серия_паспорта>
								<номер_паспорта>old</номер_паспорта>
								<адрес>
									<страна>new</страна>
									<город>new</город>
									<улица>new</улица>
								</адрес>
						   </паспорт>' 
                where name = 'Александр';


select name, 
     passport.value('(/паспорт/серия_паспорта)[1]','varchar(10)') [серия паспорта],
	 passport.value('(/паспорт/номер_паспорта)[1]','varchar(10)') [номер паспорта],
     passport.query('/паспорт/адрес') [адрес]
             from  StudentPass;       

--task5
drop xml schema collection StudentPass
create xml schema collection StudentPass as 
N'<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="страна" type="xs:string"/>
  <xs:element name="город" type="xs:string"/>
  <xs:element name="улица" type="xs:string"/>
  <xs:element name="серия_паспорта" type="xs:string"/>
  <xs:element name="номер_паспорта" type="xs:string"/>
  <xs:element name="адрес">
    <xs:complexType>
      <xs:sequence>
        <xs:element ref="страна"/>
        <xs:element ref="город"/>
        <xs:element ref="улица"/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name="паспорт">
    <xs:complexType>
      <xs:sequence>
        <xs:element ref="серия_паспорта"/>
        <xs:element ref="номер_паспорта"/>
        <xs:element ref="адрес"/>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>';

create table StudentPass(
	name varchar(50) primary key,
	passport xml(StudentPass)
);

insert into StudentPass(name, passport)
		values('Дмитрий', '<паспорт>
								<серия_паспорта>MP</серия_паспорта>
								<номер_паспорта>12345678</номер_паспорта>
								<адрес>
									<страна>Беларусь</страна>
									<город>Борисов</город>
									<улица>б-р Гречко</улица>
								</адрес>
						   </паспорт>');

insert into StudentPass(name, passport)
		values('Александр', '<паспорт>
								<серия_паспорта>MC</серия_паспорта>
								<номер_паспорта>87654321</номер_паспорта>
								<адрес>
									<страна>Беларусь</страна>
									<город>Гродно</город>
									<улица>ул. Гагарина</улица>
								</адрес>
						   </паспорт>');

update StudentPass 
        set passport = '<паспорт>
								<серия_паспорта>old</серия_паспорта>
								<номер_паспорта>old</номер_паспорта>
								<адрес>
									<страна>new</страна>
									<город>new</город>
									<улица>new</улица>
								</адрес>
						   </паспорт>' 
                where name = 'Александр';


select name, 
     passport.value('(/паспорт/серия_паспорта)[1]','varchar(10)') [серия паспорта],
	 passport.value('(/паспорт/номер_паспорта)[1]','varchar(10)') [номер паспорта],
     passport.query('/паспорт/адрес') [адрес]
             from  StudentPass;    

