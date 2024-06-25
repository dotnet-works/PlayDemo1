namespace PlayDemo1.Drivers.PlayDriver
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Playwright;

    //public class Driver : IDisposable
    //{
    //    private readonly Task<IPage> page;
    //    private IBrowser browser;


    //    public Driver() => this.page = Task.Run(this.InitializePlaywright);

    //    public IPage Page => this.page.Result;

    //    public void Dispose() => this.browser?.CloseAsync();

    //    private async Task<IPage> InitializePlaywright()
    //    {
    //        var playwright = await Playwright.CreateAsync();

    //        this.browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //        {
    //            Headless = false,
    //        });

    //        return await this.browser.NewPageAsync();
    //    }
    //}



    //***  Code Enhencement              ***//

    public class Driver : IDisposable
    {
        private readonly Task<IPage> page;
        private IBrowser browser;
        private IBrowserContext context;

        public Driver() => page = Task.Run(InitializePlaywright);

        public IPage Page => page.Result;

        public void Dispose() => browser?.CloseAsync();

        private async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            context = await browser.NewContextAsync();
            return await context.NewPageAsync();
            // return await this.browser.NewPageAsync();
        }
    }




    //***                                ***//








}