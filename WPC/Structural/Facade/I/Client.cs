using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Facade.I
{
    public class Client
    {
        public static void Execute()
        {
            var item = new Person { Name = "Ewa Ewowska", Age = 32 };


            //var jsonSettings = new JsonSerializerSettings()
            //{
            //    DateFormatString = "MM.dd.yyyy HH.mm.ss",
            //    Formatting = Formatting.Indented,
            //    DefaultValueHandling = DefaultValueHandling.Ignore
            //};

            //var json = JsonConvert.SerializeObject(item, jsonSettings);

            var json = JsonFacade.Serialize(item);

            Console.WriteLine(json);

            item = JsonFacade.Deserialize<Person>(json);

        }
    }
}
