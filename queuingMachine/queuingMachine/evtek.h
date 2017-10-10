//siwanghu 2017.8.8 v1.0
#pragma once
#include<windows.h>
#include <string>
typedef int _serialnumber;
typedef int _baudrate;
typedef int _address;
typedef std::string _content;
typedef int _leafnumber;
typedef int _showmode;
typedef int _showtime;
typedef int _showspeed;
typedef int _wincolwidth;
typedef int _winno;
typedef int(_stdcall*_SendDatafun)(int, long, int, char[], int, int, int, int);
typedef int(_stdcall*_SendDatagen)(int, long, int, int, char[], int, int, int, int);
typedef int(_stdcall*_SendDatagen16c)(int, long, int, int, char[], int, int, int, int, int);
typedef int(_stdcall*_dataSend)(int, int, char[], int, int, int, int);
typedef int(_stdcall*_dataSendgen)(int, int, int, char[], int, int, int, int);
typedef int(_stdcall*_picSend)(int, int, int, char[], int);
typedef int(_stdcall*_plainSend)(int, int, int, byte[]);
typedef HANDLE(_stdcall*_portOpen)(char[], long, char, byte, byte);
typedef int(_stdcall*_portClose)(HANDLE);
typedef int(_stdcall*_setWindowNo)(int, int, int, int, char[]);
typedef int(_stdcall*_setWindowNogen)(int, int, int, int, int, char[]);
typedef int(_stdcall*_ComShut)(int, int, int, int);
typedef int(_stdcall*_SendDataZHLine)(int, long, int, char[], int);




