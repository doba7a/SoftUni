namespace ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            Console.Write("Type 1 to *SLICE* a file or 2 to *ASSEMBLE* file: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                try
                {
                    Console.Write("Enter source file directory and name with extension: ");
                    string directoryAndName = Console.ReadLine();

                    Console.Write("Enter directory for sliced files: ");
                    string destionationDirectory = Console.ReadLine();

                    Console.Write("Enter number of slices: ");
                    int parts = int.Parse(Console.ReadLine());

                    Slice(directoryAndName, destionationDirectory, parts);
                }
                catch (Exception)
                {
                    Console.WriteLine("You have entered invalid data. Please try again!");
                }

            }
            else if (option == "2")
            {
                List<string> files = new List<string>();

                Console.Write("Enter file directory and name with extension to be assembled or press *ENTER* if you won't add more files: ");
                string file = Console.ReadLine();
                while (file != string.Empty)
                {
                    if (file.EndsWith(".gz"))
                    {
                        files.Add(file);
                    }
                    else
                    {
                        Console.WriteLine("Only files with .gz extension are valid for merging");
                    }

                    Console.Write("Enter file directory and name with extension to be assembled or press *ENTER* if you won't add more files: ");
                    file = Console.ReadLine();
                }

                Console.Write("Enter directory for assembled file: ");
                string destionationDirectory = Console.ReadLine();

                Console.Write("Enter name for assembled file: ");
                string fileName = Console.ReadLine();

                try
                {
                    Assemble(files, destionationDirectory, fileName);
                }
                catch (Exception)
                {
                    Console.WriteLine("You have entered invalid data. Please try again");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
            }
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            using (FileStream fsIN = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                int sizeOfEachFile = (int)Math.Ceiling((double)fsIN.Length / parts);

                string fileName = sourceFile.Substring(0, sourceFile.LastIndexOf('.'));

                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                for (int i = 1; i <= parts; i++)
                {
                    string outFilepath = destinationDirectory + "\\" + fileName + $"Part{i}." + extension;

                    using (FileStream fsOUT = new FileStream(outFilepath, FileMode.Create, FileAccess.Write))
                    using (GZipStream zipStream = new GZipStream(fsOUT, CompressionMode.Compress, false))
                    {
                        int bytesRead = 0;
                        byte[] buffer = new byte[sizeOfEachFile];

                        if ((bytesRead = fsIN.Read(buffer, 0, sizeOfEachFile)) > 0)
                        {
                            zipStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            Console.WriteLine("Slicing done.");
        }

        public static void Assemble(List<string> files, string destinationDirectory, string fileName)
        {
            if (files.Count <= 0)
            {
                Console.WriteLine("No input files specified!");
                return;
            }
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            var fileExtension = Path.GetExtension(files.First());

            var path = destinationDirectory + "\\" + fileName + fileExtension;

            using (FileStream fsOUT = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                foreach (string filePath in files)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    using (FileStream inpFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (GZipStream zipStream = new GZipStream(fsOUT, CompressionMode.Compress, false))
                    {
                        while ((bytesRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsOUT.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            Console.WriteLine("Files Merged");
        }
    }
}
