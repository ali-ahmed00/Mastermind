using System;

class SecretCode
{
    public string Code { get; private set; }

    public SecretCode(string code = null)
    {
        Code = string.IsNullOrEmpty(code) ? GenerateRandomCode() : code;
    }

    private string GenerateRandomCode()
    {
        string digits = "012345678";
        string result = "";
        Random rnd = new Random();

        while (result.Length < 4)
        {
            char ch = digits[rnd.Next(digits.Length)];
            if (!result.Contains(ch))
            {
                result += ch;
            }
        }

        return result;
    }

    public bool IsValidGuess(string guess)
    {
        if (guess.Length != 4) return false;

        for (int i = 0; i < guess.Length; i++)
        {
            char ch = guess[i];
            if (ch < '0' || ch > '8') return false;

            for (int j = i + 1; j < guess.Length; j++)
            {
                if (guess[i] == guess[j]) return false;
            }
        }

        return true;
    }
}

class Game
{
    private SecretCode secretCode;
    private int maxAttempts;

    public Game(string customCode = null, int attempts = 10)
    {
        secretCode = new SecretCode(customCode);
        maxAttempts = attempts;
    }

    public void Start()
    {
        Console.WriteLine("Can you break the code? Enter a valid guess.");

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.Write($"Attempt {attempt}/{maxAttempts}: ");
            string guess = Console.ReadLine();

            if (string.IsNullOrEmpty(guess)) break;

            if (!secretCode.IsValidGuess(guess))
            {
                Console.WriteLine("Invalid guess! Try again.");
                attempt--;
                continue;
            }

            int wellPlaced = 0;
            int misplaced = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretCode.Code[i])
                {
                    wellPlaced++;
                }
                else if (secretCode.Code.Contains(guess[i]))
                {
                    misplaced++;
                }
            }

            if (wellPlaced == 4)
            {
                Console.WriteLine("Congratz! You did it!");
                return;
            }

            Console.WriteLine("Well-placed pieces: " + wellPlaced);
            Console.WriteLine("Misplaced pieces: " + misplaced);
        }

        Console.WriteLine("Game Over! The code was: " + secretCode.Code);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string customCode = null;
        int customattempt = 10;


        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-c" && i + 1 < args.Length)
            {
                customCode = args[i + 1];
            }
            else if (args[i] == "-t" && i + 1 < args.Length && int.TryParse(args[i + 1], out int parsed))
            {
                customattempt = parsed;
            }

        }

        Game game = new Game(customCode, customattempt);
        game.Start();
    }
}
