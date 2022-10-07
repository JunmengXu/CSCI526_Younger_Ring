using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utility
{
    public class SimpleJson
    {
        public Dictionary<String, object> Json = new Dictionary<string, object>();
        
        public SimpleJson() {}

        public SimpleJson(String key, object value)
        {
            Json.Add(key, value);
        }

        public void Put(String key, SimpleJson json)
        {
            Json.Add(key, json.Json);
        }
        
        public void Put(String key, object value)
        {
            Json.Add(key, value);
        }

        public String ToJsonString()
        {
            Dictionary<String, object> temp = new Dictionary<string, object>();
            temp.Add(DateTime.Now.Ticks.ToString(), Json);
            return JsonConvert.SerializeObject(temp);
        }
        
    }

}