using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.UI.Pages.SocialPages
{
    public class LoginPage : BasePage
    {
        IPage _page;
        public LoginPage(IPage page) : base(page)
        {
            this._page = page;
        }

        //public readonly string _TXTLoc_BirthDate = "[name=\"birthdate\"]";

        //public readonly string TXTLoc_FirstName = "[name=\"firstname\"]";

        
        //public readonly string RDLoc_Gender = "//input[@name='gender'and @value='male']";
        //public readonly string CKLoc_Agree = "[name=\"gdpr_agree\"]";
        //public readonly string BTNLoc_Submit = "input#ossn-submit-button";

        //public readonly string BTNLoc_Login = "a.btn.btn-primary.btn-sm";
        //public readonly string BTNLoc_ResetPassword = "a.btn.btn-warning.btn-sm";
        //public readonly string TXTLoc_NewUserName = "[name=\"username\"]";
        //public readonly string TXTLoc_NewUserPassword = "[name=\"password\"]";
        //public readonly string BTNLoc_NewUserLogin = "input.btn.btn-primary.btn-sm";

        public ILocator TXT_FirstName => _page.Locator("[name=\"firstname\"]");
        public ILocator TXT_LastName => _page.Locator("[name=\"lastname\"]");
        public ILocator TXT_Email => _page.Locator("[name=\"email\"]");
        public ILocator TXT_ReEmail => _page.Locator("[name=\"email_re\"]");
        public ILocator TXT_UserName => _page.Locator("[name=\"username\"]");
        public ILocator TXT_Password => _page.Locator("[name=\"password\"]");

        public ILocator TXT_BirthDate => _page.Locator("[name=\"birthdate\"]");

        public ILocator RD_Gender => _page.Locator("//input[@name='gender'and @value='male']");
        public ILocator CK_Agree => _page.Locator("[name=\"gdpr_agree\"]");
        public ILocator BTN_Submit => _page.Locator("input#ossn-submit-button");

        public ILocator BTN_Login => _page.Locator("a.btn.btn-primary.btn-sm");
        public ILocator BTN_ResetPassword => _page.Locator("a.btn.btn-warning.btn-sm");
        public ILocator TXT_NewUserName => _page.Locator("[name=\"username\"]");
        public ILocator TXT_NewUserPassword => _page.Locator("[name=\"password\"]");
        public ILocator BTN_NewUserLogin => _page.Locator("input.btn.btn-primary.btn-sm");

        public async Task GoToLoginPage()
        {
          await _page.GotoAsync("https://demo.opensource-socialnetwork.org/");
        }
    }
}
