using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInterviewTest
{
    class CloudAutomationHomePage : CloudAutomation
    {
        private readonly By MainPage = By.XPath("//div[@class='cat-title'][contains(text(), 'Categories')]");
        private readonly By Img = By.XPath("//img[@class='logo img-responsive']");
        
        private readonly By Dresses = By.XPath("(//a[@title='Dresses'])[2]");
        private readonly By AddToCart = By.XPath("//span[contains(text(),  'Add to cart')]");
 
        private readonly By DressesSku5 = By.XPath("//span[@itemprop='sku'][contains(text(), 'demo_5')]");
        private readonly By DressesSku6 = By.XPath("//span[@itemprop='sku'][contains(text(), 'demo_6')]");
        private readonly By DressesCat = By.XPath("//span[@class='cat-name'][contains(text(), 'Dresses')]");

        private readonly By AddedToCartCheck = By.XPath("//i[@class='icon-ok']");

        private readonly String SummerDressSku5 = "http://automationpractice.com/index.php?id_product=5&controller=product";
        private readonly String SummerDressSku6 = "http://automationpractice.com/index.php?id_product=6&controller=product";

        public CloudAutomationHomePage()
        {
        }

        public bool WaitForHomePage()
        {
            return FrameWork.WaitForElementPresent(MainPage);
        }
        public bool WaitForHomeImg()
        {
            return FrameWork.WaitForElementPresent(Img);
        }
        public void ClickDresses()
        {
            FrameWork.ClickButton(Dresses);
        }
        
        public bool SelectSummerDressSku5()
        {
            driver.Navigate().GoToUrl(SummerDressSku5);
            FrameWork.Highlight(DressesSku5, 5);
            return FrameWork.WaitForElementPresent(DressesSku5);
        }
        public bool SelectSummerDressSku6()
        {
            driver.Navigate().GoToUrl(SummerDressSku6);
            FrameWork.Highlight(DressesSku6, 5);
            return FrameWork.WaitForElementPresent(DressesSku6);
        }

        public bool WaitForDressesCat()
        {
            return FrameWork.WaitForElementPresent(DressesCat);
        }
               

        public bool SelectAddToCart()
        {
            bool returnBool = false;
            FrameWork.ClickButton(AddToCart);
            return returnBool;
        }

        public bool WaitForCAddToCart()
        {
            return FrameWork.WaitForElementPresent(AddedToCartCheck);
        }

        public bool WaitForCAddToCartNull()
        {
           return FrameWork.WaitForElementNotPresent(AddedToCartCheck);
        }

    }

}
