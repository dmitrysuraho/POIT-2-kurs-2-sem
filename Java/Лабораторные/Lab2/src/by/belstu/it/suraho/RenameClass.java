package by.belstu.it.suraho;

public class RenameClass
{
    public int Num;
    public String Str;
    public RenameClass(int num, String str)
    {
        Num = num;
        Str = str;
    }
    public int getNum() {
        return Num;
    }

    public void setNum(int num) {
        Num = num;
    }

    public String getValue()
    {
        return "Hello from First project";
    }

    public void onCreate() {
        for (int count = 0; count < 10; count++) {
            System.out.println("Counter " + count);
        }
    }
}
