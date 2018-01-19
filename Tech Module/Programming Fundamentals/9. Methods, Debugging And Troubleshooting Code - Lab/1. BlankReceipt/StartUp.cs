namespace blankReceipt
{
    using System;

    public class blankReceipt
    {
        public static void Main()
        {
            printReceipt();
        }

        public static void printReceipt()
        {
            printHeader();
            printBody();
            printFooter();
        }

        public static void printHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        public static void printBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        public static void printFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
    }
}
