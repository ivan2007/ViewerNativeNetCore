#pragma once
#include <windows.h>
#include <string>
#include <memory>

class ViewerWpfManagedState;

class __declspec(dllexport) ViewerWpfInterop
{
public:
	ViewerWpfInterop();
	~ViewerWpfInterop();

	virtual void InitWpfWindowViewer(HWND hwnd, int width, int height);
	virtual void ResizeWpfWindowViewer(int width, int height);

private:
#pragma warning(suppress: 4251)
	std::unique_ptr<ViewerWpfManagedState> _upManagedState = nullptr;
};
