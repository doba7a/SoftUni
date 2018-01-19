namespace TakeSkipRope
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class TakeSkipRope
    {
        public static void Main()
        {
            string encryptedMessage = Console.ReadLine();

            List<int> numberList = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            string encryptedMessageWithoutDigits = Regex.Replace(encryptedMessage, "[0-9]", "");

            FillLists(encryptedMessage, numberList, takeList, skipList);

            StringBuilder decryptedMessage = new StringBuilder();
            int skipCount = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                string submessage = string.Empty;

                if (skipCount + takeList[i] < encryptedMessageWithoutDigits.Length)
                {
                    submessage = encryptedMessageWithoutDigits.Substring(skipCount, takeList[i]);
                }
                else
                {
                    submessage = encryptedMessageWithoutDigits.Substring(skipCount);
                }

                skipCount += skipList[i] + takeList[i];

                decryptedMessage.Append(submessage);
            }

            Console.WriteLine(decryptedMessage);
        }

        public static void FillLists(string encryptedMessage, List<int> numberList, List<int> takeList, List<int> skipList)
        {
            foreach (char character in encryptedMessage)
            {
                if (char.IsDigit(character))
                {
                    numberList.Add(character - 48);
                }
            }

            for (int i = 0; i < numberList.Count; i += 2)
            {
                takeList.Add(numberList[i]);
                skipList.Add(numberList[i + 1]);
            }
        }
    }
}