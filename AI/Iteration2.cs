/*
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace RohlicekTests
{
    public class BabyClubRegistrationTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestRohlicekBabyClubRegistration()
        {
            // Navigate to the Rohlíček page
            driver.Navigate().GoToUrl("https://www.rohlik.cz/rohlicek");

            // Accept cookies if the banner appears
            try
            {
                var acceptCookies = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid='cookie-consent-accept']")));
                acceptCookies.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Cookie banner not present
            }

            // Click on the button to start registration
            var joinClubButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Přidat se do klubu')]")));
            joinClubButton.Click();

            // Wait for the login form to appear and fill in credentials
            var emailField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("email")));
            emailField.SendKeys("testuser@example.com");

            var passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys("TestPassword123");

            var loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            loginButton.Click();

            // Wait for the age category selection to appear
            var ageCategoryOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[name='ageCategory'][value='0-12months']")));
            ageCategoryOption.Click();

            var continueButton = driver.FindElement(By.CssSelector("button.continue"));
            continueButton.Click();

            // Choose to add a new child
            var addChildButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.add-child")));
            addChildButton.Click();

            // Select gender
            var genderOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[name='gender'][value='boy']")));
            genderOption.Click();

            var nextButton = driver.FindElement(By.CssSelector("button.next"));
            nextButton.Click();

            // Fill in baby's name and date of birth
            var childNameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("childName")));
            childNameField.SendKeys("TestBaby");

            var dobField = driver.FindElement(By.Name("childDob"));
            dobField.SendKeys("01.01.2024");

            var submitButton = driver.FindElement(By.CssSelector("button.submit"));
            submitButton.Click();

            // Verify successful registration
            var successMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.success-message")));
            Assert.IsTrue(successMessage.Text.Contains("Děkujeme za registraci"), "Registration was not successful.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
*/
