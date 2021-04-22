using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumDemoMsTest
{
    public class UnitTestBase
    {
        public IWebDriver _driver;
        public WebDriverWait wait;

        [TestInitialize]
        public void SetUpBrowser()
        {
            _driver = new ChromeDriver(@"C:\WebDriver\bin\");
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.Manage().Window.Maximize();
            Assert.AreEqual("My Store", _driver.Title);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
        /// <summary>
        /// Wait for IWebElement to be displayed using WebDriverWait
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        public void WaitForDisplayed(IWebElement element, int timeoutInSeconds = 10)
        {
            Assert.IsNotNull(element, $"nameof{element} returned as null!!");
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Message = $"nameof{element} timed out after {timeoutInSeconds}."
            };
            wait.Until(e => element.Displayed);
        }
        /// <summary>
        /// Verify a list of elements are all displayed.
        /// </summary>
        /// <param name="element"></param>
        public void IsEachElementDisplayed(List<IWebElement> element)
        {
            var isEachElementsDisplayed = element.Where(e => e != null).Aggregate((first, second) => first.Displayed ? second : first);
            Assert.IsTrue(isEachElementsDisplayed.Displayed, $"nameof{isEachElementsDisplayed} was not displayed.");
        }
        /// <summary>
        /// Verify a collection of elements are all displayed.
        /// </summary>
        /// <param name="elementList"></param>
        public void ElementCollectionDisplayed(ReadOnlyCollection<IWebElement> elementList)
        {
            var isElementCollectionDisplayed = elementList.Where(e => e != null).Aggregate((first, second) => first.Displayed ? second : first);
            Assert.IsTrue(isElementCollectionDisplayed.Displayed, $"nameof{isElementCollectionDisplayed} was not displayed.");
        }
        /// <summary>
        /// Wait for element to be displayed using WebDriverWait
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeout"></param>
        public void WaitForElementDisplayed(IWebElement element, int timeout = 15)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Message = $"{nameof(WaitForElementDisplayed)} timed out after {timeout} seconds."
            };
            wait.Until(ele => element.Displayed);
        }
    }
}
