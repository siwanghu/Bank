//siwanghu 2017.8.25 v1.0
#pragma once
#include <iostream>
#include "synthesis.h"
#include <Windows.h>
#include <tchar.h>
#include <string.h>
class readCard
{
public:
	readCard();
	~readCard();
	bool openDevice();
	bool closeDevice();
	bool getIDcardState();
	bool getIDCardMediaState();
	bool icPoweroff(int);
	unsigned char* getIDcard();
	bool getICCardState(int);
	bool getICCardMediaState(int);
	bool getICCard(int, unsigned char*, unsigned char*, unsigned char*);
private:
	unsigned char* IDCard;
	HINSTANCE hInstance;
	_SS_OpenDevice SS_OpenDevice;
	_SS_CloseDevice SS_CloseDevice;
	_SS_ID_GetDevState SS_ID_GetDevState;
	_SS_ID_GetMediaState SS_ID_GetMediaState;
	_SS_ID_GetIdCardInfo SS_ID_GetIdCardInfo;
	_SS_ICC_PowerOn SS_ICC_PowerOn;
	_SS_ICC_GetICCInfo SS_ICC_GetICCInfo;
	_SS_ICC_GetDevState SS_ICC_GetDevState;
	_SS_ICC_GetMediaState SS_ICC_GetMediaState;
	_SS_ICC_PowerOff SS_ICC_PowerOff;
}; 

bool readCard::openDevice()
{
	if (0==SS_OpenDevice(USB, USB_BAUD, (unsigned char *)"261A0011"))
		return true;
	else
		return false;
}

bool readCard::closeDevice()
{
	if (0==SS_CloseDevice())
		return true;
	else
		return false;
}

bool readCard::getIDcardState()
{
	if (0==SS_ID_GetDevState())
		return true;
	else
		return false;
}

bool readCard::getIDCardMediaState()
{
	if (0==SS_ID_GetMediaState())
		return true;
	else
		return false;
}

bool readCard::getICCardState(int cardType)
{
	if (0==SS_ICC_GetDevState(cardType))
		return true;
	else
		return false;
}

bool readCard::icPoweroff(int cardtype)
{
	if (0 == SS_ICC_PowerOff(cardtype))
		return true;
	else
		return false;
}

bool readCard::getICCardMediaState(int cardType)
{
	//std::cout << SS_ICC_GetMediaState(cardType);
	if (0==SS_ICC_GetMediaState(cardType))
		return true;
	else
		return false;
}

unsigned char * readCard::getIDcard()
{
	if (1==SS_ID_GetIdCardInfo(IDCard, TIMEOUT))
		return IDCard;
	else
		return NULL;
}

bool readCard::getICCard(int cardType, unsigned char* AIDList, unsigned char* tagList, unsigned char* infoBuf)
{
	if (1==SS_ICC_GetICCInfo(cardType, AIDList, tagList, infoBuf))
		return true;
	else
		return false;
}

readCard::readCard()
{
	IDCard = (unsigned char *)malloc(IDCARDSIZE);
	if ((hInstance = LoadLibrary(_T("Comminterface.dll"))) != NULL)
	{
		SS_OpenDevice = (_SS_OpenDevice)GetProcAddress(hInstance, "SS_OpenDevice");
		SS_CloseDevice = (_SS_CloseDevice)GetProcAddress(hInstance, "SS_CloseDevice");
		SS_ID_GetDevState = (_SS_ID_GetDevState)GetProcAddress(hInstance, "SS_ID_GetDevState");
		SS_ID_GetMediaState = (_SS_ID_GetMediaState)GetProcAddress(hInstance, "SS_ID_GetMediaState");
		SS_ID_GetIdCardInfo = (_SS_ID_GetIdCardInfo)GetProcAddress(hInstance, "SS_ID_GetIdCardInfo");
		SS_ICC_PowerOn = (_SS_ICC_PowerOn)GetProcAddress(hInstance, "SS_ICC_PowerOn");
		SS_ICC_GetICCInfo = (_SS_ICC_GetICCInfo)GetProcAddress(hInstance, "SS_ICC_GetICCInfo");
		SS_ICC_GetDevState = (_SS_ICC_GetDevState)GetProcAddress(hInstance, "SS_ICC_GetDevState");
		SS_ICC_GetMediaState = (_SS_ICC_GetMediaState)GetProcAddress(hInstance, "SS_ICC_GetMediaState");
		SS_ICC_PowerOff = (_SS_ICC_PowerOff)GetProcAddress(hInstance, "SS_ICC_PowerOff");
	}
}

readCard::~readCard()
{
	free(IDCard);
}