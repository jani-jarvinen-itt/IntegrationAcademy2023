Console.WriteLine("Syötä ensimmäinen luku:");
string luku1 = Console.ReadLine() ?? "0";

Console.WriteLine("Syötä toinen luku:");
string luku2 = Console.ReadLine() ?? "0";

int summa = int.Parse(luku1) + int.Parse(luku2);
Console.WriteLine("Summa on: " + summa);
