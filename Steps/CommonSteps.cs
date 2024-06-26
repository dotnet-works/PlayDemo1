using Allure.Net.Commons;
using Microsoft.Playwright;
using PlayDemo1.Drivers.PlayDriver;
using PlayDemo1.Drivers.TestConfigs;
using PlaywrightTests.UI.Pages;
using System.Text;

namespace PlayDemo1.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly BasePage basePage = null;
        private readonly ScenarioContext scenarioContext = null;
        private IPage page;
        public CommonSteps(Driver driver, ScenarioContext scenarioContext)
        {
            this.page = driver.Page;
            basePage = new BasePage(this.page);
            //demoPage = new DemoPage(driver.Page);
            this.scenarioContext = scenarioContext;
        }

        [Given(@"^(?i)I navigate to '([^']*)'")]
        [Given(@"^(?i)User navigate to '([^']*)'")]
        [Given(@"^(?i)user open '([^']*)'")]
        public async Task NavigateTo(string url)
        {
            await basePage.GoToSite(url);
        }



        [When(@"^(?i)Switch to new tab")]
        public async Task tabSwitch()
        {

            Console.WriteLine($"Total Tabs Open: {page.Context.Pages.Count}");

            foreach (var tab in page.Context.Pages)
            {
                await tab.BringToFrontAsync();
                string _tabTitle = await tab.TitleAsync();
                Thread.Sleep(500);
                Console.WriteLine(_tabTitle);
            }
            Thread.Sleep(2000);
            await page.Context.Pages[1].BringToFrontAsync();
            Thread.Sleep(1000);

            page = page.Context.Pages[0];
            await page.CloseAsync();
            Thread.Sleep(3000);
        }


        [When("allure sample attachments")]
        public async Task TestLabels()
        {
            AllureApi.AddAttachment("../../../TestData/alluredata.txt","text/plain",Encoding.UTF8.GetBytes("This is the sample text file content."));
            
            var filePath = ProjectDirPaths.ScreenShotPath + "sample.png";
            var filex = await page.ScreenshotAsync(new() { Path = filePath });
            AllureApi.AddAttachment("image1.png","image/png",File.ReadAllBytes(filePath));

            AllureApi.AddAttachment("../../../TestData/data1.json", "text/json");

            //AllureApi.AddAttachment("image2.png","image/png","/path/to/image2.png");

            AllureApi.AddAttachment("alluredata.txt", "text/plain", "../../../TestData/alluredata.txt");

        }







        public async Task<IPage> SwitchTabs(string tabTitle, IBrowserContext BrowserCTX)
        {
            IPage _page = null;
            foreach (var tab in BrowserCTX.Pages)
            {
                await tab.BringToFrontAsync();
                string _tabTitle = await tab.TitleAsync();
                Thread.Sleep(1000);
                if (_tabTitle.StartsWith(tabTitle, StringComparison.OrdinalIgnoreCase))
                {
                    _page = tab;
                }
            }


            return _page!;
        }




        





    }
}