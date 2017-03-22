using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorGuessingGame
{
    class Program
    {
        static int PromptUser()
        {
            Console.WriteLine("Give me your best guess");
            var input = Console.ReadLine();
            int.TryParse(input, out int guess);
            return guess;
        }

        static bool WasAlreadyGuess(int[] pastGuess, int userGuess) //pastGuess is my array  userGuess is the current guess
        {
            bool WasAlreadyGuess = false;

            foreach (var testGuess in pastGuess)  //test guess is my container for testing and comparing
            {
                if (userGuess == testGuess)
                {
                    WasAlreadyGuess = true;
                }
            }
            return WasAlreadyGuess;
        }

        static string EndingCredit(int tryvalue)
        {
            if (tryvalue > 4)
            {
                return "You lost";
            }
            else
            {
                return "You Won!";
            }

        }

        static void Main(string[] args)
        {
            var target = new Random().Next(1, 101);
            Console.WriteLine($"the target is {target}");

            var counter = 0;
            var guess = 0;
            var pastGuess = new int[5];

            while (counter < 5 && guess != target)
            {
                guess = PromptUser();

                //**wasalreadyguess
                bool wasAlreadyGuess = false;
                wasAlreadyGuess = WasAlreadyGuess(pastGuess, guess);

                if (wasAlreadyGuess)
                {
                    Console.WriteLine("You already guessed that, try again");
                }
                else
                {
                    pastGuess[counter] = guess;

                    Console.WriteLine($"your guess was {guess}");

                    if (guess < target)
                    {
                        Console.WriteLine("Too low, try again.");
                    }
                    else if (guess > target)
                    {
                        Console.WriteLine("Too high, try again");
                    }

                    Console.WriteLine("Your past guesses are:");
                }

                foreach (var userGuess in pastGuess)
                {
                    if (userGuess != 0)
                    {
                        Console.Write($"{userGuess},");
                    }
                }
                counter++;
                
            }

           Console.WriteLine($"{EndingCredit(counter)}");

        }
    }
}
