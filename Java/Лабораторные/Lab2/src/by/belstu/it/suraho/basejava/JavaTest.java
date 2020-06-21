package by.belstu.it.suraho.basejava;

import static java.lang.Math.*;

public class JavaTest {
    static int sint;

    final int cons = 22;
    public final int cons1 = 22;
    public static final int cons2 = 22;

    public static void main(String[] args) {
        char ch = 'a';
        String str = "Dmitry";
        int in = 10;
        short sh = 15;
        byte byt = 20;
        long lon = 300;
        double dou = 500;
        boolean bool = true;
        boolean bool1 = false;

        System.out.println("String + int: " + (str + in));
        System.out.println("String + char: " + (str + ch));
        System.out.println("String + double: " + (str + dou));

        byte byt1 = (byte) (byt + in);
        System.out.println("byte = byte + int: " + byt1);

        int in1 = (int) (dou + lon);
        System.out.println("int = double + long: " + in1);

        long lon1 = in + 2147483647;
        System.out.println("long = int + 2147483647: " + Math.abs(lon1));

//        static int sint;
        System.out.println("static int sint без инициализации: " + sint);

        boolean bool2 = bool && bool1;
        System.out.println("boolean = boolean && boolean: " + bool2);
        boolean bool3 = bool ^ bool1;
        System.out.println("boolean = boolean ^ boolean: " + bool3);

//        boolean bool4 = bool1 + bool2; !!can't!!

        long l = 9223372036854775807L;
        long l1 = 0x7fff_ffff_fffL;

        char c = 'a', c1 = '\u0061', c2 = 97;
        System.out.println("Sum of char: " + (c + c1 + c2));

        System.out.println("3.45 % 2.4: " + (3.45 % 2.4));
        System.out.println("1.0/0.0: " + (1.0/0.0));
        System.out.println("0.0/0.0: " + (0.0/0.0));
        System.out.println("log(-345): " + log(-345));
        System.out.println("Float.intBitsToFloat(0x7F800000): " + Float.intBitsToFloat(0x7F800000));
        System.out.println("Float.intBitsToFloat(0xFF800000): " + Float.intBitsToFloat(0xFF800000));
        //--------------------------------------------------------------
        System.out.println("\nMath.PI: " + round(PI));
        System.out.println("Math.E: " + E);
        System.out.println("Math.min(PI, E): " + min(PI, E));
        System.out.println("random(): " + random());
        //--------------------------------------------------------------
        Character oChar   = new Character('l');
        Integer oInt    = new Integer(1);
        Short oShort  = new Short((short)30);
        Long oLOng   = new Long (123456l);
        Double oDouble = new Double(34.487);

        int nInt = ~oInt;
        System.out.println("\n~Integer=" + nInt);

        char ze = 'b';
        ze += oChar;
        System.out.println("+Char=" + ze);

        int ne = oShort >> 2;
        System.out.println(ne);
        int be = oShort >>> 2;
        System.out.println(be);

        long lo = oLOng & 111;
        System.out.println("Long & 111=" + lo);

        System.out.println("longMIN=" + oLOng.MIN_VALUE);
        System.out.println("longMAX=" + oLOng.MAX_VALUE);
        System.out.println("doubleMIN=" + oDouble.MIN_VALUE);
        System.out.println("doubleMAX=" + oDouble.MAX_VALUE);

        Integer zint = new Integer(123);
        int zu = zint;
        Byte zbyte = new Byte((byte)255);
        byte zer = zbyte;

        int x = Integer.parseInt("9");
        System.out.println(x);
        System.out.println(Integer.toHexString(10)) ;
        System.out.println(Integer.compare(10, 2));//сравнение
        System.out.println(Integer.toString(123, 2));
        System.out.println(Integer.bitCount(10));
        //------------------------------------------------
        String s34 = "2345";
        System.out.println("\n" + Integer.valueOf(s34));
        Integer mmm = new Integer(s34);
        System.out.println(mmm);

        byte[] nen = s34.getBytes();
        System.out.println(nen);
        String news34 = new String(nen);
        System.out.println(news34);

        System.out.println(Boolean.valueOf(s34));
        System.out.println(Boolean.getBoolean(s34) + "\n");

        String str1 = "Dmitry";
        String str2 = "Dmitry";
        System.out.println(str1 == str2);
        System.out.println(str1.equals(str2));
        System.out.println(str1.compareTo(str2));
//        str2 = null;
//        System.out.println(str1 == str2);
//        System.out.println(str2.equals(str1));
//        System.out.println(str1.compareTo(str2));

        String stroka = new String("hello world hi guys");
        String mass[] = stroka.split(" ");
        for (int i = 0; i < mass.length; i++)
        {
            System.out.println(mass[i]);
        }
        System.out.println(stroka.contains("he"));
        System.out.println(stroka.hashCode());
        System.out.println(stroka.indexOf("hi"));
        System.out.println(stroka.length());
        System.out.println(stroka.replace("world", "girl") + "\n");
        //----------------------------------------------------------------
        char[][] mass1;
        int[] mass2[];
        int mass3[][];

       // int ze[] = new int[0];

        //System.out.println(ze[2]);

        mass1 = new char[3][];
        mass1[0] = new char[0];
        mass1[1] = new char[1];
        mass1[2] = new char[2];
        System.out.println(mass1.length);
        System.out.println(mass1[0].length);
        System.out.println(mass1[1].length);
        System.out.println(mass1[2].length);

        mass2 = new int[][]{ {1,2,3}, {1,2,3}, {1,2,3}};
        mass3 = new int[][]{ {1,2,3}, {1,2,3}, {1,2,3}};
        boolean comRez = mass2==mass3; // сравнение по ссылкам,разные
        System.out.println(comRez);
        mass2 = mass3;

        for (int[] z2 :
                mass2) {
            for (int z:
                    z2) {
                System.out.print(" " + z);
            }
            System.out.println("");
        }
        //------------------------------------------------
        WrapperString wrapp = new WrapperString("Dmitry");
        wrapp.replace('r', 'R');
        System.out.println(wrapp.getStr());

        WrapperString wrapp1 = new WrapperString("Suraho")
        {
            @Override
            public void replace(char oldchar, char newchar) {
                super.replace(oldchar, newchar);
            }

            public void delete(char newchar)
            {
                super.replace(newchar, '\0');
            }
        };

        wrapp1.replace('r', 'R');
        System.out.println(wrapp1.getStr());

    }
}
