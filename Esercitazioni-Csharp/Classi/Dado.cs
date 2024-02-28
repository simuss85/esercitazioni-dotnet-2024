class Dado
{
    private Random random = new();

    public int Lancia()
    {
        return random.Next(1, 7);
    }
}