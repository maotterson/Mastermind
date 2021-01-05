using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark_Otterson___Mastermind__Quadax_Exercise_
{
    // Mastermind Game class
    public class Game
    {
        // Constants for length of answer and maximum value of each integer
        public const int answerLength = 4;
        public const int answerMaxInteger = 6;
        public const int numberOfGuessesAllowed = 10;

        // Properties
        public string Answer { get; set; }
        public string PreviousGuess { get; set; }
        public string DisplayedResult { get; set; }
        public int CurrentGuessNumber { get; set; }
        public bool IsFinished { get; set; }
        public bool IsWinner { get; set; }

        // Constructor to set the initial game state
        public Game()
        {
            Answer = generateAnswer();
            CurrentGuessNumber = 1;
            PreviousGuess = "";
            IsFinished = false;
            IsWinner = false;
        }

        // Initially generate a random code/answer
        public string generateAnswer()
        {
            Random randomGenerator = new Random();
            StringBuilder sbAnswer = new StringBuilder();

            // Generate random integers for each digit in answer
            for(int i=0; i<answerLength; i++)
            {
                int answerInteger = randomGenerator.Next(1, answerMaxInteger + 1);
                sbAnswer.Append(answerInteger.ToString());
            }

            return sbAnswer.ToString();
        }

        public void makeGuess(string argGuess)
        {
            PreviousGuess = argGuess;

            // Validate the guess; invalid attempts will still count as guesses!
            bool isValid = validateGuess(argGuess);

            if (!isValid)
            {
                processGuess();
                PreviousGuess += " (Invalid Guess)";
                DisplayedResult = "The previous guess was invalid.";
                return;
            }

            StringBuilder sbDisplayedResult = new StringBuilder();

            // Iterate through the answer and check each position
            for(int i=0; i < answerLength; i++)
            {
                // Current digit of guess matches that of the answer
                if(argGuess[i] == Answer[i])
                {
                    sbDisplayedResult.Append("+");
                }
                // Digit doesn't match, but is contained within answer
                else if (Answer.Contains(argGuess[i])) 
                {
                    sbDisplayedResult.Append("-");
                }
                // Digit is not contained within answer
                else
                {
                    sbDisplayedResult.Append(" ");
                }
            }
            DisplayedResult = sbDisplayedResult.ToString();
            processGuess();

        }

        // Process the state of the game following guess
        private void processGuess()
        {
            // Check to see if there was a perfect match
            if (DisplayedResult == "++++")
            {
                IsFinished = true;
                IsWinner = true;
                return;
            }

            // Increment the current guess
            CurrentGuessNumber++;
            if (CurrentGuessNumber == 11)
            {
                IsFinished = true;
            }
        }

        // Validate that the guessed code is a 4-digit integer (including guesses with a digit outside of range)
        private bool validateGuess(string argGuess)
        {
            if(argGuess.Length!=4 || !int.TryParse(argGuess, out int guessAsInteger))
            {
                return false;
            }

            foreach(char digit in argGuess)
            {
                // Verify that the guessed digits are between 1-6 (corresponding to ascii codes 49 and 54)
                if ((int)digit < 49 || (int)digit > 54)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
