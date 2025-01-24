using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using PlayWrightTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightTests.Tests
{
    [TestClass]
    public class TextInputTest
    {
        [TestMethod]
        public async Task EnterCustomTextAndVerifyFieldChange()
        {
            // Initialize Playwright
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            // Create an instance of the page class
            var textInputPage = new TextInputPage(page);

            // Navigate to the page
            await textInputPage.NavigateAsync();

            // Define the custom text
            string customText = "Hello, Playwright!";

            // Enter the custom text into the input field
            await textInputPage.EnterTextAsync(customText);

            // Click the button to update its text
            await textInputPage.ClickButtonAsync();

            // Verify that the button text has changed to the custom text
            var buttonText = await textInputPage.GetButtonTextAsync();
            Assert.AreEqual(customText, buttonText);

            // Close the browser
            await browser.CloseAsync();
        }
    }
}