#include <stdio.h>
#include <windows.h>
#include <math.h>
#include "SpidarMouse.h"//SpidarMouse�̃w�b�h��ǂݍ���
#pragma comment(lib, "SpidarMouse.lib") //SpidarMouse�̃��C�u������ǂݍ���
const float PI = 3.1415926;// �΂̒萔���`���Ă���


int main(void) {

	int theta = 0;
	float Power = 0;    

	// SPIDAR-mouse�̐ڑ��m�F
	if (OpenSpidarMouse() != 1)
	{
		printf("SPIDAR-mouse�̐ڑ����m�F�ł��܂���ł����B\n");
		return -1;
	}


	//�I�[���̎�����������ʒu�Ɉړ�(�v�����j
	SetForce(1, 0, 10);

	// �͊o��
	while (1)
	{
		//�����v���
		for (theta = 270; theta < -90; theta--)
		{
			//C#����l�iPower�j���擾
			

			//SetForce(x����,Y����,�p������)
			SetForce(Power * sin(theta), Power * cos(theta), 10);

		}
	}

	// SPIDAR-mouse�̏I��
	CloseSpidarMouse();

	return 0;
}