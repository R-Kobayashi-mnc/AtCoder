#include <iostream>
#include <vector>
#include <algorithm>
#include <sstream>
#include <functional>
#include <numeric>
#include <string>

using namespace std;

int main() {
	int n;

	cin >> n;

	vector<int> val(2 * n + 1, 0);

	while (true) {

		for (int i = 0; i < val.size(); i++) {
			if (val[i] == 0) {
				cout << i + 1 << endl;
				val[i] = 1;
				break;
			}
		}

		int inputVal;
		cin >> inputVal;

		if (inputVal == 0) return 0;
		else val[inputVal - 1] = 1;
	}
}