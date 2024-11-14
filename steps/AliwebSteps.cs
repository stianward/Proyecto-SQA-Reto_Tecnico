
using automation_test.pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace automation_test.steps
{
    [Binding]
    public class AliwebSteps
    {
        private readonly AliWebPage _aliWebPage;
        public AliwebSteps(AliWebPage aliWebPage) => _aliWebPage = aliWebPage;

 
        [Given(@"An user selects a country (.*)")]
        public async Task AnUserSelectsACountry(string country)
        {
            await _aliWebPage.NavigateAsync();
            await _aliWebPage.SelectACountry(country);

        }
        [When(@"An user search a product and choosed it(.*)")]
        public async Task AnUserSearchAProduct(string product)
        {
            await _aliWebPage.SearchAProduct(product);
            for (int i = 0; i <= 3; i++)
            {
                await _aliWebPage.ChooseAProduct();
            }
        }
            [Then(@"An user validates gran total")]
            public async Task AnUserValidatesGranTotal()
            {
                Assert.True(await _aliWebPage.ValidateProductPrice());

            }
        }

}