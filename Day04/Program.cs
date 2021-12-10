var input = File.ReadAllText("./input.txt");

var lines = input.Split(Environment.NewLine);

var nums = lines[0].Split(",").Select(x => int.Parse(x.Trim()));

var bingoBoards = new List<int[][]>();

for (int i = 6; i < lines.Length; i += 6)
{
    var board = lines[(i - 4)..(i+1)].Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray()).ToArray();

    bingoBoards.Add(board);
}

int[][]? winnerBoard = null;
var winNum = -1;

foreach (var num in nums)
{
    foreach (var board in bingoBoards)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == num)
                {
                    board[row][col] = -1;
                }
            }
        }

        for (int row = 0; row < board.GetLength(0); row++)
        {
            var isColFull = true;
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[col][row] != -1)
                {
                    isColFull = false;
                    break;
                }
            }

            if (board[row][0..5].All(n => n == -1) || isColFull)
            {
                winnerBoard = board;
                winNum = num;
                break;
            }
        }

        if (winnerBoard != null && winNum != -1)
        {
            break;
        }
    }

    if (winnerBoard != null && winNum != -1)
    {
        break;
    }
}

var sum = 0;

if (winnerBoard != null)
{
    for (int row = 0; row < winnerBoard.GetLength(0); row++)
    {
        var currSum = winnerBoard[row].Where(n => n != -1).Sum();
        sum += currSum;
    }
}

Console.WriteLine(sum * winNum);

bingoBoards = new List<int[][]>();

for (int i = 6; i < lines.Length; i += 6)
{
    var board = lines[(i - 4)..(i + 1)].Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray()).ToArray();

    bingoBoards.Add(board);
}

winnerBoard = null;
winNum = -1;
var wonBingoBoardIndexes = new List<int>();

foreach (var num in nums)
{
    for (var i = 0; i < bingoBoards.Count; i++)
    {
        var board = bingoBoards[i];
        if (!wonBingoBoardIndexes.Contains(i))
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == num)
                    {
                        board[row][col] = -1;
                    }
                }
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                var isColFull = true;
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[col][row] != -1)
                    {
                        isColFull = false;
                        break;
                    }
                }

                if (board[row][0..5].All(n => n == -1) || isColFull)
                {
                    winnerBoard = board;
                    winNum = num;
                    wonBingoBoardIndexes.Add(i);
                }
            }
        }
    }
}

sum = 0;

if (winnerBoard != null)
{
    for (int row = 0; row < winnerBoard.GetLength(0); row++)
    {
        var currSum = winnerBoard[row].Where(n => n != -1).Sum();
        sum += currSum;
    }
}

Console.WriteLine(sum * winNum);
