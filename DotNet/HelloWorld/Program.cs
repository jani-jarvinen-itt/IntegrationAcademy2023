// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int luku = 1234;
Console.WriteLine(luku);


luku++;
Console.WriteLine(luku);

int summa = laskeSumma(1, 2);
Console.WriteLine(summa);

// summa = laskeSumma(1);
// Console.WriteLine(summa);

int laskeSumma(int a, int b)
{
    return a + b;
}
