using GuessNumber.Interfaces;

namespace GuessNumber.Implementations;

public class Game
{
    private readonly GameSettings _settings;
    private readonly INumberGenerator _numberGenerator;
    private readonly IUserInterface _ui;
    private int _targetNumber;
    private int _attempts;

    public Game(GameSettings settings, INumberGenerator numberGenerator, IUserInterface ui)
    {
        _settings = settings;
        _numberGenerator = numberGenerator;
        _ui = ui;
    }

    public void Play()
    {
        _settings.Configure(_ui);
        _targetNumber = _numberGenerator.GenerateNumber(_settings.LowerBound, _settings.UpperBound);
        _attempts = 0;

        _ui.ShowMessage("Welcome to 'Guess the Number' game!");
        _ui.ShowMessage($"Guess a number between {_settings.LowerBound} and {_settings.UpperBound}. You have {_settings.MaxAttempts} attempts.");

        while (_attempts < _settings.MaxAttempts)
        {
            try
            {
                int guess = int.Parse(_ui.GetUserInput("Enter your guess: "));
                _attempts++;
                GuessEvaluator evaluator = new GuessEvaluator();
                string result = evaluator.EvaluateGuess(guess, _targetNumber);
                if (result == "correct")
                {
                    _ui.ShowMessage($"Congratulations! You've guessed the number {_targetNumber} in {_attempts} attempts.");
                    return;
                }
                else
                {
                    _ui.ShowMessage($"Your guess is {result}. Try again.");
                }
            }
            catch (FormatException)
            {
                _ui.ShowMessage("Invalid input. Please enter a valid number.");
            }
        }

        _ui.ShowMessage($"Sorry, you've used all your attempts. The correct number was {_targetNumber}.");
    }
}