#include <stdio.h>
#include "screen.h"

int main()
{
	initPort(9,9600,1,1,3);
	sendText(2,"�й��Ƽ���ѧ");
	getchar();
}