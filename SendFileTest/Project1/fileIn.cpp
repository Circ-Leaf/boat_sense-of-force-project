#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main(void)
{
	while (1) {
		char ch;
		FILE* fp;
		fp = fopen("D:/�G���f�U�����i/�e�L�X�g�t�@�C��/PowerData.txt", "r");

		if (fp == NULL) {
			perror("�t�@�C���ǂݍ��ݎ��s\n");
			return 1;
		}

		printf("====�e�L�X�g�t�@�C���̓��e====\n");

		while ((ch = fgetc(fp)) != EOF) {
			
			printf("%c", ch);
		}

		fclose(fp);
	}

	return 0;
}