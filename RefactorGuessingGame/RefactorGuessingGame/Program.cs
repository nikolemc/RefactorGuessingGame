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

        static void DataProcessor(bool wasAlreadyGuess, int randomNumber, int filteredNumber, int[] pastGuess, int counter)
        {
            if (wasAlreadyGuess)

            {
                Console.WriteLine("You already guessed that, try again");
            }
            else
            {
                pastGuess[counter] = (filteredNumber);

                if (filteredNumber < randomNumber)
                {
                    Console.WriteLine("Too high, try again.");
                }
                else if (filteredNumber > randomNumber)
                {
                    Console.WriteLine("Too low, try again");
                }
            }

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

        static void PastGuesses(int[] pastGuess)
            {
            foreach (var userGuess in pastGuess)
            {
                if (userGuess != 0)
                {
                    Console.Write($"{userGuess},");
                }
            }

            }
                    

        static void Main(string[] args)
        {
            var randomNumber = new Random().Next(1, 101);
            Console.WriteLine($"the target is {randomNumber}");

            var counter = 0;
            var filteredNumber = 0;
            var pastGuess = new int[5];
            
            while (counter < 5 && filteredNumber != randomNumber)
            {
                filteredNumber = PromptUser();

                //**wasalreadyguess
                bool wasAlreadyGuess = false;
                wasAlreadyGuess = WasAlreadyGuess(pastGuess, filteredNumber);

                //WasAlreadyGuess guessed
                DataProcessor(wasAlreadyGuess, randomNumber, filteredNumber, pastGuess, counter);               


                PastGuesses(pastGuess);

                counter++;
                
            }

           Console.WriteLine($"{EndingCredit(counter)}");
           Console.ReadLine();
        

        }
    }
}
