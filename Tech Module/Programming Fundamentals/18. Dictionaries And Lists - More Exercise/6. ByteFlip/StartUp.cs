namespace ByteFlip
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class ByteFlip
    {
        public static void Main()
        {
            List<string> bytesListInHexFormat = Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length == 2)
                .Reverse()
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (string byteInHexFormat in bytesListInHexFormat)
            {
                string reversedByteInHexFormat = ReverseByteInHexFormat(byteInHexFormat);

                result.Append(ConvertHexToChar(reversedByteInHexFormat));
            }

            Console.WriteLine(result);
        }

        public static string ReverseByteInHexFormat(string byteInHexFormat)
        {
            char[] ByteInHexFormatAsCharArray = byteInHexFormat.ToCharArray();
            Array.Reverse(ByteInHexFormatAsCharArray);
            return new string(ByteInHexFormatAsCharArray);
        }

        public static char ConvertHexToChar(string reversedByteInHexFormat)
        {
            char convertedChar = Convert.ToChar(Convert.ToUInt32(reversedByteInHexFormat, 16));

            return convertedChar;
        }
    }
}