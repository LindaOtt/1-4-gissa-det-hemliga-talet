using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_4_Gissa_Talet
{
    public class SecretNumber
    {
        private int _number; //The secret number
        private List<int> _previousGuesses; //All made guesses since secret number was created
        private int MaxNumberOfGuesses; //Nr of guesses for user to guess secret number
        public enum OutcomeType
        {
            Indefinite,
            Low,
            High,
            Correct,
            NoMoreGuesses,
            PreviousGuess
        }

        //Shows if a guess can be made
        public bool CanMakeGuess
        {
            get;
        }

        //Number of guesses made since secret number was created
        public int Count
        {
            get;
        }

        //Gives or sets the secret number
        public int? Number
        {
            get;
        }

        //Gives the result of the latest made guess
        public OutcomeType OutCome
        {
            get;
            set;
        }

        //Collection of made guesses
        public IEnumerable<int> PreviousGuesses
        {
            get;
        }

        /*
         * Constructor
         * Creates a valid random number in object of SecretNumber
         * Creates instance of List-object with room for seven elements
         * holding made guesses since secret number was created
         */
        public SecretNumber()
        {

        }

        /*Initilizes members of this class
         * number is given a random number between 1 and 100
         * Elements in _previousGuesses are removed through Clear()
         * Outcome is given value Indefinite
         * */
        public void Initialize()
        {

        }

        /* Returns value of type OutcomeType which indicates if 
         * the guessed number is right, too low, too high, an already made
         * guess or if the user has used all possible guesses.
         * If guess is not between 1 and 100, ArgumentOutOfRangeException is thrown.
         */
        public OutcomeType MakeGuess(int guess)
        {
            OutcomeType outcome = OutcomeType.High;
            return outcome;
        }

    }
}