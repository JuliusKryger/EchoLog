using System;
using System.IO;
using System.Threading;

namespace EchoLog.Outputs
{
    public class FileOutput
    {
        private readonly string filePath;
        private static readonly object fileLock = new object();

        public FileOutput(string path)
        {
            filePath = path;
        }

        public void Log(string message)
        {
            lock (fileLock)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to write to log file: {ex.Message}");
                }
            }
        }
    }
}