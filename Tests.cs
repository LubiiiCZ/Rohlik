using OpenQA.Selenium;
using Rohlik.Selenium;
using Rohlik.Selenium.Pages;

namespace Rohlik;

public class Tests
{
    protected IWebDriver? WebDriver { get; set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        WebDriver = DriverFactory.CreateDriver(false);
    }

    [Test]
    public void HomePageTest()
    {
        using (Assert.EnterMultipleScope())
        {
            HomePage homePage = new(WebDriver!);
            homePage.NavigateTo();
            Assert.That(homePage.Title, Is.EqualTo("Online supermarket Rohlik.cz — nejrychlejší doručení ve městě"), "Title does not match.");
            Assert.That(homePage.Aside.IsPresent(), Is.False, "Cookies still present.");

            //homePage.Login();

            var productName = homePage.GetProductName();
            var productPrice = homePage.GetProductPrice();
            homePage.AddFirstProductToCart();
            Assert.That(homePage.BasketCounter.Text, Is.EqualTo("1"), "Basket counter does not match.");

            homePage.OpenBasket();
            Assert.That(homePage.BasketItemName.Text, Is.EqualTo(productName), "Product name does not match.");
            Assert.That(homePage.BasketItemPrice.Text, Is.EqualTo(productPrice), "Product price does not match.");
        }
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Thread.Sleep(5000);
        WebDriver?.Quit();
        WebDriver?.Dispose();
    }
}
