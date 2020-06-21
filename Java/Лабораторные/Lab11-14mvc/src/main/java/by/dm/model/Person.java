package by.dm.model;

import java.io.Serializable;
import java.util.Objects;

public class Person implements Serializable {
        private int id;
        private String name;
        private String phone;
        private String email;

    public Person(Person person) {
        name = person.name;
        phone = person.phone;
        email = person.email;
        id = person.id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getName() {
        return name;
    }

    public String getPhone() {
        return phone;
    }

    public String getEmail() {
        return email;
    }

    public Person(int id, String name, String phone, String email) {
        this.id = id;
        this.name = name;
        this.phone = phone;
        this.email = email;
    }

    public Person() {
    }

    public Person(String name, String phone, String email) {
        this.id = 0;
        this.name = name;
        this.phone = phone;
        this.email = email;
    }

    @Override
    public String toString() {
        return "Person{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", phone='" + phone + '\'' +
                ", email='" + email + '\'' +
                '}';
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        Person person = (Person) o;
        return Objects.equals(getEmail(), person.getEmail()) &&
                Objects.equals(getPhone(), person.getPhone()) &&
                Objects.equals(getName(), person.getName()) &&
                Objects.equals(getId(), person.getId());
    }

    @Override
    public int hashCode() {
         return Objects.hash(getId(), getEmail(), getPhone(), getName());
    }
}
