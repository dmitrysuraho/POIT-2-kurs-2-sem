package com.company;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.UnknownHostException;

public class Main {

    public static void main(String[] args) {
        //Получить ip адрес и хост
        try {
            InetAddress address = InetAddress.getByName("ya.ru");
            System.out.println("IP хоста: " + address.getHostAddress() + ",имя хоста: " + address.getHostName());
            System.out.println();
        } catch (UnknownHostException e) {
            System.out.println("Error");
        }

        //html содержимое по url
        URL url = null;
        String urlName = "https://planetcalc.ru";
        try {
            url = new URL(urlName);
        }
        catch (MalformedURLException e) {
            e.printStackTrace();
        }
        if(url == null) {
            throw new RuntimeException();
        }
        try(BufferedReader d = new BufferedReader(new InputStreamReader(url.openStream()))) {
            String line = "";
            while((line = d.readLine()) != null) {
                System.out.println(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}
