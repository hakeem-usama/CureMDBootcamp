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
            string[] newarr = WordsSeprator();
            int Select;
            Console.WriteLine("====================================\nEnter the Number[1-7]\n1= Word Frequency Analysis\n2= Sentence Maker\n3= Longest and Shortest Word Finder\n4= Word Search\n5= Palindrome Detector\n6= Vowel/Consonant Counter\n7= All of Above\n====================================\nPress 0 to exit....");
            Select = Convert.ToInt32(Console.ReadLine());
            //do
            //{
                //Select = Convert.ToInt32(Console.ReadLine());
                switch (Select)
            {
                case 1:
                    {
                        FrequencyCalculation(newarr);
                    }
                    break;
                case 2:
                    {
                        SentenceMakerNew(newarr);
                    }
                    break;
                case 3:
                    {
                        LongestShortestWordFinder(newarr);
                    }
                    break;
                case 4:
                    {
                        WordFinder(newarr);
                    }
                    break;
                case 5:
                    {
                        PalindromeFinder(newarr);
                    }
                    break;
                case 6:
                    {
                        VowelCounter(newarr);
                    }
                    break;
                case 7:
                    {
                        Console.WriteLine("====================================");
                        FrequencyCalculation(newarr);
                        Console.WriteLine("====================================");
                        SentenceMakerNew(newarr);
                        Console.WriteLine("====================================");
                        LongestShortestWordFinder(newarr);
                        Console.WriteLine("====================================");
                        WordFinder(newarr);
                        Console.WriteLine("====================================");
                        PalindromeFinder(newarr);
                        Console.WriteLine("====================================");
                        VowelCounter(newarr);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invaild Number\nTry Again And Enter Valid Number");
                    }
                    break;
            }
            //} while (Select != 0);

            //SentenceMaker(newarr);
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
            Console.WriteLine("\n1)	Word Frequency Analysis\n");
            //Initialize a new array to store the Unique words of array
            string[] UniqueArray = new string[100];
            int[] frequuency = new int[100];//Array to store Frequency of Unique words
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
                Console.WriteLine("The word \"" + UniqueArray[i] + "\" has occured \"" + frequuency[i] + "\" times");
            }
        }
        //static int[] RandomArrayGenerator(string[] array)
        //{
        //    int[] RandomArray = new int[5];
        //    Random rand = new Random();
        //    int Range = array.Length;
        //    for (int i=0; i<5;i++)
        //    {
        //        RandomArray[i]= rand.Next(0, Range);
        //    }
        //    return RandomArray;
        //}
        //static void SentenceMaker(string[] array)
        //{

        //    Console.WriteLine("Enter the Number N");
        //    int Number = Convert.ToInt32(Console.ReadLine());
        //    string[] NewArrays = new string[Number];

        //    int[] RandomIndexs = new int[5];

        //    int temp = 0;
        //    string sentense = string.Empty;
        //    for (int i = 0; i < Number; i++)
        //    {
        //        RandomIndexs = RandomArrayGenerator(array);
        //        for (int j=0; j<5;j++)
        //        {
        //            temp = RandomIndexs[j];
        //            sentense = sentense + " " + array[temp];
        //            temp = 0;
        //        }
        //        NewArrays[i] = sentense;
        //        sentense = string.Empty;

        //    }

        //    Console.WriteLine("The New Generated Sentences are: ");
        //    for (int i = 0; i < Number; i++)
        //    {

        //        Console.WriteLine( NewArrays[i]);
        //    }

        //}
        static void SentenceMakerNew(string[] array)
        {
            Console.WriteLine("\n2)	Sentence Maker\n");
            Console.WriteLine("Enter the Number of Sentences N");
            int Number = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            string[] NewArrays = new string[Number]; 
            int temp = 0;
            int Range = array.Length;
            string sentense = string.Empty;
            for (int i = 0; i < Number; i++)
            {               
                for (int j = 0; j < 5; j++)
                {
                    temp = rand.Next(0, Range);
                    sentense = sentense + " " + array[temp];
                    temp = 0;
                }
                NewArrays[i] = sentense;
                sentense = string.Empty;
            }
            Console.WriteLine("The New Generated Sentences are: ");
            for (int i = 0; i < Number; i++)
            {
                Console.WriteLine(NewArrays[i]);
            }
        }
        static void LongestShortestWordFinder(string[] array)
        {
            Console.WriteLine("\n3)	Longest and Shortest Word Finder\n");
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
            //Console.WriteLine("Sorted Array");
            //for (int i = 0; i < SortedArray.Length; i++)
            //{
            //    Console.WriteLine(SortedArray[i]);
            //}
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
            Console.WriteLine("\n4)	Word Search\n");
            string EnteredWord = string.Empty;
            Console.WriteLine("Enter the Word you want to Search");
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
                Console.WriteLine("The Word \"" + EnteredWord + "\" appears \"" + count + "\" times in String");
            }
            else
            {
                Console.WriteLine("Entered Word not found in string");
            }
        }
        static void PalindromeFinder(string[] array)
        {
            Console.WriteLine("\n5)	Palindrome Detector\n");
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
                Console.WriteLine("The palindromic words in the sentence are: \n");
                for (int i=0; i<count;i++)
                {
                    Console.WriteLine(PalindromeArray[i]);
                }
            }

        }
        static void VowelCounter(string[] array)
        {
            Console.WriteLine("\n6)	Vowel/Consonant Counter\n");
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
                Console.WriteLine("The Word "+"\""+array[i]+"\"has \""+ VowelArray[i] + "\" Vowels and \""+ ConsonentArray[i] + "\" Consonants");
            }
        }
    }
}