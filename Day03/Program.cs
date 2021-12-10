var input = File.ReadAllText("./input.txt");

var lines = input.Split(Environment.NewLine).Select(l => l.Trim()).ToArray();

var gammaRate = string.Empty;
var epsilonRate = string.Empty;

for (int i = 0; i < lines[0].Length; i++)
{
    var countZeroes = 0;
    var countOnes = 0;
    for (int j = 0; j < lines.Length; j++)
    {
        if (lines[j][i] == '0')
        {
            countZeroes++;
        }
        else if (lines[j][i] == '1')
        {
            countOnes++;
        }
    }

    if (countOnes > countZeroes)
    {
        gammaRate += '1';
        epsilonRate += '0';
    }
    else
    {
        gammaRate += '0';
        epsilonRate += '1';
    }
}

var gamma = Convert.ToInt32(gammaRate, 2);
var epsilon = Convert.ToInt32(epsilonRate, 2);

Console.WriteLine(gamma * epsilon);

var oxygenNums = lines.Where(l => l[0] == gammaRate[0]).ToArray();
var co2Nums = lines.Where((l) => l[0] == epsilonRate[0]).ToArray();

for (int i = 1; i < gammaRate.Length; i++)
{
    var countZeroes = 0;
    var countOnes = 0;
    if (oxygenNums.Length > 1)
    {
        for (int j = 0; j < oxygenNums.Length; j++)
        {
            if (oxygenNums[j][i] == '0')
            {
                countZeroes++;
            }
            else if (oxygenNums[j][i] == '1')
            {
                countOnes++;
            }
        }

        if (countZeroes > countOnes)
        {
            oxygenNums = oxygenNums.Where(l => l[i] == '0').ToArray();
        }
        else
        {
            oxygenNums = oxygenNums.Where(l => l[i] == '1').ToArray();
        }
    }
    
    countZeroes = 0;
    countOnes = 0;
    if (co2Nums.Length > 1)
    {
        for (int j = 0; j < co2Nums.Length; j++)
        {
            if (co2Nums[j][i] == '0')
            {
                countZeroes++;
            }
            else if (co2Nums[j][i] == '1')
            {
                countOnes++;
            }
        }

        if (countZeroes > countOnes)
        {
            co2Nums = co2Nums.Where((l) => l[i] == '1').ToArray();
        }
        else
        {
            co2Nums = co2Nums.Where((l) => l[i] == '0').ToArray();
        }
    }
}

var oxygenRating = Convert.ToInt32(oxygenNums.First(), 2);
var co2Rating = Convert.ToInt32(co2Nums.First(), 2);

Console.WriteLine(oxygenRating * co2Rating);
