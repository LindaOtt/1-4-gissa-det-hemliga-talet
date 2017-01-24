using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace _1_4_Gissa_Talet
{
    public class SecretNumber
    {
        private int _number; //The secret number
        private List<int> _previousGuesses; //All made guesses since secret number was created
        private int MaxNumberOfGuesses; //Nr of guesses allowed for user to guess secret number
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
            
            get
            {
                   int countGuesses = 0;
                   bool isGuessListEmpty = !_previousGuesses.Any();
                   if (isGuessListEmpty) {
                       countGuesses = 0;
                   }
                   else {
                       countGuesses = _previousGuesses.Count;
                   }
                
                   return countGuesses;
            }
        }

        //Gives or sets the secret number
        public int? Number
        {
            set
            {
                _number = (int)value;
            }
            get
            {
                return _number;
            }
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
            get
            {
                return _previousGuesses;
            }
        }

        /*
         * Constructor
         * Creates a valid random number in object of SecretNumber
         * Creates instance of List-object with room for seven elements
         * holding made guesses since secret number was created
         */
        public SecretNumber()
        {
            Initialize();
            //_previousGuesses = new List<int>(new int[7]);
            _previousGuesses = new List<int>();
        }

        /*Initilizes members of this class
         * number is given a random number between 1 and 100
         * Elements in _previousGuesses are removed through Clear()
         * Outcome is given value Indefinite
         * */
        public void Initialize()
        {
            if (_previousGuesses != null) { 
                _previousGuesses.Clear();
            }
            Random rnd = new Random();
            Number = rnd.Next(1, 100);
            OutCome = OutcomeType.Indefinite;
        }

        /* Returns value of type OutcomeType which indicates if 
         * the guessed number is right, too low, too high, an already made
         * guess or if the user has used all possible guesses.
         * If guess is not between 1 and 100, ArgumentOutOfRangeException is thrown.
         */
        public OutcomeType MakeGuess(int guess)
        {
            //Check that the guess is between 1 and 100
            if (guess > 100 || guess < 1)
            {
                throw new ArgumentOutOfRangeException("Your guess is not between 1 and 100.");
            }

            //Check if the guess has been made before
            bool isInList = _previousGuesses.IndexOf(guess) != -1;
            if (isInList )
            {
                _previousGuesses.Add(guess);
                OutCome = OutcomeType.PreviousGuess;
                return OutCome;
            }
            else { 

                if (guess == Number)
                {
                    _previousGuesses.Add(guess);
                    OutCome = OutcomeType.Correct;
                    return OutCome;
                }
                else if (guess < Number)
                {
                    _previousGuesses.Add(guess);
                    OutCome = OutcomeType.Low;
                    return OutCome;
                }
                else if (guess > Number)
                {
                    _previousGuesses.Add(guess);
                    OutCome = OutcomeType.High;
                }

            }

            OutCome = OutcomeType.Indefinite;
            return OutCome;
        }

    }
}