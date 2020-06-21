package com.company;

import org.testng.Assert;
import org.testng.annotations.*;
import univer.faculty.FITFullTime.poitft;
import univer.student.Student;

public class TestStudentClass {
    @Test
    public void Test_ConstructorPOITFT() {
        Student stud = new poitft("Дмитрий", 19, 1, 30, 1);
        Assert.assertEquals(1, stud.Info.getKurs());
        Assert.assertEquals("Дмитрий", stud.Info.getName());
        Assert.assertEquals(19, stud.Info.getAge());
    }

    @Test
    public void Test_GetterSetterAge() {
        poitft stud = new poitft();
        stud.setNameScpec("newSpec");
        Assert.assertEquals("newSpec", stud.getNameScpec());
    }

    @BeforeMethod
    public void BeforeMethod() {
        System.out.println("Начало тестового метода STUDENT");
    }
    @AfterMethod
    public void AfterMethod() {
        System.out.println("Конец тестового метода STUDENT");
    }
    @BeforeTest
    public void BeforeTest() {
        System.out.println("Начало теста STUDENT");
    }
    @AfterTest
    public void AfterTest() {
        System.out.println("Конец теста STUDENT");
    }
}