using Logger.Models.LogFiles.Contracts;
using System;
using System.IO;

namespace Logger.Models.LogFiles
{
    public class LogFile : ILogFile
    {
        const string path = "./data/";

        public LogFile(string fileName)
        {
            this.Path = path + fileName;
            InitializeFile();
            this.Size = 0;
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int sizeToAdd = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                if (char.IsLetter(errorLog[i]))
                {
                    sizeToAdd += errorLog[i];
                }
            }
            this.Size += sizeToAdd;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(path);
            File.AppendAllText(this.Path, "");
        }
    }
}
