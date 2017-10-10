//siwanghu 2017.8.17 v1.0
#pragma once
typedef int(*_SetPrintport)(char[],int);
typedef int(*_SetUsbportauto)();
typedef int(*_SetClose)();
typedef int(*_SetClean)();
typedef int(*_SetSizetext)(int, int);
typedef int(*_SetAlignment)(int);
typedef int(*_PrintString)(char*);
typedef int(*_PrintFeedline)(int);
typedef int(*_PrintCutpaper)(int);
typedef int(*_GetStatus)();
typedef int(*_SetInit)();