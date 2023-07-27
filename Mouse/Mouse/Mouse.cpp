#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <windows.h>
#include <math.h>
#include "SpidarMouse.h"//SpidarMouseのヘッドを読み込む
#pragma comment(lib, "SpidarMouse.lib") //SpidarMouseのライブラリを読み込む
const float PI = 3.1415926;// πの定数を定義しておく


int main(void) {
	// SPIDAR-mouseの接続確認
	if (OpenSpidarMouse() != 1)
	{
		printf("SPIDAR-mouseの接続が確認できませんでした。\n");
		return -1;
	}
	//SetForce(0.5, 0.0, 1000);

	// 力覚提示
	for (int i = 0; i < 360 * 3; i++)
	{
		// ループカウンタ[i]を元に実数[theta]を計算する。
		float theta = PI * i / 180.0;

		// 実数[theta]をsinとcosのパラメータとして、力の方向を決定する。(シータの方向に動く、x,yのsincosに数値をかければ力の大きさも制御可能
		// それからその力を10[msec]持続するようにパラメータを与える。
		SetForce(sin(theta), cos(theta), 10);

		// sleepさせて時間を稼ぐ
		Sleep(5);
	}

	/*while (1) {
		char ch;
		FILE* fp;
		fp = fopen("D:/エレデザ完成品/テキストファイル/PowerData.txt", "r");

		if (fp == NULL) {
			perror("ファイル読み込み失敗!\n");
			return 1;
		}

		printf("====テキストファイルの内容====\n");

		while ((ch = fgetc(fp)) != EOF) {
			printf("%c", ch);
		}

		fclose(fp);
	}*/

	// SPIDAR-mouseの終了
	CloseSpidarMouse();

	return 0;
}