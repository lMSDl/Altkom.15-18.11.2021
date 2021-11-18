using System;

namespace WPC.Behavioral.MethodTemplate
{
    public class FileLogger : Logger<string, FileService>
    {
        protected override void LogMessage(FileService service, string info)
        {
            Console.WriteLine("Appending Log message to file : " + info);
        }

        protected override FileService GetService()
        {
            return new FileService();
        }

        protected override string ConvertMessage(string message)
        {
            Console.WriteLine("Serializing message");
            return message.ToString();
        }
    }
}

