package com.company;
import java.util.ArrayDeque;

public class Street {
    private ArrayDeque<Car> firstDirection;
    private ArrayDeque<Car> secondDirection;
    public int streetSize;
    static int countOfCars = 0;
    static boolean selectDirection;

    public Street(int size, int count)
    {
        this.streetSize = size;
        firstDirection = new ArrayDeque<Car>(count);
        secondDirection = new ArrayDeque<Car>(count);
    }

    public synchronized void driveAway()
    {
        String line = new String();
        Car car = null;
        car = getCar(selectDirection);
        if (car == null) {
            line = "\nНет автомобилей";
        }
        else {
            line = car.getCarsName() + " уехала";
            this.countOfCars++;
        }
        System.out.println(line);
    }

    public synchronized void crossTheRoad() {
        showStreet();
        if ((this.countOfCars >= this.streetSize || this.checkDirection(selectDirection)) && !this.checkDirection(!selectDirection))
        {
            selectDirection = !selectDirection;
            this.countOfCars = 0;
        }
        System.out.println("count = " + this.countOfCars + ", направление " + (selectDirection?1:2));
        driveAway();
    }

    public synchronized Car getCar(boolean flag)
    {
        if(flag)
        {
            return getCarFromFirstDirection();
        }
        else
        {
            return getCarFromSecondDirection();
        }
    }

    public synchronized boolean checkDirection(boolean flag)
    {
        if(flag)
        {
            return checkCarInFirstDirection();
        }
        else
        {
            return checkCarInSecondDirection();
        }
    }

    public synchronized void addCarToFirstDirection(Car car)
    {
        this.firstDirection.addLast(car);
    }

    public synchronized void addCarToSecondDirection(Car car)
    {
        this.secondDirection.addLast(car);
    }

    public synchronized Car getCarFromFirstDirection()
    {
        if (!this.checkCarInFirstDirection())
        {
            return this.firstDirection.pollFirst();
        }
        else
        {
            return null;
        }
    }

    public synchronized Car getCarFromSecondDirection()
    {
        if (!this.checkCarInSecondDirection())
        {
            return this.secondDirection.pollFirst();
        }
        else
        {
            return null;
        }
    }

    public synchronized boolean checkCarInFirstDirection()
    {
        return this.firstDirection.isEmpty();
    }

    public synchronized boolean checkCarInSecondDirection()
    {
        return this.secondDirection.isEmpty();
    }

    public synchronized void showStreet()
    {
        System.out.print("Дорога:\nПервое направление { ");
        for (Car c: this.firstDirection) {
            System.out.print(c.getCarsName()+" ");
        }
        System.out.print("};\nВторое направление { ");
        for (Car c: this.secondDirection) {
            System.out.print(c.getCarsName()+" ");
        }
        System.out.println("}");
    }
}
