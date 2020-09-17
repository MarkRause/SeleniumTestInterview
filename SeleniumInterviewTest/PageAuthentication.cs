using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumInterviewTest
{
    class PageAuthentication : CloudAutomation
    {

        private readonly By Authentication = By.XPath("//h1[@class='page-heading'][contains(text(), 'Authentication')]");
        private readonly By email = By.Id("email");
        private readonly By passwd = By.Id("passwd");
        private readonly By SubmitLogin = By.Id("SubmitLogin");

        public PageAuthentication()
        {
        }

        public bool WaitForAuthentication()
        {
            return FrameWork.WaitForElementPresent(Authentication);
        }

        public bool EnterEmail(String emailAddress)
        {
            FrameWork.SetTextBoxValue(email, emailAddress);
            String resultText = FrameWork.GetText(email);
            StatusOutput("resultText:" + resultText.ToString());
            if (resultText.Equals(emailAddress) == true)
                return true;
            else
                return false;
        }

        public bool EnterPwd(String password)
        {
            FrameWork.SetTextBoxValue(passwd, password);
            String resultText = FrameWork.GetText(passwd);
            StatusOutput("resultText:" + resultText.ToString());
            if (resultText.Equals(password) == true)
                return true;
            else
                return false;
        }

        public void SelectSignIn()
        {
            FrameWork.ClickButton(SubmitLogin);
        }
        

    }
}

