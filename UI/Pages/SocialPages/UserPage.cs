using Microsoft.Playwright;
using PlayDemo1.Drivers.TestConfigs;
using PlaywrightTests.UI.Pages;
using TechTalk.SpecFlow;

namespace PlayDemo1.UI.Pages.SocialPages
{
    
    public class UserPage : BasePage
    {
        IPage _page;
        public UserPage(IPage page) : base(page)
        {
            this._page = page;
        }

        //logout app
        public ILocator UserDropDownMenu => _page.Locator("li.ossn-topbar-dropdown-menu");
        public ILocator LogOut => _page.GetByRole(AriaRole.Link, new() {Name ="Log out"});

        public async Task UserLoginSuccessfully()
        {
            await UserDropDownMenu.IsVisibleAsync(new() { Timeout = 25000 });
            await _page.ScreenshotAsync(new() { Path = ProjectDirPaths.ScreenShotPath + "_1.png" });
        }





    }
}