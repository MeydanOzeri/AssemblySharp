# Supported Instructions

Data Transfer Instructions
-

- MOV: Moves data from one location to another.
- PUSH: Pushes a register or value onto the stack.
- POP: Pops a value from the stack into a register.

Arithmetic Instructions
-

- ADD: Adds two values.
- SUB: Subtracts one value from another.
- INC: Increments a value.
- DEC: Decrements a value.
- MUL: Multiplies two values.
- DIV: Divides one value by another.

Logical Instructions
-

- AND: Performs bitwise AND operation.
- OR: Performs bitwise OR operation.
- XOR: Performs bitwise XOR operation.
- NOT: Performs bitwise NOT operation.

Control Flow Instructions
-

- JMP: Jumps to another location in code.
- CALL: Calls a procedure or function.
- RET: Returns from a procedure or function.
- Conditional Jumps: Jumps based on specific conditions (e.g., JE, JNE, JG).

String and Set Instructions
-

- MOVS: Moves string data from one string to another.
- CMPS: Compares two strings.
- SCAS: Scans a string.

Miscellaneous Instructions
-

- NOP: No operation.
- LEA: Load effective address.

# Architecture

      +------------------+       +------------------+
      |   X86Instruction |<------+  X64Instruction  |
      +------------------+       +------------------+
               ^                           ^
               |                           |
       +-------+--------+          +-------+--------+
       | X86MovInstruction |          | X64MovInstruction |
       +------------------+          +------------------+
       | X86AddInstruction |          | X64AddInstruction |
       +------------------+          +------------------+
       // ... other instructions //  // ... other instructions //

      +----------------+       +----------------+
      |  X86Assembler  |       |  X64Assembler  |
      +----------------+       +----------------+

|
-

General Purpose Registers
AX (16 bits) - Accumulator Register
BX (16 bits) - Base Register
CX (16 bits) - Count Register
DX (16 bits) - Data Register
SI (16 bits) - Source Index
DI (16 bits) - Destination Index
SP (16 bits) - Stack Pointer
BP (16 bits) - Base Pointer
EAX (32 bits) - Extended AX
EBX (32 bits) - Extended BX
ECX (32 bits) - Extended CX
EDX (32 bits) - Extended DX
ESI (32 bits) - Extended SI
EDI (32 bits) - Extended DI
ESP (32 bits) - Extended SP
EBP (32 bits) - Extended BP
RAX (64 bits) - 64-bit Accumulator
RBX (64 bits) - 64-bit Base
RCX (64 bits) - 64-bit Counter
RDX (64 bits) - 64-bit Data
RSI (64 bits) - 64-bit Source Index
RDI (64 bits) - 64-bit Destination Index
RSP (64 bits) - 64-bit Stack Pointer
RBP (64 bits) - 64-bit Base Pointer
R8 to R15 (64 bits each) - Extended General Purpose Registers
Segment Registers (16 bits each)
CS - Code Segment
DS - Data Segment
SS - Stack Segment
ES - Extra Segment
FS - Additional Segment
GS - Another Segment
Floating Point Unit (FPU) Registers (80 bits each)
ST0 to ST7 - Floating Point Registers
MMX Registers (64 bits each)
MM0 to MM7 - Multimedia Extension Registers
XMM Registers (128 bits each)
XMM0 to XMM15 (in 64-bit mode, XMM16 to XMM31) - Streaming SIMD Extensions Registers
YMM Registers (256 bits each)
YMM0 to YMM15 (in 64-bit mode, YMM16 to YMM31) - AVX (Advanced Vector Extensions) Registers
ZMM Registers (512 bits each)
ZMM0 to ZMM31 - AVX-512 Extension Registers
Control Registers (32 or 64 bits)
CR0 to CR8 - Control Registers for Various Purposes
Debug Registers (32 or 64 bits)
DR0 to DR7 - Used for Hardware Debugging
Instruction Pointer
IP/EIP/RIP (16/32/64 bits) - Instruction Pointer
Flags Register
FLAGS/EFLAGS/RFLAGS (16/32/64 bits) - Processor Status and Control Flags
Model Specific Registers (MSR)
Various MSRs - Special Purpose Registers, Size Varies
Task Registers
TR - Task Register for Task Switching
Test Registers (Obsolete)
TR0 to TR7 - Used for Testing the MMU (Memory Management Unit)
Vector Registers (128/256/512 bits)
Vector Registers in AVX-512
Mask Registers (64 bits each)
K0 to K7 - AVX-512 Mask Registers
Conclusion
This list encompasses the majority of registers found in x86 and x64 architectures, including general-purpose registers, segment registers, system registers, and those used in SIMD (Single Instruction, Multiple Data) and floating-point operations. The sizes and types vary, reflecting the diverse functionalities these registers serve in different contexts.
