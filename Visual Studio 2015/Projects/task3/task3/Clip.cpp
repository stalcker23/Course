#pragma once
#include "stdafx.h"
#include <algorithm>
#include "Transform.h"

using namespace std;


void Clip1Left(point &a, float dx, float dy, float dxL) {
	a.x += dxL;
	a.y += dxL * (dy / dx);
}

void Clip1Top(point &a, float dx, float dy, float dyT) {
	a.x += dyT * (dx / dy);
	a.y += dyT;
}

void Clip1Bottom(point &a, float dx, float dy, float dyB) {
	a.x += dyB * (dx / dy);
	a.y += dyB;
}

void Clip2Right(point a, point &b, float dx, float dy, float dxR) {
	b.x = a.x + dxR;
	b.y = a.y + dxR * (dy / dx);
}

void Clip2Top(point a, point &b, float dx, float dy, float dyT) {
	b.x = a.x + dyT * (dx / dy);
	b.y = a.y + dyT;
}

void Clip2Bottom(point a, point &b, float dx, float dy, float dyB) {
	b.x = a.x + dyB * (dx / dy);
	b.y = a.y + dyB;
}
