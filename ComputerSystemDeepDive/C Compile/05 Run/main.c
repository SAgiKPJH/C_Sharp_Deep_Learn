// cd "ComputerSystemDeepDive/C Compile/05 Run"

// # Run 32-bit
// gcc -m32 -S main.c > main.s
// gcc -m32 -c main.s > main.o
// objdump -d main.o
// gcc -m32 -o main main.o

// # Run
// ./main

#include <stdio.h>

int main() {
    printf("Hello, World!\n 1 + 1 = %d, 1>>1 = %d \n", 1+1, 1>>1 );
    return 0;
}