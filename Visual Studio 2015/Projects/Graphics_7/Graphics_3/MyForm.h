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
		System::Collections::Generic::List<polygon^> polygons;
		float left, right, top, bottom;
		float Wcx, Wcy, Wx, Wy;
		float Vcx, Vcy, Vx, Vy;
		bool names = false;

	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
	private: System::Windows::Forms::Button^  btnOpen;

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
			this->btnOpen->Location = System::Drawing::Point(309, 340);
			this->btnOpen->Name = L"btnOpen";
			this->btnOpen->Size = System::Drawing::Size(75, 23);
			this->btnOpen->TabIndex = 0;
			this->btnOpen->Text = L"Открыть";
			this->btnOpen->UseVisualStyleBackColor = true;
			this->btnOpen->Click += gcnew System::EventHandler(this, &MyForm::btnOpen_Click);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(384, 361);
			this->Controls->Add(this->btnOpen);
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

		lines.Clear();
		unit(T);
		left = 20; right = 20; top = 20; bottom = 30;
		Wcx = left;
		Wcy = Form::ClientRectangle.Height - bottom;
		Wx = Form::ClientRectangle.Width - left - right;
		Wy = Form::ClientRectangle.Height - top - bottom;

	}
	private: System::Void MyForm_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
		Graphics^ g = e->Graphics;
		System::Drawing::Pen^ blackPen = gcnew Pen(Color::Black);
		blackPen->Width = 1;

		System::Drawing::Pen^ redPen = gcnew Pen(Color::Red);
		redPen->Width = 4;

		g->DrawRectangle(redPen, Wcx, top, Wx, Wy);
		point min, max;
		min.x = left;
		min.y = top;
		max.x = System::Windows::Forms::Form::ClientRectangle.Width - right;
		max.y = System::Windows::Forms::Form::ClientRectangle.Height - bottom;

		System::Drawing::Font^ drawFont = gcnew System::Drawing::Font("Arial", 8);
		SolidBrush^ drawBrush = gcnew SolidBrush(Color::Black);

		min.x = min.x + 2;
		min.y = min.y + 2;
		max.x = max.x - 2;
		max.y = max.y - 2;
		for (int i = 0; i < polygons.Count; i++) {
			polygon^ p = polygons[i];
			polygon^ NewP = gcnew polygon(0);
			point a, b;
			vec A, B, A1, B1;
			for (int j = 0; j < p->Count; j++) {
				point2vec(p[j], A);
				timesMatVec(T, A, B);
				vec2point(B, a);
				NewP->Add(a);
			}
			
			NewP = Pclip(NewP, min, max);
			if (NewP->Count != 0) {
				a = NewP[NewP->Count - 1];
				for (int j = 0; j < NewP->Count; j++) {
					b = NewP[j];
					g->DrawLine(blackPen, a.x, a.y, b.x, b.y);
					a = NewP[j];
				}
			}
		}

	}

	private: System::Void btnOpen_Click(System::Object^  sender, System::EventArgs^  e) {
		if (this->openFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK) {
			wchar_t fileName[1024];
			for (int i = 0; i < openFileDialog->FileName->Length; i++)
				fileName[i] = openFileDialog->FileName[i];
			fileName[openFileDialog->FileName->Length] = '\0';

			std::ifstream in;
			in.open(fileName);
			if (in.is_open()) {
				lines.Clear();
				std::string str;
				getline(in, str);

				while (in) {
					if ((str.find_first_not_of(" \t\r\n") != std::string::npos) && (str[0] != '#')) {
						std::stringstream s(str);
						std::string cmd;
						s >> cmd;
						if (cmd == "frame") {
							float newVcx, newVcy, newVx, newVy;
							s >> newVcx >> newVcy >> newVx >> newVy;
							Vcx = newVcx;
							Vcy = newVcy;
							Vx = newVx;
							Vy = newVy;
							frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
						}
						else if (cmd == "polygon") {
							int numpoint;
							s >> numpoint;
							polygon^ P = gcnew polygon(0);
							for (int i = 0; i<numpoint; i++) {
								point p;
								s >> p.x >> p.y;
								P->Add(p);
							}
							polygons.Add(P);
						}
					}
					getline(in, str);
				}
			}
			frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
			this->Refresh();
		}
	}
	private: System::Void MyForm_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {

		int k = 0;
		MyForm^ form = gcnew MyForm;
		mat R, T1;
		mat CenterLine, CenterLine1, Ttansparent, Transparent1;
		
		switch (e->KeyCode) {
		        case Keys::S:
			        move(0, 1, R);
			        break;
			    case Keys::W:
				    move(0, -1, R);
				    break;
				case Keys::A:
					move(-1, 0, R);
					break;
				case Keys::D:
					move(1, 0, R);
					break;
				case Keys::Q:
					rotate(0.05, R);
					break;
				case Keys::E:
					rotate(-0.05, R);
					break;
				case Keys::Z:
					scale(1/1.1, R);
					break;
				case Keys::X:
					scale(1.1, R);
					break;
				case Keys::G:
					move(0, 10, R);
					break;
				case Keys::T:
					move(0, -10, R);
					break;
				case Keys::F:
					move(-10, 0, R);
					break;
				case Keys::H:
					move(10, 0, R);
					break;
				case Keys::U:
					mirrorOX(Form::ClientRectangle.Width,0, R);
					break;
				case Keys::J:
					mirrorOY(0, Form::ClientRectangle.Height-10, R);
					break;
				case Keys::Y:
				rotate(Form::ClientRectangle.Width / 2, Form::ClientRectangle.Height /2 ,0.05, R);
				break;
				case Keys::R:
					rotate(Form::ClientRectangle.Width / 2, Form::ClientRectangle.Height / 2, -0.05, R);
					break;
				case Keys::C:
					scale(1/1.1, Form::ClientRectangle.Width / 2, Form::ClientRectangle.Height / 2, R);
					break;
				case Keys::V:
					scale(1.1, Form::ClientRectangle.Width / 2, Form::ClientRectangle.Height / 2, R);
					break;
				case Keys::I:
					move(-float(Form::ClientRectangle.Width / 2), 0.f, CenterLine);
					move(float(Form::ClientRectangle.Width / 2), 0.f, CenterLine1);
					unit(R);
					scale(1 / 1.1, 1, Ttansparent);
					times(Ttansparent, CenterLine, Transparent1);
					times(CenterLine1, Transparent1, R);
					break;
				case Keys::O:
					move(-float(Form::ClientRectangle.Width / 2), 0.f, CenterLine);
					move(float(Form::ClientRectangle.Width / 2), 0.f, CenterLine1);
					unit(R);
					scale(1.1, 1, Ttansparent);
					times(Ttansparent, CenterLine, Transparent1);
					times(CenterLine1, Transparent1, R);
					break;
				case Keys::K:
					move(0.f, -float(Form::ClientRectangle.Height / 2), CenterLine);
					move(0.f, float(Form::ClientRectangle.Height / 2), CenterLine1);
					unit(R);
					scale(1, 1 / 1.1, Ttansparent);
					times(Ttansparent, CenterLine, Transparent1);
					times(CenterLine1, Transparent1, R);
					break;
				case Keys::L:
					move(0.f, -float(Form::ClientRectangle.Height / 2), CenterLine);
					move(0.f, float(Form::ClientRectangle.Height / 2), CenterLine1);
					unit(R);
					scale(1, 1.1 / 1, Ttansparent);
					times(Ttansparent, CenterLine, Transparent1);
					times(CenterLine1, Transparent1, R);
					break;
					break;
				case Keys::Escape:
					unit(T);
					unit(R);
					frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);

					break;
				case Keys::P:
					names =!names;
				default:
				 unit(R);
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
	times(R, T, T);

	unit(R);
	scale(Wx / oldWx, Wy / oldWy,R);
	times(R, T, T);

	move(Wcx, top, R);

	times(R, T, T);


	this->Refresh();

}
};
}
