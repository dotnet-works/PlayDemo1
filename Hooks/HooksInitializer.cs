using NUnit.Framework;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]



namespace PlaywrightTests.Hooks
{
    [Binding]
    public class HooksInitializer
    {

        private readonly ScenarioContext scenarioContext;
        

        public HooksInitializer(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [BeforeTestRun]
        public void BeforeTestRun()
        {
            //string browserName = Environment.GetEnvironmentVariable("BROWSER");
            //string ENV2 = Environment.GetEnvironmentVariable("ENV2");
            //string platform = Environment.OSVersion.ToString();

            //if (ENV2 == "") { Console.WriteLine("ENV2 is empty"); }
            //else if (ENV2 == null) { Console.WriteLine("ENV2 is null"); }

            //Console.WriteLine(ENV2.GetType());
            //Console.WriteLine($"Param: {TestContext.Parameters["param1"]}");
            //AllureLifecycle.Instance.CleanupResultDirectory();

        }

        [AfterTestRun]
        public void AfterTestRun()
        {

        }

        [BeforeStep]
        public void BeforeStep()
        {

        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            //Console.WriteLine("======= After Step =======");
            //var stepContext = scenarioContext.StepContext;

            //Console.WriteLine($"Status: {stepContext.Status}");
            //Console.WriteLine($"StepInfo: {stepContext.StepInfo.Text}");
            //Console.WriteLine($"Test Error: {stepContext.TestError}");
        }



        [BeforeScenario]
        public void BeforeScenario()
        {
           
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("======= After Scenario =======");
            Console.WriteLine($"Title: {this.scenarioContext.ScenarioInfo.Title}");
            Console.WriteLine($"Description: {this.scenarioContext.ScenarioInfo.Description}");
            
        }
    }
}
