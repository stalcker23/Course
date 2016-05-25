


#include "stdafx.h"
#include <vector>
#include <algorithm>
#include <iostream>
#include <fstream>
#include "Transform.h"
#include "Pclip.h"
#include <math.h>

std::ofstream outp("output.txt");
polygon^ Pclip(polygon^ P, point Pmin, point Pmax)
{
	int k = 0;
	int n = P->Count;
	point start = P[n - 1];
	int n1 = 0;
	polygon^ P1 = gcnew polygon(0);
	while (k<n)
	{
		point end = P[k];
		float dx = end.x - start.x;
		float dy = end.y - start.y;
		point out, in;
		out.x=out.y=in.x=in.y= 0.0;
		float inf = 1e9;
		if (dx>0 || (dx == 0 && start.x>Pmax.x))
		{
			in.x = Pmin.x;
			out.x = Pmax.x;
		}
		else
		{
			out.x = Pmin.x;
			in.x = Pmax.x;
		}
		if (dy>0 || (dy == 0 && start.y>Pmax.y))
		{
			in.y = Pmin.y;
			out.y = Pmax.y;
		}
		else
		{
			out.y = Pmin.y;
			in.y = Pmax.y;
		}
		float toutX = 0.0;
		float toutY = 0.0;
		if (dx != 0)
		{

			toutX = (out.x - start.x) / dx;
		}
		else
		{
			if (Pmin.x <= start.x && start.x <= Pmax.x)
			{
				toutX = inf;
			}
			else
			{
				toutX = -inf;
			}
		}
		if (dy != 0)
		{

			toutY = (out.y - start.y) / dy;
		}
		else
		{
			if (Pmin.y <= start.y && start.y <= Pmax.y)
			{
				toutY = inf;
			}
			else
			{
				toutY = -inf;
			}
		}
		float t1out = 0.0;
		float t2out = 0.0;
		if (toutX<toutY)
		{
			t1out = toutX;
			t2out = toutY;
		}
		else
		{
			t1out = toutY;
			t2out = toutX;
		}
		float tinX = 0.0;
		float tinY = 0.0;
		float t2in = 0.0;
		if (t2out>0)
		{
			if (dx != 0)
			{
				tinX = (in.x - start.x) / dx;
			}
			else
			{
				tinX = inf;
			}
			if (dy != 0)
			{
				tinY = (in.y - start.y) / dy;
			}
			else
			{
				tinY = -inf;
			}
			if (tinX<tinY)
			{
				t2in = tinY;
			}
			else
			{
				t2in = tinX;
			}
			if (t1out<t2in)
			{
				if (0<t1out&& t1out < 1)
				{
					n1 = n1 + 1;
					if (tinX<tinY)
					{
						point temp;
						temp.x = out.x;
						temp.y = in.y;
						P1->Add(temp);
					}
					else
					{
						point temp;
						temp.x = in.x;
						temp.y = out.y;
						P1->Add(temp);
					}
				}
			}
			else
			{
				if (t1out>0 && t2in <= 1)
				{
					if (t2in >= 0)
					{
						n1 = n1 + 1;
						if (tinX>tinY)
						{
							point temp;
							temp.x = in.x;
							temp.y = start.y + tinX*dy;
							P1->Add(temp);
						}
						else
						{
							point temp;
							temp.x = start.x + tinY*dx;
							temp.y = in.y;
							P1->Add(temp);
						}
					}
					if (t1out <= 1)
					{
						n1 = n1 + 1;
						if (toutX<toutY)
						{
							point temp;
							temp.x = out.x;
							temp.y = start.y + toutX*dy;
							P1->Add(temp);
						}
						else
						{
							point temp;
							temp.x = start.x + toutY*dx;
							temp.y = out.y;
							P1->Add(temp);
						}
					}
					else
					{
						n1 = n1 + 1;
						P1->Add(end);
					}
				}
			}
			if (0<t2out && t2out <= 1)
			{
				n1 = n1 + 1;
				point temp;
				temp.x = out.x;
				temp.y = out.y;
				P1->Add(temp);
			}
		}
		k = k + 1;
		start = end;
	}
	return P1;
}
// Индекс предыдущего элемента в массиве
int indexPrev(int i, int n) {
	return (i - 1 + n) % n;
}

// Индекс следующего элемента в массиве
int indexNext(int i, int n) {
	return (i + 1 + n) % n;
}

// Перед поиском внутренней точки нужно проверить, что кол-во точек в полигоне >= 3х
point getInPoint(polygon^ P) {
	float e = 0.01;
	// удаление горизонтальных ребер
	for (int i = P->Count - 1; i >= 0; i--) 
		if (abs(P[i].y - P[indexPrev(i, P->Count)].y) < e) 
			P->RemoveAt(i);
	int n = P->Count;
	float x, x1, x2, y, y1, y2;
	int y1Index;
	y1 = y2 = float::MaxValue;
	for (int i = 0; i < n; i++) {
		if (P[i].y <= y1) {
			y2 = y1;
			y1 = P[i].y;
			y1Index = i;
		}
		else if (P[i].y < y2)
			y2 = P[i].y;
	}
	point m, l, r;
	// Нижняя точка
	m.x = P[y1Index].x;
	m.y = y1;
	// Точки исходящих ребер
	l.x = P[indexPrev(y1Index, n)].x;
	l.y = P[indexPrev(y1Index, n)].y;
	r.x = P[indexNext(y1Index, n)].x;
	r.y = P[indexNext(y1Index, n)].y;
	y = y1 + (y2 - y1) / 2;
	// уравнение прямой по 2 точкам
	x1 = (y - m.y) * (l.x - m.x) / (l.y - m.y) + m.x;
	x2 = (y - m.y) * (r.x - m.x) / (r.y - m.y) + m.x;
	x = x1 + (x2 - x1) / 2;
	point res;
	res.x = x;
	res.y = y;
	return res;
}


void Pfill (polygon^ P, System::Drawing::Bitmap^ image, System::Drawing::Color C, System::Drawing::Color grColor) {
	System::Collections::Generic::Stack<point> s;
	s.Push(getInPoint(P));
	while (s.Count) {
		point p = s.Pop();
		if (image->GetPixel(p.x, p.y) == grColor) continue;
		float xmin, xmax;
		xmin = xmax = p.x;
		while(image->GetPixel(xmin - 1, p.y).ToArgb() != grColor.ToArgb())
			xmin--;
		while(image->GetPixel(xmax + 1, p.y).ToArgb() != grColor.ToArgb())
			xmax++;
		for (int i = xmin; i <= xmax; i++) {
			image->SetPixel(i, p.y, C);
			point next;
			next.x = i;
			next.y = p.y + 1;
			if (image->GetPixel(next.x, next.y).ToArgb() != grColor.ToArgb()
				&& image->GetPixel(next.x, next.y).ToArgb() != C.ToArgb())
				s.Push(next);
			next.y -= 2;
			if (image->GetPixel(next.x, next.y).ToArgb() != grColor.ToArgb()
				&& image->GetPixel(next.x, next.y).ToArgb() != C.ToArgb())
				s.Push(next);
		}              
	}
}