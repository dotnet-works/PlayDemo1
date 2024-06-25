using PlaywrightTests.UI.Pages.SocialPages;
using Microsoft.Playwright;
using NUnit.Framework;


using PlayDemo1.Drivers.PlayDriver;

namespace PlayDemo1.Steps
{
    [Binding]
    public sealed class SocialNetSteps1
    {
        private readonly DemoPage demoPage = null;
        private LoginPage loginPage = null;
        private readonly ScenarioContext scenarioContext = null;
        private IPage page;

        public SocialNetSteps1(Driver driver, ScenarioContext scenarioContext)
        {
            page = driver.Page;
            demoPage = new DemoPage(driver.Page);
            //this.loginPage = new LoginPage(driver.Page);
            this.scenarioContext = scenarioContext;
        }

        [When(@"navigate to socialnetwork page")]
        public async Task s1()
        {
            Thread.Sleep(2000);
            //await demoPage.ClickFrontDemoBTN();
            await demoPage.DemoBtn.ClickAsync();
            //await _page.Locator("//a[contains(text(),'Frontend Demo')]").ClickAsync();
            Thread.Sleep(2000);
            TestContext.WriteLine($"Thread-ID => {Thread.CurrentThread.ManagedThreadId}");
            //var tabs = _page.Context.Pages; //.Browser;
            //Console.WriteLine($"Total Tabs: {tabs.Count}"); 

            var x = page.Context;
            Console.WriteLine(x);
            Console.WriteLine(await page.TitleAsync());

        }

        [When("enter first name data")]
        public async Task fillFirstname()
        {
            
            page = await SwitchTabs1(page, "Welcome");

            loginPage = new LoginPage(page);

            await loginPage.TXT_FirstName.ClickAsync();
            await loginPage.TXT_FirstName.PressSequentiallyAsync("MyFirstName");
            Thread.Sleep(3000);
            
            await loginPage.HandleTextField(loginPage.TXT_FirstName);
            await loginPage.HandleTextField(loginPage.TXT_FirstName,"LOOOOOOL");
            Thread.Sleep(3000);
            




        }


        //[When(@"^(?i)Switch to new tab")]
        //public async Task tabSwitch()
        //{
        //    //_page = await SwitchTabs("Welcome :", _page.Context);
        //    //_sharedContext.SharedPageContext = _page;
        //    Console.WriteLine($"Total Tabs Open: {page.Context.Pages.Count}");

        //    foreach (var tab in page.Context.Pages)
        //    {
        //        await tab.BringToFrontAsync();
        //        string _tabTitle = await tab.TitleAsync();
        //        Thread.Sleep(500);
        //        Console.WriteLine(_tabTitle);
        //        //if (_tabTitle.StartsWith(tabTitle, StringComparison.OrdinalIgnoreCase))
        //        //{
        //        //    _page = tab;
        //        //}
        //    }
        //    Thread.Sleep(2000);
        //    await page.Context.Pages[1].BringToFrontAsync();
        //    Thread.Sleep(1000);

        //    page = page.Context.Pages[0];
        //    await page.CloseAsync();
        //    Thread.Sleep(8000);
        //}


        public async Task<IPage> SwitchTabs1(IPage p, string tabTitle)
        {
            IPage? page = null;
            foreach (var tab in p.Context.Pages)
            {
                //await tab.BringToFrontAsync();
                string _tabTitle = await tab.TitleAsync();
                Thread.Sleep(500);
                if (p.Context.Pages.Count > 1)
                {
                    if (_tabTitle.StartsWith(tabTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Switching tab if availiable");
                        page = tab;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("No extra tabs aviliable");
                    page = tab;
                    break;
                }
                
                
               
            }

            return page!;
        }



        //public async Task<IPage> SwitchTabs(string tabTitle, IBrowserContext BrowserCTX)
        //{
        //    IPage? _page = null;
        //    foreach (var tab in BrowserCTX.Pages)
        //    {
        //        await tab.BringToFrontAsync();
        //        string _tabTitle = await tab.TitleAsync();
        //        Thread.Sleep(1000);
        //        if (_tabTitle.StartsWith(tabTitle, StringComparison.OrdinalIgnoreCase))
        //        {
        //            _page = tab;
        //        }
        //    }


        //    return _page!;
        //}



    }
}