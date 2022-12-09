//string input = "../../../input-example.txt";
string input = "../../../input.txt";

string[] lines = File.ReadAllLines(input);
List<string> taillog = new List<string>();

// playfield --
// positive X to the right
// positive Y upward
// Head of rope starts at origin (0,0)
// Input is 2000 lines so we won't exceed an int


int headx = 0;
int heady = 0;

int tailx = 0;
int taily = 0;

foreach(var line in lines)
{
    HandleLine(line);
}
SummarizeTailLog();



void HandleLine(string line)
{
    string[] parts = line.Split();
    string dir = parts[0];
    int numsteps = int.Parse(parts[1]);

    int xstep = 0;
    int ystep = 0;

    switch(dir)
    {
        case "R":
            xstep = 1;
            break;
        case "L":
            xstep = -1;
            break;
        case "U":
            ystep = 1;
            break;
        case "D":
            ystep = -1;
            break;
        default:
            throw new Exception("Bad input");
    }

    // log the starting position of the tail
    LogTailPosition();

    for (int i = 0; i<numsteps; i++)
    {
        Move(xstep, ystep);
        if (Follow())
        {
            LogTailPosition();
        }
        //Console.Out.WriteLine($"Head: x={headx}  y={heady}");
        //Console.Out.WriteLine($"Tail: x={tailx}  y={taily}");

    }
}

void Move(int deltax, int deltay)
{
    headx += deltax;
    heady += deltay;
}

// Move the tail (if necessary) to keep it next to the head.
// If a tail move was made return true, else return false
bool Follow()
{
    int xdiff = headx - tailx;
    int ydiff = heady - taily;

    // "normalize" the x and y differences
    // for example, if x is off by +2, xnorm = +1
    // if y is off by -2, ynorm = -1
    // if y is off by 1, ynorm = 1
    int xnorm = xdiff == 0 ? 0 : xdiff / int.Abs(xdiff);
    int ynorm = ydiff == 0 ? 0 : ydiff / int.Abs(ydiff);

    // if they are touching, nothing to do
    if (int.Abs(xdiff) <= 1 &&
        int.Abs(ydiff) <= 1)
    {
        return false;
    }

    // if they are not touching, take one step
    // toward the head.  If 
    // 
    tailx += xnorm;
    taily += ynorm;

    return true;
}

void LogTailPosition()
{
    string s = $"{tailx},{taily}";
    taillog.Add(s);
}

void SummarizeTailLog()
{
    var uniqueTailePositions = taillog.Distinct();
    Console.WriteLine($"The tail visited {uniqueTailePositions.Count()} " +
        $"unique positions");
}