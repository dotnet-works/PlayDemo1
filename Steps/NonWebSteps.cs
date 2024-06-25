using Microsoft.Playwright;
using NUnit.Framework;
using PlayDemo1.Drivers.PlayDriver;
using PlaywrightTests.UI.Pages;
using TechTalk.SpecFlow;

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

        [When(@"switch to tab (.*) as title")]
        [When(@"switch to tab (.*) as index")]
        public async Task steps1(string x)
        {
            Console.WriteLine("");
        }

        [StepArgumentTransformation(@"(having '([^']*)')")]
        public string SAT1(string d)
        {
            return null;
        }

        [StepArgumentTransformation(@"(having (//d+))")]
        public string SAT2(int d)
        {
            return null;

        }
    }
}