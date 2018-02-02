namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            Console.Write("Enter text file directory and name with extension:");
            string directoryAndName = Console.ReadLine();

            PrintNumberedLines(directoryAndName);
        }

        public static void PrintNumberedLines(string directoryAndName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(directoryAndName))
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    int count = 1;
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        sw.WriteLine($"Line {count++}: {line}");

                        line = sr.ReadLine();
                    }

                    Console.WriteLine("Result added to output.txt in project folder. Press any key to exit.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid path or file name. Press any key to exit.");
                Environment.Exit(0);
            }
        }
    }
}
