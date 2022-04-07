#include <iostream>
#include <vector>
#include <algorithm>
#include <sstream>
#include <functional>
#include <numeric>

//https://atcoder.jp/contests/abc245/tasks/abc245_c

using namespace std;

int main() {
	int n, k;

	cin >> n >> k;

	vector<int> a(n);
	for (int i = 0; i < n; i++) {
		cin >> a[i];
	}

	vector<int> b(n);
	for (int i = 0; i < n; i++) {
		cin >> b[i];
	}

	bool isA = false;
	bool isB = false;
	bool isBeforeA = true;
	bool isBeforeB = true;

	for (int i = n - 1; i > 0; i--) {
		isA = false;
		isB = false;

		if ((isBeforeA && abs(a[i - 1] - a[i]) <= k) || (isBeforeB && abs(a[i - 1] - b[i]) <= k)) isA = true;

		if ((isBeforeA && abs(b[i - 1] - a[i]) <= k) || (isBeforeB && abs(b[i - 1] - b[i]) <= k)) isB = true;

		if (!isA && !isB) {
			cout << "No" << endl;
			return 0;
		}

		isBeforeA = isA;
		isBeforeB = isB;
	}

	cout << "Yes" << endl;
}