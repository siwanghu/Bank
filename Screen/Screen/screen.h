/***********************************************************
* �汾: V1.0
* �����ˣ���˼��
* ����ʱ�䣺2017��9��20��
* ��Ȩ����:��˼��
* ˵����δ������ͬ�ⲻ��������ҵ��;
* ��ϵ��ʽ:siwanghu@hotmail.com
************************************************************/
#pragma once
#include "evtek.h" 	
int _serialPort;
int _baudrate;
int _address;
int _showmode;
int _showtime;
int _showspeed;
HINSTANCE hInstance;
_ComShut ComShut;
_SendDatafun SendDatafun;
extern "C" _declspec(dllexport) void setShowMode(int showmode);
extern "C" _declspec(dllexport) void setShowTime(int showtime);
extern "C" _declspec(dllexport) void setShowSpeed(int showspeed);
extern "C" _declspec(dllexport) void initPort(int serialPort,int baudrate,int showmode,int showtime,int showspeed);
extern "C" _declspec(dllexport) void openScreen(int address);
extern "C" _declspec(dllexport) void closeScreen(int address);
extern "C" _declspec(dllexport) void sendText(int address,char* text);



