using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes"; 

        while (playAgain == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // Random number between 1 and 100

            int guess = -1;
            int guessCount = 0;  
            
            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine("I'm thinking of a number between 1 and 100...\n");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();
                guess = int.Parse(userInput);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher\n");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower\n");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.\n"); // Stretch Challenge #1
                }
            }

            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine().ToLower();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing Guess My Number!");
    }
}
