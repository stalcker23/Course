value struct point {
 float x, y;
};
value struct point3D {
 float x, y, z;
};

value struct line {
 point start, end;
 
 };
value struct start {
float Vcx,Vcy,Vx,Vy;
 };
value struct col {
int R,G,B;
 };
value struct AEL {
float x,y,z;
 };
value struct APLL {

int P;
bool Sur;
 };
value struct zn_nie
{double a,b,c,d;
	
	
	;};
#define M 3
 typedef float vec[M];
 typedef float vec3D[M+1];
 typedef float mat[M][M];
 typedef float mat3D[M+1][M+1];

 extern mat3D T;extern vec A,B;
 typedef System::Collections::Generic::List<point> polygon;
  typedef System::Collections::Generic::List<APLL> APL;
   typedef System::Collections::Generic::List<point3D> APL1;
 typedef System::Collections::Generic::List<point3D> polygon3D;
 void times(mat a, mat b, mat &c);
 void timesMatVec(mat a, vec b, vec &c);
 void set(mat a, mat &b);
 void point2vec(point a, vec &b);
 void vec2point(vec a, point &b);
 void makeHomogenVec(float x, float y, vec &c);
 void unit(mat &a);
 void move(float Tx, float Ty, mat &c);
 void zerk_goriz(float Tx, mat &c);
 void zerk_vert(float Tx, mat &c);
 void rotate(float phi, mat &c);
  void unrotate(float phi, mat &c);
 void scale(float S, mat &c);
  void scalew(float S, mat &c);
   void scaleh(float S, mat &c);
     void unscalew(float S, mat &c);
   void unscaleh(float S, mat &c);
  void unscale(float S, mat &c);
   void scales(float S,float L, mat &c);
  void frame (float Vx, float Vy, float Vcx, float Vcy,
float Wx, float Wy, float Wcx, float Wcy,
mat &c);

  void times3D (mat3D a, mat3D b, mat3D &c);
 void timesMatVec3D (mat3D a, vec3D b, vec3D &c);
 void set3D (mat3D a, mat3D &b);
 void point2vec3D (point3D a, vec3D &b);
 void vec2point3D (vec3D a, point3D &b);
 void makeHomogenVec3D (float x, float y, float z, vec3D &c);
 void unit3D (mat3D &a);
 void move3D (float Tx, float Ty, float Tz, mat3D &c);
 void rotate3D (point3D n, float phi, mat3D &c);
 void scale3D (float Sx, float Sy, float Sz, mat3D &c);
 void LookAt (point3D eye, point3D center, point3D up, mat3D &c);
 void Ortho (float Vx, float Vy, float near, float far, mat3D &c);
 void Frustrum (float Vx, float Vy, float near, float far, mat3D &c);
 void Perspective (float fovy, float aspect, float near, float far, mat3D &c);
 void set3Dto2D (point3D a, point &b);

