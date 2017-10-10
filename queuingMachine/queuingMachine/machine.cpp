//siwanghu 2017.8.18 v1.0
#include "screen.h"
#include <iostream>
#include "printer.h"
#include <time.h>
std::string number[100] = {
	"","first","second","third","fourth","fifth","sixth","seventh","eighth","ninth","tenth"
};

int main()
{
	int peopleID = 1,windowsID=1;
	bool flag = true;
	srand((unsigned)time(NULL));
	Print *print = new Print();
	print->openUsbPort();
	Screen* screen = new Screen();
	screen->setSerialNumber((_serialnumber)9);
	screen->setBaudrate((_baudrate)9600);
	screen->setAddress((_address)2);
	screen->setShowMode((_showmode)1);
	screen->setShowSpeed((_showspeed)2);
	screen->setShowTime((_showtime)1);
	ISpVoice * pVoice = NULL;
	if (FAILED(::CoInitialize(NULL)))
		return -1;
	HRESULT hr = CoCreateInstance(CLSID_SpVoice, NULL, CLSCTX_ALL,
		IID_ISpVoice, (void**)&pVoice);
	char printbuffer[100] = "请%d号客户取号";
	char chinesebuffer[100] = "请%d号客户到%d号窗口办理业务";
	char englishbuffer[100] = "Please customers on the %s to the %s window for business";
	while (flag)
	{
		if (SUCCEEDED(hr))
		{
			windowsID = rand() % 10 + 1;
			sprintf(printbuffer, "请%d号客户取号", peopleID);
			USES_CONVERSION;
			//hr = pVoice->Speak(A2W(printbuffer), 0, NULL);
			//print->print(true,"对内业务", peopleID,peopleID-1,true);
			//Sleep(6000);
			sprintf(chinesebuffer, "请 %d 号客户到 %d 号窗口办理业务", peopleID, windowsID);
			sprintf(englishbuffer, "Please customers on the %s to the %s window for business", number[peopleID].c_str(), number[windowsID].c_str());
			_content chineseContent = chinesebuffer, englishContent = englishbuffer;	
			screen->sendText(chineseContent);
			std::cout << chineseContent << std::endl;
			//hr = pVoice->Speak(A2W(chineseContent.c_str()), 0, NULL);
			screen->sendText(englishContent);
			std::cout << englishContent << std::endl;
			//hr = pVoice->Speak(A2W(englishContent.c_str()), 0, NULL);
			Sleep(3000);
			peopleID++;
			if (peopleID == 11)
				peopleID = 1;
		}
	}
	pVoice->Release();
	pVoice = NULL;
}