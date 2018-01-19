namespace PrintPartOfASCIITable
{
    using System;

    public class PrintPartOfASCIITable
    {
        public static void Main()
        {
            byte beggining = byte.Parse(Console.ReadLine());
            byte end = byte.Parse(Console.ReadLine());

            for (int i = beggining; i <= end; i++)
            {
                Console.Write($"{Convert.ToChar(i)} ");
            }

            Console.WriteLine();
        }
    }
}