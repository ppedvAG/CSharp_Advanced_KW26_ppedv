// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Summe(1, 2, 3, 4);

Summe(1, 2, 3);
Summe(1, 2);

Summe(1);


long Summe(int a, int b, int c = default, int d = default)
 => a + b + c + d;
