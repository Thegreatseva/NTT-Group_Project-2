string binary = Console.ReadLine();
int decimalNumber = 0;

foreach (char bit in binary)
{
	decimalNumber = decimalNumber * 2 + (bit - '0');
}

Console.WriteLine(decimalNumber);