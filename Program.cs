using System;

class HangmanGame
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Array that stores words
            string[] words = { "Apples", "Banana", "Oranges" };
            string word = words[new Random().Next(0, words.Length)];
            int score = 0;
            int lifeLeft = 10;
            int wrongLetter = 0;

            char[] guessedLetters = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            Console.WriteLine("Hangman Game");
            Console.WriteLine("Guess the word!");
            Console.WriteLine("Clue: Types of Fruits");
            Console.WriteLine();

            bool wordGuessed = false; // Declare wordGuessed variable

            while (score < 7 && lifeLeft > 0)
            {
                Console.WriteLine("Enter a letter: ");
                string inputStr = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrEmpty(inputStr))
                {
                    Console.WriteLine("Invalid input. Please enter a letter.");
                    continue;
                }

                char input = char.ToLower(inputStr[0]);

                bool found = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.ToLower(word[i]) == input)
                    {
                        guessedLetters[i] = word[i];
                        found = true;
                    }
                }

                if (found)
                {
                    Console.WriteLine("Congratulations! '{0}' is a hidden letter.", input);
                    score++;
                }
                else
                {
                    Console.WriteLine("Oops! '{0}' is not a hidden letter.", input);
                    wrongLetter++;
                    lifeLeft--;
                }

                Console.WriteLine("Hidden Word: {0}", new string(guessedLetters));
                Console.WriteLine("Score: {0} ", score);
                Console.WriteLine("Failed Attempts: {0} (Number Of Lives left: {1})", wrongLetter, lifeLeft);
                Console.WriteLine();

                // Check if all letters have been guessed correctly
                wordGuessed = new string(guessedLetters).Equals(word, StringComparison.OrdinalIgnoreCase);
                if (wordGuessed)
                {
                    break;
                }
            }

            if (wordGuessed)
            {
                Console.WriteLine("Congratulations! You guessed the word '{0}' correctly!", word);
            }
            else
            {
                Console.WriteLine("opps sorry! You failed to guess the word '{0}'.", word);
            }

            Console.WriteLine();
            Console.WriteLine("Do you want to play again? (Y/N)");
            string playAgainInput = Console.ReadLine();
            playAgain = (playAgainInput.ToUpper() == "Y");
            Console.Clear();


            if (!playAgain)
            {
                Console.WriteLine("Thank you for playing the game! Goodbye!");
            }
        }
    }
}
