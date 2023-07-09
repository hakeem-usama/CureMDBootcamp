using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World;");
            string[] newarr = WordsSeprator();

            //FrequencyCalculation(newarr);
            //SentenceMaker(newarr);
            //LongestShortestWordFinder(newarr);
            // WordFinder(newarr);
            //PalindromeFinder(newarr);
            VowelCounter(newarr);

            Console.ReadKey();
        }
        static string[] WordsSeprator()
        {
            Console.WriteLine("Enter your String");
            string str = Console.ReadLine();
            string[] array = new string[100];
            string word = string.Empty;
            int b = 0;
            int count = 1;
            for (int j = 0; j <= count; j++)
            {

                for (int i = b; i < str.Length; i++)
                {
                    if (str[i] == ' ' || str[i] == ',' || str[i] == '.' || str[i] == '?')
                    {
                        b = i + 1;
                        count++;
                        break;

                    }
                    else
                    {
                        word += Convert.ToString(str[i]);
                    }
                }
                array[j] = word;
                word = string.Empty;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(array[i]);
            }
            string[] newarr = new string[count];
            for (int i = 0; i < count; i++)
            {
                newarr[i] = array[i];
            }



            return newarr;
        }
        static void FrequencyCalculation(string[] array)
        {
            //Initialize a new array to store the Unique words of array
            string[] UniqueArray = new string[30];
            int[] frequuency = new int[30];//Array to store Frequency of Unique words
            string NewWord = string.Empty; // Temp variable to store word
            int Num = 0;// Index of Unique Array
            bool Duplicate;// Bool variable to check flag if word already exists or not.
            for (int i = 0; i < array.Length; i++)
            {
                NewWord = array[i];
                Duplicate = false;
                for (int j = 0; j < Num; j++)
                {

                    if (array[j] == NewWord)
                    {
                        frequuency[j]++;
                        Duplicate = true;
                        break;
                    }
                }
                if (!Duplicate)
                {
                    UniqueArray[Num] = NewWord;
                    frequuency[Num] = 1;
                    Num++;
                }

            }
            for (int i = 0; i < Num; i++)
            {
                Console.WriteLine("The word " + UniqueArray[i] + "has occured " + frequuency[i] + " times");
            }
        }
        static void SentenceMaker(string[] array)
        {
            Console.WriteLine("Enter the Number N");
            int Number = Convert.ToInt32(Console.ReadLine());
            int Range = array.Length;
            int[] RandomIndexs = new int[Number];
            string[] NewSentence = new string[Number];
            Random rand = new Random();
            int temp = 0;
            for (int i = 0; i < Number; i++)
            {
                RandomIndexs[i] = rand.Next(0, Range);
            }
            for (int i = 0; i < Number; i++)
            {
                temp = RandomIndexs[i];
                NewSentence[i] = array[temp];
            }
            Console.WriteLine("The New Generated Sentence is: ");
            for (int i = 0; i < Number; i++)
            {

                Console.Write(" " + NewSentence[i]);
            }

        }
        static void LongestShortestWordFinder(string[] array)
        {
            int LengthOfString = array.Length;
            //Initialize the new array to Sort the seperated words array
            string[] SortedArray = new string[LengthOfString];
            SortedArray = array;//Copy The Array in Sorted Array
            string temp = string.Empty;// Temp variable for Swaping(Used in Bubble Sorting)
            //Code for bubble sorting the array of string based on String length
            for (int j = 0; j < LengthOfString - 1; j++)
            {
                for (int i = 0; i < LengthOfString - j - 1; i++)
                {
                    if (SortedArray[i].Length < SortedArray[i + 1].Length)
                    {
                        //Swap the elements in array
                        temp = SortedArray[i];
                        SortedArray[i] = SortedArray[i + 1];
                        SortedArray[i + 1] = temp;
                    }

                }
            }
            // Display the Sorted Array
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < SortedArray.Length; i++)
            {
                Console.WriteLine(SortedArray[i]);
            }
            // Store the Length of First and Last Element of Sorted array that shows the Maximum Word Length and Minimum Word Length
            int LargestLength = SortedArray[0].Length;
            int LargestLengthCount = 0;
            int SmallestLengthCount = 0;
            int SmallestLength;
            // If else to skip the last element of array of it is blank space or '.'
            if (SortedArray[SortedArray.Length - 1] == "" || SortedArray[SortedArray.Length - 1] == ".")
            {
                SmallestLength = SortedArray[SortedArray.Length - 1 - 1].Length;
            }
            else
            {
                SmallestLength = SortedArray[SortedArray.Length - 1].Length;
            }
            //Count the number of Maximum Length Word and Minimum Length Words
            for (int i = 0; i < SortedArray.Length; i++)
            {
                if (SortedArray[i].Length == LargestLength)
                {
                    LargestLengthCount++;
                }
                if (SortedArray[i].Length == SmallestLength)
                {
                    SmallestLengthCount++;
                }
            }
            //Output the Largest Length Words
            Console.WriteLine("The Largest Word is:");
            for (int i = 0; i < LargestLengthCount; i++)
            {
                Console.WriteLine(SortedArray[i]);
            }
            //Output the smallest length words and if last element is space or '.' then print the previous element. 
            Console.WriteLine("The Smallest Word is:");
            if (SortedArray[SortedArray.Length - 1] == "" || SortedArray[SortedArray.Length - 1] == ".")
            {

                for (int i = SortedArray.Length - 1 - 1; i > SortedArray.Length - 1 - 1 - SmallestLengthCount; i--)
                {
                    Console.WriteLine(SortedArray[i]);
                }
            }
            else
            {
                for (int i = SortedArray.Length - 1; i > SortedArray.Length - 1 - SmallestLengthCount; i--)
                {
                    Console.WriteLine(SortedArray[i]);
                }
            }
        }
        static void WordFinder(string[] array)
        {
            string EnteredWord = string.Empty;
            Console.WriteLine("Enter the Word to Search");
            EnteredWord = Console.ReadLine();
            int count = 0;

            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == EnteredWord)
                {
                    flag = true;
                    count++;

                }

            }
            if (flag)
            {
                Console.WriteLine("The Word " + EnteredWord + " appears " + count + " times in String");
            }
            else
            {
                Console.WriteLine("Entered Word not found in string");
            }
        }
        static void PalindromeFinder(string[] array)
        {
            int count = 0;
            string word = string.Empty;
            string[] PalindromeArray= new string[10];
            for(int i=0; i<array.Length;i++)
            {
                word = array[i];
                bool Palandrome = true;
                for (int j=0;j<word.Length;j++)
                {                   
                    if(word[j]!=word[word.Length-j-1])
                    {
                        Palandrome = false;
                        
                    }
                }
                if(Palandrome)
                {
                    PalindromeArray[count] = word;
                    count++;
                }
            }
            if(count==0)
            {
                Console.WriteLine("There are no palindromic words in the sentence.");
            }
            else
            {
                Console.WriteLine("The palindromic words in the sentence are: ");
                for (int i=0; i<count;i++)
                {
                    Console.WriteLine(PalindromeArray[i]);
                }
            }

        }
        static void VowelCounter(string[] array)
        {
            string word = string.Empty;
            int[] VowelArray = new int[array.Length];
            int[] ConsonentArray = new int[array.Length];
            int Vowels=0;
            int Consonents = 0;
            for(int i=0; i<array.Length; i++)
            {
                word = array[i];
                for(int j=0;j<word.Length; j++)
                {
                    if(word[j]=='a'|| word[j] == 'e' || word[j] == 'i' || word[j] == 'o' || word[j] == 'u' )
                    {
                        Vowels++;
                    }
                    else
                    {
                        Consonents++;
                    }
                }
                VowelArray[i] = Vowels;
                ConsonentArray[i] = Consonents;
                Vowels = 0;
                Consonents = 0;
            }
            Console.WriteLine("Vowels and Consonants Count: ");
            for (int i=0; i<array.Length;i++)
            {
                Console.WriteLine("\""+array[i]+"\": "+ VowelArray[i] + " Vowels and "+ ConsonentArray[i] + " Consonants");
            }
        }
    }
}