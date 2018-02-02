namespace OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            Console.Write("Enter text file directory and name with extension:");
            string directoryAndName = Console.ReadLine();

            PrintOddLines(directoryAndName);
        }

        public static void PrintOddLines(string directoryAndName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(directoryAndName))
                {
                    int count = 0;
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            Console.WriteLine(line);
                            count++;
                        }
                        else
                        {
                            count++;
                        }

                        line = sr.ReadLine();
                    }
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
