using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumInterviewTest
{


    class FrameWork
    {
        private static IWebDriver driver = null;
        private static IJavaScriptExecutor js = null;

        static public void Init(IWebDriver driverx)
        {
            driver = driverx;
            js = (IJavaScriptExecutor)driver;
        }

        public static bool WaitForElementPresent(By by)
        {
            bool returnBool = false;
            bool resultBool = false;
            int counter = 0;
            while (true)
            {
                resultBool = IsElementPresentSilent(by);
                
                if (resultBool == true)
                {
                    Highlight(by, 6);
                    returnBool = true;
                    break;
                }
                else
                {
                    //Keep Looking;
                }

                if (counter == 40)
                {
                    break;
                }

                Thread.Sleep(1000);
                counter++;
            }


            return returnBool;
        }
        public static bool WaitForElementNotPresent(By by)
        {
            bool returnBool = false;
            bool resultBool = false;
            int counter = 0;
            Thread.Sleep(1000);
            while (true)
            {

                if (driver.FindElement(by).Displayed)
                {
                    Highlight(by, 6);
                    //keep going
                }
                else
                {
                    //not found so break;
                    returnBool = true;
                    break;
                }

                if (counter == 10)
                {
                    break;
                }

                Thread.Sleep(1000);
                counter++;
            }


            return returnBool;
        }

        public static bool IsElementPresentSilent(By by)
        {

            bool returnBool = true;
            try
            {
                IWebElement element = driver.FindElement(by);
                if (element != null)
                {
                    if (element != null)
                    {

                        returnBool = true;
                    }
                    else
                    {
                        returnBool = false;
                    }
                }
                else
                {

                }

            }
            catch (NoSuchElementException e)
            {

                returnBool = false;
            }


            return returnBool;
        }



        public static void Highlight(By by, int blinkCount)
        {

            if (js != null)
            {
                int count = 0;
                IWebElement tempElement = driver.FindElement(by);

                while (count < blinkCount)
                {
                    //string title = (string)js.ExecuteScript("return document.title");
                    js.ExecuteScript("arguments[0].style.border='2px solid red'", tempElement);
                    Thread.Sleep(50);
                    js.ExecuteScript("arguments[0].style.border='2px solid white'", tempElement);
                    Thread.Sleep(50);
                    count++;
                }
            }
            else
            {
            }

        }

        public static void Highlight(IWebElement tempElement, int blinkCount)
        {

            if (js != null)
            {
                int count = 0;
                while (count < blinkCount)
                {
                    //string title = (string)js.ExecuteScript("return document.title");
                    js.ExecuteScript("arguments[0].style.border='2px solid red'", tempElement);
                    Thread.Sleep(50);
                    js.ExecuteScript("arguments[0].style.border='2px solid white'", tempElement);
                    Thread.Sleep(50);
                    count++;
                }
            }
            else
            {
            }

        }

        public static void ClickButton(IWebElement element)
        {

            Highlight(element, 1);
            element.Click();
        }

        //used for stale elements
        public static void ClickButton(By by)
        {
            IWebElement element = driver.FindElement(by);
            Highlight(element, 4);
            element.Click();
        }

        public static void RefeshPage()
        {
            driver.Navigate().Refresh();
        }

        public void ScrollToElement(By by)
        {
            var element = driver.FindElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static String GetText(By by)
        {
            String returnString = null;
            IWebElement resultElement = driver.FindElement(by);
            if (resultElement != null)
            {
                Highlight(resultElement, 1);
                returnString = resultElement.GetAttribute("value");
            }
            else
            {
  
            }
            return returnString;
        }

        public static void SetTextBoxValue(By by, String value)
        {
            IWebElement element = driver.FindElement(by);
            element.SendKeys(value);
        }

        public static bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
    }//class
}//namespace
