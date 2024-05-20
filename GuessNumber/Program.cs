using GuessNumber.Implementations;
using GuessNumber.Interfaces;

namespace GuessNumber;

public abstract class Program
{
    public static void Main()
    {
        INumberGenerator numberGenerator = new RandomNumberGenerator();
        IUserInterface ui = new ConsoleUser();
        var settings = new GameSettings();
        var game = new Game(settings, numberGenerator, ui);
        game.Play();
    }
}