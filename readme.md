Performance @ r = 100:
INC: 312
DEC: 30
ADD: 0
SUB: 100
SHF: 101
MUL: 101
CMP: 402

Performance @ r = 1000:
INC: 3120
DEC: 293
ADD: 0
SUB: 1000
SHF: 1001
MUL: 1001
CMP: 3999

INCDEC = (4.12 - sqrt(2)) * r;
SHIFTS = r + 1;
SUBCMP = 5 * r +- 1%;
MUL = r + 1;

bitwidth MUL = log2(r) * 2;


M1 Pro - 142 Million Y-values per second
10.414 Ops per Y-value

1479 MIPS M1 Pro Using C#
5441 MIPS using 7-Zip
72.8% Overhead (?!?!)

11.68 Million r=8 circles per second
121.64 MIPS equivalent
is this all C# overhead?