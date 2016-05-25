value struct point;
bool clip(point &a, point &b, point min, point max);
point Clip1Left(point &A, float deltax, float deltay, float deltaxL);
point Clip1Top(point &A, float deltax, float deltay, float deltayT);
point Clip1Bottom(point &A, float deltax, float deltay, float deltayB);

point Clip2Right(point &A, float deltax, float deltay, float deltaxR);
point Clip2Top(point &A, float deltax, float deltay, float deltayT);
point Clip2Bottom(point &A, float deltax, float deltay, float deltayB);