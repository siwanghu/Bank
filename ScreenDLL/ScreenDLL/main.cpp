#include <stdio.h>
#include "screen.h"

int main()
{
	initPort(9,9600,1,1,3);
	sendText(2,"中国科技大学");
	getchar();
}