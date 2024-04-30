using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101); // Generate a random number between 1 and 100

        int guess;
        bool guessedCorrectly = false;
        int guessesCount = 0;

        Console.WriteLine("Guess My Number Game!");
        Console.WriteLine("I've picked a number between 1 and 100. Try to guess it.");

        do
        {
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());
            guessesCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                guessedCorrectly = true;
            }
        } while (!guessedCorrectly);

        Console.WriteLine($"It took you {guessesCount} guesses to find the magic number.");
    }
}
