package com.company;

import java.io.*;
import java.net.InetAddress;
import java.net.Socket;

public class ServerThread extends Thread {
    private Socket socket; // сокет, через который сервер общается с клиентом,
    // кроме него - клиент и сервер никак не связаны
    private BufferedReader in; // поток чтения из сокета
    private BufferedWriter out; // поток записи в сокет

    public ServerThread(Socket socket) throws IOException {
        this.socket = socket;
        // если потоку ввода/вывода приведут к генерированию исключения, оно проброситься дальше
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
        start(); // вызываем run()
    }
    @Override
    public void run() {
        String word;
        try {

            while (true) {
                word = in.readLine();
                word = word.substring(0,17);
                String[] arr = word.split(" ");
                if ((arr[0].equals("0") && arr[1].equals("0") && arr[2].equals("0")) ||
                        (arr[3].equals("0") && arr[4].equals("0") && arr[5].equals("0")) ||
                        (arr[6].equals("0") && arr[7].equals("0") && arr[8].equals("0")) ||
                        (arr[0].equals("0") && arr[3].equals("0") && arr[6].equals("0")) ||
                        (arr[1].equals("0") && arr[4].equals("0") && arr[7].equals("0")) ||
                        (arr[2].equals("0") && arr[5].equals("0") && arr[8].equals("0"))) {
                    for (ServerThread vr : Server.serverList) {
                        vr.send("Победил Client2 0"); // отослать принятое сообщение с
                        vr.in.close();
                        vr.out.close();
                        vr.socket.close();
                    }
                }
                else if ((arr[0].equals("X") && arr[1].equals("X") && arr[2].equals("X")) ||
                        (arr[3].equals("X") && arr[4].equals("X") && arr[5].equals("X")) ||
                        (arr[6].equals("X") && arr[7].equals("X") && arr[8].equals("X")) ||
                        (arr[0].equals("X") && arr[3].equals("X") && arr[6].equals("X")) ||
                        (arr[1].equals("X") && arr[4].equals("X") && arr[7].equals("X")) ||
                        (arr[2].equals("X") && arr[5].equals("X") && arr[8].equals("X"))) {
                    for (ServerThread vr : Server.serverList) {
                        vr.send("Победил Client1 X"); // отослать принятое сообщение с
                        vr.in.close();
                        vr.out.close();
                        vr.socket.close();
                    }
                }
                else {
                    for (ServerThread vr : Server.serverList) {
                        if (!vr.equals(this)) vr.send(word); // отослать принятое сообщение
                    }
                }
            }
        } catch (IOException e) {
        }
    }

    private void send(String msg) {
        try {
            out.write(msg + "\n");
            out.flush();
        } catch (IOException ignored) {}
    }
}

