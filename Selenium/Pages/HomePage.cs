using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Rohlik.Selenium.Pages;

public class HomePage
{
    public static string Url => "https://www.rohlik.cz/";
    public IWebDriver Driver { get; set; }
    public WebDriverWait Wait { get; set; }
    public string Title => Driver.Title;
    public Element Aside;

    public HomePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        Aside = new(Driver, By.TagName("aside"));
    }

    public IWebElement UserLogin => Driver.FindWebElement(Driver, By.CssSelector("div[data-test='header-user-icon']"));
    public IWebElement UserEmail => Driver.FindWebElement(Driver, By.Id("email"));
    public IWebElement UserPassword => Driver.FindWebElement(Driver, By.Id("password"));
    public IWebElement UserSignIn => Driver.FindWebElement(Driver, By.CssSelector("button[data-test='btnSignIn']"));

    public IWebElement FirstProductName => Driver.FindWebElement(Driver, By.CssSelector("h3[data-test='productCard-body-name']"));
    public IWebElement FirstProductPrice1 => Driver.FindWebElement(Driver, By.CssSelector("span[data-test='productCard-body-price-priceNo'] span"));
    public IWebElement FirstProductPrice2 => Driver.FindWebElement(Driver, By.CssSelector("span[data-test='productCard-body-price-priceNo'] sup"));
    public IWebElement FirstProductPrice3 => Driver.FindWebElement(Driver, By.CssSelector("span[data-test='productCard-body-price-currency']"));
    public IWebElement FirstProductAdd => Driver.FindWebElement(Driver, By.CssSelector("div[data-test='productCard-header-counterButton']"));
    public IWebElement BasketCounter => Driver.FindWebElement(Driver, By.CssSelector("div[data-test='cart-header-wrapper'] div p"));

    public IWebElement BasketItemName => Driver.FindWebElement(Driver, By.CssSelector("li[data-test='cart-item'] div a"));
    public IWebElement BasketItemPrice => Driver.FindWebElement(Driver, By.CssSelector("li[data-test='cart-item'] span[data-test='actual-price']"));


    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl(Url);

        if (Aside.IsPresent())
        {
            Aside.WebElement.GetShadowRoot().FindElement(By.CssSelector("#accept")).Click();
            Driver.Navigate().Refresh();
        }
    }

    public string GetProductName()
    {
        return FirstProductName.Text;
    }

    public string GetProductPrice()
    {
        return $"{FirstProductPrice1.Text},{FirstProductPrice2.Text} {FirstProductPrice3.Text}";
    }

    public void Login()
    {
        UserLogin.Click();
        UserEmail.SendKeys("lubosrohlik@email.cz");
        UserPassword.SendKeys("bububububu");
        UserSignIn.Click();
    }

    public void AddFirstProductToCart()
    {
        FirstProductAdd.Click();
    }

    public void OpenBasket()
    {
        BasketCounter.Click();
    }
}
