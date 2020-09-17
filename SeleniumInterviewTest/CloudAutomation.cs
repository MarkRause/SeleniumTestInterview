using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumInterviewTest
{
    /*
     Notes
      //Install-Package Selenium.Chrome.WebDriver -Version 85.0.0 -> webdriver.dll https://chromedriver.storage.googleapis.com/index.html?path=86.0.4240.22/
      //v85.0.4183.87 - Chrome Driver 85.0.4183.87 release
      //85.0.4183.87 chomedriver.exe https://chromedriver.storage.googleapis.com/index.html?path=85.0.4183.87/

        CloudAutomation (this)
             PageAuthentication
             PageShoppingCartSummary
             PopUpAddToCart
    */
    class CloudAutomation
    {
        protected Form1 Parent = null;
        public void SetParent(Form1 parentObj)
        {
            Parent = parentObj;
        }

        public void StatusOutput(string text)
        {
            if (Parent != null)
            {
                Parent.StatusOutput(text);
            }
        }

        protected String UrlOutput()
        {
            String currentUrl = null;
            if (driver != null)
            {
                currentUrl = driver.Url;
                if (currentUrl != null)
                {
                    StatusOutput(currentUrl);
                }
            }

            return currentUrl;
        }

        static protected IWebDriver driver = null;
        protected String url = null;

        public CloudAutomation()
        {
            //default constructor
        }

        public CloudAutomation(Form1 parentObj)
        {
            Parent = parentObj;
        }

        private bool Initialize()
        {
            bool returnBool = false;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            url = "http://automationpractice.com/index.php";
            FrameWork.Init(driver);
            return returnBool;
        }

        private bool Navigate()
        {
            bool returnBool = false;
            StatusOutput("Navigate()");
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);

            if (url == UrlOutput())
                returnBool = true;

            Thread.Sleep(1000);

            StatusOutput("Current url:" + url);
            return returnBool;
        }

        public bool RunScript()
        {
            bool returnBool = false;
            StatusOutput("RunScript()");

            bool resultInit = Initialize();

            bool resultUrl = FrameWork.RemoteFileExists(url);
            StatusOutput("resultUrl:" + resultUrl);

            bool resultNavigate = Navigate();
            StatusOutput("resultNavigate:" + resultNavigate);

            CloudAutomationHomePage cloudAutomationHomePage = new CloudAutomationHomePage();
            bool resultHomePage = cloudAutomationHomePage.WaitForHomePage();
            StatusOutput("resultHomePage:" + resultHomePage);

            bool resultHImg = cloudAutomationHomePage.WaitForHomeImg();
            StatusOutput("resultHImg:" + resultNavigate);

            cloudAutomationHomePage.ClickDresses();

            bool resultClickDresses = cloudAutomationHomePage.WaitForDressesCat();
            StatusOutput("resultClickDresses:" + resultClickDresses);

            cloudAutomationHomePage.SelectSummerDressSku5();
            UrlOutput();//should output summer dress A url

            cloudAutomationHomePage.SelectAddToCart();
            bool resultWaitForCart = cloudAutomationHomePage.WaitForCAddToCart();
            StatusOutput(" resultWaitForCart:" + resultWaitForCart);

            PopUpAddToCart popUpAddToCart = new PopUpAddToCart();
            bool resultAddedToCart = popUpAddToCart.WaitForCAddToCart();
            StatusOutput("resultAddedToCart:" + resultAddedToCart);

            bool resultcount1 = popUpAddToCart.CheckCartCount(1);
            StatusOutput("resultcount1:" + resultNavigate);

            popUpAddToCart.SelectContinueShopping();
            FrameWork.RefeshPage();
            
            bool resultAddedToCartNull = cloudAutomationHomePage.WaitForCAddToCartNull();//Add to cart page closed
            StatusOutput("resultAddedToCartNull:" + resultAddedToCartNull);

            cloudAutomationHomePage.SelectSummerDressSku6();
            UrlOutput();//should output summer dress B url
            
            cloudAutomationHomePage.SelectAddToCart();
            resultAddedToCart = cloudAutomationHomePage.WaitForCAddToCart();
            StatusOutput("resultAddedToCart:" + resultAddedToCart);
            
            bool resultcount2 = popUpAddToCart.CheckCartCount(2);
            StatusOutput("resultcount2:" + resultNavigate);

            popUpAddToCart.SelectProceedToCheckout();

            PageShoppingCartSummary pageShoppingCartSummary = new PageShoppingCartSummary();
            bool resultWaitForShoppingCartSummary = pageShoppingCartSummary.WaitForCart();
            StatusOutput("resultWaitForShoppingCartSummary:" + resultWaitForShoppingCartSummary);

            pageShoppingCartSummary.ScrollToProceedToCheckout();
            pageShoppingCartSummary.HighlightProceedToCheckout();
            pageShoppingCartSummary.SelectProceedToCheckout();
                        
            PageAuthentication pageAuthentication = new PageAuthentication();
            pageAuthentication.WaitForAuthentication();

            bool resultLogin = pageAuthentication.EnterEmail("MyEmailAddress@domain.com");
            StatusOutput("resultLogin:" + resultLogin);
            bool resultPassword = pageAuthentication.EnterPwd("MyPassword");
            StatusOutput("resultPassword:" + resultPassword);

            pageAuthentication.SelectSignIn();

            StatusOutput("Done with script");

            Thread.Sleep(2500);
            StatusOutput("Call Close()");
            bool resultClose = Close();

            StatusOutput("resultClose:" + resultClose);
            return returnBool;
        }

        private bool Close()
        {
            bool returnBool = false;
            if(driver != null)
            {
                driver.Close();
            }

            return returnBool;
        }


    }//class

}//namespace

