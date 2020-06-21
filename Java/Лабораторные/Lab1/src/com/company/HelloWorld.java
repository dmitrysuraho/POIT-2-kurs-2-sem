package com.company;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

class HelloWorld {
public static void main(String[] args) throws IOException {
// Display "Hello World!"
    String login = "dmitry";
    String pass = "12345";
    FileReader fr= new FileReader("C:\\Users\\Dmitry\\Desktop\\labs\\Java\\Лабораторные\\Lab10\\users.txt");
    Scanner scan = new Scanner(fr);
    int i = 1;
    ArrayList<String> users = new ArrayList();
    while (scan.hasNextLine()) {
        users.add(scan.nextLine());
    }
    fr.close();
    Boolean flag = false;
    for (String str: users) {
        String[] arr = new String[2];
        arr = str.split(" ");
        if(arr[0].equals(login) && arr[1].equals(pass)) {
            flag = true;
            break;
        }
    }
    if(flag) {
        System.out.println("Successful");
    }
    else {
        System.out.println("Check login or pass");
    }
}
}