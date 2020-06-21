package univer.faculty.FITExtramural;

import univer.student.StudentInfo;

public class isitextr extends FITExtramural {
    public Subjects Subject = Subjects.Csis;
    public String NameScpec;
    public Subjects getSubject() {
        return Subject;
    }

    public void setSubject(Subjects subject) {
        Subject = subject;
    }

    public isitextr(String name, int age, int date, int shift, int kurs)
    {
        Info = new StudentInfo(name, age, kurs);
        DateExem = date;
        Shift = shift;
        NameScpec = "ISIT";
    }

    @Override
    public void Spec()
    {
        System.out.println("Name: " + Info.Name + ", age: " + Info.Age + ", date: " + DateExem + ", shift: " + Shift + ", name of spec: " + NameScpec + ", subject: " + Subject + ", kurs: " + Info.Kurs);
    }
}
