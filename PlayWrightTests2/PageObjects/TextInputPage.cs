using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlayWrightTests.PageObjects
{
    public class TextInputPage
    {
        private readonly IPage _page;
        private const string TextInputSelector = "#newButtonName";
        private const string ButtonSelector = "#updatingButton";

        public TextInputPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("http://www.uitestingplayground.com/textinput");
        }

        public async Task EnterTextAsync(string text)
        {
            await _page.FillAsync(TextInputSelector, text);
        }

        public async Task<string> GetInputValueAsync()
        {
            return await _page.InputValueAsync(TextInputSelector);
        }

        public async Task<string> GetButtonTextAsync()
        {
            return await _page.InnerTextAsync(ButtonSelector);
        }

        public async Task ClickButtonAsync()
        {
            await _page.ClickAsync(ButtonSelector);
        }
    }
}