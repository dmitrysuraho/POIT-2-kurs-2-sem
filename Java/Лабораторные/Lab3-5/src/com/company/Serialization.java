package com.company;
import univer.faculty.FITFullTime.poitft;
import univer.student.Student;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.*;

public class Serialization {

    public static void Serialization(Student student, String fileName) throws IOException {
        ObjectMapper mapper = new ObjectMapper();
        mapper.writeValue(new File(fileName), student);
        System.out.println("Объект сериализован");
    }
    public static void Deserialization(String fileName) throws IOException {
        ObjectMapper mapper = new ObjectMapper();
        BufferedReader reader = new BufferedReader(new FileReader(fileName));
        StringBuffer json = new StringBuffer(reader.readLine());
        Student student = mapper.readValue(json.toString(), poitft.class);
        System.out.println("Объект десериализован");
        student.Spec();
    }
}
