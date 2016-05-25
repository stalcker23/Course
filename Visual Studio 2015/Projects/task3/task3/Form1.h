#pragma once


namespace task3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// —водка дл€ Form1
	///
	/// ¬нимание! ѕри изменении имени этого класса необходимо также изменить
	///          свойство имени файла ресурсов ("Resource File Name") дл€ средства компил€ции управл€емого ресурса,
	///          св€занного со всеми файлами с расширением .resx, от которых зависит данный класс. ¬ противном случае,
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
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Collections::Generic::List<line> lines;
	private: float left, right, top, bottom, Wcx, Wcy, Wx, Wy, Vcx, Vcy, Vx, Vy;
	private: bool drawNames;
	private: System::Void DrawFigure(Graphics^ g, Pen^ blackPen) {
		g->DrawLine(blackPen, 4, 51, 8, 51);
		g->DrawLine(blackPen, 8, 51, 18, 47);
		g->DrawLine(blackPen, 18, 47, 22, 44);
		g->DrawLine(blackPen, 22, 44, 24, 37);
		g->DrawLine(blackPen, 24, 37, 22, 33);
		g->DrawLine(blackPen, 22, 33, 24, 33);
		g->DrawLine(blackPen, 24, 33, 24, 37);
		g->DrawLine(blackPen, 18, 47, 18, 50);
		g->DrawLine(blackPen, 18, 50, 24, 53);
		g->DrawLine(blackPen, 24, 53, 32, 47);
		g->DrawLine(blackPen, 32, 47, 32, 37);
		g->DrawLine(blackPen, 32, 37, 28, 31);
		g->DrawLine(blackPen, 28, 31, 18, 31);
		g->DrawLine(blackPen, 18, 31, 14, 40);
		g->DrawLine(blackPen, 14, 40, 8, 43);
		g->DrawLine(blackPen, 8, 43, 4, 49);
		g->DrawLine(blackPen, 4, 49, 4, 51);
		g->DrawLine(blackPen, 18, 31, 10, 29);
		g->DrawLine(blackPen, 10, 29, 8, 27);
		g->DrawLine(blackPen, 8, 27, 4, 21);
		g->DrawLine(blackPen, 4, 21, 4, 19);
		g->DrawLine(blackPen, 4, 19, 8, 13);
		g->DrawLine(blackPen, 8, 13, 12, 10);
		g->DrawLine(blackPen, 12, 10, 18, 9);
		g->DrawLine(blackPen, 18, 9, 26, 9);
		g->DrawLine(blackPen, 26, 9, 30, 10);
		g->DrawLine(blackPen, 30, 10, 32, 13);
		g->DrawLine(blackPen, 32, 13, 32, 14);
		g->DrawLine(blackPen, 32, 14, 30, 14);
		g->DrawLine(blackPen, 30, 16, 34, 16);
		g->DrawLine(blackPen, 34, 16, 34, 14);
		g->DrawLine(blackPen, 34, 14, 36, 13);
		g->DrawLine(blackPen, 36, 13, 38, 17);
		g->DrawLine(blackPen, 38, 17, 38, 23);
		g->DrawLine(blackPen, 38, 23, 36, 26);
		g->DrawLine(blackPen, 36, 26, 28, 31);
		g->DrawLine(blackPen, 18, 9, 16, 7);
		g->DrawLine(blackPen, 16, 7, 12, 6);
		g->DrawLine(blackPen, 12, 6, 12, 3);
		g->DrawLine(blackPen, 12, 3, 14, 1);
		g->DrawLine(blackPen, 14, 1, 20, 1);
		g->DrawLine(blackPen, 20, 1, 20, 6);
		g->DrawLine(blackPen, 20, 6, 22, 7);
		g->DrawLine(blackPen, 20, 1, 30, 1);
		g->DrawLine(blackPen, 30, 1, 32, 3);
		g->DrawLine(blackPen, 32, 3, 32, 6);
		g->DrawLine(blackPen, 32, 6, 28, 7);
		g->DrawLine(blackPen, 28, 7, 26, 9);
		g->DrawLine(blackPen, 8, 13, 4, 11);
		g->DrawLine(blackPen, 4, 11, 4, 9);
		g->DrawLine(blackPen, 4, 9, 6, 10);
		g->DrawLine(blackPen, 4, 9, 6, 7);
		g->DrawLine(blackPen, 6, 7, 8, 9);
		g->DrawLine(blackPen, 6, 7, 8, 7);
		g->DrawLine(blackPen, 8, 7, 12, 10);
		g->DrawLine(blackPen, 30, 10, 32, 7);
		g->DrawLine(blackPen, 32, 7, 34, 7);
		g->DrawLine(blackPen, 34, 7, 34, 9);
		g->DrawLine(blackPen, 34, 7, 38, 9);
		g->DrawLine(blackPen, 38, 9, 36, 10);
		g->DrawLine(blackPen, 38, 9, 38, 11);
		g->DrawLine(blackPen, 38, 11, 36, 13);
		g->DrawLine(blackPen, 8, 16, 10, 14);
		g->DrawLine(blackPen, 10, 14, 18, 14);
		g->DrawLine(blackPen, 18, 14, 22, 17);
		g->DrawLine(blackPen, 12, 14, 12, 11);
		g->DrawLine(blackPen, 12, 11, 16, 11);
		g->DrawLine(blackPen, 16, 11, 16, 14);
		g->DrawLine(blackPen, 14, 11, 14, 24);
		g->DrawLine(blackPen, 14, 24, 16, 26);
		g->DrawLine(blackPen, 16, 26, 16, 27);
		g->DrawLine(blackPen, 16, 27, 20, 27);
		g->DrawLine(blackPen, 20, 27, 22, 26);
		g->DrawLine(blackPen, 22, 26, 18, 26);
		g->DrawLine(blackPen, 18, 26, 16, 26);
		g->DrawLine(blackPen, 18, 26, 20, 24);
		g->DrawLine(blackPen, 20, 24, 20, 17);
		g->DrawLine(blackPen, 20, 17, 18, 16);
		g->DrawLine(blackPen, 18, 16, 16, 16);
		g->DrawLine(blackPen, 16, 16, 14, 17);
		g->DrawLine(blackPen, 14, 17, 16, 17);
		g->DrawLine(blackPen, 16, 17, 16, 20);
		g->DrawLine(blackPen, 16, 20, 12, 20);
		g->DrawLine(blackPen, 12, 20, 12, 17);
		g->DrawLine(blackPen, 12, 17, 14, 17);
		g->DrawLine(blackPen, 14, 17, 12, 16);
		g->DrawLine(blackPen, 12, 16, 16, 16);
		g->DrawLine(blackPen, 12, 16, 10, 16);
		g->DrawLine(blackPen, 10, 16, 8, 19);
		g->DrawLine(blackPen, 8, 19, 8, 23);
		g->DrawLine(blackPen, 8, 23, 10, 24);
		g->DrawLine(blackPen, 10, 24, 12, 24);
		g->DrawLine(blackPen, 12, 24, 14, 23);
		g->DrawLine(blackPen, 14, 26, 8, 26);
		g->DrawLine(blackPen, 8, 26, 8, 27);
		g->DrawLine(blackPen, 8, 27, 12, 27);
		g->DrawLine(blackPen, 12, 27, 14, 26);
		mat c;
	}
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
	private: System::Windows::Forms::Button^  btnOpen;
	private:
		/// <summary>
		/// “ребуетс€ переменна€ конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// ќб€зательный метод дл€ поддержки конструктора - не измен€йте
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
			this->openFileDialog->Filter = L"“екстовые файлы (*.txt)|*.txt|¬се файлы (*.*)|*.*";
			this->openFileDialog->Title = L"ќткрыть файл";
			// 
			// btnOpen
			// 
			this->btnOpen->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->btnOpen->Location = System::Drawing::Point(560, 613);
			this->btnOpen->Margin = System::Windows::Forms::Padding(3, 2, 3, 2);
			this->btnOpen->Name = L"btnOpen";
			this->btnOpen->Size = System::Drawing::Size(95, 28);
			this->btnOpen->TabIndex = 0;
			this->btnOpen->Text = L"ќткрыть";
			this->btnOpen->UseVisualStyleBackColor = true;
			this->btnOpen->Click += gcnew System::EventHandler(this, &Form1::btnOpen_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(672, 659);
			this->Controls->Add(this->btnOpen);
			this->DoubleBuffered = true;
			this->KeyPreview = true;
			this->Margin = System::Windows::Forms::Padding(3, 2, 3, 2);
			this->MinimumSize = System::Drawing::Size(400, 300);
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
		Wcx = left;
		Wcy = Form::ClientRectangle.Height - bottom;
		Wx = Form::ClientRectangle.Width - left - right;
		Wy = Form::ClientRectangle.Height - top - bottom;
		lines.Clear();
		unit(T);
	}
	private: System::Void Form1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
		Graphics^ g = e->Graphics;

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
			mat —;
			times(T, matrices[i], —);
			g->Transform = gcnew System::Drawing::Drawing2D::Matrix(—[0][0], —[1][0], —[0][1], —[1][1], —[0][2], —[1][2]);
			DrawFigure(g, blackPen);
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
				matrices.clear();
				std::stack<mat> matStack;
				mat K;
				unit(K);
				unit(T);
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
						else if (cmd == "figure") {
							matrices.push_back(K);
						}
						else if (cmd == "pushTransform") {
							matStack.push(K);
						}
						else if (cmd == "popTransform") {
							K = matStack.top();
							matStack.pop();
						}
						else if (cmd == "translate") {
							float Tx, Ty;
							s >> Tx >> Ty;
							mat C, C1;
							move(Tx, Ty, C);
							times(K, C, C1);
							K = C1;
						}
						else if (cmd == "scale") {
							float S;
							s >> S;
							mat C, C1;
							scale(S, S, C);
							times(K, C, C1);
							K = C1;
						}
						else if (cmd == "rotate") {
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
					getline(in, str);
				}
			}
			this->Refresh();
		}
	}
	private: System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
		Rectangle rect = Form::ClientRectangle;
		mat R, T1;
		switch (e->KeyCode) {
		case Keys::W:
			move(0, -1, R);
			break;
		case Keys::S:
			move(0, 1, R);
			break;
		case Keys::A:
			move(-1, 0, R);
			break;
		case Keys::D:
			move(1, 0, R);
			break;
		case Keys::E: //поворот по часовой стрелке
			rotate(0.05f, R);
			break;
		case Keys::Q: //поворот против часовой стрелке
			rotate(-0.05f, R);
			break;
		case Keys::X://увеличение относительно начала координат
			scale(1.1f, 1.1f, R);
			break;
		case Keys::Z://уменьшение относительно начала координат
			scale(1 / 1.1f, 1 / 1.1f, R);
			break;
		case Keys::T:
			move(0, -5, R);
			break;
		case Keys::G:
			move(0, 5, R);
			break;
		case Keys::F:
			move(-5, 0, R);
			break;
		case Keys::H:
			move(5, 0, R);
			break;
		case Keys::U: // зеркальное отображение относительно вертикальной оси
			reflectVert(R);
			times(R, T, T1);
			set(T1, T);
			move(rect.Width + 0.0f, 0.0f, R);
			break;
		case Keys::J:  // зеркальное отображение относительно горизонтальной оси
			reflectHoriz(R);
			times(R, T, T1);
			set(T1, T);
			move(0.0f, rect.Height + 0.0f, R);
			break;
		case Keys::Y: //поворот по часовой стрелки относительно центра окна
			move(-rect.Width / 2.0f, -rect.Height / 2.0f, R);
			times(R, T, T1);
			set(T1, T);
			rotate(-0.1f, R);
			times(R, T, T1);
			set(T1, T);
			move(rect.Width / 2.0f, rect.Height / 2.0f, R);
			break;
		case Keys::R: //поворот против часовой стрелки относительно центра окна
			move(-rect.Width / 2.0f, -rect.Height / 2.0f, R);
			times(R, T, T1);
			set(T1, T);
			rotate(0.1f, R);
			times(R, T, T1);
			set(T1, T);
			move(rect.Width / 2.0f, rect.Height / 2.0f, R);
			break;
		case Keys::C: //уменьшение в 1.1 раза относительно центра окна
			move(-rect.Width / 2.0f, -rect.Height / 2.0f, R);
			times(R, T, T1);
			scale(1 / 1.1f, 1 / 1.1f, R);
			times(R, T1, T);
			move(rect.Width / 2.0f, rect.Height / 2.0f, R);
			break;
		case Keys::V: //увеличение в 1.1 раза относительно центра окна
			move(-rect.Width / 2.0f, -rect.Height / 2.0f, R);
			times(R, T, T1);
			scale(1.1f, 1.1f, R);
			times(R, T1, T);
			move(rect.Width / 2.0f, rect.Height / 2.0f, R);
			break;
		case Keys::L: //увеличение в 1.1 раза по горизонтали
			move(-rect.Width / 2.0f, 0.0f, R);
			times(R, T, T1);
			scale(1.1f, 1, R);
			times(R, T1, T);
			move(rect.Width / 2.0f, 0.0f, R);
			break;
		case Keys::K: //уменьшение в 1.1 раза по горизонтали
			move(-rect.Width / 2.0f, 0.0f, R);
			times(R, T, T1);
			scale(1 / 1.1f, 1, R);
			times(R, T1, T);
			move(rect.Width / 2.0f, 0, R);
			break;
		case Keys::O: //увеличение в 1.1 раза по вертикали
			move(0.0f, -rect.Height / 2.0f, R);
			times(R, T, T1);
			scale(1.0f, 1.1f, R);
			times(R, T1, T);
			move(0.0f, rect.Height / 2.0f, R);
			break;
		case Keys::I: //уменьшение в 1.1 раза по горизонтали
			move(0.0f, -rect.Height / 2.0f, R);
			times(R, T, T1);
			scale(1.0f, 1 / 1.1f, R);
			times(R, T1, T);
			move(0.0f, rect.Height / 2.0f, R);
			break;
		case Keys::P:
			drawNames = !drawNames;
			unit(R);
			break;
		case Keys::Escape:
			unit(R);
			unit(T);
			frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
			break;

		default:
			unit(R);
		}
		times(R, T, T1);
		set(T1, T);
		this->Refresh();
	}

	private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
		float oldWx = Wx, oldWy = Wy;
		Wcx = left;
		Wcy = Form::ClientRectangle.Height - bottom;
		Wx = Form::ClientRectangle.Width - left - right;
		Wy = Form::ClientRectangle.Height - top - bottom;

		mat R, T1;
		move(-Wcx, -top, R);
		times(R, T, T);
		scale(Wx / oldWx, Wy / oldWy, R);
		times(R, T, T);
		move(Wcx, top, R);
		times(R, T, T);
		this->Refresh();

	}
	};
}

