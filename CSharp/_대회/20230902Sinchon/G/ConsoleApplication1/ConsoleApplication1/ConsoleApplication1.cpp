// ConsoleApplication1.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//
#include <iostream>
#include <vector>
#include <algorithm>

template <typename T>
class Heap {
private:
    bool (*funcPtr)(T, T);
    std::vector<T> data;
    int count;

    const int NOT_FOUND = -1;

public:
    Heap(int size, bool (*function)(T, T))
        : data(size + 1), count(0) { funcPtr = function}

    void Push(T item) {
        ++count;
        data[count] = item;
        M_Heapify(count);
    }

    T Peek() {
        if (count < 1)
            return T();
        return data[count];
    }

    T Pop() {
        if (count < 1)
            return T();
        T result = data[1];
        data[1] = data[count];
        count--;
        M_Heapify(1);
        return result;
    }

private:
    void M_Swap(int leftIndex, int rightIndex) {
        T temp = data[leftIndex];
        data[leftIndex] = data[rightIndex];
        data[rightIndex] = temp;
    }

    void M_Heapify(int targetIndex) {
        for (int currentIndex = targetIndex, daughterIndex = M_FindDaughterIndex(targetIndex);
            daughterIndex != NOT_FOUND;
            currentIndex = daughterIndex, daughterIndex = M_FindDaughterIndex(daughterIndex)) {
            if (M_IsLeftPriority(data[currentIndex], data[daughterIndex]))
                break;
            M_Swap(currentIndex, daughterIndex);
        }
        for (int currentIndex = targetIndex, motherIndex = M_FindMotherIndex(targetIndex);
            motherIndex != NOT_FOUND;
            currentIndex = motherIndex, motherIndex = M_FindMotherIndex(motherIndex)) {
            if (M_IsLeftPriority(data[motherIndex], data[currentIndex]))
                break;
            M_Swap(motherIndex, currentIndex);
        }
    }

    int M_FindMotherIndex(int targetIndex) {
        return (targetIndex < 2) ? NOT_FOUND : targetIndex >> 1;
    }

    int M_FindDaughterIndex(int targetIndex) {
        int result = NOT_FOUND;
        if ((targetIndex << 1) > count)
            return result;
        result = (targetIndex << 1);
        if (result + 1 > count)
            return result;
        if (M_IsLeftPriority(data[result], data[result + 1]))
            return result;
        return result + 1;
    }

    bool M_IsLeftPriority(T left, T right) {
        return IsLeftGreaterThanOrEqualToRight(left, right);
    }
};

int main() {
    int count;
    std::cin >> count;

    std::vector<int> pCount(5);
    for (int index = 0; index < 5; ++index)
        std::cin >> pCount[index];

    auto comparitor = [](int a, int b) { return a - b; };
    Heap<int> problems[] = {}

    std::vector<Heap<int>> problems(5, new Heap<int>(count, comparitor));

    for (int i = 0; i < count; ++i) {
        int type, value;
        std::cin >> type >> value;
        problems[type - 1].Push(value);
    }

    int result = -60;
    int prevTime = 0;

    for (int level = 0; level < 5; ++level) {
        for (int solveCount = 0; solveCount < pCount[level]; ++solveCount) {
            int one = problems[level].Pop();

            if (solveCount == 0)
                result += 60;
            else
                result += one - prevTime;

            result += one;
            prevTime = one;
        }
    }

    std::cout << result << std::endl;

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
