package univer.student;

public class StudentInfo
{
    public int Kurs;
    public String Name;
    public int Age;
    public StudentInfo() {}

    public int getKurs() {
        return Kurs;
    }

    public void setKurs(int kurs) {
        Kurs = kurs;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public int getAge() {
        return Age;
    }

    public void setAge(int age) {
        Age = age;
    }
    public StudentInfo(String name, int age, int kurs)
    {
        Name = name;
        if (age < 17) {
            throw new Error("Age > 17");
        }
        else {
            Age = age;
        }
        if (kurs < 1 && kurs > 4) {
            throw new Error("Kurs: 1-4");
        }
        else {
            Kurs = kurs;
        }
    }
}
