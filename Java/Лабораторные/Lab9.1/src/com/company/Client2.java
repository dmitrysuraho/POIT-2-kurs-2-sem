package com.company;

import java.io.*;
import java.net.InetAddress;
import java.net.Socket;
import java.util.Scanner;

public class Client2 {
    private static Socket clientSocket; //сокет для общения
    private static BufferedReader reader; // нам нужен ридер читающий с консоли, иначе как
    // мы узнаем что хочет сказать клиент?
    private static BufferedReader in; // поток чтения из сокета
    private static BufferedWriter out; // поток записи в сокет
    private static BufferedReader inputUser; // поток чтения с консоли
    private static String[] matrix = new String[]{"-", "-", "-", "-", "-", "-", "-", "-", "-"}; // полученная матрица
    public Client2(){

    }

    public static void main(String[] args) {
        try {
            // адрес - локальный хост, порт - 4004, такой же как у сервера
            clientSocket = new Socket("localhost", 8080); // этой строкой мы запрашиваем
            //  у сервера доступ на соединение
            inputUser = new BufferedReader(new InputStreamReader(System.in));
            reader = new BufferedReader(new InputStreamReader(System.in));
            // читать соообщения с сервера
            in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
            // писать туда же
            out = new BufferedWriter(new OutputStreamWriter(clientSocket.getOutputStream()));

            new ReadMsg().start(); // нить читающая сообщения из сокета в бесконечном цикле
            new WriteMsg().start(); // нить пишущая сообщения в сокет приходящие с консоли в бесконечном цикле

        } catch (IOException e) {
            System.err.println(e);
        }
    }

    // нить чтения сообщений с сервера
    private static class ReadMsg extends Thread {
        @Override
        public void run() {
            String str;
            try {
                while (true) {
                    str = in.readLine(); // ждем сообщения с сервера
                    str = str.substring(0, 17);
                    matrix = str.split(" ");
                    for(int i = 0; i < 9; i++) {
                        System.out.print(matrix[i] + " ");
                        if(i == 2 || i == 5) {
                            System.out.println();
                        }
                    } // пишем сообщение с сервера на консоль
                }
            } catch (IOException e) {

            }
        }
    }

    public static class WriteMsg extends Thread {

        @Override
        public void run() {
            while (true) {
                String userWord;
                try {
                    userWord = inputUser.readLine(); // сообщения с консоли
                    int num = Integer.parseInt(userWord);
                    matrix[num - 1] = "0";
                    userWord = "";
                    for (int i = 0; i < 9; i++) {
                        if (i != 8) {
                            userWord += (matrix[i] + " ");
                        } else {
                            userWord += matrix[i];
                        }
                    }
                    out.write(userWord + "\n"); // отправляем на сервер
                    out.flush(); // чистим
                } catch (IOException e) {

                }

            }
        }
    }
}
