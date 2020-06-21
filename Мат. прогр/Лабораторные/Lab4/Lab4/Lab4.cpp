// Lab4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenshtein.h"
#include "LCH.h"

using namespace std;

char* prefix(char* S, int k)
{
    char* arr = new char[k];
    for (int i = 0; i < k; i++)
    {
        arr[i] = S[i];
    }
    return arr;
}

int main()
{
    setlocale(LC_ALL, "rus");
    int i;
    srand(time(NULL));
    char S1[300], S2[250];
    cout << "S1 = ";
    for (i = 0; i < 300; ++i) 
    {
        S1[i] = (rand() % 26) + 'a';
        cout << S1[i];
    }
    cout << endl;
    cout << "S2 = ";
    for (i = 0; i < 250; ++i)
    {
        S2[i] = (rand() % 26) + 'a';
        cout << S2[i];
    }
    cout << endl << endl;
    cout << levenshtein(3, { "сын" }, 5, {"фасон"});

    int k[] = { 25, 20, 15, 10, 5, 2, 1 };
    //clock_t t1 = 0, t2 = 0, t3,t4;
    //char x[] = "сын",  y[] = "фасон";
    //int  lx = sizeof(x)-1, ly = sizeof(y)-1; 
    //std::cout<<std::endl;
    //std::cout<<std::endl<< "-- расстояние Левенштейна -----"<< std::endl;
    //std::cout<<std::endl<< "--длина --- рекурсия -- дин.програм. ---" <<std::endl;
    //cout << levenshtein_r(3, x, 5, y) << endl;
    //for (int i = 0; i < 7; i++)
    //{
    //    /*t1 = clock(); levenshtein_r(300 / k[i], S1, 250/k[i], S2); t2 = clock();*/
    //    t3 = clock(); levenshtein(300 / k[i], prefix(S1, 300/k[i]), 250 / k[i], prefix(S2, 250/k[i])); t4 = clock();
    //    std::cout << std::right << std::setw(2) << 300 / k[i] << "/" << 250 / k[i]
    //        << "        " << std::left << std::setw(10) << (t2 - t1)
    //        << "   " << std::setw(10) << (t4 - t3) << std::endl;
    //}

    cout << endl << "-----------------------5 TASK----------------------------------" << endl;

    char z[100] = "";
    char X[] = "MIOPLKJ", Y[] = "GUIOLW";
    clock_t t11 = 0, t22 = 0, t33, t43;
    /*std::cout << std::endl
        << "-- наибольшая общая подпоследовательость - LCS(динамическое"
        << "программирование)" << std::endl;
    for (int j = 0; j < 7; j++)
    {
        t11 = clock();
        int l = lcsd(prefix(S1, 300 / k[j]), prefix(S2, 250 / k[j]), z);
        t22 = clock();
        std::cout << "время: " << (t22 - t11) << " k: " << k[j] << " длина: " << l << std::endl;
    }*/
    

    std::cout << std::endl << "-- вычисление длины LCS для X и Y(рекурсия)";
    for (int j = 0; j < 7; j++)
    {
        t11 = clock();
        int l = lcs(
            300/k[j],  // длина   последовательности  X   
            prefix(S1, 300 / k[j]),       // последовательность X
            250 / k[j],  // длина   последовательности  Y
            prefix(S2, 250 / k[j])       // последовательность Y
        );
        t22 = clock();
        std::cout << std::endl << "время: " << (t22 - t11) << " k: " << k[j] << " длина: " << l;
    }
    cout << endl;

    system("pause");
}
