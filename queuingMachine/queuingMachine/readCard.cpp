//siwanghu 2017.8.25 v1.0
#include "readCard.h"
#include <iostream>

void readICCard(readCard * readcard)
{
	if (readcard->openDevice())
	{

		if (readcard->getICCardState(0xFF))
		{
			std::cout << "---------------------------" << std::endl;
			Sleep(2000);
			unsigned char idinfo[100];
			readcard->getICCard(1,NULL,(unsigned char *)"A",idinfo);
			if (idinfo != NULL)
				std::cout << idinfo;
			else
				std::cout << "读取失败";
		}
		else
		{
			std::cout << "模块加载失败" << std::endl;
		}
	}
	else
	{
		std::cout << "设备打开失败" << std::endl;
	}
}

void readIDCard(readCard * readcard)
{
	if (readcard->openDevice())
	{
		
		if (readcard->getIDcardState())
		{
			std::cout << "---------------------------"<<std::endl;
			Sleep(2000);
			if (readcard->getIDCardMediaState())
			{
				unsigned char* idinfo= readcard->getIDcard();
				if (idinfo != NULL)
					std::cout << idinfo;
				else
					std::cout << "读取失败";
			}
			else
			{
				std::cout << "请放置身份证" << std::endl;
			}
		}
		else
		{
			std::cout << "模块加载失败" << std::endl;
		}
	}
	else
	{
		std::cout << "设备打开失败" << std::endl;
	}
}

/*int main()
{
	readCard* readcard = new readCard();
	//readIDCard(readcard);
	readICCard(readcard);
	getchar();
}*/