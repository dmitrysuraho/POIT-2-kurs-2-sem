package com.company;
import java.net.*;
import java.io.*;
import java.util.LinkedList;

public class Server {
    public static final int PORT = 8080;
    public static LinkedList<ServerThread> serverList = new LinkedList<>(); // список всех нитей

    public static void main(String[] args) throws IOException {
        ServerSocket server = new ServerSocket(PORT);
        try {
            System.out.println("Сервер стартовал");
            while (true) {
                // Блокируется до возникновения нового соединения:
                Socket socket = server.accept();
                try {
                    System.out.println(socket.getInetAddress().getHostName() + " connected");
                    serverList.add(new ServerThread(socket)); // добавить новое соединенние в список
                } catch (IOException e) {
                    // Если завершится неудачей, закрывается сокет,
                    // в противном случае, нить закроет его при завершении работы:
                    socket.close();
                }
            }
        } finally {
            server.close();
        }
    }

}
