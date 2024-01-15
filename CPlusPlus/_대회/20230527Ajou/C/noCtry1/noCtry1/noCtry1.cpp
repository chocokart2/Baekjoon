
// noCtry1.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <sstream>
#include <string.h>
using namespace std;

int main()
{
    // 변수 초기화
    int result = 0;

    string numCountString = "aaaaa aaaaa";
    string numberLine;
    string singleNumberString = "";
    int numCount = 0;
    int maxNumber = 0;
    int index = 0;
    int numIndex = 0;
    int startNumber = INT16_MIN; // 끝 숫자와 시작 숫자와 비교해야 합니다.
    bool isStartNumberInited = false;

    // 실행
    cin >> numCountString;
    stringstream ssInt(numCountString);
    ssInt >> numCount;

    cin >> numberLine;
    while (true)
    {
        std::cout << index << '\n';

        if (numberLine[index] != ' ' && numberLine[index] != '\0') // 현재 문자가 숫자인 경우
        {
            singleNumberString += numberLine[index];
        }
        else
        {
            int number;
            stringstream ssInt(singleNumberString);
            ssInt >> number;

            if (isStartNumberInited == false)
            {
                startNumber = number;
            }

            if (maxNumber > number) ++result;
            maxNumber = number;
            numIndex++;
        }

        if (numCount == numIndex)
        {
            std::cout << "break in index " << index << '\n';
            break;
        }
        ++index;
    }

    if (maxNumber > startNumber) ++result;

    std::cout << result;
    system("pause");
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
