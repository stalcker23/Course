#include "stdafx.h"
#include <fstream>
#include <sstream>
#include <array>
#include <vector>
#include <stack>
#include "Transform.h"
#include "Clip.h"
#include "Form1.h"
using std::ofstream;
using std::ifstream;
using std::fstream;

using std::ios;
using std::string;

using namespace System;
using namespace System::Windows::Forms;


[STAThread]
void Main(array<String^>^ args)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	task3::Form1 form;
	Application::Run(%form);
}
