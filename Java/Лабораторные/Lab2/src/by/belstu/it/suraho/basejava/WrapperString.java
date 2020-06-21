package by.belstu.it.suraho.basejava;

import java.util.Objects;

public class WrapperString {
    private String str;

    public String getStr() {
        return str;
    }

    public void setStr(String str) {
        this.str = str;
    }

    @Override
    public String toString() {
        return "WrapperString{" +
                "str='" + str + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof WrapperString)) return false;
        WrapperString that = (WrapperString) o;
        return Objects.equals(getStr(), that.getStr());
    }

    @Override
    public int hashCode() {
        return Objects.hash(getStr());
    }

    public WrapperString(String str) {
        this.str = str;
    }

    public void replace(char oldchar, char newchar)
    {
        str = str.replace(oldchar, newchar);
    }
}
