/***********************************************************
* 版本: V1.0
* 创建人：胡思旺
* 创建时间：2017年9月20日
* 版权所有:胡思旺
* 说明：未经作者同意不得用于商业用途
* 联系方式:siwanghu@hotmail.com
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



