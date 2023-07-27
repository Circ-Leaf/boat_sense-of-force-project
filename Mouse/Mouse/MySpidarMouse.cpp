#include <stdio.h>
#include <windows.h>
#include <math.h>
#include "SpidarMouse.h"//SpidarMouseのヘッドを読み込む
#pragma comment(lib, "SpidarMouse.lib") //SpidarMouseのライブラリを読み込む
const float PI = 3.1415926;// πの定数を定義しておく


int main(void) {

	int theta = 0;
	float Power = 0;    

	// SPIDAR-mouseの接続確認
	if (OpenSpidarMouse() != 1)
	{
		printf("SPIDAR-mouseの接続が確認できませんでした。\n");
		return -1;
	}


	//オールの持ち手を初期位置に移動(要調整）
	SetForce(1, 0, 10);

	// 力覚提示
	while (1)
	{
		//反時計回り
		for (theta = 270; theta < -90; theta--)
		{
			//C#から値（Power）を取得
			

			//SetForce(x方向,Y方向,継続時間)
			SetForce(Power * sin(theta), Power * cos(theta), 10);

		}
	}

	// SPIDAR-mouseの終了
	CloseSpidarMouse();

	return 0;
}