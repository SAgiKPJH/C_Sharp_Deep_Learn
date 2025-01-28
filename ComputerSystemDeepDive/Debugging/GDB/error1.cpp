// cd "ComputerSystemDeepDive/Debugging/GDB"

// # Make out
// g++ -g error1.cpp -o error.out

#include <iostream>

void causeError() {
    int arr[5] = {0, 1, 2, 3, 4}; // 범위를 벗어난 인덱스 접근
    std::cout << arr[10] << std::endl; // 오류 발생

    int a;
    std::cout << a << std::endl; // 미할당 오류

    int* ptr = nullptr; // 널 포인터 역참조
    std::cout << *ptr << std::endl; // 오류 발생

    std::cout << 10/0 << std::endl; // 0으로 누나기 오류
}

int main() {
    std::cout << "디버깅을 시작합니다." << std::endl;
    causeError();
    return 0;
}