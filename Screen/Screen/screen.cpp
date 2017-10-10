/***********************************************************
* 版本: V1.0
* 创建人：胡思旺
* 创建时间：2017年9月20日
* 版权所有:胡思旺
* 说明：未经作者同意不得用于商业用途
* 联系方式:siwanghu@hotmail.com
************************************************************/
#include "screen.h"

extern "C" _declspec(dllexport) void setShowMode(int showmode)
{
	_showmode = showmode;
}

extern "C" _declspec(dllexport) void setShowSpeed(int showspeed)
{
	_showspeed = showspeed;
}

extern "C" _declspec(dllexport) void setShowTime(int showtime)
{
	_showtime = showtime;
}

extern "C" _declspec(dllexport) void initPort(int serialPort, int baudrate, int showmode, int showtime, int showspeed)
{
	if ((hInstance = LoadLibrary(_T("dlltpzp.dll"))) != NULL)
	{
		SendDatafun = (_SendDatafun)GetProcAddress(hInstance, "SendDatafun");
		ComShut = (_ComShut)GetProcAddress(hInstance, "ComShut");
	}
	_serialPort = serialPort;
	_baudrate = baudrate;
	_showmode = showmode;
	_showtime = showtime;
	_showspeed = showspeed;
}

extern "C" _declspec(dllexport) void openScreen(int address)
{
	ComShut(_serialPort, _baudrate, address, 1);
}

extern "C" _declspec(dllexport) void closeScreen(int address)
{
	ComShut(_serialPort, _baudrate, address, 0);
}

extern "C" _declspec(dllexport) void sendText(int address, char* text)
{
	SendDatafun(_serialPort, _baudrate, address, text, 17,
		_showmode, _showtime, _showspeed);
}
