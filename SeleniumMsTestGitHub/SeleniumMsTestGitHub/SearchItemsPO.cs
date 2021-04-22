using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumDemoMsTest.PageObjects
{
    public class SearchItemsPO
    {
        private IWebDriver _driver;
        public SearchItemsPO(IWebDriver driver)
        {
            _driver = driver;
        }
        public SearchItemsPO() { }


        public IWebElement WholePage => _driver.FindElement(By.XPath("//div[@id='page']"));
        public IWebElement Banner => _driver.FindElement(By.XPath("//div[@class='banner']"));
        public IWebElement CallUsNow => _driver.FindElement(By.XPath("//span[@class='shop-phone' and text()='Call us now: ']"));
        public IWebElement SearchBox => _driver.FindElement(By.XPath("//input[@id='search_query_top' and @name='search_query']"));
        public IWebElement ContactUs => _driver.FindElement(By.XPath("//div[@id='contact-link']//a[@title='Contact Us']"));
        public IWebElement SignIn => _driver.FindElement(By.XPath("//div[@class='header_user_info']//a[@title='Log in to your customer account']"));
        public IWebElement StoreLogo => _driver.FindElement(By.XPath("//img[@class='logo img-responsive' and @alt='My Store']"));
        public IWebElement ShoppingCart => _driver.FindElement(By.XPath("//div[@class='shopping_cart']//following::a[@title='View my shopping cart']"));
        public IWebElement MenuContent => _driver.FindElement(By.XPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']"));
        public IWebElement HomepageSlicer => _driver.FindElement(By.XPath("//div[@id='homepage-slider']"));
        public ReadOnlyCollection<IWebElement> ContentItemCards => _driver.FindElements(By.XPath("//div[@id='htmlcontent_top']//following::li[contains(@class, 'htmlcontent')]"));
        public ReadOnlyCollection<IWebElement> HomepageTabs => _driver.FindElements(By.XPath("//ul[@id='home-page-tabs']//li"));
        public ReadOnlyCollection<IWebElement> ProductImageLinks => _driver.FindElements(By.XPath("//ul[@id='homefeatured']//img[contains(@class, 'replace-2x img-responsive')]"));
        public ReadOnlyCollection<IWebElement> CustomInfoBlocks => _driver.FindElements(By.XPath("//div[@id='cmsinfo_block']//div[@class='col-xs-6']"));
        public ReadOnlyCollection<IWebElement> CustomInfoEachBlocks => _driver.FindElements(By.XPath("//div[@id='cmsinfo_block']//div[@class='col-xs-6']//ul//li"));
        public IWebElement FacebookBlock => _driver.FindElement(By.XPath("//div[@id='facebook_block']"));
        public IWebElement EditorialBlock => _driver.FindElement(By.XPath("//div[@id='editorial_block_center']"));
        public IWebElement FooterContainer => _driver.FindElement(By.XPath("//div[@class='footer-container']"));

        //Search Box
        public IWebElement SearchInputBox => _driver.FindElement(By.XPath("//input[@id='search_query_top']"));
        public IWebElement SearchButton => _driver.FindElement(By.XPath("//button[@class='btn btn-default button-search']"));
        public IWebElement SearchHeading => _driver.FindElement(By.XPath("//h1[@class='page-heading  product-listing']"));
        public IWebElement SearchItemLighter => _driver.FindElement(By.XPath("//span[@class='lighter']"));
        public IWebElement SearchResultFound => _driver.FindElement(By.XPath("//span[@class='heading-counter']"));
        public IWebElement NoSearchItemFound => _driver.FindElement(By.XPath("//p[@class='alert alert-warning']"));
        public ReadOnlyCollection<IWebElement> SearchResultItems => _driver.FindElements(By.XPath("//div[@class='product-container']"));
        public ReadOnlyCollection<IWebElement> ItemContainers => _driver.FindElements(By.XPath("//div[@class='product-container']"));
        public ReadOnlyCollection<IWebElement> AddToCartButtons => _driver.FindElements(By.XPath("//a[@class='button ajax_add_to_cart_button btn btn-default' and @title='Add to cart']"));
        public ReadOnlyCollection<IWebElement> MoreButtons => _driver.FindElements(By.XPath("//a[@class='button lnk_view btn btn-default' and @title='View']"));
        public ReadOnlyCollection<IWebElement> InStockCards => _driver.FindElements(By.XPath("//span[@class='available-now']"));
        public ReadOnlyCollection<IWebElement> QuickViewButtons => _driver.FindElements(By.XPath("//a[@class='quick-view']"));
        public IWebElement PopupProduct => _driver.FindElement(By.TagName("iframe"));
        public IWebElement ProductImage => _driver.FindElement(By.XPath("//body[@id='product']"));
        public IWebElement CloseButton => _driver.FindElement(By.XPath("//a[@title='Close' and @class='fancybox-item fancybox-close']"));

    }
}
