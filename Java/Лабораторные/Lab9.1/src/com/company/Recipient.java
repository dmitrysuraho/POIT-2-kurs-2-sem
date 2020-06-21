package com.company;

import java.net.DatagramPacket;
import java.net.DatagramSocket;

class Recipient{
    public static void main(String[] args) {
            try {
                DatagramSocket ds = new DatagramSocket(1050);
                while (true) {
                    DatagramPacket pack = new DatagramPacket(new byte[1024], 1024);
                    ds.receive(pack); //дожидаться получения
                    System.out.println(new String(pack.getData()));
                }
            }catch(Exception e){
            System.out.println(e);
        }
    }
}
