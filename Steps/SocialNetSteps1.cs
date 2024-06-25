using PlaywrightTests.UI.Pages.SocialPages;
using Microsoft.Playwright;
using NUnit.Framework;


using PlayDemo1.Drivers.PlayDriver;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace PlayDemo1.Steps
{
    [Binding]
    public sealed class SocialNetSteps1
    {
        private readonly DemoPage demoPage = null;
        private LoginPage loginPage;// = null;
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


        [When(@"open new tab and navigate to ""([^""]*)""")]
        public async Task OpenTab(string newURL)
        {
            //_page = _sharedContext.SharedPageContext;
            //var newTab = await _page.Context.NewPageAsync();
            //await newTab.GotoAsync(newURL);
            //_sharedContext.SharedPageContext = newTab;

            page = await page.Context.NewPageAsync();
            await page.GotoAsync(newURL);
            

        }

        [When(@"click on 'dob' element and enter birtdate as ""([^""]*)""")]
        public async Task stepDob(string birthDate)
        {
            //_page = _sharedContext.SharedPageContext;

            string[] birthString = birthDate.Split(" ");
            Thread.Sleep(200);

            string patternX = @"^(\d{1}|\d{2}) ((January|Jan\.|Jan)|(February|Feb\.|Feb)|(March|Mar\.|Mar)|(April|Apr\.|Apr)|(May)|(June|Jun\.|Jun)|(July|Jul\.|Jul)|(August|Aug\.|Aug)|(September|Sep\.|Sept\.|Sept)|(October|Oct\.|Oct)|(November|Nov\.|Nov)|(December|Dec\.|Dec)) \d{4}$";
            bool isMatch5 = Regex.IsMatch(birthDate, patternX);
            if (isMatch5)
            { await SetUserDob(birthString[0], birthString[1], birthString[2]); }
            else
            { throw new Exception("Error => Enter DOB in correct format of : day monthname year (00 March 1983)"); }
        }

        public async Task SetUserDob(string _month, string _year)
        {
            if (!await page.Locator("div#ui-datepicker-div").IsVisibleAsync())
            {
                await loginPage.TXT_BirthDate.ClickAsync();
                Thread.Sleep(500);

                await page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { $"{_month}" });
                Thread.Sleep(200);

                await page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { $"{_year}" });
                Thread.Sleep(200);

                var todayNum = DateTime.Today.Day; //.Now.ToString("d");
                string _dayLocator = $"//td/a[@data-date='{todayNum}']";
                await page.Locator(_dayLocator).ClickAsync();
                Thread.Sleep(1500);

            }


        }

        public async Task SetUserDob(string _day, string _month, string _year)
        {
            if (!await page.Locator("div#ui-datepicker-div").IsVisibleAsync())
            {
                await loginPage.TXT_BirthDate.ClickAsync();
                Thread.Sleep(500);

                await page.Locator("select.ui-datepicker-month").SelectOptionAsync(new[] { $"{_month}" });
                Thread.Sleep(200);

                await page.Locator("select.ui-datepicker-year").SelectOptionAsync(new[] { $"{_year}" });
                Thread.Sleep(200);

                //var todayNum = DateTime.Today.Day; //.Now.ToString("d");
                string _dayLocator = $"//td/a[@data-date='{_day}']";
                await page.Locator(_dayLocator).ClickAsync();
                Thread.Sleep(1500);

            }
        }


        [Then(@"verify birthdate should be in dd/mm/yyyy format")]
        public async Task ValidFormat()
        {
            string birthvalue = await loginPage.TXT_BirthDate.InputValueAsync();  // await _page.Locator("[name=\"birthdate\"]").InputValueAsync();
            Console.WriteLine(birthvalue);

            string validFormat = @"\d{2}/\d{2}/\d{4}";
            bool isMatch3 = Regex.IsMatch(birthvalue, validFormat);
            isMatch3.Should().BeTrue($"String {birthvalue} is in correct format of dd/MM/yyyy");
            Console.WriteLine($"String {birthvalue} is in correct format of dd/MM/yyyy");

            ////DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
            //DateTime userDate = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);
            //DateTime userDate1 = DateTime.ParseExact(birthvalue, "dd/MM/yyyy", null);

            //DateTime dt = DateTime.Parse("09/12/2009");

            //Console.WriteLine(dt.ToString("dd/MM/yyyy"));

            ////DateTime dat = DateTime.Parse($"{birthvalue.Trim()}");
            //string x = string.Format("{0:dd/MM/yyyy}", birthvalue);
            //Console.WriteLine($"Format1: {x}");

            //Console.WriteLine($"Parsed: {birthvalue} DateTime1: {userDate}");
            //string.Equals(birthvalue, x);
            //if (string.Compare(birthvalue, x) == 0)
            //{
            //    Console.WriteLine("strings are valid");
            //}
        }

        [When(@"enter new user data")]
        public async Task enterdata1()
        {
            List<string> userList = new string[] { "Zulu", "Max", "Mint" }.ToList<string>();
            Random randNum = new Random();
            int userName = randNum.Next(0, userList.Count);
            int randValue = randNum.Next(1000, 2000);

            string firstName = userList[userName];
            string newUserName = $"{firstName}_{randValue}";
            string newUserEmail = $"{newUserName}@yopmail.com";

            await loginPage.TXT_FirstName.ClickAsync();
            await loginPage.TXT_FirstName.FillAsync(firstName);
            await loginPage.TXT_LastName.FillAsync("Laaast");
            await loginPage.TXT_Email.FillAsync(newUserEmail);
            await loginPage.TXT_ReEmail.FillAsync(newUserEmail);
            await loginPage.TXT_UserName.FillAsync(newUserName);
            await loginPage.TXT_Password.FillAsync("Test@1234");
            await loginPage.RD_Gender.ClickAsync();
            await loginPage.CK_Agree.ClickAsync();

            int id = Thread.CurrentThread.ManagedThreadId;
            //await page.ScreenshotAsync(new() { Path = TestUtil.ScreenShotPath + $"newuser_{id}.png" });
            //await page.Locator(_loginPage.BTNLoc_Submit).ClickAsync();
            //Thread.Sleep(15000);
            //if (await VerifyNewUserCreated())
            //{
            //    _sharedContext.NEWUSEREMAIL = newUserEmail;
            //}
        }

        public async Task FillUserTextFeildData(bool RandomData = false, string? new_username = null)
        {
            string? firstName = null;
            string? newUserName = null;
            string? newUserEmail = null;
            if (RandomData)
            {
                List<string> userList = new string[] { "Zulu", "Max", "Mint" }.ToList<string>();
                Random randNum = new Random();
                int userName = randNum.Next(0, userList.Count);
                int randValue = randNum.Next(1000, 2000);

                firstName = userList[userName];
                newUserName = $"{firstName}{randValue}";
                newUserEmail = $"{newUserName}@yopmail.com";
            }
            else
            {
                firstName = "Toon";
                newUserName = $"{new_username}";
                newUserEmail = $"{new_username}@yopmail.com";

            }
            //await _page.Locator(_loginPage.TXTLoc_FirstName).ClickAsync();
            //await _page.Locator(_loginPage.TXTLoc_FirstName).FillAsync(firstName);
            //await _page.Locator(_loginPage.TXTLoc_LastName).FillAsync("Tester");
            //await _page.Locator(_loginPage.TXTLoc_Email).FillAsync(newUserEmail);
            //await _page.Locator(_loginPage.TXTLoc_ReEmail).FillAsync(newUserEmail);
            //await _page.Locator(_loginPage.TXTLoc_UserName).FillAsync(newUserName);
            //await _page.Locator(_loginPage.TXTLoc_Password).FillAsync("Test@1234");
            //await _page.Locator(_loginPage.RDLoc_Gender).ClickAsync();
            //await _page.Locator(_loginPage.CKLoc_Agree).ClickAsync();
            ////await _page.ScreenshotAsync(new() { Path = TestUtil.ScreenShotPath + $"newuser_{id}.png" });
            ////await _page.Locator(_loginPage.BTNLoc_Submit).ClickAsync();



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