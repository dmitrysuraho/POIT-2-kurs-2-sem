package by.dm.model;

import java.io.Serializable;
import java.util.Objects;

public class User implements Serializable {

    private int id;
    private String login;
    private byte[] passw;

    public User(int id, String login, byte[] passw) {
        this.id = id;
        this.login = login;
        this.passw = passw;
    }

    public User(String login, byte[] passw) {
        this.id = 0;
        this.login = login;
        this.passw = passw;
    }

    public User() {
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public void setPassw(byte[] passw) {
        this.passw = passw;
    }

    public int getId() {
        return id;
    }

    public String getLogin() {
        return login;
    }

    public byte[] getPassw() {
        return passw;
    }

    @Override
    public String toString() {
        return "User{" +
                "id=" + id +
                ", login='" + login + '\'' +
                ", passw='" + passw + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        User user = (User) o;
        return Objects.equals(getId(), user.getId()) &&
                Objects.equals(getLogin(), user.getLogin()) &&
                Objects.equals(getPassw(), user.getPassw());
    }

    @Override
    public int hashCode() {
        return Objects.hash(getLogin(), getPassw(), getId());
    }
}