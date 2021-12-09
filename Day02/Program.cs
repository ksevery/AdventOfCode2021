
public class Program
{
    public const string Forward = "forward";
    public const string Down = "down";
    public const string Up = "up";



    public static void Main()
    {
        var input = File.ReadAllText("./input.txt");

        var horizontalPos = 0;
        var depth = 0;

        var commandsStr = input.Split(Environment.NewLine).Select(x => x.Trim().Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        var commands = commandsStr.Select(cs => new Command(cs[0], int.Parse(cs[1])));

        foreach (var command in commands)
        {
            switch (command.Direction)
            {
                case Forward:
                    horizontalPos += command.HowMuch;
                    break;
                case Down:
                    depth += command.HowMuch;
                    break;
                case Up:
                    depth -= command.HowMuch;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(horizontalPos * depth);

        horizontalPos = 0;
        depth = 0;
        var aim = 0;

        foreach (var command in commands)
        {
            switch (command.Direction)
            {
                case Forward:
                    horizontalPos += command.HowMuch;
                    depth += aim * command.HowMuch;
                    break;
                case Down:
                    aim += command.HowMuch;
                    break;
                case Up:
                    aim -= command.HowMuch;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(horizontalPos * depth);
    }
}

public class Command
{
    public Command(string direction, int howMuch)
    {
        Direction = direction;
        HowMuch = howMuch;
    }

    public string Direction { get; }
    public int HowMuch { get; }
}



