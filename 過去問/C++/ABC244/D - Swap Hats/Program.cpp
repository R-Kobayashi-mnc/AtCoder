#include <iostream>
#include <vector>
#include <algorithm>
#include <sstream>
#include <functional>
#include <numeric>
#include <string>

using namespace std;

//https://atcoder.jp/contests/abc244/tasks/abc244_d


int findIndex(vector<string> s, string targetStr) {
	for (int i = 0; i < 3; i++) {
		if (s[i] == targetStr) {
			return i;
		}
	}
}

int main() {
	vector<string> s(3);
	vector<string> t(3);

	cin >> s[0] >> s[1] >> s[2];
	cin >> t[0] >> t[1] >> t[2];

	int top = findIndex(s, t[0]);



	string tmp;
	int cnt = 0;

	if (top != 0) {
		tmp = s[0];
		s[0] = t[0];
		s[top] = tmp;
		cnt++;
	}

	int mid = findIndex(s, t[1]);

	if (mid != 1) {
		tmp = s[1];
		s[1] = t[1];
		s[mid] = tmp;
		cnt++;
	}

	if (cnt == 1) cout << "No" << endl;
	else cout << "Yes" << endl;
}