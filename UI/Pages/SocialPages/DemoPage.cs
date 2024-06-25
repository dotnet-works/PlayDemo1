using Microsoft.Playwright;
using PlaywrightTests.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.UI.Pages.SocialPages
{
    public class DemoPage : BasePage
    {
        IPage _page;
        public DemoPage(IPage page) : base(page)
        {
            this._page = page;
        }

        
        public static string _BTN_FrontEndDemo => "//a[contains(text(),'Frontend Demo')]";

        public ILocator DemoBtn => _page.Locator("//a[contains(text(),'Frontend Demo')]");

        public async Task GoToDemoSite()
        {
            await _page.GotoAsync("https://www.opensource-socialnetwork.org/demo");
        }
        public async Task ClickFrontDemoBTN()
        {
            await _page.Locator(_BTN_FrontEndDemo).ClickAsync();
        }









    }
}
