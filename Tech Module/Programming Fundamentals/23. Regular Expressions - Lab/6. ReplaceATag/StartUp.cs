namespace ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceATag
    {
        public static void Main()
        {
            string inputText = Console.ReadLine();

            string patternToFindATag = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            string patternToReplaceATag = @"[URL href=$1]$2[/URL]";

            while (inputText != "end")
            {
                string textWithReplacedTag = Regex.Replace(inputText, patternToFindATag, patternToReplaceATag);

                Console.WriteLine(textWithReplacedTag);

                inputText = Console.ReadLine();
            }
        }
    }
}