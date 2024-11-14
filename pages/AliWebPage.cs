
using automationSQA.pages;
using Microsoft.Playwright;

namespace automation_test.pages
{
    public class AliWebPage : BasePage
    {
        private static string url = "https://es.aliexpress.com/";
        public override string PagePath => url;
        public override IPage Page { get; set; }

        public override IBrowser Browser { get; }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public AliWebPage(IBrowser browser)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {

            Browser = browser;
        }
        
        private string countrySelectButton = "//div[contains(@class,'ship-to--menuItem--')]/div[@class='ship-to--text--3H_PaoC']";
        private string saveCountryButton = "//div[contains(text(),'Guardar')]";
        private string addCarPlusButton = "//div[@class='image--wrapper--1E-TZ1I']";
        private string addCarButton = "//button/span[contains(text(),'Agregar al carrito')]";
        private string shoppingCarButton = "//a[contains(text(),'Ir a la Cesta')]";
        private string countrySelectList = "//div[contains(@class,'select--text--')]/span[contains(@class,'country-flag')]";
        private string searchBarInput = "//input[contains(@class,'search--keyword--')]";
        private string searchButton = "//input[contains(@class,'search--submit')]";
        private string resultToAddProductToast = "//span[contains(text(),'Añadido a la cesta')]";
        private string total = "//div[contains(text(),'Total estimado')]";
        public async Task SelectACountry(string country)
        {
            if (await Page.IsVisibleAsync(countrySelectButton))
            {
                await Page.ClickAsync(countrySelectButton);
                await Page.ClickAsync(countrySelectList);
                await Page.FillAsync("//div[contains(@class,'select--search-')]/input", country);
                await Page.ClickAsync(saveCountryButton);
             
            }
            else {
                Console.WriteLine("Error list not ready yet!");
            }

        }
        public async Task SearchAProduct(string product) {
            if (await Page.IsVisibleAsync(searchBarInput))
                await Page.FillAsync(searchBarInput,product);
            await Page.ClickAsync(searchButton);

        }
        public async Task<Boolean> ChooseAProduct() { 
        await Page.ClickAsync(addCarPlusButton);
            await Page.ClickAsync(addCarButton);
            return await  Page.IsVisibleAsync(resultToAddProductToast);
        }

        public async Task<Boolean> ValidateProductPrice() {
            if(await Page.IsVisibleAsync(shoppingCarButton))
            await Page.ClickAsync(shoppingCarButton);
            return await Page.IsVisibleAsync(total);
        }
    }
}
