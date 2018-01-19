namespace StringAndObjects
{
    using System;

    public class StringAndObjects
    {
        public static void Main()
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();
            object twoWords = firstWord + ' ' + secondWord;
            string output = (string)twoWords;
            Console.WriteLine(output);
        }
    }
}