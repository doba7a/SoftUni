namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            Console.Write("Enter binary file directory and name with extension:");
            string directoryAndName = Console.ReadLine();
            string fileExtension = directoryAndName.Substring(directoryAndName.LastIndexOf('.') + 1);

            CopyFile(directoryAndName, fileExtension);
        }

        public static void CopyFile(string directoryAndName, string fileExtension)
        {
            try
            {
                using (FileStream fs = new FileStream(directoryAndName, FileMode.Open))
                using (FileStream destination = new FileStream($"copied.{fileExtension}", FileMode.Create))
                {
                    byte[] buffer = new byte[fs.Length];

                    while (true)
                    {
                        int readBytes = fs.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }

                    Console.WriteLine($"Result added to copied.{fileExtension} in project folder. Press any key to exit.");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid path or file name. Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
