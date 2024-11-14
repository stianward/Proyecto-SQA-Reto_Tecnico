using BoDi;
using automationSQA.pages;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using automation_test.pages;

namespace automationSQA
{

    [Binding]
    public class Runner
    {
        private static List<string> failedScenarios = new List<string>();

        [BeforeScenario]
        public static async Task BeforeScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            //{
            //    Headless = false,
            //});
            
            var browser = await playwright.Chromium.LaunchAsync();
            var pageObject = new AliWebPage(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageObject);
            System.Console.WriteLine("Starting test case..."+string.Join(",",ScenarioContext.Current.ScenarioInfo.Tags.ToArray()));
        }
        [AfterScenario]
        public static async Task AfterScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            //if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            //{
            //    failedScenarios.Add(ScenarioContext.Current.ScenarioInfo.Title);
            //}
            System.Console.WriteLine("Finishing test case..." + string.Join(",", ScenarioContext.Current.ScenarioInfo.Tags.ToArray()));
            Console.WriteLine("Result test case: "+ NUnit.Framework.TestContext.CurrentContext.Result.Outcome);
            // playwright.Dispose();
        }
        //[OneTimeTearDown]
        //public static async Task RunFailedScenarios()
        //{
            
        //    if (failedScenarios.Count > 0)
        //    {
        //        foreach (var scenario in failedScenarios) 
        //        {
        //            ExecuteScenario(scenario);
        //        }

        //        System.Console.WriteLine("Case failed..." + string.Join(",", ScenarioContext.Current.ScenarioInfo.Tags.ToArray()));
        //    }
        //}
    }

}


