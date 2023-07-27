#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main(void)
{
	while (1) {
		char ch;
		FILE* fp;
		fp = fopen("D:/エレデザ完成品/テキストファイル/PowerData.txt", "r");

		if (fp == NULL) {
			perror("ファイル読み込み失敗\n");
			return 1;
		}

		printf("====テキストファイルの内容====\n");

		while ((ch = fgetc(fp)) != EOF) {
			
			printf("%c", ch);
		}

		fclose(fp);
	}

	return 0;
}