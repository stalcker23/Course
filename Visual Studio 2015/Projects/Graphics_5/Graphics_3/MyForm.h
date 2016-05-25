#pragma once

namespace Graphics_3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private:
		System::Collections::Generic::List<line> lines;
		float left, right, top, bottom;
		float Wcx, Wcy, Wx, Wy;
		float Vcx, Vcy, Vx, Vy;
		float VcxOld, VcyOld, VxOld, VyOld;
		bool names = false;
		int gl, vl;
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;


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
			this->SuspendLayout();
			// 
			// openFileDialog
			// 
			this->openFileDialog->DefaultExt = L"txt";
			this->openFileDialog->FileName = L"openFileDialog1";
			this->openFileDialog->Filter = L"Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
			this->openFileDialog->Title = L"Открыть файл";
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(384, 361);
			this->KeyPreview = true;
			this->MinimumSize = System::Drawing::Size(300, 300);
			this->Name = L"MyForm";
			this->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
			this->Text = L"MyForm";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &MyForm::MyForm_Paint);
			this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &MyForm::MyForm_KeyDown);
			this->Resize += gcnew System::EventHandler(this, &MyForm::MyForm_Resize);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void MyForm_Load(System::Object^  sender, System::EventArgs^  e) {

		names = true;
		Wcx = left;
		Wcy = System::Windows::Forms::Form::ClientRectangle.Height - bottom;
		Wx = System::Windows::Forms::Form::ClientRectangle.Width - left - right;
		Wy = System::Windows::Forms::Form::ClientRectangle.Height - top - bottom;
		unit(T);



		start koord;
		Vcx = -9; Vcy = -5; Vx = 18; Vy = 10;
		VxOld = Vx;
		VyOld = Vy;
		VcxOld = Vcx;
		VcyOld = Vcy;
		gl = 10; vl = 10;



		this->Refresh();

		lines.Clear();
	}
	private: System::Void  MyForm_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
		left = 10.0; right = 100.0; top = 60.0; bottom = 80.0;
		/* left=150.0; right= 100.0; top=150.0; bottom=100.0;*/
		Graphics^ g = e->Graphics;


		Rectangle rect = Form::ClientRectangle;

		System::Drawing::Pen^ rectPen = gcnew Pen(Color::Red);
		rectPen->Width = 2;

		Wcx = left;
		Wcy = System::Windows::Forms::Form::ClientRectangle.Height - bottom;
		Wx = System::Windows::Forms::Form::ClientRectangle.Width - left - right;
		Wy = System::Windows::Forms::Form::ClientRectangle.Height - top - bottom;



		g->DrawRectangle(rectPen, Wcx, top, Wx, Wy);

		System::Drawing::Pen^ blackPen = gcnew Pen(Color::Black);
		blackPen->Width = 2;

		System::Drawing::Pen^ yellowPen = gcnew Pen(Color::Yellow);
		yellowPen->Width = 1;


		point min, max;

		SolidBrush^ drawBrush = gcnew SolidBrush(Color::Black);
		System::Drawing::Font^ drawFont = gcnew System::Drawing::Font("Arial", 10);

		float x = Vcx, x1 = Wcx;
		float y, y1, y2;
		bool visible1 = true, visible2 = true, vis = true;



		float interval = Wx / vl;
		float x_x1 = Wcx, z_n_x_x1;
		while (x_x1 <= Wx + Wcx)
		{
			vec A1;
			line l; point z_n;
			z_n_x_x1 = Vcx + x_x1*Vx / Wx;
			z_n_x_x1 *= 100;
			z_n_x_x1 = std::floor(z_n_x_x1 + 0.5);
			z_n.x = z_n_x_x1 / 1000;
			z_n.y = 0;


			l.start.x = x_x1;
			l.start.y = top;
			l.end.x = x_x1;
			l.end.y = Wcy;
			point2vec(l.start, A);
			point2vec(l.end, B);

			point a, b;
			vec2point(A, a);
			vec2point(B, b);
			point min, max;
			min.x = Wcx; min.y = top;
			max.x = Wx + 10; max.y = Wcy;

			if (clip(a, b, min, max))
				g->DrawLine(yellowPen, a.x, a.y, b.x, b.y);
			std::string str;
			std::ostringstream stream;
			stream << z_n.x;
			str = stream.str();
			l.name = gcnew String(str.c_str());
			g->DrawString(l.name, drawFont, drawBrush, x_x1, Wcy);
			x_x1 += interval;

			;
		}

		interval = (Wcy - top) / gl;
		float y_y1 = top, z_n_y_y1;
		while (y_y1 <= Wcy)
		{
			z_n_y_y1 = Vcy - (y_y1 - Wcy)*Vy / Wy;
			vec AA;
			z_n_y_y1 *= 100;
			z_n_y_y1 = std::floor(z_n_y_y1 + 0.5);

			line l; point z_n;
			z_n.x = 0; z_n.y = z_n_y_y1 / 1000;


			l.start.x = Wcx;
			l.start.y = y_y1;
			l.end.x = Wx + Wcx;
			l.end.y = y_y1;
			point2vec(l.start, A);
			point2vec(l.end, B);

			point a, b;
			vec2point(A, a);
			vec2point(B, b);
			point min, max;
			min.x = Wcx; min.y = top;
			max.x = Wx + 10; max.y = Wcy;

			if (clip(a, b, min, max))
				g->DrawLine(yellowPen, a.x, a.y, b.x, b.y);
			std::string str;
			std::ostringstream stream;
			stream << z_n.y;
			str = stream.str();
			l.name = gcnew String(str.c_str());
			g->DrawString(l.name, drawFont, drawBrush, ClientRectangle.Size.Width - right, y_y1);
			y_y1 += interval;

			;
		}
		if (fexists(x))
		{
			visible1 = true;
			y = f(x);
			y1 = Wcy - ((y - Vcy) * Wy) / Vy;
		}
		else
			visible1 = false;
		while (x1 <= Wx + Wcx)
		{
			if (x1 >= (Wcx + Wx))
			{
				visible1 = false;
			}
			else
			{
				x = ((x1 + 1 - Wcx) *Vx) / Wx + Vcx;
			}
			if (fexists(x))
			{
				visible2 = true;
				y = f(x);
				y2 = Wcy - ((y - Vcy) * Wy) / Vy;
			}
			else
				if (!fexists(x))
					visible2 = false;

			if (visible1 && visible2)
			{

				vec A, B;
				line l;
				l.start.x = x1;
				l.start.y = y1;
				l.end.x = x1 + 1;
				l.end.y = y2;
				point2vec(l.start, A);
				point2vec(l.end, B);

				point a, b;
				vec2point(A, a);
				vec2point(B, b);
				point min, max;
				min.x = Wcx; min.y = top;
				max.x = Wx + Wcx; max.y = Wcy;
				if (clip(a, b, min, max))
					g->DrawLine(blackPen, a.x, a.y, b.x, b.y);
			}

			x1 += 1;
			y1 = y2;
			visible1 = visible2;

		}

	}
	private: System::Void openFileDialog_FileOk(System::Object^  sender, System::ComponentModel::CancelEventArgs^  e) {
	}
			
	private: System::Void  MyForm_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
		float temp;
		mat R, T1;
		switch (e->KeyCode)
		{



		case Keys::W:
			Vcy -= (Vy / Wy);
			break;

		case Keys::S:
			Vcy += (Vy / Wy);
			break;

		case Keys::A:
			Vcx += (Vx / Wx);
			break;

		case Keys::D:
			Vcx -= (Vx / Wx);
			break;



		case Keys::T:
			Vcy -= 5 * (Vy / Wy);
			break;

		case Keys::G:
			Vcy += 5 * (Vy / Wy);
			break;

		case Keys::F:
			Vcx += 5 * (Vx / Wx);
			break;

		case Keys::H:
			Vcx -= 5 * (Vx / Wx);
			break;


		case Keys::O:
			temp = Vx;
			Vx *= 1 / 1.1;
			Vcx += (temp - Vx) / 2;
			break;
		case Keys::I:
			temp = Vx;
			Vx *= 1.1;
			Vcx += (temp - Vx) / 2;
			break;



			break;

		case Keys::K:
			temp = Vy;

			Vy *= 1.1;
			Vcy += (temp - Vy) / 2;
			break;

		case Keys::L:

			temp =Vy;
			Vy *= 1 / 1.1;
			Vcy += (temp - Vy) / 2;
			break;





		case Keys::P:
			unit(R);
			names = !names;

			break;

		
		case Keys::Q:
			if (gl) gl--;
			break;
		case Keys::E:
			gl++;
			break;
		case Keys::Z:
			if (vl) vl--;
			break;
		case Keys::C:
			vl++;
			break;
		break;
		case Keys::Escape:
			Vcx = VcxOld; Vcy = VcyOld; Vx = VxOld; Vy = VyOld;
		    default:
			break;
		}
		times(R, T, T1);
		set(T1, T);

		this->Refresh();

	}
	private: System::Void MyForm_Resize(System::Object^  sender, System::EventArgs^  e) {
		float oldWx = Wx, oldWy = Wy;

		Wcx = left;
		Wcy = Form::ClientRectangle.Height - bottom;
		Wx = Form::ClientRectangle.Width - left - right;
		Wy = Form::ClientRectangle.Height - top - bottom;

		mat R, T1;
		move(-Wcx, -top, R);
		times(R, T, T1);
		set(T1, T);

		unit(R);
		scale(Wx / oldWx, Wy / oldWy, R);
		times(R, T, T1);
		set(T1, T);

		move(Wcx, top, R);
		times(R, T, T1);
		set(T1, T);

		this->Refresh();
	}
	private: System::Void label1_Click(System::Object^  sender, System::EventArgs^  e) {
	}
	};
}


