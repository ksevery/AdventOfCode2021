
public class Program
{
    public static void Main()
    {
        var input = File.ReadAllText("./input.txt");

        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var maxMatrixX = 0;
        var maxMatrixY = 0;

        var ventLines = new List<VentLine>();

        foreach (var line in lines)
        {
            var startEnd = line.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var startCoords = startEnd[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToArray();

            var endCoords = startEnd[1].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToArray();

            var newLine = new VentLine(startCoords[0], startCoords[1], endCoords[0], endCoords[1]);

            if (newLine.XStart > maxMatrixX)
            {
                maxMatrixX = newLine.XStart;
            }

            if (newLine.YStart > maxMatrixY)
            {
                maxMatrixY = newLine.YStart;
            }

            if (newLine.XEnd > maxMatrixX)
            {
                maxMatrixX = newLine.XEnd;
            }

            if (newLine.YEnd > maxMatrixY)
            {
                maxMatrixY = newLine.YEnd;
            }

            ventLines.Add(newLine);
        }

        var overlapCount = 0;

        var ventsMatrix = new int[maxMatrixY + 1, maxMatrixX + 1];

        foreach (var line in ventLines)
        {
            var maxX = line.XEnd;
            var minX = line.XStart;

            var maxY = line.YEnd;
            var minY = line.YStart;
            if (line.XStart > line.XEnd)
            {
                minX = line.XEnd;
                maxX = line.XStart;
            }

            if (line.YStart > line.YEnd)
            {
                minY = line.YEnd;
                maxY = line.YStart;
            }

            if (minX == maxX || minY == maxY)
            {
                for (int row = minY; row <= maxY; row++)
                {
                    for (int col = minX; col <= maxX; col++)
                    {
                        ventsMatrix[row, col]++;
                        if (ventsMatrix[row, col] == 2)
                        {
                            overlapCount++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(overlapCount);

        overlapCount = 0;

        ventsMatrix = new int[maxMatrixY + 1, maxMatrixX + 1];

        foreach (var line in ventLines)
        {
            var maxX = line.XEnd;
            var minX = line.XStart;

            var maxY = line.YEnd;
            var minY = line.YStart;
            if (line.XStart > line.XEnd)
            {
                minX = line.XEnd;
                maxX = line.XStart;
            }

            if (line.YStart > line.YEnd)
            {
                minY = line.YEnd;
                maxY = line.YStart;
            }

            if (minX == maxX || minY == maxY)
            {
                for (int row = minY; row <= maxY; row++)
                {
                    for (int col = minX; col <= maxX; col++)
                    {
                        ventsMatrix[row, col]++;
                        if (ventsMatrix[row, col] == 2)
                        {
                            overlapCount++;
                        }
                    }
                }
            }
            else
            {
                var currCol = line.XStart;
                for (int row = line.YStart; line.YStart > line.YEnd ? row >= line.YEnd : row <= line.YEnd;)
                {
                    ventsMatrix[row, currCol]++;
                    if (ventsMatrix[row, currCol] == 2)
                    {
                        overlapCount++;
                    }

                    if (line.XStart > line.XEnd)
                    {
                        currCol--;
                    }
                    else
                    {
                        currCol++;
                    }

                    if (line.YStart > line.YEnd)
                    {
                        row--;
                    }
                    else
                    {
                        row++;
                    }
                }
            }
        }

        Console.WriteLine(overlapCount);
    }
}

public record struct VentLine(int XStart, int YStart, int XEnd, int YEnd);



