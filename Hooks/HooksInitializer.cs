using Allure.Net.Commons;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PlayDemo1.Drivers.Models;
using PlayDemo1.Drivers.PlayDriver;
using PlayDemo1.Drivers.TestConfigs;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]



namespace PlaywrightTests.Hooks
{
    [Binding]
    public class HooksInitializer
    {

        private readonly ScenarioContext scenarioContext;
        private ProjectDirPaths projectDir;
        private AllureLifecycle _allureLifecycle;
        IPage _page;

        
        public HooksInitializer(Driver driver,ScenarioContext scenarioContext)
        {
            _page = driver.Page;
            this.scenarioContext = scenarioContext;
            //_allureLifecycle = AllureLifecycle.Instance;
        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //string browserName = Environment.GetEnvironmentVariable("BROWSER");
            //string ENV2 = Environment.GetEnvironmentVariable("ENV2");
            //string platform = Environment.OSVersion.ToString();

            //if (ENV2 == "") { Console.WriteLine("ENV2 is empty"); }
            //else if (ENV2 == null) { Console.WriteLine("ENV2 is null"); }

            //Console.WriteLine(ENV2.GetType());
            //Console.WriteLine($"Param: {TestContext.Parameters["param1"]}");
            
            AllureLifecycle.Instance.CleanupResultDirectory();
            //_allureLifecycle.CleanupResultDirectory();

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            CopyInstallFiles();
        }

        private static void CopyInstallFiles()
        {
            //// The correct syntax for a path name requires the verbatim @ char
            //string sourceFile = @"F:\inetpub\ftproot\test.txt";
            //string file = Path.GetFileName(sourceFile);
            //string copyPathone = directoryInput.Text;
            //System.IO.File.Copy(sourceFile, Path.Combine(copyPathone, file), true);
            string sourceFile = ProjectDirPaths.ProjectPath + "TestData/environment.properties";
            string destFile = ProjectDirPaths.ProjectPath + "Reports/allure-results/";

            if (!File.Exists(destFile))
            {
                File.Copy(sourceFile, destFile);
            }
            else
            {
                throw new Exception($"Some environment file error:");
            }



        }







        [BeforeStep]
        public async Task BeforeStep(ScenarioContext scenarioContext)
        {

        }

        [AfterStep]
        public async Task AfterStep(ScenarioContext scenarioContext)
        {
            //Console.WriteLine("======= After Step =======");
            //var stepContext = scenarioContext.StepContext;

            //Console.WriteLine($"Status: {stepContext.Status}");
            //Console.WriteLine($"StepInfo: {stepContext.StepInfo.Text}");
            //Console.WriteLine($"Test Error: {stepContext.TestError}");
        }



        [BeforeScenario]
        public async Task BeforeScenario()
        {
           
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            Console.WriteLine("======= After Scenario =======");
            Console.WriteLine($"Title: {this.scenarioContext.ScenarioInfo.Title}");
            Console.WriteLine($"Description: {this.scenarioContext.ScenarioInfo.Description}");

            if (this.scenarioContext.TestError != null)
            {
                var filePath = ProjectDirPaths.ScreenShotPath+"Error.png";
                var filex = await _page.ScreenshotAsync(new() { Path = filePath });
                AllureApi.AddAttachment("error.png", "image/png", File.ReadAllBytes(filePath));

            }   
        }

        //AllureHackForScenarioOutlineTests();
    }

}