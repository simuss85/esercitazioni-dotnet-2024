enum Color
{
    Red = 15,
    Green = 25,
    Blue = 35
}

class Test
{
    static void Main()
    {
        Console.WriteLine(StringFromColor(Color.Red));
        Console.WriteLine(StringFromColor(Color.Green));
        Console.WriteLine(StringFromColor(Color.Blue));
    }

    static string StringFromColor(Color c)
    {
        switch (c)
        {
            case Color.Red:
                return $"Red = {(int)c}";
            case Color.Green:
                return $"Green = {(int)c}";
            case Color.Blue:
                return $"Blue = {(int)c}";
            default:
                return "Invalid color";
        }
    }
}