#include "stdafx.h"
#include "Transform.h"
#include "Clip.h"
#include "function.h"
#include <algorithm> 
#include <fstream>
#include <sstream>
#include "MyForm.h"


using namespace System;
using namespace System::Windows::Forms;


[STAThread]
void Main(array<String^>^ args)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	Graphics_3::MyForm form;
	Application::Run(%form);
}
