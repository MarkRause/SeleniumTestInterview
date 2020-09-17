using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInterviewTest
{
    
    class PageShoppingCartSummary : CloudAutomation
    {

        private readonly By ShoppingCartSummary = By.XPath("//h1[@id='cart_title'][contains(text(), 'Shopping-cart summary')]");
        private readonly By ProceedToCheckout = By.XPath("(//span[contains(text(), 'Proceed to checkout')])[2]");//[2]

        public PageShoppingCartSummary()
        {
        }

        public bool WaitForCart()
        {
            return FrameWork.WaitForElementPresent(ShoppingCartSummary);
        }

        public void SelectProceedToCheckout()
        {
            FrameWork.ClickButton(ProceedToCheckout);
        }
        public void HighlightProceedToCheckout()
        {
           FrameWork.Highlight(ProceedToCheckout, 4);
        }

        public void ScrollToProceedToCheckout()
        {
            var element = driver.FindElement(ProceedToCheckout);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }



    }
}
