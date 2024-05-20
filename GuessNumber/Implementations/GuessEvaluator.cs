namespace GuessNumber.Implementations;

public class GuessEvaluator
{
    public string EvaluateGuess(int guess, int target)
    {
        if (guess < target)
        {
            return "higher";
        }
        else if (guess > target)
        {
            return "lower";
        }
        else
        {
            return "correct";
        }
    }
}