using GuessNumber.Interfaces;

namespace GuessNumber.Implementations;

public class GameSettings
{
    public int LowerBound { get; private set; }
    public int UpperBound { get; private set; }
    public int MaxAttempts { get; private set; }

    public void Configure(IUserInterface ui)
    {
        ui.ShowMessage("Configure your game settings:");
        LowerBound = GetValidInput(ui, "Enter the lower bound: ");
        UpperBound = GetValidInput(ui, "Enter the upper bound: ");
        MaxAttempts = GetValidInput(ui, "Enter the maximum number of attempts: ");
    }

    private int GetValidInput(IUserInterface ui, string prompt)
    {
        int result;
        while (true)
        {
            string input = ui.GetUserInput(prompt);
            if (int.TryParse(input, out result) && result > 0)
            {
                return result;
            }
            ui.ShowMessage("Invalid input. Please enter a positive integer.");
        }
    }
}