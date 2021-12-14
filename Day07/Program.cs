var input = File.ReadAllText("./input.txt");

var positions = input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim()));

var minFuel = positions.Min();
var maxFuel = positions.Max();

var minFuelSum = int.MaxValue;

for (int i = minFuel; i < maxFuel; i++)
{
    var currFuelSum = 0;
    foreach (var pos in positions)
    {
        currFuelSum += Math.Abs(pos - i);
    }

    if (currFuelSum < minFuelSum)
    {
        minFuelSum = currFuelSum;
    }
}

Console.WriteLine(minFuelSum);

minFuelSum = int.MaxValue;

for (int i = minFuel; i < maxFuel; i++)
{
    var currFuelSum = 0;
    foreach (var pos in positions)
    {
        var totalFuelForMove = 0;
        var fuelConsumptionIndex = 1;
        var currPos = pos;
        while (currPos != i)
        {
            totalFuelForMove += fuelConsumptionIndex;
            fuelConsumptionIndex++;
            if (currPos < i)
            {
                currPos = currPos + 1;
            }
            else
            {
                currPos = currPos - 1;
            }
        }

        currFuelSum += totalFuelForMove;
    }

    if (currFuelSum < minFuelSum)
    {
        minFuelSum = currFuelSum;
    }
}

Console.WriteLine(minFuelSum);