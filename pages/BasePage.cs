using System.Diagnostics.Metrics;
using Microsoft.Playwright;


namespace automationSQA.pages
{
    public abstract class BasePage
    {
        public abstract string PagePath { get; }

        public abstract IPage Page { get; set; }

        public abstract IBrowser Browser { get; }

       
        public async Task NavigateAsync()
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
        }
       
              
        


    }
}
