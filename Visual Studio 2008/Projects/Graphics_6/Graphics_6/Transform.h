#include <array>
#include <vector>

value struct point {
	float x, y;
};
value struct line {
	point start, end;
	System::String^ name;
};
#define M 3
typedef std::tr1::array<float, M> vec;
typedef std::tr1::array<vec, M> mat;

extern std::vector<mat> matrices;

extern mat T;;

void times(mat a, mat b, mat &c);
void timesMatVec(mat a, vec b, vec &c);
void set(mat a, mat &b);
void point2vec(point a, vec &b);
void vec2point(vec a, point &b);
void makeHomogenVec(float x, float y, vec &c);
void unit(mat &a);
void move(float Tx, float Ty, mat &c);
void rotate(float phi, mat &c);
void scale(float x, float y, mat &c);
void reflectHoriz(mat &c); 
void reflectVert(mat &c);
void start(float Tx, mat &c);
void frame (float Vx, float Vy, float Vcx, float Vcy, float Wx, float Wy, float Wcx, float Wcy, mat &c);
