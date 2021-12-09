// See https://aka.ms/new-console-template for more information
var input = File.ReadAllText("./input.txt");

var lines = input.Split(Environment.NewLine).Select(i => int.Parse(i.Trim())).ToArray();
var count = 0;
var prevNum = lines[0];
for (int i = 1; i < lines.Length; i++)
{
    var line = lines[i];
    if (line > prevNum)
    {
        count++;
        
    }

    prevNum = line;
}

Console.WriteLine(count);

count = 0;
var prevSum = lines[0] + lines[1] + lines[2];

for (int i = 3; i < lines.Length; i++)
{
    var sum = lines[i] + lines[i - 1] + lines[i - 2];
    if (sum > prevSum)
    {
        count++;
    }

    prevSum = sum;
}

Console.WriteLine(count);