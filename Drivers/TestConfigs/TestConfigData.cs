using Newtonsoft.Json;
using PlayDemo1.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDemo1.Drivers.TestConfigs
{
    public class TestConfigData
    {
        public static TestConfigRoot GetConfigData
        {
            get
            {
                var f = File.ReadAllText("AppConfig.json");
                TestConfigRoot x = JsonConvert.DeserializeObject<TestConfigRoot>(f)!;
                //Console.WriteLine($"{x.BrowserName}");
                return x;
            }
        }



    }
}
