string binary = Console.ReadLine();
List<int> numbers = new List<int>();

for (int i = 0; i < binary.Length; i++)
{
	numbers.Add(binary[i] - '0');
}

int decimalNumber = 0;
int power = 1;

for (int i = numbers.Count - 1; i >= 0; i--)
{
	decimalNumber += numbers[i] * power;
	power *= 2;
}

Console.WriteLine(decimalNumber);
