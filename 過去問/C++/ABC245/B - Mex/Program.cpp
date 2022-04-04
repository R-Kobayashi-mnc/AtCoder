#include <iostream>
#include <vector>
#include <algorithm>
#include <sstream>
#include <functional>
#include <numeric>

//https://atcoder.jp/contests/abc245/tasks/abc245_b

using namespace std;


int main() {
	int cnt;

	cin >> cnt;

	vector<int> value(cnt);

	for (int i = 0; i < cnt; i++) {
		cin >> value[i];
	}

	//ソート(昇順)
	sort(value.begin(), value.end());
	//重複省く
	value.erase(unique(value.begin(), value.end()), value.end());

	for (int i = 0; i < value.size(); i++) {
		if (value[i] != i) {
			cout << i << endl;
			return 0;
		}
	}

	cout << value.size() << endl;
}