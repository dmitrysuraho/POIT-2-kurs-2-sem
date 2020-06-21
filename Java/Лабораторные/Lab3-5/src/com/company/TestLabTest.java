package com.company;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.testng.Assert;
import org.testng.annotations.*;
import univer.faculty.Dean;
import univer.faculty.FITExtramural.isitextr;
import univer.faculty.FITExtramural.mobextr;
import univer.faculty.FITExtramural.poitextr;
import univer.faculty.FITFullTime.poitft;
import univer.student.Student;

//@RunWith(value = Suite.class)
//@Suite.SuiteClasses(value = {TestLabTest.class,
//        TestStudentClass.class})

public class TestLabTest {
    @DataProvider(name = "listStudent")
    public Object[][] stud() { // Внешние данные
        return new Object[][] {
                {new poitft("gwfed", 19, 1, 30, 1),
                new poitextr("afaag", 21, 3, 30, 1),
                new mobextr("iun", 18, 4, 30, 2),
                new isitextr("tynfbd", 22, 2, 30, 1),
                new mobextr("yumnt", 19, 3, 30, 3)}
        };
    }
    @Test(dataProvider = "listStudent",timeOut = 5000) // TimeOut
    public void Test_NumKurs(Student s1,Student s2, Student s3, Student s4, Student s5) {
        Student[] list = {s1, s2, s3, s4, s5};
        int kurs1 = Dean.NumKurs(list), kursResult = 3;
        Assert.assertEquals(kurs1, kursResult, "bad result");
    }
    @Test(dataProvider = "listStudent")
    public void Test_Choose(Student s1,Student s2, Student s3, Student s4, Student s5) {
        Student[] list = {s1, s2, s3, s4, s5};
        Student stud = Dean.Choose(list, 2);
        Assert.assertNotNull(stud);
        System.out.println("Тестовый метод без задержки".toUpperCase());
    }
    @Ignore() //Ignore
    @Test(dataProvider = "listStudent")
    public void Test_Sort(Student s1,Student s2, Student s3, Student s4, Student s5) {
        Student[] list = {s1, s2, s3, s4, s5};
        Student[] sortList = Dean.Sort(list);
        Assert.assertSame(list, sortList);
    }

    @BeforeMethod
    public void BeforeMethod() {
        System.out.println("Начало тестового метода LAB");
    }
    @AfterMethod
    public void AfterMethod() {
        System.out.println("Конец тестового метода LAB");
    }
    @BeforeTest
    public void BeforeTest() {
        System.out.println("Начало теста LAB");
    }
    @AfterTest
    public void AfterTest() {
        System.out.println("Конец теста LAB");
    }
    @BeforeSuite
    public void BeforeSuite() {
        System.out.println("Начало набора тестов");
    }
    @AfterSuite
    public void AfterSuite() {
        System.out.println("Конец набора тестов");
    }
}