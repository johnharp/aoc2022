//string input = "../../../input-example.txt";
string input = "../../../input.txt";

string[] lines = File.ReadAllLines(input);
List<string> tailPositionLog = new List<string>();

// playfield --
// positive X to the right
// positive Y upward
// Head of rope starts at origin (0,0)
// Input is 2000 lines so we won't exceed an int


(int, int) head = (0, 0);
(int, int) tail = (0, 0);


foreach(var line in lines)
{
    HandleLine(line);
}

Console.WriteLine($"The tail visited {tailPositionLog.Distinct().Count()} " +
    $"unique positions");


void HandleLine(string line)
{
    string[] parts = line.Split();
    string dir = parts[0];
    int numsteps = int.Parse(parts[1]);

    (int, int) step = (0, 0);

    switch(dir)
    {
        case "R":
            step = (1, 0);
            break;
        case "L":
            step = (-1, 0);
            break;
        case "U":
            step = (0, 1);
            break;
        case "D":
            step = (0, -1);
            break;
        default:
            throw new Exception("Bad input");
    }

    // log the starting position of the tail
    tailPositionLog.Add(tail.ToString());

    for (int i = 0; i<numsteps; i++)
    {
        head = Move(head, step);
        tail = Follow(head, tail);
        tailPositionLog.Add(tail.ToString());

        Console.Out.WriteLine($"Head: {head}   Tail: {tail}");

    }
}

(int, int) Move((int, int) head, (int, int) step)
{
    return (head.Item1 + step.Item1, head.Item2 + step.Item2);
}

// Move the tail (if necessary) to keep it next to the head.
// If a tail move was made return true, else return false
(int, int) Follow((int, int) leader, (int, int) follower)
{
    (int, int) diff = (
        leader.Item1 - follower.Item1,
        leader.Item2 - follower.Item2);

    // "normalize" the x and y differences
    // for example, if x is off by +2, xnorm = +1
    // if y is off by -2, ynorm = -1
    // if y is off by 1, ynorm = 1
    (int, int) norm = (
        diff.Item1 == 0 ? 0 : diff.Item1 / int.Abs(diff.Item1),
        diff.Item2 == 0 ? 0 : diff.Item2 / int.Abs(diff.Item2)
        );

    // if they are touching, nothing to do
    if (int.Abs(diff.Item1) <= 1 &&
        int.Abs(diff.Item2) <= 1)
    {
        return follower;
    }

    // if they are not touching, take one step
    // toward the head.
    return (follower.Item1 + norm.Item1,
        follower.Item2 + norm.Item2);
}