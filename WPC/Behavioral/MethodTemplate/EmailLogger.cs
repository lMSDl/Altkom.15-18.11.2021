using System;

namespace WPC.Behavioral.MethodTemplate
{
    public class EmailLogger : Logger<string, IDisposable>
    {
        protected override void LogMessage(IDisposable service, string info)
        {
            Console.WriteLine("Sending Email with Log Message : " + info);
        }

        protected override IDisposable GetService()
        {
            return null;
        }

        protected override string ConvertMessage(string message)
        {
            Console.WriteLine("Serializing message");
            return message.ToString();
        }
    }
}

