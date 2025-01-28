// cd "ComputerSystemDeepDive/C Compile/04 binary"

// # Binary File
// gcc -c main.c
// objdump -d main.o

// Result
//   0:   f3 0f 1e fa             endbr64 
//   4:   55                      push   %rbp
//   5:   48 89 e5                mov    %rsp,%rbp
//   8:   ba 00 00 00 00          mov    $0x0,%edx
//   d:   be 02 00 00 00          mov    $0x2,%esi
//  12:   48 8d 3d 00 00 00 00    lea    0x0(%rip),%rdi        # 19 <main+0x19>
//  19:   b8 00 00 00 00          mov    $0x0,%eax
//  1e:   e8 00 00 00 00          callq  23 <main+0x23>
//  23:   b8 00 00 00 00          mov    $0x0,%eax
//  28:   5d                      pop    %rbp
//  29:   c3                      retq   

#include <stdio.h>

int main() {
    printf("Hello, World!\n 1 + 1 = %d, 1>>1 = %d \n", 1+1, 1>>1 );
    return 0;
}