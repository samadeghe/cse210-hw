using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = randomGenerator.Next(1, 100);
            int guess = -1;

            Console.WriteLine("Welcome to the Guessing Game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing! Goodbye!");
            }
        }
    }
}
