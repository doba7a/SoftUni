namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            Console.Write("Enter directory: ");
            string searchedDirectory = Console.ReadLine();
            DirectoryInfo directorySelected = new DirectoryInfo(searchedDirectory);

            SortedDictionary<string, Dictionary<string, double>> extensions = new SortedDictionary<string, Dictionary<string, double>>();
            FilesExtensions(directorySelected, extensions);

            using (StreamWriter writer = new StreamWriter("extensions.txt"))
            {
                WritingOnFile(writer, extensions);
            }
        }

        private static void WritingOnFile(StreamWriter writer, SortedDictionary<string, Dictionary<string, double>> extensions)
        {
            foreach (var extension in extensions
               .OrderByDescending(extension => extension.Value.Count)
               .ThenBy(extension => extension.Key))
            {

                writer.WriteLine(extension.Key);
                var orderedDic = extension.Value.OrderBy(dic => dic.Value);
                foreach (var dic in orderedDic)
                {
                    writer.WriteLine("{0}{1:F2}kb", dic.Key, dic.Value / 1024);
                }
            }

            Console.WriteLine("Result added to extensions.txt at project folder");
        }

        private static void FilesExtensions(DirectoryInfo directorySelected, SortedDictionary<string, Dictionary<string, double>> extensions)
        {
            foreach (var file in directorySelected.GetFiles())
            {
                if (!extensions.ContainsKey(file.Extension))
                {
                    extensions.Add(file.Extension, new Dictionary<string, double> { { string.Format("--{0} - ", file.Name), file.Length } });
                }
                else
                {
                    extensions[file.Extension].Add(string.Format("--{0} - ", file.Name), file.Length);
                }

            }
        }
    }
}