using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Facade.I
{
    public static class JsonFacade
    {
        public static JsonSerializerSettings Settings { get; } = new()
        {
            DateFormatString = "MM.dd.yyyy HH.mm.ss",
            Formatting = Formatting.Indented,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public static string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item, Settings);
        }
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }

    }
}
