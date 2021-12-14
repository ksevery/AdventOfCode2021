var input = File.ReadAllText("./input.txt");

var entries = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var validSymbolCounts = new HashSet<int>()
{
    2, 3, 4, 7
};

var outputValues = entries.Select(e => e.Split("|", StringSplitOptions.RemoveEmptyEntries)[1]);

var validSum = 0;

foreach (var ov in outputValues)
{
    var combosCount = ov.Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(c => validSymbolCounts.Contains(c.Length)).Count();
    validSum += combosCount;
}

Console.WriteLine(validSum);