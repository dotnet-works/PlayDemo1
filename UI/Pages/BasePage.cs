namespace PlaywrightTests.UI.Pages
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Playwright;

    public class BasePage
    {
        private readonly IPage page;

        public BasePage(IPage page) => this.page = page;

        public static string EnterButtonName => "Enter";

        public IPage GetPage() => this.page;

        public async Task ClickToButtonByName(string buttonName)
        {
            await this.GetPage().GetByRole(AriaRole.Button, new () { Name = buttonName, Exact = true }).ClickAsync();
        }

        public async Task ChooseCalendarDate(string date)
        {
            await this.GetPage().Locator("#gc-order-form-date i").ClickAsync();
            await this.GetPage().GetByRole(AriaRole.Link, new () { Name = date, Exact = true }).ClickAsync();
        }

        public void StopTestWithReason(string reason)
        {
            var bTestFail = true;
            bTestFail.Should().BeFalse($"{reason}");
        }

        public async Task GoToSite(string appURL)
        {
            await this.GetPage().GotoAsync(appURL);
        }



        /// <summary>
        /// Clear and enter data in text feild
        /// </summary>
        /// <param ILocator="locator"></param>
        /// <param string="txtdata"></param>
        /// <returns></returns>
        public async Task HandleTextField(ILocator locator, string txtdata = null)
        {
            await locator.ClearAsync();
            if(txtdata!= null)
            {
                await locator.FillAsync(txtdata);
            }
            
        }

        public async Task TakeElementScreenShot(ILocator _loc,string path = null)
        {

        }

        public async Task TakeFullPageScreenShot(ILocator _loc, string path = null)
        {

        }

        public async Task TakeScreenShot(ILocator _loc, string path = null)
        {

        }













    }
}