package com.company;

import java.util.ArrayList;
import java.util.Random;
import java.util.concurrent.Semaphore;

public class Main {
    public static final int CARCOUNT = 10;
    public static final int STREETSIZE = 3;
    public static final int AMOUNT_OF_OPERATORS = 3;
    public static final int AMOUNT_OF_CLIENTS = 10;

    public static void main(String[] args) {

        // Task 1
//        Random rand = new Random();
//        Semaphore semaphore = new Semaphore(AMOUNT_OF_OPERATORS, true);
//        SkyCenter skyCenter = new SkyCenter(AMOUNT_OF_OPERATORS);
//        Client client;
//        try {
//            for (int i = 0; i < AMOUNT_OF_CLIENTS; i++) {
//                client = new Client(skyCenter, semaphore, i+1);
//                client.start();
//                Thread.sleep(rand.nextInt(10) + 300);
//            }
//        } catch (Exception e) {
//            e.printStackTrace();
//        }

        // Task 2
        Street street = new Street(STREETSIZE,CARCOUNT);

        for (int i = 0; i < CARCOUNT; i++)
        {
            (new Car(i+1, street)).start();
            try
            {
                Thread.sleep(100);
            }
            catch(InterruptedException e)
            {
                e.printStackTrace();
            }
        }
    }
}
