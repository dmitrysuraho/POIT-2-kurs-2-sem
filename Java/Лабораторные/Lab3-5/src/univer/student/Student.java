package univer.student;

interface IMethods
{
    void Spec();
}

public abstract class Student implements IMethods {

    public StudentInfo Info;

    public Student() {}
    public Student(String name, int age, int kurs)
    {
        Info = new StudentInfo(name, age, kurs);
    }
    abstract public void Spec();
}
