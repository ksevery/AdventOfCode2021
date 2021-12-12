var input = File.ReadAllText("./input.txt");

var initialValues = input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();

var allFish = new List<int>(initialValues);

for (int i = 0; i < 80; i++)
{
    var newFish = new List<int>();
    for (int j = 0; j < allFish.Count; j++)
    {
        if (allFish[j] == 0)
        {
            allFish[j] = 6;
            newFish.Add(8);
        }
        else
        {
            allFish[j]--;
        }
    }

    allFish.AddRange(newFish);
}

Console.WriteLine(allFish.Count);

var fishDict = new Dictionary<int, long>()
{
    [0] = 0,
    [1] = 0,
    [2] = 0,
    [3] = 0,
    [4] = 0,
    [5] = 0,
    [6] = 0,
    [7] = 0,
    [8] = 0,
    [9] = 0
};

foreach (var fish in initialValues)
{
    fishDict[fish]++;
}

for (int i = 0; i < 256; i++)
{
    foreach (var fish in fishDict)
    {
        if (fish.Key == 0 && fish.Value > 0)
        {
            fishDict[9] += fish.Value;
            fishDict[7] += fish.Value;
            fishDict[0] = 0;
        }
        else
        {
            if (fish.Value > 0)
            {
                fishDict[fish.Key - 1] += fish.Value;
                fishDict[fish.Key] = 0;
            }
        }
    }
}

Console.WriteLine(fishDict.Values.Sum(v => Convert.ToInt64(v)));