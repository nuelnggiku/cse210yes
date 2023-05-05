using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string scripture = "Proverbs 3:5-6 - Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        List<string> hiddenWords = new List<string>();

        while (hiddenWords.Count < scripture.Split(' ').Length)
        {
            // Clear console screen
            Console.Clear();

            // Display scripture
            Console.WriteLine(scripture);

            // Prompt user to press enter or type quit
            Console.WriteLine("\nPress enter to reveal more words or type 'quit' to end.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }
            else
            {
                // Hide random word
                string[] words = scripture.Split(' ');
                string hiddenWord;
                do
                {
                    hiddenWord = words[new Random().Next(words.Length)];
                } while (hiddenWords.Contains(hiddenWord));
                hiddenWords.Add(hiddenWord);

                // Replace word with underscores
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == hiddenWord)
                    {
                        words[i] = new string('_', hiddenWord.Length);
                    }
                }
                scripture = string.Join(' ', words);
            }
        }
    }
}