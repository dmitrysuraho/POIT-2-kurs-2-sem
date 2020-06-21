package univer.faculty;
import univer.student.Extramural;
import univer.student.Student;

public class Dean {
    public static int NumKurs(Student[] student)
    {
        int kurs1 = 0, kurs2 = 0, kurs3 = 0, kurs4 = 0;
        for(Student stud: student) {
            if (stud.Info.Kurs == 1) kurs1++;
            else if (stud.Info.Kurs == 2) kurs2++;
            else if (stud.Info.Kurs == 3) kurs3++;
            else if (stud.Info.Kurs == 4) kurs4++;
        }
        System.out.println("1 kurs: " + kurs1 + ", kurs 2: " + kurs2 + ", kurs 3: " + kurs3 + ", kurs 4: " + kurs4);
        return kurs1;
    }

    public static Student Choose(Student[] student, int kurs)
    {
        for(Student stud: student) {
            if (stud.Info.Kurs == kurs && stud instanceof Extramural)
            {
                return stud;
            }
        }
        return null;
    }

    public static Student[] Sort(Student[] student)
    {
        Student x;
        for(int i=0; i < student.length; i++) {
            for (int j = student.length - 1; j > i; j--) {
                if (student[j - 1].Info.Age > student[j].Info.Age) {
                    x = student[j - 1];
                    student[j - 1] = student[j];
                    student[j] = x;
                }
            }
        }
        return student;
    }
}
