#pragma once
int levenshtein_r(
	int lx,           // ����� ������ x 
	const char x[],   // ������ ������ lx
	int ly,           // ����� ������ y
	const char y[]    // ������ y
);

int levenshtein(
	int lx,           // ����� ����� x 
	const char x[],   // ����� ������ lx
	int ly,           // ����� ����� y
	const char y[]    // ����� y
);
