// Laba_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
// -- main (решение задачи  о размещении контейнеров)  
#include <iostream>
#include <iomanip> 
#include "Boat.h"
#include <ctime>
#define NN (sizeof(v)/sizeof(int))
#define MM 6
#define N (sizeof(AA)/2)
#define M 3

using namespace std;
int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "rus");

	char  BB[][2] = { "A", "B", "C", "D" };
	cout << endl << "Генератор множества всех подмножеств";
	cout << endl << "Исходное множество";
	cout << "{";
	for (int i = 0; i < sizeof(BB) / 2; i++)
	{
		std::cout << BB[i] << ((i < sizeof(BB) / 2 - 1) ? ", " : " ");
	}
	std::cout << "}";
	std::cout << std::endl << "Генерация всех подмножеств ";
	combi::subset s1(sizeof(BB) / 2);			// создание генератора
	int b = s1.getfirst();						//первое(пустое) подмножество
	while (b >= 0)								// пока есть подмножество
	{
		cout << endl << "{";
		for (int i = 0; i < b; i++)
		{
			cout<< BB[s1.ntx(i)]<<((i<b-1)? ", " : " ");
		}
		cout << endl << "}";
		b = s1.getnext();						// следующее подмножество
	};
	cout << endl << "всего:" << s1.count() << endl;


	cout << "----------- ПЕРЕСТАНОВКА --------------" << endl;
	char  CC[][2] = { "A", "B", "C", "D" };
	std::cout << std::endl << " --- Генератор перестановок ---";
	std::cout << std::endl << "Исходное множество: ";
	std::cout << "{ ";
	for (int i = 0; i < sizeof(CC) / 2; i++)

		std::cout << CC[i] << ((i < sizeof(CC) / 2 - 1) ? ", " : " ");
	std::cout << "}";
	std::cout << std::endl << "Генерация перестановок ";
	combi::permutation p(sizeof(CC) / 2);
	__int64  t = p.getfirst();
	while (t >= 0)
	{
		std::cout << std::endl << std::setw(4) << p.np << ": { ";

		for (int i = 0; i < p.n; i++)

			std::cout << CC[p.ntx(i)] << ((i < p.n - 1) ? ", " : " ");

		std::cout << "}";

		t = p.getnext();
	};
	std::cout << std::endl << "всего: " << p.count() << std::endl;
	
	cout << endl << endl << endl;

	cout << "------------- РАЗМЕЩЕНИЕ ------------" << endl;
	char  AA[][2] = { "A", "B", "C", "D" };
	std::cout << std::endl << " --- Генератор размещений ---";
	std::cout << std::endl << "Исходное множество: ";
	std::cout << "{ ";
	for (int i = 0; i < N; i++)

		std::cout << AA[i] << ((i < N - 1) ? ", " : " ");
	std::cout << "}";
	std::cout << std::endl << "Генерация размещений  из  " << N << " по " << M;
	combi::accomodation y(N, M);
	int  n = y.getfirst();
	while (n >= 0)
	{

		std::cout << std::endl << std::setw(2) << y.na << ": { ";

		for (int i = 0; i < 3; i++)

			std::cout << AA[y.ntx(i)] << ((i < n - 1) ? ", " : " ");

		std::cout << "}";

		n = y.getnext();
	};
	std::cout << std::endl << "всего: " << y.count() << std::endl;
	
	cout << endl << endl << endl;


	clock_t  t1 = 0, t2 = 0;
	//int V = 1500;
	//int v[] = { 100,  200, 300,  400,500,650,750,850,900,122,133,144,155,166,177,188,199,
	//	277,181,191,201,223,283,263,   287,492, 185, 735, 645, 654, 365, 274, 856, 493, 183}; // вес
	//int c[NN] = { 10, 15,  20, 25,30,25 }; // доход 
	//short r[MM];
	//int cc = boat(
	//	V,
	//	MM,    // [in]  количество мест для контейнеров
	//	NN,    // [in]  всего контейнеров  
	//	v,     // [in]  вес каждого контейнера  
	//	c,     // [in]  доход от перевозки каждого контейнера   
	//	r      // [out] номера  выбранных контейнеров  
	//);
	//
	//std::cout << std::endl << "- Задача о размещении контейнеров на судне -";
	//std::cout << std::endl << "- общее количество контейнеров   : " << NN;
	//std::cout << std::endl << "- количество мест для контейнеров  : " << MM;
	//std::cout << std::endl << "- ограничение по суммарному весу : " << V;
	//std::cout << std::endl << "- вес контейнеров      : ";
	//for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
	//std::cout << std::endl << "- доход от перевозки     : ";
	//for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
	//std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1) : ";
	//for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
	//std::cout << std::endl << "- доход от перевозки     : " << cc;
	//cout << endl << "- общий вес выбранных контейнеров : ";
	//int  s = 0; for (int i = 0; i < MM; i++) s += v[r[i]];
	//cout << s;
	//cout << "\nВсего контейнеров: "<< NN<<endl;
	//for (int i = 24; i < NN; i++)
	//{
	//	t1 = clock();
	//	boat(V, MM, NN, v, c, r);
	//	t2 = clock();
	//}

	int V = 1000,
		v[] = { 250, 560, 670, 400, 200, 270, 370, 330, 330, 440, 530, 120,
			   200, 270, 370, 330, 330, 440, 700, 120, 550, 540, 420, 170,
			   600, 700, 120, 550, 540, 420, 430, 140, 300, 370, 310, 120 };
	int c[NN] = { 15,26,  27,  43,  16,  26,  42,  22,  34,  12,  33,  30,
			   42,22,  34,  43,  16,  26,  14,  12,  25,  41,  17,  28,
			   12,45,  60,  41,  33,  11,  14,  12,  25,  41,  30,  40 };
	short r[MM];
	int maxcc = 0;
	std::cout << std::endl << "-- Задача об оптимальной загрузке судна -- ";
	std::cout << std::endl << "-  ограничение по весу    : " << V;
	std::cout << std::endl << "-  количество мест        : " << MM;
	std::cout << std::endl << "-- количество ------ продолжительность -- ";
	std::cout << std::endl << "   контейнеров        вычисления  ";
	for (int i = 24; i <= NN; i++)
	{
		t1 = clock();
		int maxcc = boat(V, MM, i, v, c, r);
		t2 = clock();
		std::cout << std::endl  << std::setw(2) << i
			<< std::setw(5) << (t2 - t1);
	}
	std::cout << std::endl << std::endl;


	cout<<endl <<"Затраченное время "<<(t2 - t1);
	std::cout << std::endl << std::endl;
	system("pause");
	return 0;
}

