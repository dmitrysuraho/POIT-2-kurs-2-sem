
// --- Вoat.cpp
#include "Boat.h"
#include "Combi.h"
namespace boatfnc
{
	bool calcv(combi::xcombination s,  const int v[])
	{
		int rc = 0;
		for (int i = 0; i < s.m; i++) rc += v[s.ntx(i)];
		return rc;
	};
	int calcc(combi::xcombination s, const int c[])
	{
		int rc = 0;
		for (int i = 0; i < s.m; i++) rc += c[s.ntx(i)];
		return rc;
	};
	void copycomb(short m, short *r1, const short *r2)
	{
		for (int i = 0; i < m; i++)  r1[i] = r2[i];
	};
}
int boat(      // функция возвращает доход от перевозки контейнеров
	int V,		//[in] максимальный вес груза
	short m,	//[in] количество мест для окнтейнеров
	short n,	//[in] всего контейнеров
	const int v[],	//[in] вес каждого контейнера
	const int c[],	//[in] Доход от перевозки каждого контейнера 
	short r[]	//[out] результат:индексы выбранных контейнеров  
)
{
	combi::xcombination xc(n, m);
	int rc = 0, i = xc.getfirst(), cc = 0;
	while (i > 0)
	{

		if (boatfnc::calcv(xc, v)<=V)
		if ((cc = boatfnc::calcc(xc, c)) > rc)
			{
				rc = cc; boatfnc::copycomb(m, r, xc.sset);
			}

		i = xc.getnext();
	};
	return rc;
}