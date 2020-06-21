package univer.faculty.FITFullTime;

import univer.student.StudentInfo;

import java.io.Serializable;

public class poitft extends FITFullTime {
    public Subjects Subject = Subjects.Java;
    public String NameScpec = "POIT";

    public String getNameScpec() {
        return NameScpec;
    }

    public void setNameScpec(String nameScpec) {
        NameScpec = nameScpec;
    }

    public poitft() {}

    public poitft(String name, int age, int date, int shift, int kurs)
    {
        Info = new StudentInfo(name, age, kurs);
        DateExem = date;
        Shift = shift;
    }


    @Override
    public void Spec()
    {
        System.out.println("Name: " + Info.Name + ", age: " + Info.Age + ", date: " + DateExem + ", shift: " + Shift + ", name of spec: " + NameScpec + ", subject: " + Subject + ", kurs: " + Info.Kurs);
    }
}
