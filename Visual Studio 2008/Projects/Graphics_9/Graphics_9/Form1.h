#pragma once


namespace grafic9 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{


			InitializeComponent();

		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private:
		System::Collections::Generic::List<line> lines;
	private: System::Collections::Generic::List<polygon^> polygons;
	private: System::Collections::Generic::List<polygon3D^> polygons3D;
			 System::Collections::Generic::List<col> colors;
	public: point3D eye,first_eye,center,first_center,up,first_up;
			 float fovy, near ,far,first_fovy,first_near,first_far,aspect,aspect1;
	private:
			 float left, right, top, bottom;
			 float Wcx, Wcy, Wx, Wy;
			 col color;
			 start param;
			 bool Drawnames;
			 bool prOrtho;
			 float alpha;
	private:System::Drawing::Pen^ BlPen ;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
	private: System::Windows::Forms::Button^  btnOpen;
	private: System::Windows::Forms::Label^  label1;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
			this->btnOpen = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// openFileDialog
			// 
			this->openFileDialog->DefaultExt = L"txt";
			this->openFileDialog->FileName = L"openFileDialog1";
			this->openFileDialog->Filter = L"Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
			this->openFileDialog->Title = L"Открыть файл";
			this->openFileDialog->FileOk += gcnew System::ComponentModel::CancelEventHandler(this, &Form1::openFileDialog_FileOk);
			// 
			// btnOpen
			// 
			this->btnOpen->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->btnOpen->Location = System::Drawing::Point(539, 379);
			this->btnOpen->Name = L"btnOpen";
			this->btnOpen->Size = System::Drawing::Size(75, 23);
			this->btnOpen->TabIndex = 0;
			this->btnOpen->Text = L"Открыть";
			this->btnOpen->UseVisualStyleBackColor = true;
			this->btnOpen->Click += gcnew System::EventHandler(this, &Form1::btnOpen_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(343, -2);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(0, 13);
			this->label1->TabIndex = 1;
			this->label1->Click += gcnew System::EventHandler(this, &Form1::label1_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(617, 414);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->btnOpen);
			this->DoubleBuffered = true;
			this->KeyPreview = true;
			this->MinimizeBox = false;
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::Form1_Paint);
			this->Resize += gcnew System::EventHandler(this, &Form1::Form1_Resize);
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				
				 polygons3D.Clear();
				 lines.Clear();unit3D(T);
				  left=10.0; right= 100.0; top=100.0; bottom=20.0;
				 Wcx = left;
				 Wcy = System::Windows::Forms::Form::ClientRectangle.Height - bottom;
				 Wx = System::Windows::Forms::Form::ClientRectangle.Width - left - right;
				 Wy = System::Windows::Forms::Form::ClientRectangle.Height - top - bottom;
				 aspect1 = Wx/Wy;
				 prOrtho = true;
				 alpha= 3.14/(180/5);
				 

			 }
	private: System::Void Form1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
				 left=110.0; right= 110.0; top=50.0; bottom=20.0;
				 Bitmap^ image1 = gcnew Bitmap( this->ClientRectangle.Width , this->ClientRectangle.Height );
				 Graphics^ g = Graphics::FromImage(image1);
				 System::Drawing::Pen^ BlPen ;
				 Rectangle rect = Form::ClientRectangle;
				 System::Drawing::Pen^ rectPen = gcnew Pen(Color::Red);
				 rectPen->Width = 1;
 			 mat3D V,U,R,UV;
				
				 if (first_eye.x!=0)
				 {	
				
				
				 

				 unit3D(U); unit3D(V);
				unit3D(UV);unit3D(R);
				float Vx,Vy;
				 LookAt (eye,center ,up, V);
				 
				 if(prOrtho == true) 
				 {
					  Vy = 2 * near * tan(fovy / 2);
					  Vx = Vy * aspect1;
					 Ortho(Vx, Vy, near, far, U);
				 }
				 else
				 {
					Perspective(fovy,aspect1,near,far,U);
				 }

				 
				 times3D (U, V, UV);
				 times3D (UV, T, R);
				 
				 }

				 Wcx = left;
				 Wcy = System::Windows::Forms::Form::ClientRectangle.Height - bottom;
				 Wx = System::Windows::Forms::Form::ClientRectangle.Width - left - right;
				 Wy = System::Windows::Forms::Form::ClientRectangle.Height - top - bottom;

				 g->DrawRectangle(rectPen, Wcx, top, Wx, Wy);

				 mat T1,T2,T3,F;unit(T1); unit(T2);float minus=-1.0;
				 unit(F);
				 frame(2.0, 2.0,minus,minus, Wx, Wy, Wcx, Wcy,F);
				 point Pmin,Pmax;
				 SolidBrush^ drawBrush = gcnew SolidBrush(Color::Black);
				 System::Drawing::Font^ drawFont = gcnew System::Drawing::Font( "Arial",10 );

				 for (int i = 0; i <  polygons3D.Count; i++) 
				 {

					 BlPen = gcnew Pen(Color::FromArgb(colors[i].R, colors[i].G, colors[i].B));
					 polygon3D^ p1 = polygons3D[i]; polygon^ p = gcnew polygon(0);
					 polygon^ p2;
					 point a, b, c;
					 vec A, B, A1, B1;
					 vec3D AA,AA1;point3D a1;

					 for (int j = 0; j < p1->Count; j++){

						 point2vec3D(p1[j], AA);
						 timesMatVec3D(R, AA, AA1);
						 vec2point3D(AA1, a1);
						 //p->Add(b);

					 
					 set3Dto2D(a1,b);
					 point2vec(b,A);
					 timesMatVec(F, A, A1);
					 vec2point(A1, b);
					 p->Add(b);
					 }



					 Pmin.x=Wcx;Pmin.y=top;
					 Pmax.x=Wx+Wcx; Pmax.y=Wcy;
					
					 p2= Pclip ( p,  Pmin,  Pmax);
					 float min= 99999.0,min2= 99999.0,min1= 99999.0,xy=0,xy2=0;
					 float xmin= 99999.0,xmin2= 99999.0,xmin1= 99999.0,yx=0,yx2=0;

					 if ((p2->Count - 1)>1){

						 //Pfill (p2,image1,Color::FromArgb(colors[i].R, colors[i].G, colors[i].B));
						 //Pfill (p2,image1,Color::FromArgb(200, 200, 200));
						 delete p;
						 BlPen->Width = 1;
						 point2vec(p2[p2->Count - 1], A);						 
						 vec2point(A, a);

						



						 for (int j = 0; j < p2->Count; j++){

							 point2vec(p2[j], B);
							
							 vec2point(B, b);
							 g ->DrawLine(BlPen, a.x, a.y, b.x, b.y);
							 a = b;}

					 }}			
				 
				 g = e->Graphics;
				 g->DrawImage(image1,0,0);
				 delete image1;



			 }
	private: System::Void openFileDialog_FileOk(System::Object^  sender, System::ComponentModel::CancelEventArgs^  e) {
			 }
	private: System::Void btnOpen_Click(System::Object^  sender, System::EventArgs^  e) {
				 BlPen = gcnew Pen(Color::Black);int k=-1;

				 Drawnames=true;
				 Wcx = left;
				 Wcy = System::Windows::Forms::Form::ClientRectangle.Height - bottom;
				 Wx = System::Windows::Forms::Form::ClientRectangle.Width - left - right;
				 Wy = System::Windows::Forms::Form::ClientRectangle.Height - top - bottom; 			
				 unit3D(T);
				 if ( this->openFileDialog->ShowDialog() ==
					 System::Windows::Forms::DialogResult::OK){
						 wchar_t fileName[1024];
						 for (int i = 0; i < openFileDialog->FileName->Length; i++)
							 fileName[i] = openFileDialog->FileName[i];
						 fileName[openFileDialog->FileName->Length] = '\0';
						 std::ifstream in;

						 in.open(fileName);
						 if ( in.is_open() ) {
							 lines.Clear();

							 mat K; unit(K);


							 std::string str; 
							 getline (in, str);


							 while (in) 
							 {	

								 if ((str.find_first_not_of(" \t\r\n") != std::string::npos)
									 && (str[0] != '#')) 
								 { std::stringstream s(str);
								 std::string cmd;

								 s >> cmd;
								 if ( cmd == "frame" ) 

								 { unit3D(T);
								 start para;
								 s >> para.Vcx >> para.Vcy >> para.Vx >>para.Vy;
								 param=para;

								 //frame ( param.Vx, param.Vy, param.Vcx, param.Vcy, Wx, Wy, Wcx, Wcy, T);
								 }else if (cmd=="color"&&k>=0)
								 {int r,g,b;
								 s>>r>>g>>b;
								 color.R=r;color.G=g;color.B=b;
								 colors[polygons3D.Count-1]=color;

								 ;}
								 else if (cmd=="screen")
								 {int fov,nea,fa;
								 s>>fov>>nea>>fa;
								 fovy =3.14/(180 / fov);
								 first_fovy = fovy;
								 first_near = near = nea;
								 first_far = far = fa;

								 ;}
								 else if (cmd=="lookat")
								 {float xx,yy,zz;

								 s>>xx>>yy>>zz;
								 eye.x = xx;
								 eye.y = yy;
								 eye.z = zz;

								 s>>xx>>yy>>zz;
								 center.x = xx;
								 center.y = yy;
								 center.z = zz;

								 s>>xx>>yy>>zz;
								 up.x = xx;
								 up.y = yy;
								 up.z = zz;
								 first_eye = eye;
								 first_center = center;
								 first_up = up;

								 ;}
								 else if (cmd == "triangle" )
								 {int numpoint=3;
								 k++;

								 polygon3D^ P = gcnew polygon3D(0);
								 for (int i = 0; i<numpoint; i++) {
									 point3D p;
									 s >> p.x >> p.y>>p.z;
									 P->Add(p);
								 }
								 color.R=0;color.G=0;color.B=0;
								 polygons3D.Add(P);colors.Add(color)

									 ;}
								 }
								 getline (in, str); 
								}


						 }
				 }
				  vec3D first_eye_vec,first_up_vec,first_center_vec;point3D eye1;
				 vec3D bb;
				 mat3D E,TT;unit3D(T);
 LookAt ( first_center,first_eye,first_up, T);
				
				 point2vec3D (first_eye,first_eye_vec);
				 timesMatVec3D (T, first_eye_vec,bb);
				 vec2point3D(bb,eye1);eye=eye1;
				 point2vec3D (first_up,first_up_vec);
				 point2vec3D (first_center,first_center_vec);
				 up.x= 0; up.y=1; up.z= 0;
				 center.x=0; center.y=0; center.z=0;

				 makeHomogenVec3D (0,1 ,0 ,first_up_vec );
				 makeHomogenVec3D (0,0 ,0 ,first_center_vec ); 
				

				 this->Refresh();

			 }			 
	private: System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
				 mat3D R,T1;
				 switch(e->KeyCode)
				 {
				 case Keys::D :
					 {point3D ww;
					 ww.x=0; ww.y=1;ww.z=0;
						 rotate3D(ww,alpha, R);}
					 break;
				 case Keys::A :
					{point3D ww;
					 ww.x=0; ww.y=1;ww.z=0;
						 rotate3D(ww,-alpha, R);}
					 break;
				 case Keys::W :
					 {point3D ww;
					 ww.x=1; ww.y=0;ww.z=0;
						 rotate3D(ww,alpha, R);}
					 break;
				 case Keys::S :
					 {point3D ww;
					 ww.x=1; ww.y=0;ww.z=0;
						 rotate3D(ww,-alpha, R);}
					 break;
				 case Keys::T :
					 move3D(0, -7,0, R);
					 unit3D(R);
					 break;
				 case Keys::G :
					 move3D(0, 7,0, R);
					 unit3D(R);
					 break;
				 case Keys::F :
					 move3D(-7, 0,0, R);
					 unit3D(R);
					 break;
				 case Keys::H :
					 move3D(7, 0,0, R);
					 unit3D(R);
					 break;
				 case Keys::Q :
					 {point3D ww;
					 ww.x=0; ww.y=0;ww.z=1;
						 rotate3D(ww,-alpha, R);}
					 break;
				 case Keys::R :
					 /*{move(-System::Windows::Forms::Form::ClientRectangle.Width/2, -System::Windows::Forms::Form::ClientRectangle.Height/2, R);
					 times(R,T,T1);
					 set(T1,T);
					 rotate(0.1, R);
					 times(R,T,T1);
					 set(T1,T);
					 move(System::Windows::Forms::Form::ClientRectangle.Width/2, System::Windows::Forms::Form::ClientRectangle.Height/2, R);}
					 */unit3D(R);break;
				 case Keys::Y :
					 {/*move(-System::Windows::Forms::Form::ClientRectangle.Width/2, -System::Windows::Forms::Form::ClientRectangle.Height/2, R);
					 times(R,T,T1);
					 set(T1,T);
					 unrotate(0.1, R);
					 times(R,T,T1);
					 set(T1,T);
					 move(System::Windows::Forms::Form::ClientRectangle.Width/2, System::Windows::Forms::Form::ClientRectangle.Height/2, R);
					 */unit3D(R);break;}
				 case Keys::X :
					 near-=5;
					 unit3D(R);

					 break;
				 case Keys::P :
					 unit3D(R);
					 Drawnames=!Drawnames;
					 prOrtho= !prOrtho;

					 break;
				 case Keys::C :
					 if (fovy<3.14-3.14/(180))
					  fovy +=3.14/(180 );
					 
					 unit3D(R);
					 					 break;
				 case Keys::V:
					 {if (fovy>3.14/(180 ))
					  fovy -=3.14/(180 );
					 
					 
					 unit3D(R);
					 } 
					 break;
				 case Keys::I:
					 {/*
						 move(-System::Windows::Forms::Form::ClientRectangle.Width/2, -System::Windows::Forms::Form::ClientRectangle.Height/2, R);
						 times(R,T,T1);
						 set(T1,T);
						 scalew(1.1, R);
						 times(R,T,T1);
						 set(T1,T);
						 move(System::Windows::Forms::Form::ClientRectangle.Width/2, System::Windows::Forms::Form::ClientRectangle.Height/2, R);
					*/unit3D(R); } 
					 break;
				 case Keys::O:
					 {alpha*=1.1;
					 unit3D(R);
					 ;} 
					 break;
				 case Keys::K:
					 {/*
						 move(-System::Windows::Forms::Form::ClientRectangle.Width/2, -System::Windows::Forms::Form::ClientRectangle.Height/2, R);
						 times(R,T,T1);
						 set(T1,T);
						 scaleh(1.1, R);
						 times(R,T,T1);
						 set(T1,T);
						 move(System::Windows::Forms::Form::ClientRectangle.Width/2, System::Windows::Forms::Form::ClientRectangle.Height/2, R);
					*/unit3D(R); } 
					 break;
				 case Keys::L:
					 {alpha*=(1.0/1.1);
					 unit3D(R);
					 } 
					 break;
				 case Keys::Escape:
					 {unit3D(R);
					 near=first_near; far = first_far;fovy=first_fovy;
					 unit3D(T);
 LookAt ( first_center,first_eye,first_up, T);

					 } 
					 break;
				 case Keys::U :
					// zerk_goriz(System::Windows::Forms::Form::ClientRectangle.Height,R);
					 unit3D(R);
					 break;
				 case Keys::J :
					 //zerk_vert(System::Windows::Forms::Form::ClientRectangle.Width,R);
					 unit3D(R);
					 break;
				 case Keys::E :
					 {point3D ww;
					 ww.x=0; ww.y=0;ww.z=1;
						 rotate3D(ww,alpha, R);}
					 break;
				 case Keys::Z :
					 near+=5;
					 unit3D(R);
					 break;
				 default:
					 unit3D(R);
				 }
				times3D(R,T,T1);
				 set3D(T1,T);
				 this->Refresh();

			 }
	private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
				 float oldWx = Wx, oldWy = Wy;

				 Wcx = left;
				 Wcy = Form::ClientRectangle.Height - bottom;
				 Wx = Form::ClientRectangle.Width - left - right;
				 Wy = Form::ClientRectangle.Height - top - bottom;
/*
				 mat R,T1;
				 move(-Wcx,-top,R);
				 times(R,T,T1);
				 set(T1,T);
				 unit(R);
				 R[0][0]=Wx/oldWx;R[1][1]=Wy/oldWy;
				 times(R,T,T1);
				 set(T1,T);
				 move(Wcx,top,R);

				 times(R,T,T1);
				 set(T1,T);*/


				 this->Refresh();
			 }
	private: System::Void label1_Click(System::Object^  sender, System::EventArgs^  e) {
			 }
	};
}

