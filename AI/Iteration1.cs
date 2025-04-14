/* generováno pomocí AI - zakomentováno z důvodu výskytu chyb

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace RohlicekTests
{
    public class BabyClubRegistrationTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
        }

        [Test]
        public void TestRohlicekBabyClubRegistration()
        {
            // Go to the registration page
            driver.Navigate().GoToUrl("https://www.rohlik.cz/rohlicek");

            // Wait for page to load
            Thread.Sleep(3000); // Use proper wait in production (e.g., WebDriverWait)

            // Accept cookies if needed
            try
            {
                var acceptCookies = driver.FindElement(By.CssSelector("button[data-testid='cookie-consent-accept']"));
                acceptCookies.Click();
                Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                // Cookie banner not shown
            }

            // Start registration (assuming a button or link leads to the form)
            driver.FindElement(By.XPath("//a[contains(text(),'Přidat se do klubu')]")).Click();

            Thread.Sleep(2000); // Wait for modal or form

            // Fill out registration form
            driver.FindElement(By.Name("firstName")).SendKeys("Testovací");
            driver.FindElement(By.Name("lastName")).SendKeys("Uživatel");
            driver.FindElement(By.Name("email")).SendKeys($"test{Guid.NewGuid()}@example.com");
            driver.FindElement(By.Name("phone")).SendKeys("123456789");
            driver.FindElement(By.Name("childBirthDate")).SendKeys("01.01.2024"); // Format may vary

            // Agree to terms
            driver.FindElement(By.CssSelector("input[name='terms']")).Click();

            // Submit form
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Thread.Sleep(3000); // Wait for success message

            // Validate success message or redirect
            Assert.IsTrue(driver.PageSource.Contains("Děkujeme za registraci") || driver.Url.Contains("dekujeme"),
                "Registration did not complete successfully.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
*/
