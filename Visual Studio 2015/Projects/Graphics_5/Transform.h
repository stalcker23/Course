#pragma once
#define M 3
value struct point {
	float x, y;
	
};

value struct line {
	 point start, end;
	 System::String^ name;	};
 typedef float vec[M];
 typedef float mat[M][M];

 extern mat T;

 void times(mat a, mat b, mat c);
 void timesMatVec(mat a, vec b, vec c);
 void set(mat a, mat b);
 void point2vec(point a, vec b);
 void vec2point(vec a, point &b);
 void makeHomogenVec(float x, float y, vec c);
 void unit(mat a);
 void move(float Tx, float Ty, mat c);
 void rotate(float phi, mat c);
 void scale(float S, mat c); void mirrorX(float S, float Tx, float Ty, mat c); void mirrorY(float S, float Tx, float Ty, mat c); void rotateCentr(float Tx, float Ty, float phi, mat c); void changeCoordinates(float Tx, float Ty, mat c); void rotate(float m, float n, float phi, mat c); void scale(float S, float m, float n, mat c); void scaleVertical(float S,  mat c); void scaleHorizon(float S, mat c);