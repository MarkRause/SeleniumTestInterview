using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInterviewTest
{
    class PopUpAddToCart : CloudAutomation
    {
        private readonly By AddedToCartCheck = By.XPath("//i[@class='icon-ok']");
        private readonly By X = By.XPath("//i[@class='icon-ok']");
        private readonly By ContinueShopping = By.XPath("//span[@title='Continue shopping']");
        private readonly By ProceedToCheckout = By.XPath("//a[@title='Proceed to checkout']");

        public PopUpAddToCart()
        {
        }

        public bool WaitForCAddToCart()
        {
            return FrameWork.WaitForElementPresent(AddedToCartCheck);
        }

        public bool CheckCartCount(int count)
        {
            By quantity = By.XPath("//span[@class='ajax_cart_quantity'][contains(text(), '" + count.ToString() + "')]");
            return FrameWork.WaitForElementPresent(quantity);
        }

        public void SelectX()
        {
            FrameWork.ClickButton(X);
        }

        public void SelectContinueShopping()
        {
            FrameWork.ClickButton(ContinueShopping);
        }

        public void SelectProceedToCheckout()
        {
            FrameWork.ClickButton(ProceedToCheckout);
        }

    }
}
