#pragma once


namespace Graphiccs_6{

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Form1
	///
	/// Внимание! При изменении имени этого класса необходимо также изменить
	///          свойство имени файла ресурсов ("Resource File Name") для средства компиляции управляемого ресурса,
	///          связанного со всеми файлами с расширением .resx, от которых зависит данный класс. В противном случае,
	///          конструкторы не смогут правильно работать с локализованными
	///          ресурсами, сопоставленными данной форме.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Collections::Generic::List<line> lines;
	private: float left, right, top, bottom, Wcx, Wcy, Wx, Wy, Vcx, Vcy, Vx, Vy, wcx, wcy, wx, wy,vcx, vcy, vx;
	private: bool drawNames;
	private: System::Void DrawFigure(Graphics^ g, Pen^ blackPen){
g->DrawLine(blackPen,20, 20, 160, 20   );
g->DrawLine(blackPen,20, 20, 20, 100 );
g->DrawLine(blackPen,20, 100, 120, 100);
g->DrawLine(blackPen,120, 80, 120, 80);
g->DrawLine(blackPen,20, 100, 70, 150);
g->DrawLine(blackPen,70, 150, 120, 100);
g->DrawLine(blackPen,40, 120, 40, 140);
g->DrawLine(blackPen,40, 140, 50,140);
g->DrawLine(blackPen,50, 140, 50, 130 );
g->DrawLine(blackPen,40, 50, 40, 80);
g->DrawLine(blackPen,60, 50, 60, 80);
g->DrawLine(blackPen,40,50, 60, 50);
g->DrawLine(blackPen,40, 80, 60, 80);
g->DrawLine(blackPen,50, 50, 50, 80);
g->DrawLine(blackPen,40, 70, 60, 70);
g->DrawLine(blackPen,80, 50, 80,80);
g->DrawLine(blackPen,100, 50, 100, 80);
g->DrawLine(blackPen,80, 50, 100, 50);
g->DrawLine(blackPen,80, 80, 100, 80);
g->DrawLine(blackPen,90, 50, 90, 80);
g->DrawLine(blackPen,80, 70, 100, 70);
g->DrawLine(blackPen,120, 80, 140, 70);
g->DrawLine(blackPen,120, 20, 120, 100);
g->DrawLine(blackPen,140, 70, 140, 30);

g->DrawLine(blackPen,140 ,30, 150 ,30);
g->DrawLine(blackPen,150, 30, 150 ,25); 
g->DrawLine(blackPen,150, 25, 160, 25  );
g->DrawLine(blackPen,160, 25, 160, 20 );

//g->DrawLine(blackPen,20 ,20, 160 ,20);
//g->DrawLine(blackPen,20, 20, 20 ,150); 
//g->DrawLine(blackPen,160, 20, 160, 150  );
//g->DrawLine(blackPen,20,150, 160, 150 );
//
//g->DrawLine(blackPen,90, 20, 90, 150  );
//g->DrawLine(blackPen,20,85, 160, 85 );

				 mat c;
			 }
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
	private: System::Windows::Forms::Button^  btnOpen;
	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
			this->btnOpen = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// openFileDialog
			// 
			this->openFileDialog->DefaultExt = L"txt";
			this->openFileDialog->FileName = L"openFileDialog1";
			this->openFileDialog->Filter = L"Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
			this->openFileDialog->Title = L"Открыть файл";
			// 
			// btnOpen
			// 
			this->btnOpen->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->btnOpen->Location = System::Drawing::Point(866, 529);
			this->btnOpen->Margin = System::Windows::Forms::Padding(2);
			this->btnOpen->Name = L"btnOpen";
			this->btnOpen->Size = System::Drawing::Size(71, 23);
			this->btnOpen->TabIndex = 0;
			this->btnOpen->Text = L"Открыть";
			this->btnOpen->UseVisualStyleBackColor = true;
			this->btnOpen->Click += gcnew System::EventHandler(this, &Form1::btnOpen_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(950, 561);
			this->Controls->Add(this->btnOpen);
			this->DoubleBuffered = true;
			this->KeyPreview = true;
			this->Margin = System::Windows::Forms::Padding(2);
			this->MinimumSize = System::Drawing::Size(304, 251);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::Form1_Paint);
			this->Resize += gcnew System::EventHandler(this, &Form1::Form1_Resize);
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				 left = 100;
				 right = 100;
				 top = 100;
				 bottom = 100;
				 wcx=Wcx = left;
				 wcy=Wcy = Form::ClientRectangle.Height - bottom;
				 wx=Wx = Form::ClientRectangle.Width - left - right;
				 wy=Wy = Form::ClientRectangle.Height - top - bottom;
				 lines.Clear();
				 unit(T);
			 }
	private: System::Void Form1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
				 Graphics^ g = e->Graphics; 
                 Graphics^ h = e->Graphics; 
                 
				 System::Drawing::Pen^ blackPen = gcnew Pen(Color::Black);
				 blackPen->Width = 2;

				 System::Drawing::Pen^ redPen = gcnew Pen(Color::Red);
				 redPen->Width = 4;

				 Rectangle rect = System::Drawing::Rectangle(Wcx, top, Wx, Wy);
				 
				

				 g->DrawRectangle(redPen, rect);
				 g->Clip = gcnew System::Drawing::Region(rect);

				 System::Drawing::Font^ drawFont = gcnew System::Drawing::Font("Arial", 8);
				 SolidBrush^ drawBrush = gcnew SolidBrush(Color::Black);

				 g->Transform = gcnew System::Drawing::Drawing2D::Matrix(T[0][0], T[1][0], T[0][1], T[1][1], T[0][2], T[1][2]);

				 for (int i = 0; i < matrices.size(); i++) {
					 mat С;
					 times(T, matrices[i], С);
					 g->Transform = gcnew System::Drawing::Drawing2D::Matrix(С[0][0], С[1][0], С[0][1], С[1][1], С[0][2], С[1][2]);
					 DrawFigure(g, blackPen);
				 }
				 System::Drawing::Pen^ yellowPen = gcnew Pen(Color::Yellow);
		/*yellowPen->Width = 1;
        vec A,B;
		int vl=40;int gl=20;
	    float interval = wx / vl;
		float x_x1 = wcx, z_n_x_x1;
		while (x_x1 <= wx+wcx)
		{
			vec A1;
			line l; point z_n;
			z_n_x_x1 = Vcx + x_x1*Vx / wx;
			z_n_x_x1 *= 100;
			z_n_x_x1 = (int)(z_n_x_x1 + 0.5);
			z_n.x = z_n_x_x1 / 1000;
			z_n.y = 0;


			l.start.x = x_x1;
			l.start.y = top;
			l.end.x = x_x1;
			l.end.y = wcy;
			point2vec(l.start, A);
			point2vec(l.end, B);

			point a, b;
			vec2point(A, a);
			vec2point(B, b);
			point min, max;
			min.x = wcx; min.y = top;
			max.x = wx + 10; max.y = wcy;

			
		    h->DrawLine(yellowPen, a.x, a.y, b.x, b.y);
			std::string str;
			std::ostringstream stream;
			stream << z_n.x;
			str = stream.str();
			l.name = gcnew String(str.c_str());
			x_x1 += interval;

			;
		}
		interval = (Wcy - top) / gl;
		float y_y1 = top, z_n_y_y1;
		while (y_y1 <= wcy)
		{
			z_n_y_y1 = Vcy - (y_y1 - wcy)*Vy / wy;
			vec AA;
			z_n_y_y1 *= 100;
			z_n_y_y1 = (int)(z_n_y_y1 + 0.5);

			line l; point z_n;
			z_n.x = 0; z_n.y = z_n_y_y1 / 1000;


			l.start.x = wcx;
			l.start.y = y_y1;
			l.end.x = wx + wcx;
			l.end.y = y_y1;
			point2vec(l.start, A);
			point2vec(l.end, B);

			point a, b;
			vec2point(A, a);
			vec2point(B, b);
			point min, max;
			min.x = wcx; min.y = top;
			max.x = wx + 10; max.y = wcy;

			
				h->DrawLine(yellowPen, a.x, a.y, b.x, b.y);
			std::string str;
			std::ostringstream stream;
			stream << z_n.y;
			str = stream.str();
			l.name = gcnew String(str.c_str());
			y_y1 += interval;

			;
		}*/
			 }
			 
	private: System::Void btnOpen_Click(System::Object^  sender, System::EventArgs^  e) {
				 if (this->openFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK){
					 wchar_t fileName[1024];
					 for (int i = 0; i < openFileDialog->FileName->Length; i++)
						 fileName[i] = openFileDialog->FileName[i];
					 fileName[openFileDialog->FileName->Length] = '\0'; 

					 std::ifstream in;
					 in.open(fileName);
					 if (in.is_open()) { 
						 matrices.clear();
						 std::stack<mat> matStack;
						 mat K; 
						 unit(K);
						 unit(T);
						 std::string str;
						 getline (in, str);

						 while (in) { 
							 if ((str.find_first_not_of(" \t\r\n") != std::string::npos) && (str[0] != '#')) { 
								 std::stringstream s(str);
								 std::string cmd;
								 s >> cmd;
								 if ( cmd == "frame" ) {
									 float newVcx, newVcy, newVx, newVy;
									 s >>  newVcx >> newVcy >> newVx >> newVy;
									 Vcx = newVcx; 
									 Vcy = newVcy;
									 Vx = newVx;
									 Vy = newVy;
									 frame (Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
								 }
								 else if ( cmd == "figure" ) {
									 matrices.push_back(K);
								 }
								 else if ( cmd == "pushTransform" ) {
									 matStack.push(K);
								 }
								 else if ( cmd == "popTransform" ) {
									 K = matStack.top();
									 matStack.pop();
								 }
								 else if ( cmd == "translate" ) {
									 float Tx, Ty;
									 s >> Tx >> Ty;
									 mat C, C1;
									 move(Tx, Ty, C);
									 times(K, C, C1);
									 K = C1;
								 }
								 else if ( cmd == "scale" ) {
									 float S;
									 s >> S;
									 mat C, C1;
									 scale(S, S, C);
									 times(K, C, C1);
									 K = C1;
								 }
								 else if ( cmd == "rotate" ) {
									 float Phi;
									 s >> Phi;
									 float pi = 3.1415926535;
									 float PhiR = Phi * (pi / 180);
									 mat C, C1;
									 rotate(PhiR, C);
									 times(K, C, C1);
									 K = C1;
								 }
							 }
							 getline (in, str);
						 }
					 }
					 this->Refresh();
				 }
				 }
		
	private: System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
				 Rectangle rect = Form::ClientRectangle;
				 mat R, T1;
				 switch(e->KeyCode){
					 case Keys::W :
						 move(0, -1, R);
						 break;
					 case Keys::S :
						 move(0, 1, R);
						 break;
					 case Keys::A :
						 move(-1, 0, R);
						 break;
					 case Keys::D :
						 move(1, 0, R);
						 break;
					 case Keys::E : 
						 rotate(0.05f, R);
						 break;
					 case Keys::Q : 
						 rotate(-0.05f, R);
						 break;
					 case Keys::X :
						 scale(1.1f, 1.1f, R);
						 break;
					 case Keys::Z :
						 scale(1/1.1f, 1/1.1f, R);
						 break;
					 case Keys::T : 
						 move(0, -5, R);
						 break;
					 case Keys::G : 
						 move(0, 5, R);
						 break;
					 case Keys::F: 
						 move(-5, 0, R);
						 break;
					 case Keys::H : 
						 move(5, 0, R);
						 break;
					 case Keys::U : 
						 reflectVert(R);
						 times(R, T, T1);
						 set(T1, T);
						 move(rect.Width + 0.0f, 0.0f, R);				
						 break;
					 case Keys::J :  
						 reflectHoriz(R);
						 times(R, T, T1);
						 set(T1, T);
						 move(0.0f, rect.Height + 0.0f, R);	
						 break;
					 case Keys::Y : 
						 move(-rect.Width/2.0f, -rect.Height/2.0f, R);
						 times(R, T, T1);
						 set(T1, T);
						 rotate(-0.1f, R);
						 times(R, T, T1);
						 set(T1, T);
						 move(rect.Width/2.0f, rect.Height/2.0f, R);
						 break;
					 case Keys::R : 
						 move(-rect.Width/2.0f, -rect.Height/2.0f, R);
						 times(R, T, T1);
						 set(T1, T);
						 rotate(0.1f, R);
						 times(R, T, T1);
						 set(T1, T);
						 move(rect.Width/2.0f, rect.Height/2.0f, R);
						 break;
					 case Keys::C : 
						 move(-rect.Width / 2.0f, -rect.Height / 2.0f, R);
						 times(R, T, T1);
						 scale(1 / 1.1f, 1 / 1.1f, R);
						 times(R, T1, T);
						 move(rect.Width / 2.0f, rect.Height / 2.0f, R);
						 break;
					 case Keys::V : 
						 move(-rect.Width / 2.0f, -rect.Height / 2.0f, R);
						 times(R, T, T1);
						 scale(1.1f, 1.1f, R);
						 times(R, T1, T);
						 move(rect.Width / 2.0f, rect.Height / 2.0f, R);
						 break;
					 case Keys::L : 
						 move(-rect.Width / 2.0f, 0.0f, R);
						 times(R, T, T1);
						 scale(1.1f, 1, R);
						 times(R, T1, T);
						 move(rect.Width / 2.0f, 0.0f, R);
						 break;
					 case Keys::K :
						 move(-rect.Width / 2.0f, 0.0f, R);
						 times(R, T, T1);
						 scale(1 / 1.1f, 1, R);
						 times(R, T1, T);
						 move(rect.Width / 2.0f, 0, R);
						 break;
					 case Keys::O : 
						 move(0.0f, -rect.Height / 2.0f, R);
						 times(R, T, T1);
						 scale(1.0f, 1.1f, R);
						 times(R, T1, T);
						 move(0.0f, rect.Height / 2.0f, R);
						 break;
					 case Keys::I : 
						 move(0.0f, -rect.Height / 2.0f, R);
						 times(R, T, T1);
						 scale(1.0f, 1 / 1.1f, R);
						 times(R, T1, T);
						 move(0.0f, rect.Height / 2.0f, R);
						 break;
					 case Keys::P :
						 drawNames = !drawNames;
						 unit(R);
						 break;
					 case Keys::Escape :
						 unit(R);
						 unit(T);
						 frame (Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
						 break;

					 default :
						 unit(R);
				 }
				 times(R,T,T1);
				 set(T1, T);
				 this->Refresh();
			 }

	private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
				 float oldWx = Wx, oldWy = Wy;
				 Wcx = left;
				 Wcy = Form::ClientRectangle.Height - bottom;
				 Wx = Form::ClientRectangle.Width - left - right;
				 Wy = Form::ClientRectangle.Height - top - bottom;

				 mat R,T1;
				 move(-Wcx,-top,R);
				 times(R,T,T);
				 scale(Wx/oldWx, Wy/oldWy, R);
				 times(R,T,T);
				 move(Wcx,top,R);
				 times(R,T,T);	
				 this->Refresh();

			 }
			 };
	}

