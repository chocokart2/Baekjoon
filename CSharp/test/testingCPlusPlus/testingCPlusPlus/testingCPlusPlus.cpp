// testingCPlusPlus.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#define INF 1e9 
using namespace std;

int N, END;
int cost[16][16];
int dp[16][1 << 16];

int TSP(int now, int visited) {
	// 모든 노드를 방문했는데 
	if (visited == END) {
		// 현재 노드에서 0번으로 가는 경로가 있으면 
		if (cost[now][0] > 0) {
			return cost[now][0]; // 최소 비용 반환 
		}

		return INF; // 불가능한 경우에는 INF 반환 
	}

	// 현재 상태를 이미 계산한 값이 dp 테이블에 있다면 그대로 사용
	if (dp[now][visited] != 0) return dp[now][visited];

	// 없으면 현재 노드에 대한 탐색 진행 
	dp[now][visited] = INF;

	for (int i = 0; i < N; i++) {
		// 현재 노드에서 i번 노드로 가는 경로가 없으면 패스
		if (cost[now][i] == 0) continue;

		// 이미 방문한 노드면 패스 
		if (visited & (1 << i)) continue;

		// i번 노드 방문 처리 후 최소 비용 반환 
		int temp = TSP(i, visited | 1 << i);
		dp[now][visited] = min(dp[now][visited], cost[now][i] + temp);
	}

	return dp[now][visited]; // 최소 비용 반환 
}

int main()
{
	ios::sync_with_stdio(0);
	cin.tie(0);

	cin >> N;
	END = (1 << N) - 1;

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++) {
			cin >> cost[i][j];
		}
	}

	// 0번 노드부터 그래프 탐색 
	cout << TSP(0, 1) << "\n";
	int aaa = 0;
	cin >> aaa;
	return 0;
}

// 프로그램 실행: <Ctrl+F5> 또는 [디버그] > [디버깅하지 않고 시작] 메뉴
// 프로그램 디버그: <F5> 키 또는 [디버그] > [디버깅 시작] 메뉴

// 시작을 위한 팁: 
//   1. [솔루션 탐색기] 창을 사용하여 파일을 추가/관리합니다.
//   2. [팀 탐색기] 창을 사용하여 소스 제어에 연결합니다.
//   3. [출력] 창을 사용하여 빌드 출력 및 기타 메시지를 확인합니다.
//   4. [오류 목록] 창을 사용하여 오류를 봅니다.
//   5. [프로젝트] > [새 항목 추가]로 이동하여 새 코드 파일을 만들거나, [프로젝트] > [기존 항목 추가]로 이동하여 기존 코드 파일을 프로젝트에 추가합니다.
//   6. 나중에 이 프로젝트를 다시 열려면 [파일] > [열기] > [프로젝트]로 이동하고 .sln 파일을 선택합니다.
