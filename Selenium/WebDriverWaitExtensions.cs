using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Rohlik.Selenium;

public static class WebDriverWaitExtensions
{
    public static void TryUntil<T>(this WebDriverWait wait, Func<IWebDriver, T> condition)
    {
        Assert.That(() => wait.Until(condition), Throws.Nothing);
    }
}
