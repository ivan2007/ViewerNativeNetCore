#include "pch.h"
#include <msclr\auto_gcroot.h>
#include "ViewerWpfInterop.h"

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Interop;

using namespace ViewerWpf;

class ViewerWpfManagedState
{
public:
	msclr::auto_gcroot<Window^> pWindow= nullptr;
	msclr::auto_gcroot <HostHelperWpf^> hostHelper = nullptr;
};

ViewerWpfInterop::ViewerWpfInterop()
{
	_upManagedState= std::make_unique<ViewerWpfManagedState>();
}

ViewerWpfInterop::~ViewerWpfInterop()
{
}

void ViewerWpfInterop::InitWpfWindowViewer(HWND hwnd, int width, int height)
{
	_upManagedState->hostHelper = gcnew HostHelperWpf();
	_upManagedState->hostHelper->InitWpfWindow(IntPtr(hwnd), gcnew String("WpfViewerHwndSourceClass"), width, height);
}

void ViewerWpfInterop::ResizeWpfWindowViewer(int width, int height)
{
	_upManagedState->hostHelper->ResizeWpfWindow(width, height);
}
