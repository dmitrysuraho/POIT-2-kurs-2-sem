package univer.faculty.FITFullTime;

import univer.student.StudentInfo;

public class mobft extends FITFullTime {
    public Subjects Subject = Subjects.C;
    public String NameScpec;
    public Subjects getSubject() {
        return Subject;
    }

    public void setSubject(Subjects subject) {
        Subject = subject;
    }

    public mobft(String name, int age, int date, int shift, int kurs)
    {
        Info = new StudentInfo(name, age, kurs);
        DateExem = date;
        Shift = shift;
        NameScpec = "MOB";
    }

    @Override
    public void Spec()
    {
        System.out.println("Name: " + Info.Name + ", age: " + Info.Age + ", date: " + DateExem + ", shift: " + Shift + ", name of spec: " + NameScpec + ", subject: " + Subject + ", kurs: " + Info.Kurs);
    }
}
