// See https://aka.ms/new-console-template for more information

var s = new StreamReader("../../../input.txt");
var b = new Buffer(4);

while(!s.EndOfStream)
{
    char c = (char) s.Read();
    b.Add(c);
    if (b.IsMarker())
    {
        b.Print();
        Console.WriteLine($"Total read: {b.TotalCharsRead}");
        break;
    }
}



public class Buffer
{
    private int BufferSize = 0;
    private int TotalCharactersRead = 0;
    private List<Char> Chars;

    private Dictionary<Char, int> CharCounts;

    public Buffer(int size)
    {
        BufferSize = size;
        Chars = new List<Char>(size);
        CharCounts = new Dictionary<char, int>();
    }

    public int TotalCharsRead
    {
        get { return TotalCharactersRead;  }
    }

    public void Add(char c)
    {
        if (TotalCharactersRead >= BufferSize)
        {
            char toRemove = Chars[0];
            CharCounts[toRemove] -= 1;
            if (CharCounts[toRemove] == 0)
            {
                CharCounts.Remove(toRemove);
            }
            Chars.RemoveAt(0);
        }

        Chars.Add(c);
        TotalCharactersRead += 1;

        if (CharCounts.ContainsKey(c))
        {
            CharCounts[c] += 1;
        }
        else
        {
            CharCounts[c] = 1;
        }
    }

    public void Print()
    {
        for (int i = 0; i < BufferSize && i < TotalCharactersRead; i++)
        {
            Console.Write(Chars[i]);
        }
        Console.WriteLine();
    }

    public bool IsMarker()
    {
        if (TotalCharactersRead >= BufferSize &&
            CharCounts.Keys.Count == BufferSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}