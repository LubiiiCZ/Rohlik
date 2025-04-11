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
        HomePage homePage = new(WebDriver!);
        homePage.NavigateTo();
        Assert.That(homePage.Title, Is.EqualTo("Online supermarket Rohlik.cz — nejrychlejší doručení ve městě"), "Title does not match.");

        //homePage.Login();

        homePage.AddFirstProductToCart();
        Assert.That(homePage.BasketCounter.Text, Is.EqualTo("1"), "Basket counter does not match.");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Thread.Sleep(5000);
        WebDriver?.Quit();
        WebDriver?.Dispose();
    }
}
