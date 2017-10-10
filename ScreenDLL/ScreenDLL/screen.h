#pragma once
#include "evtek.h" 	
static int _serialPort;
static int _baudrate;
static int _address;
static int _showmode;
static int _showtime;
static int _showspeed;
HINSTANCE hInstance;
_ComShut ComShut;
_SendDatafun SendDatafun;

extern "C"  void setShowMode(int showmode);
extern "C"  void setShowTime(int showtime);
extern "C"  void setShowSpeed(int showspeed);
extern "C"  void initPort(int serialPort, int baudrate, int showmode, int showtime, int showspeed);
extern "C"  void openScreen(int address);
extern "C"  void closecreen(int address);
extern "C"  void sendText(int address, char* text);

extern "C"  void setShowMode(int showmode)
{
	_showmode = showmode;
}

extern "C"  void setShowSpeed(int showspeed)
{
	_showspeed = showspeed;
}

extern "C"  void setShowTime(int showtime)
{
	_showtime = showtime;
}

extern "C"  void initPort(int serialPort, int baudrate, int showmode, int showtime, int showspeed)
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

extern "C"  void openScreen(int address)
{
	ComShut(_serialPort, _baudrate, address, 1);
}

extern "C"  void closecreen(int address)
{
	ComShut(_serialPort, _baudrate, address, 0);
}

extern "C"  void sendText(int address, char* text)
{
	SendDatafun(_serialPort, _baudrate, address, text, 17,
		_showmode, _showtime, _showspeed);
}



