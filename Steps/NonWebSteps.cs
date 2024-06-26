using Microsoft.Playwright;
using NUnit.Framework;
using PlayDemo1.Drivers.PlayDriver;
using PlayDemo1.Drivers.TestConfigs;
using PlaywrightTests.UI.Pages;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlayDemo1.Steps
{
    [Binding]
    public sealed class NonWebSteps
    {
        private readonly ScenarioContext scenarioContext;
        private IPage page;
        public NonWebSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"^(?i)Some valid data")]
        public async Task s1()
        {
            Console.WriteLine("Some valid data");
        }

        [When(@"^(?i)fail step")]
        [Then(@"^(?i)fail step")]
        public async Task s2()
        {
            Assert.Fail("Intentionaly Fail step");
        }

        [When(@"^(?i)some '(.*)' data")]
        [Then(@"^(?i)some '(.*)' data")]
        public async Task dynamicData1(string data1)
        {
            int i = 0;
            bool result = int.TryParse(data1, out i);
            Console.WriteLine($"given {data1 } in form of string  {data1 is string}");
            Console.WriteLine($"given {data1} in form of string  {data1 is string} but data is numeric {result}");
        }


        [When(@"^(?i)some another (.*) data")]
        [Then(@"^(?i)some another (.*) data")]
        public async Task dynamicData2(dynamic data1)
        {
            Console.WriteLine($"given {data1} in form of string  {data1 is string}");
            Console.WriteLine($"given {data1} in form of string  {data1 is string}");
        }

        //[When(@"switch to tab (.*) as title")]
        //[When(@"switch to tab (.*) as index")]
        [When(@"switch to tab having ""([^""]*)"" as title")]
        [When(@"switch to tab having ""([^""]*)"" as index")]
        public async Task steps1(string tabLocator)
        {
            Console.WriteLine($"Pass Arg: {tabLocator}");
            int i = 0;
            bool result = int.TryParse(tabLocator, out i);
            Console.WriteLine($"given {tabLocator} in form of string  {tabLocator is string}");
            Console.WriteLine($"given {tabLocator} in form of string  {tabLocator is string} but data is numeric {result}");

            if(tabLocator is string)
            {
                Console.WriteLine("Tab Locator is String");
            }
            else if(result)
            {
                Console.WriteLine("Tab Locator is Numeric");
            }
            else
            {
                throw new Exception("Data type is not defined for step");
            }
        }

        [When(@"wait for (.*) secs")]
        [Then(@"wait for (.*) secs")]
        public async Task waitfor(int wait)
        {
            Thread.Sleep(wait);
        }


        [When(@"test project config data")]
        public async Task st12()
        {
            Console.WriteLine($"Browser :{TestConfigData.GetConfigData.BrowserName}");
            Console.WriteLine($"File :{TestConfigData.GetConfigData.IsHeadless}");
        }










        //[StepArgumentTransformation(@"(having '([^']*)')")]
        //public string SAT1(string tabtitle)
        //{
        //    return tabtitle;
        //}

        //[StepArgumentTransformation(@"(having (//d+))")]
        //public int SAT2(int idxNum)
        //{
        //    return idxNum;

        //}


        //[When(@"switch to tab having (.*)")]
        ////[When(@"switch to tab having index is 1")]
        //public void tabstep1(string x)
        //{
        //    Console.WriteLine(x);
        //}

        [StepArgumentTransformation(@"title as ""([^""]*)""")]
        public string SAT3(string a)
        {
            return a;
        }





    }
}