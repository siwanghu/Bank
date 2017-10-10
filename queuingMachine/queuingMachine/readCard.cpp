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
				std::cout << "��ȡʧ��";
		}
		else
		{
			std::cout << "ģ�����ʧ��" << std::endl;
		}
	}
	else
	{
		std::cout << "�豸��ʧ��" << std::endl;
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
					std::cout << "��ȡʧ��";
			}
			else
			{
				std::cout << "��������֤" << std::endl;
			}
		}
		else
		{
			std::cout << "ģ�����ʧ��" << std::endl;
		}
	}
	else
	{
		std::cout << "�豸��ʧ��" << std::endl;
	}
}

/*int main()
{
	readCard* readcard = new readCard();
	//readIDCard(readcard);
	readICCard(readcard);
	getchar();
}*/