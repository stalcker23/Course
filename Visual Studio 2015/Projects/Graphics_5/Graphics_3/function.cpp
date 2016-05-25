#pragma once
#include "stdafx.h"
#include "function.h"
#include <math.h>
#include <cmath>
const float e = 0.05;
bool fexists(float x)
{
	return abs(cos(x))>e;
}
float f(float x)
{
	return tan(x);
}