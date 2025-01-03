// cd "ComputerSystemDeepDive/05 Run"

// # Run 32-bit
// gcc -m32 -S main.c > main.s
// gcc -m32 -c simple main.s
// gcc -m32 -o simple main.o
// # Run
// ./example

#include <stdio.h>

int main() {
    printf("Hello, World!\n 1 + 1 = %d, 1>>1 = %d \n", 1+1, 1>>1 );
    return 0;
}