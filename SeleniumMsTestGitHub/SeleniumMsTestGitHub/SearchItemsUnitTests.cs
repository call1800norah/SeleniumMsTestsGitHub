using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoMsTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SeleniumDemoMsTest.PageUnitTests
{
    [TestClass]
    public class SearchItemsUnitTests : UnitTestBase
    {
        private SearchItemsPO searchItemsPO;
        /// <summary>
        /// Searchbox test for valid and invalid input and see the outcome
        /// </summary>
        [TestMethod]
        public void SearchInputBoxTest()
        {
            searchItemsPO = new SearchItemsPO(_driver);

            //validate homepage loading
            VerifyHomePageLoadTest();

            //Input invalid value in the searchbox 
            searchItemsPO.SearchInputBox.SendKeys("pants");
            searchItemsPO.SearchButton.Click();

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(e => searchItemsPO.SearchHeading.Displayed);

            Assert.IsTrue(searchItemsPO.SearchHeading.Text.Contains("0 results have been found."),
                $"{nameof(searchItemsPO.SearchHeading)} was not displayed.");
            Assert.IsTrue(searchItemsPO.NoSearchItemFound.Text.Contains("No results were found"),
                $"{nameof(searchItemsPO.NoSearchItemFound)} was not displayed.");

            //Input valid value in the search box
            searchItemsPO.SearchInputBox.Clear();
            searchItemsPO.SearchInputBox.SendKeys("printed dress");
            searchItemsPO.SearchButton.Click();

            wait.Until(e => searchItemsPO.SearchHeading.Displayed);
            wait.Until(e => searchItemsPO.SearchResultItems.Where(e1 => e1 != null).Where(e1 => e1.Displayed));

            //Select items by hovering over
            Actions action = new Actions(_driver);
            action.MoveToElement(searchItemsPO.SearchResultItems.FirstOrDefault()).Perform();
            WaitForElementDisplayed(searchItemsPO.SearchResultItems.FirstOrDefault());

            Assert.IsTrue(searchItemsPO.QuickViewButtons.FirstOrDefault().Displayed,
                $"{searchItemsPO.QuickViewButtons.FirstOrDefault()} was not displayed.");
            Assert.IsTrue(searchItemsPO.AddToCartButtons.FirstOrDefault().Displayed,
               $"{searchItemsPO.AddToCartButtons.FirstOrDefault()} was not displayed.");
            Assert.IsTrue(searchItemsPO.MoreButtons.FirstOrDefault().Displayed,
                $"{searchItemsPO.MoreButtons.FirstOrDefault()} was not displayed.");
            searchItemsPO.QuickViewButtons.FirstOrDefault().Click();

            //Validate the popup item that is iframe content
            _driver.SwitchTo().Frame(searchItemsPO.PopupProduct);
            wait.Until(e => searchItemsPO.ProductImage != null && searchItemsPO.ProductImage.Displayed);

            var isPopupProductDisplayed = searchItemsPO.ProductImage.Displayed ? true : false;
            if (isPopupProductDisplayed)
            {
                //Switch back to noniframe contant
                _driver.SwitchTo().DefaultContent();

                //Close popup item
                WaitForElementDisplayed(searchItemsPO.CloseButton, 30);
                Thread.Sleep(5000);
                searchItemsPO.CloseButton.Click();
            }
        }
        /// <summary>
        /// Validate the homepage loading
        /// </summary>
        public void VerifyHomePageLoadTest()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            searchItemsPO = new SearchItemsPO(_driver);

            List<IWebElement> allElementDisplayed = new List<IWebElement>() { searchItemsPO.WholePage,
                searchItemsPO.Banner, searchItemsPO.CallUsNow,  searchItemsPO.ContactUs, searchItemsPO.SignIn,
                searchItemsPO.StoreLogo, searchItemsPO.SearchBox, searchItemsPO.ShoppingCart, searchItemsPO.MenuContent,
                searchItemsPO.HomepageSlicer, searchItemsPO.FacebookBlock, searchItemsPO.EditorialBlock, searchItemsPO.FooterContainer };

            IsEachElementDisplayed(allElementDisplayed);
            ElementCollectionDisplayed(searchItemsPO.ContentItemCards);
            ElementCollectionDisplayed(searchItemsPO.HomepageTabs);
            ElementCollectionDisplayed(searchItemsPO.ProductImageLinks);
            ElementCollectionDisplayed(searchItemsPO.CustomInfoBlocks);
            ElementCollectionDisplayed(searchItemsPO.CustomInfoEachBlocks);

            Assert.IsTrue(searchItemsPO.CallUsNow.Text.Contains("Call us"));
            Assert.AreEqual("Contact us", searchItemsPO.ContactUs.Text);
            Assert.AreEqual("Sign in", searchItemsPO.SignIn.Text);
            Assert.IsTrue(searchItemsPO.ShoppingCart.Text.Contains("Cart"));
        }
    }
}
