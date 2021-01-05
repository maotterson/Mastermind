//Mark Otterson - Mastermind Game (Quadax Programming Exercise)
//Date:             1/5/21
//Time Started:     1:38 PM
//Time Completed:   3:43 PM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark_Otterson___Mastermind__Quadax_Exercise_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new game object
            Game gameObject = new Game();
            string guess = "";

            // Loop to handle each successive guess
            while(true)
            {
                // Refresh the UI
                refreshConsole(gameObject);
                Console.WriteLine($"Current Guess: {gameObject.CurrentGuessNumber}/{Game.numberOfGuessesAllowed}");
                Console.Write("Make your guess: ");
                guess = Console.ReadLine();

                // The game will allow the user to make invalid guesses, but will simply ignore the guess
                // (e.g. guesses with more than 4 digits are simply ignored so a user isn't allowed to guess every digit to cheat)
                gameObject.makeGuess(guess);

                // Check current game state to see if the game is finished
                if (gameObject.IsFinished)
                {
                    break;
                }
            }

            // Display end of game result
            refreshConsole(gameObject);
            if (gameObject.IsWinner)
            {
                Console.WriteLine($"Congratulations! You successfully cracked the code: {gameObject.Answer}! It took you {gameObject.CurrentGuessNumber} guesses.");
            }
            else
            {
                Console.WriteLine($"Unfortunately you were unable to correctly crack the code: {gameObject.Answer}. Better luck next time.");
            }

            // Keep the Console Open
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // Display the header information on the console.
        private static void refreshConsole(Game gameObject)
        {
            Console.Clear();
            Console.WriteLine($"Mastermind Game (by Mark Otterson)\n==================================\nCrack the code by guessing a {Game.answerLength}-digit number, each digit between 1-{Game.answerMaxInteger}\n"); 
            if (gameObject.CurrentGuessNumber > 1)
            {
                Console.WriteLine($"Previous Guess:\n{gameObject.PreviousGuess}\n");
                Console.WriteLine($"Result:\n{gameObject.DisplayedResult}\n");
            }
        }

    }
}
