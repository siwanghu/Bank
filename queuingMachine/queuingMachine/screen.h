//siwanghu 2017.8.8 v1.0
#pragma once
#include "evtek.h" 
#include "sapi.h"
#include <tchar.h>
#include "ATLCONV.H"
#pragma comment(lib, "ole32.lib")
#pragma comment(lib, "sapi.lib")
class Screen
{
public:
	Screen();
	~Screen();
	_serialnumber getSerialNumber();
	_baudrate getBaudrate();
	_address getAddress();
	_content getContent();
	_leafnumber getLeafNumber();
	_showmode getShowMode();
	_showtime getShowTime();
	_showspeed getShowSpeed();
	_wincolwidth getWincolWidth();
	_winno getWinNo();
	void sendText(_content content);
	void openScreen();
	void closeScreen();
	void setSerialNumber(_serialnumber);
	void setBaudrate(_baudrate);
	void setAddress(_address);
	void setContent(_content);
	void setLeafNumber(_leafnumber);
	void setShowMode(_showmode);
	void setShowTime(_showtime);
	void setShowSpeed(_showspeed);
	void setWincolWidth(_wincolwidth);
	void setWinNo(_winno);
private:
	HINSTANCE hInstance;
	_serialnumber serialnumber;
	_baudrate baudrate;
	_address address;
	_content content;
	_leafnumber leafnumber;
	_showmode showmode;
	_showtime showtime;
	_showspeed showspeed;
	_wincolwidth wincolwidth;
	_winno winno;
	_SendDatafun SendDatafun;
	_SendDatagen SendDatagen;
	_SendDatagen16c SendDatagen16c;
	_dataSend dataSend;
	_dataSendgen dataSendgen;
	_picSend picSend;
	_plainSend plainSend;
	_portOpen portOpen;
	_portClose portClose;
	_setWindowNo setWindowNo;
	_setWindowNogen setWindowNogen;
	_ComShut ComShut;
	_SendDataZHLine SendDataZHLine;
};

Screen::Screen()
{
	serialnumber=(_serialnumber)1;
	baudrate=(_baudrate)9600;
	address=(_address)1;
	content=(_content)"";
	leafnumber=(_leafnumber)1;
	showmode=(_showmode)1;
	showtime=(_showtime)1;
	showspeed=(_showspeed)3;
	wincolwidth=(_wincolwidth)16;
	winno=(_winno)12;
	if ((hInstance = LoadLibrary(_T("dlltpzp.dll"))) != NULL)
	{
		SendDatafun = (_SendDatafun)GetProcAddress(hInstance, "SendDatafun");
		SendDatagen = (_SendDatagen)GetProcAddress(hInstance, "SendDatagen");
		SendDatagen16c = (_SendDatagen16c)GetProcAddress(hInstance, "SendDatagen16c");
		dataSend = (_dataSend)GetProcAddress(hInstance, "dataSend");
		dataSendgen = (_dataSendgen)GetProcAddress(hInstance, "dataSendgen");
		picSend = (_picSend)GetProcAddress(hInstance, "picSend");
		plainSend = (_plainSend)GetProcAddress(hInstance, "plainSend");
		portOpen = (_portOpen)GetProcAddress(hInstance, "portOpen");
		portClose = (_portClose)GetProcAddress(hInstance, "portClose");
		setWindowNo = (_setWindowNo)GetProcAddress(hInstance, "setWindowNo");
		setWindowNogen = (_setWindowNogen)GetProcAddress(hInstance, "setWindowNogen");
		ComShut = (_ComShut)GetProcAddress(hInstance, "ComShut");
		SendDataZHLine = (_SendDataZHLine)GetProcAddress(hInstance, "SendDataZHLine");
	}
}

void Screen::sendText(_content content)
{
	SendDatafun(this->serialnumber,this->baudrate,this->address, (char*)content.c_str(), 17, 
		this->showmode,this->showtime,this->showspeed);
}

void Screen::openScreen()
{
	ComShut(this->serialnumber,this->baudrate,this->address, 1);
}

void Screen::closeScreen()
{
	ComShut(this->serialnumber, this->baudrate, this->address, 0);
}

void Screen::setSerialNumber(_serialnumber serialnumber)
{
	this->serialnumber = serialnumber;
}

void Screen::setBaudrate(_baudrate baudrate)
{
	this->baudrate = baudrate;
}

void Screen::setAddress(_address address)
{
	this->address = address;
}

void Screen::setContent(_content content)
{
	this->content = content;
}

void Screen::setLeafNumber(_leafnumber leafnumber)
{
	this->leafnumber = leafnumber;
}

void Screen::setShowMode(_showmode showmode)
{
	this->showmode = showmode;
}

void Screen::setShowTime(_showtime showtime)
{
	this->showtime = showtime;
}

void Screen::setShowSpeed(_showspeed showspeed)
{
	this->showspeed = showspeed;
}

void Screen::setWincolWidth(_wincolwidth wincolwidth)
{
	this->wincolwidth = wincolwidth;
}

void Screen::setWinNo(_winno winno)
{
	this->winno = winno;
}

_serialnumber Screen::getSerialNumber()
{
	return this->serialnumber;
}

_baudrate Screen::getBaudrate()
{
	return this->baudrate;
}

_address Screen::getAddress()
{
	return this->address;
}

_content Screen::getContent()
{
	return this->content;
}

_leafnumber Screen::getLeafNumber()
{
	return this->leafnumber;
}

_showmode Screen::getShowMode()
{
	return this->showmode;
}

_showtime Screen::getShowTime()
{
	return this->showtime;
}

_showspeed Screen::getShowSpeed()
{
	return this->showspeed;
}

_wincolwidth Screen::getWincolWidth()
{
	return this->wincolwidth;
}

_winno Screen::getWinNo()
{
	return this->winno;
}

Screen::~Screen()
{
	return;
}

