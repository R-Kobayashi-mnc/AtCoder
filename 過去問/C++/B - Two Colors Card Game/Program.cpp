#include <iostream>
#include <vector>
#include <algorithm>

/*
–â‘èURL
https://atcoder.jp/contests/abc091/tasks/abc091_b
*/


using namespace std;

int main()
{
	int blueCard;
	cin >> blueCard;

	vector<string> blueCardStr(blueCard);

	for (int i = 0; i < blueCard; i++) {
		cin >> blueCardStr.at(i);
	}

	int redCard;
	cin >> redCard;

	vector<string> redCardStr(redCard);

	for (int i = 0; i < redCard; i++) {
		cin >> redCardStr.at(i);
	}


	vector<int> blueCardStrCnt(blueCard, 1);

	for (int i = 0; i < blueCard; i++) {
		for (int j = 0; j < blueCard; j++) {
			if (i == j) continue;
			if (blueCardStr.at(i) == blueCardStr.at(j)) blueCardStrCnt.at(i)++;
		}
	}

	for (int i = 0; i < blueCard; i++) {
		for (int j = 0; j < redCard; j++) {
			if (blueCardStr.at(i) == redCardStr.at(j)) blueCardStrCnt.at(i)--;
		}
	}

	int max = *max_element(blueCardStrCnt.begin(), blueCardStrCnt.end());

	if (max < 0) max = 0;

	cout << max << endl;


	return 0;
}
