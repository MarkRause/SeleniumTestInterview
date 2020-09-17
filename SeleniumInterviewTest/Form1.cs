using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Mark Rauseo Selenium Test 
//To run %Path%\SeleniumInterviewTest\SeleniumInterviewTest\bin\x64\Release\SeleniumInterviewTest.exe
//Chromedriver Webdriver version Notes
//Install-Package Selenium.Chrome.WebDriver -Version 85.0.0 -> webdriver.dll https://chromedriver.storage.googleapis.com/index.html?path=86.0.4240.22/
//v85.0.4183.87 - Chrome Driver 85.0.4183.87 release
//85.0.4183.87 chomedriver.exe https://chromedriver.storage.googleapis.com/index.html?path=85.0.4183.87/

namespace SeleniumInterviewTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private string startPath = Directory.GetCurrentDirectory();


        delegate void SetControlTextCallback(Control control, string text);
        public void SetControlTextValue(Control control, string text)
        {
            //to remedy crossthreading errors while using selenium and Winforms
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBox1.InvokeRequired)
            {
                SetControlTextCallback d = new SetControlTextCallback(SetControlTextValue);
                Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        delegate void ClearListBoxCallback();
        delegate void SetListBoxCallback(System.Windows.Forms.ListBox listBox, string text);
        public void SetListBoxText(System.Windows.Forms.ListBox listBox, string text)
        {
            try
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (listBox.InvokeRequired)
                {
                    SetListBoxCallback d = new SetListBoxCallback(SetListBoxText);
                    Parent.Invoke(d, new object[] { listBox, text });
                }
                else
                {
                    listBox.Items.Add(text);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {

            }
        }

        public void AppendControlTextValue(Control control, string text)
        {
            if (textBox1.InvokeRequired)
            {
                SetControlTextCallback d = new SetControlTextCallback(SetControlTextValue);
                Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public void StatusOutput(string text)
        {
            SetListBoxText(listBox1, text);
        }

        public void UrlOutput(string text)
        {
            SetControlTextValue(textBox1, text);
        }

        public void Reset()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                StatusOutput("Exception:" + ex.ToString());
            }
        }

        private void RunTest_Click(object sender, EventArgs e)
        {
            bool IsNetworkAvailable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            StatusOutput("TestsAPI() Network:" + IsNetworkAvailable.ToString());

            CloudAutomation cloudAutomation = new CloudAutomation(this);

            bool resultBool = cloudAutomation.RunScript();
         

            Reset();


            StatusOutput("Done Test()");
        }
    }
}
