﻿using System;
using System.IO;

namespace Lab03_ReviewOfCSharp
{
    public class Program
    {
        /// <summary>
        /// This methods is calling all of the methods in this program. 
        /// </summary>
        /// <param name="args">Default, a string array</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("A Review of C#");

            //Calling Challenge 01
            
            Console.WriteLine("Please enter 3 numbers: ");
            string userInput = Console.ReadLine();
            MultiplyInputNumber(userInput);

            //Console.Clear();
            

            // Calling Challenge 02
            //int[] userInputTwo = UserInputChallengeTwo();
            //FindAverageNumber(userInputTwo);

            //string path = "../../../words.txt";
            //string wordToDelete = UserInputChallengeEight();

            //OutputDesign();
            //FileAppendAWord();
            //ReadAFileAndOutputContent(path);
            //FileAppendText(path);
            //ReadRemoveAndRewriteFile(path, wordToDelete);
        }

        //Challenge01
        /// <summary>
        /// This method takes user input of 3 numbers and returns the product of these 3 numbers multiplied together.
        /// If the user puts in less than 3 numbers, return 0. 
        /// If the user puts in more than 3 number, only multiply the first 3.
        /// If the number is not a number, default that value to 1. 
        /// </summary>
        /// <param name="input">A user input of a string of 3 numbers</param>
        /// <returns>An int, either product of numbers, 0, or 1. </returns>
        public static int MultiplyInputNumber(string input)
        {
            string[] stringArray = input.Split(' ');

            int product = 1;

            if (stringArray.Length < 3)
            {
                product = 0;
                Console.WriteLine($"You have entered less than 3 numbers, so the result is: {product}");
                return product;
            }

            for (int i = 0; i < 3; i++)
            {
                if (int.TryParse(stringArray[i], out int returnValue))
                {
                    product *= returnValue;
                }
                else
                {
                    product *= 1;
                }
            }

            Console.WriteLine($"The product of these first 3 numbers is: {product}");
            return product;
        }

        // Challenge 02
        /// <summary>
        /// This method asks the user to enter a number between 1-2, prompts the user that number of times for random numbers and returns an int array. 
        /// </summary> 
        /*
        public static int[] UserInputChallengeTwo()
        {
            
            while (true)
            {
                Console.WriteLine("Please enter a number between 2-10");
                string firstUserInput = Console.ReadLine();
                int[] selectedNumber = Convert.ToInt32(firstUserInput);
                if (selectedNumber < 2 || selectedNumber > 10)
                {
                    Console.WriteLine($"{selectedNumber} is not a number between 2-10");
                    Console.Clear();
                }

                int[] numberArray = new int[selectedNumber];
                for (int i = 0; i < selectedNumber; i++)
                {
                    Console.Write($"{i + 1} of {selectedNumber} - Enter a number: ");
                    string secondUserInput = Console.ReadLine();
                    int selectedArrayNumber = Convert.ToInt32(secondUserInput);
                    numberArray[i] = selectedArrayNumber;


                }

                //Console.WriteLine(String.Join(',', numberArray));
                return numberArray;
            }
            
        }
        */

        /// <summary>
        /// This method takes as input an int array of between 2-10 numbers.
        /// </summary>
        /// <param name="numberArray">An int array from UserInputChallengeTwo()</param>
        /// <returns>The average of the array numbers</returns>
        public static double FindAverageNumber(int[] numberArray)
        {
            try
            {
                int sum = 0;
                if (numberArray.Length == 0)
                {
                    return 0;
                }

                for (int i = 0; i < numberArray.Length; i++)
                {
                    sum += numberArray[i];
                }

                double average = sum / numberArray.Length;

                Console.WriteLine("The average of these numbers is: " + average);
                return average;
            }
            catch (OverflowException e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }
            catch (FormatException e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }

        }

        // Challenge 03
        /// <summary>
        /// This method outputs to the console a diamond design. 
        /// </summary>
        public static void OutputDesign()
        {
            int number = 5;
            int count = number - 1;
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= count; j++)
                    Console.Write(" ");
                count--;
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            count = 1;
            for (int i = 1; i <= number - 1; i++)
            {
                for (int j = 1; j <= count; j++)
                    Console.Write(" ");
                count++;
                for (int j = 1; j <= 2 * (number - i) - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        // Challenge 06
        /// <summary>
        /// This method asks the user to input a word, and then saves that word into an external file named words.txt.
        /// </summary>
        static void FileAppendAWord()
        {
            string path = "../../../words.txt";

            Console.WriteLine("Please enter a word: ");
            string word = Console.ReadLine();

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(word);
            }
        }

        // Challenge 07
        /// <summary>
        /// This method reads a text file and outputs the contents to the console. 
        /// </summary>
        /// <param name="path">The text file path</param>
        static void ReadAFileAndOutputContent(string path)
        {

            string[] content = File.ReadAllLines(path);

            Console.WriteLine(String.Join('\n', content));

        }
        /// <summary>
        /// This method reads in the file from Challenge 6, removes one of the words, and rewrites it back to the file.
        /// </summary>
        /// <returns>The word to delete from the text file</returns>
        // Challenge 08
        static string UserInputChallengeEight()
        {
            Console.WriteLine("Please enter the words you wish to delete: ");
            string wordToDelete = Console.ReadLine();
            return wordToDelete;
        }

        /// <summary>
        /// This method reads a file, removes one of the words and rewrites it back to the file. 
        /// </summary>
        /// <param name="path">The text file path</param>
        static void ReadRemoveAndRewriteFile(string path, string wordToDelete)
        {
            string[] words = File.ReadAllLines(path);
            string[] newWords = new string[words.Length - 1];

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != wordToDelete)
                {
                    newWords[i] = words[i];

                }
            }

            File.WriteAllLines(path, newWords);

        }

    }
}
