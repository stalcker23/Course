
#include "stdafx.h"
#include <vector>
#include <algorithm>
#include <iostream>
#include <fstream>
#include "Transform.h"
#include "clip.h"

bool clip(point &a, point &b, point min, point max)
{
	bool flag = false;
	while (flag==false)
	{
		int c1 = 0;
	if (a.x < min.x) c1++;
	if (a.x > max.x) c1 += 2;
	if (a.y < min.y) c1 += 4;
	if (a.y > max.y) c1 += 8;
	int c2 = 0;
	if (b.x < min.x) c2++;
	if (b.x > max.x) c2 += 2;
	if (b.y < min.y) c2 += 4;
	if (b.y > max.y) c2 += 8;
	if ((c1 == 0) && (c2 == 0))
	{
		flag = true;
		return true;
	}
	if
		(c1&c2)
		return false;
	if (c1 == 0)
	{
		float x = a.x;
		a.x = b.x;
		b.x = x;
		float y = a.y;
		a.y = b.y;
		b.y = y;
		int c = c1;
		c1 = c2;
		c2 = c;
	}
	if (c1 & 1)
	{
		a.y = b.y - (b.x - min.x)*((b.y - a.y) / (b.x - a.x));
		a.x = min.x;
	}
	else if (c1 & 2)
	{
		a.y = b.y - (b.x - max.x)*((b.y - a.y) / (b.x - a.x));
		a.x = max.x;
	}
	else if (c1 & 4)
	{
		a.x = b.x - (b.y - min.y)*((b.x - a.x) / (b.y - a.y));
		a.y = min.y;
	}
	else if (c1 & 8)
	{
		a.x = b.x - (b.y - max.y)*((b.x - a.x) / (b.y - a.y));
		a.y = max.y;
	}
}
}
