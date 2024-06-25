namespace PlayDemo1.Steps
{
    using System;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.Playwright;
    using PlayDemo1.Drivers.Models;
    using PlayDemo1.Drivers.PlayDriver;
    using PlaywrightTests.UI.Pages;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;


    [Binding]
    public class GiftCardsValidationSteps
    {
        private readonly HomePage homePage = null;
        private readonly GiftCardsPage giftCardsPage = null;
        private readonly ScenarioContext scenarioContext = null;

        public GiftCardsValidationSteps(Driver driver, ScenarioContext scenarioContext)
        {
            homePage = new HomePage(driver.Page);
            giftCardsPage = new GiftCardsPage(driver.Page);
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to '([^']*)'")]
        public async Task NavigateTo(string url)
        {
            await homePage.GetPage().GotoAsync(url);
            //string title = url.Substring(url.IndexOf(".") + 1);
            //string removeLastCharFromTitleResult = title.Remove(title.Length - 1, 1);

            //removeLastCharFromTitleResult.ToUpper();
            //string titleToValidate = removeLastCharFromTitleResult.Remove(1).ToUpper() + removeLastCharFromTitleResult.Substring(1);

            //// validate URL link name
            //await Assertions.Expect(this.homePage.GetPage()).ToHaveTitleAsync(new Regex(titleToValidate));
        }

        [Then(@"I search '([^']*)'")]
        public async Task Search(string searchText)
        {
            await homePage.Search(searchText);
        }

        [Then(@"I choose the gift card by type name '([^']*)'")]
        public async Task ClickOnGiftCardByTypeName(string giftCardTypeName)
        {
            Enum.TryParse(giftCardTypeName, out EGiftCardsType giftCardsType);
            await homePage.ClickToGiftCardsByType(giftCardsType);
        }

        [Then(@"I wait load page state '([^']*)'")]
        public async Task WaitLoadState(string stateToWaite)
        {
            Enum.TryParse(stateToWaite, out LoadState state);

            try
            {
                await homePage.GetPage().WaitForLoadStateAsync(state);
            }
            catch
            {
            }
        }

        [Then(@"I enter gift card details")]
        public async Task EnterGiftCardDetails(Table details)
        {
            var cardDetails = details.CreateSet<GiftCard>();
            if (cardDetails == null)
            {
                homePage.StopTestWithReason("EnterGiftCardDetails::cardDetails == null");
                return;
            }

            foreach (var field in cardDetails)
            {
                int amountValue = 0;
                if (field.Amount != null)
                {
                    await ClickToButtonByName($"${field.Amount}");
                    int.TryParse(field.Amount, out amountValue);
                }
                else if (field.CustomAmount != null)
                {
                    await giftCardsPage.GetPage().GetByLabel(GiftCardsPage.AmountGiftCardDetailsButton).FillAsync(field.CustomAmount);
                    int.TryParse(field.CustomAmount, out amountValue);
                }

                if (field.DeliveryEmail != null)
                {
                    await ClickToButtonByName(GiftCardsPage.EmailGiftCardDetailsButton);
                    await giftCardsPage.GetPage().GetByPlaceholder(GiftCardsPage.ToEmailGiftCardDetailsField).FillAsync(field.DeliveryEmail);
                }

                if (field.From != null)
                {
                    await giftCardsPage.GetPage().GetByLabel(GiftCardsPage.FromGiftCardDetailsField).FillAsync(field.From);
                }

                if (field.Message != null)
                {
                    await giftCardsPage.GetPage().GetByRole(AriaRole.Textbox, new() { Name = GiftCardsPage.MessageGiftCardDetailsField }).FillAsync(field.Message);
                }

                if (field.Quantity != null)
                {
                    await giftCardsPage.GetPage().GetByText(GiftCardsPage.QuantityGiftCardDetailsField).FillAsync(field.Quantity);
                }

                if (field.DeliveryDate != null)
                {
                    string date = string.Empty;
                    if (field.DeliveryDate == "Today")
                    {
                        date = DateTime.Today.Day.ToString();
                    }
                    else
                    {
                        date = field.DeliveryDate;
                    }

                    await giftCardsPage.ChooseCalendarDate(date);
                }

                int.TryParse(field.Quantity, out int amountQuantity);
                var totalAmountValue = amountQuantity * amountValue;

                // validate total amount before added to cart
                await giftCardsPage.GetPage().Locator("#gc-buy-box-text").GetByText($"${totalAmountValue}").ClickAsync();

                // save total amount value
                scenarioContext.Set(totalAmountValue, HomePage.TotalAmountKeyName);
            }
        }

        [Then(@"I click to button by name '([^']*)'")]
        public async Task ClickToButtonByName(string buttonName)
        {
            await homePage.ClickToButtonByName(buttonName);
        }

        [Then(@"I validate cart total amount")]
        public async Task ValidateCartTotalAmmount()
        {
            await homePage.GetPage().Locator("#ewc-content").GetByText($"${scenarioContext.Get<int>(HomePage.TotalAmountKeyName)}.00").ClickAsync();
        }
    }
}
