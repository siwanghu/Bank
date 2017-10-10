//siwanghu 2017.8.25 v1.0
#pragma once
#define USB 1001
#define BLUETOOTH 0
#define USB_BAUD 0
#define BLUETOOTH_BAUD 1
#define IDCARDSIZE 100*1024
#define TIMEOUT 10
typedef int(_stdcall* _SS_OpenDevice)(int,int, unsigned char*);
typedef int(_stdcall* _SS_CloseDevice)();
typedef int(_stdcall* _SS_ID_GetDevState)();
typedef int(_stdcall* _SS_ID_GetMediaState)();
typedef int(_stdcall* _SS_ID_GetIdCardInfo)(unsigned char*,int);
typedef int(_stdcall* _SS_ICC_PowerOn)(int, char*, int);
typedef int(_stdcall* _SS_ICC_GetICCInfo)(int, unsigned char*, unsigned char*, unsigned char*);
typedef int(_stdcall* _SS_ICC_GetDevState)(int);
typedef int(_stdcall* _SS_ICC_GetMediaState)(int);
typedef int(_stdcall* _SS_ICC_PowerOff)(int);







