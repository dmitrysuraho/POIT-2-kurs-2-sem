package univer.faculty.FITFullTime;

import univer.student.StudentInfo;

public class devift extends FITFullTime {
    public Subjects Subject = Subjects.JavaScript;
    public String NameScpec;
    public Subjects getSubject() {
        return Subject;
    }

    public void setSubject(Subjects subject) {
        Subject = subject;
    }

    public devift(String name, int age, int date, int shift, int kurs)
    {
        Info = new StudentInfo(name, age, kurs);
        DateExem = date;
        Shift = shift;
        NameScpec = "DEVI";
    }

    @Override
    public void Spec()
    {
        System.out.println("Name: " + Info.Name + ", age: " + Info.Age + ", date: " + DateExem + ", shift: " + Shift + ", name of spec: " + NameScpec + ", subject: " + Subject + ", kurs: " + Info.Kurs);
    }
}
