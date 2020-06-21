package univer.student;

public class Extramural extends Student {
    public int DateExem;

    public int getDateExem() {
        return DateExem;
    }

    public void setDateExem(int dateExem) {
        DateExem = dateExem;
    }

    public Extramural()
    {
        DateExem = 0;
    }

    @Override
    public void Spec() {}
}
