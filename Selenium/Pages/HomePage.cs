using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Rohlik.Selenium.Pages;

public class HomePage(IWebDriver driver)
{
    public static string Url => "https://www.rohlik.cz/";
    public IWebDriver Driver { get; set; } = driver;
    public WebDriverWait Wait { get; set; } = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

    public string Title => Driver.Title;
    public IWebElement Aside => Driver.FindWebElement(Driver, By.TagName("aside"));

    public IWebElement UserLogin => Driver.FindWebElement(Driver, By.CssSelector("div[data-test='header-user-icon']"));
    public IWebElement UserEmail => Driver.FindWebElement(Driver, By.Id("email"));
    public IWebElement UserPassword => Driver.FindWebElement(Driver, By.Id("password"));
    public IWebElement UserSignIn => Driver.FindWebElement(Driver, By.CssSelector("button[data-test='btnSignIn']"));

    public IWebElement FirstProduct => Driver.FindWebElement(Driver, By.CssSelector("div[data-test='productCard-header-counterButton']"));
    public IWebElement BasketCounter => Driver.FindWebElement(Driver, By.CssSelector("div[data-test='cart-header-wrapper'] div p"));

    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl(Url);
        Aside.GetShadowRoot().FindElement(By.CssSelector("#accept")).Click();
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
        FirstProduct.Click();
    }
}
