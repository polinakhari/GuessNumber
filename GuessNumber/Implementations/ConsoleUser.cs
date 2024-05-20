using GuessNumber.Interfaces;

namespace GuessNumber.Implementations;

public class ConsoleUser : IUserInterface
{
    public string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}