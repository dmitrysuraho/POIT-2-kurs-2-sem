package com.company;

public class SkyCenter {
    private int amountOfOperators;
    private Client[] operators;

    public SkyCenter(int size) {
        this.amountOfOperators = size;
        this.operators = new Client[size];
    }

    public void showLines() {
        System.out.println("Касса:{");
        for (int i = 0; i < amountOfOperators; i++) {
            if (operators[i] != null) {
                System.out.println(i+1 + ") " + operators[i].getClientName());
            } else {
                System.out.println(i+1 + ") свободна");
            }
        }
        System.out.println("}");
    }

    public void connect(Client client) {
        operators[this.FreeOperator()] = client;
    }

    public void disconnect(Client client) {
        for (int i = 0; i < this.amountOfOperators; i++) {
            if (operators[i] == client) {
                operators[i] = null;
            }
        }
    }

    public int FreeOperator() {
        for (int i = 0; i < this.amountOfOperators; i++) {
            if (operators[i] == null) {
                return i;
            }
        }
        return -1;
    }
}


