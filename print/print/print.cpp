#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>
#include <windows.h>
#include "ATLCONV.H"

int Print(char str[])
{
	HDC hdc;
	char *szDevice;
	char *szDriver;
	char *szOutput;
	DOCINFO docInfo;
	memset(&docInfo, 0, sizeof(DOCINFO));
	docInfo.cbSize = sizeof(DOCINFO);
	docInfo.lpszDocName = TEXT("测试");
	docInfo.lpszOutput = (LPTSTR)NULL;
	docInfo.fwType = 0;
	USES_CONVERSION;
	szDevice = ("USTC");
	szDriver = ("");
	szOutput = ("COM5");
	if (szDevice&&szDriver&&szOutput) 
	{
		if ((hdc = CreateDC(A2W(szDriver), A2W(szDevice), A2W(szOutput), NULL)) != 0) 
		{
			printf("%d\n",GetDeviceCaps(hdc, HORZRES));
			printf("%d\n", GetDeviceCaps(hdc, VERTRES));
			if (StartDoc(hdc, &docInfo)>0) 
			{
				StartPage(hdc); 
				SaveDC(hdc); 
				TextOut(hdc, 1, 1, A2W(str), strlen(str));
				RestoreDC(hdc, -1); 
				EndPage(hdc); 
				EndDoc(hdc); 
			}
			DeleteDC(hdc);
		}
		else
		{
			return 0;
		}
	}
	getchar();
	return 1;
}

int main(){
	char str[] = "中国科技大学";
	Print(str);
}

