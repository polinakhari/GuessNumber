using GuessNumber.Interfaces;

namespace GuessNumber.Implementations;

public class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _random = new ();
    public int GenerateNumber(int lower, int upper)
    {
        return _random.Next(lower, upper + 1);
    }
}