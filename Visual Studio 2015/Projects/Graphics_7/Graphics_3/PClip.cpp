

#include "stdafx.h"
#include <vector>
#include <algorithm>
#include <iostream>
#include <fstream>
#include "Transform.h"
#include "PClip.h"
#include <math.h>


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