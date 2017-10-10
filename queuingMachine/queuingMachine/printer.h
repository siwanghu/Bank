//siwanghu 2017.8.17 v1.0
#pragma once
#include <stdio.h>
#include<windows.h>
#include <time.h>
#include <tchar.h>
#include <string.h>
#include "MSprint.h"
class Print
{
public:
	Print();
	~Print();
	bool openUsbPort();
	bool openSerialPort(char* Port,int iBaudrate);
	void closeSerialPort();
	void cutPaper();
	void printTest(char* Text);
	char* getPrintStatus();
	void print(bool welcome,char* business, int number,int queue,bool times);
private:
	int printInit;
	int printStatus;
	HINSTANCE hInstance;
	_SetPrintport setPrintport;
	_SetUsbportauto setUsbportauto;
	_SetClose setClose;
	_PrintCutpaper printCutpaper;
	_SetClean setClean;
	_SetSizetext setSizetext;
	_SetAlignment setAlignment;
	_PrintString printString;
	_PrintFeedline printFeedline;
	_GetStatus getStatus;
	_SetInit setInit;
};

Print::~Print(){}

Print::Print()
{
	int printInit = -1;
	int printStatus = -1;
	if ((hInstance = LoadLibrary(_T("MsprintsdkRM.dll"))) != NULL)
	{
		setPrintport = (_SetPrintport)GetProcAddress(hInstance, "SetPrintport");
		setUsbportauto = (_SetUsbportauto)GetProcAddress(hInstance, "SetUsbportauto");
		setClose = (_SetClose)GetProcAddress(hInstance, "SetClose");
		printCutpaper = (_PrintCutpaper)GetProcAddress(hInstance, "PrintCutpaper");
		setClean = (_SetClean)GetProcAddress(hInstance, "SetClean");
		setSizetext = (_SetSizetext)GetProcAddress(hInstance, "SetSizetext");
		setAlignment = (_SetAlignment)GetProcAddress(hInstance, "SetAlignment");
		printString = (_PrintString)GetProcAddress(hInstance, "PrintString");
		printFeedline = (_PrintFeedline)GetProcAddress(hInstance, "PrintFeedline");
		getStatus = (_GetStatus)GetProcAddress(hInstance, "GetStatus");
		setInit = (_SetInit)GetProcAddress(hInstance, "SetInit");
	}
}

bool Print::openSerialPort(char* Port, int iBaudrate)
{
	setPrintport(Port,iBaudrate);
	printInit = setInit();
	if (printInit == 0)
		return true;
	else
		return false;
}

bool Print::openUsbPort()
{
	setUsbportauto();
	printInit = setInit();
	if (printInit == 0)
		return true;
	else
		return false;
}

void Print::closeSerialPort()
{
	setClose();
}

void Print::cutPaper()
{
	printCutpaper(1);
}

void Print::printTest(char* Text)
{
	setClean();
	setSizetext(2, 2);
	setAlignment(1);
	printString(Text);
	printFeedline(20);
	printCutpaper(1);
	setClean();
}

char* Print::getPrintStatus()
{
	printStatus = getStatus();
	switch (printStatus)
	{
	case 0:
		return "��ӡ������";
	case 1:
		return "��ӡ��δ���ӻ�δ�ϵ�";
	case 2:
		return "��ӡ���͵��ÿⲻƥ��";
	case 3:
		return "��ӡͷ��";
	case 4:
		return "�е�δ��λ";
	case 5:
		return "��ӡͷ���� ";
	case 6:
		return "�ڱ����";
	case 7:
		return "ֽ��";
	case 8:
		return "ֽ����";
	default:
		return "�����쳣";
	}
}

void Print::print(bool welcome,char* business, int number,int queue,bool times)
{
	setClean();
	setAlignment(1);
	if (welcome) 
	{
		setSizetext(3, 3);
		char* head = "��ӭ����";
		printString(head);
		printFeedline(1);
	}
	setSizetext(2, 2);
	printString(business);
	printFeedline(1);
	if (number != NULL) 
	{
		setSizetext(3, 3);
		char num[20] = { NULL };
		printString(strcat(_itoa(number, num, 10), "��"));
		printFeedline(1);
	}
	if (queue != NULL)
	{
		setSizetext(1, 1);
		char txt[20] = "��ǰ�滹��";
		char num[20] = {};
		printString(strcat(txt,strcat(_itoa(queue, num, 10), "��")));
		printFeedline(1);
	}
	if (times)
	{
		setAlignment(0);
		setSizetext(1, 1);
		SYSTEMTIME sys;
		GetLocalTime(&sys);
		char time[64] = { NULL };
		sprintf(time, "%4d-%02d-%02d %02d:%02d", sys.wYear, sys.wMonth, sys.wDay, sys.wHour, sys.wMinute);
		printString(time);
		printFeedline(5);
	}
	printCutpaper(0);
	setClean();
}