using Microsoft.Playwright.MSTest;
using PlayWrightTests2.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightTests2.Tests
{
    [TestClass]
    public class LoginTests : PageTest

    {

        [TestMethod]
        public async Task SuccessfulLoginUsingPOM()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("tomsmith", "SuperSecretPassword!");
            await Expect(loginPage.FlashMessage).ToContainTextAsync("You logged into a secure area!");
            await Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/secure");
        }

        [TestMethod]
        public async Task UnsuccessfulLoginUsingPOM()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("invalid", "invalid!");
            await Expect(loginPage.FlashMessage).ToContainTextAsync("Your username is invalid!");
        }
    }
}
