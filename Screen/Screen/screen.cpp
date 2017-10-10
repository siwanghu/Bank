/***********************************************************
* �汾: V1.0
* �����ˣ���˼��
* ����ʱ�䣺2017��9��20��
* ��Ȩ����:��˼��
* ˵����δ������ͬ�ⲻ��������ҵ��;
* ��ϵ��ʽ:siwanghu@hotmail.com
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
