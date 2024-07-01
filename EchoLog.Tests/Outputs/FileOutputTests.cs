using System;
using System.IO;
using Xunit;
using EchoLog.Outputs;

namespace EchoLog.Tests.Outputs
{
    public class FileOutputTests
    {
        [Fact]
        public void Log_WritesMessageToFile()
        {
            // Arrange
            string testFilePath = "test_log.log";
            string testMessage = "This is a test log message.";
            FileOutput fileOutput = new FileOutput(testFilePath);

            // Act
            fileOutput.Log(testMessage);

            // Assert
            string logContents = File.ReadAllText(testFilePath);
            Assert.Contains(testMessage, logContents);

            // Clean up
            File.Delete(testFilePath);
        }
    }
}