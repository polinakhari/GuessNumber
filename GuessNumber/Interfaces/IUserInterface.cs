namespace GuessNumber.Interfaces;

public interface IUserInterface
{
    string GetUserInput(string prompt);
    void ShowMessage(string message);
}