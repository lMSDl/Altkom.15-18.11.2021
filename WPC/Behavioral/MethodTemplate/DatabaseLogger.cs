using System;

namespace WPC.Behavioral.MethodTemplate
{
    public class DatabaseLogger : Logger<DatabaseLogger.Entity, DatabaseService>
    {

        protected override void LogMessage(DatabaseService service, Entity info)
        {
            Console.WriteLine("Inserting Log Message to DB table : " + info.Value);
        }

        protected override DatabaseService GetService()
        {
            return new DatabaseService();
        }

        protected override Entity ConvertMessage(string message)
        {
            Console.WriteLine("Serializing message");
            return new Entity { Value = message };
        }

        public class Entity
        {
            public string Value { get; set; }
        }

        protected override void OnServiceClosed()
        {
            Console.WriteLine("Bye!");
        }
    }
}

