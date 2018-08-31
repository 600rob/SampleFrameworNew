using OpenQA.Selenium;
using System;

namespace SampleApplicationFrameWork
{
    internal class SampleAplicationPage : BasePage
    {
        
        private string _testUrl = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-1/ ";

        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@id='submitForm']"));

        public SampleAplicationPage(IWebDriver driver) :base(driver){}



        public bool? IsVisible
        {
            get
            {
                return Driver.Title.Contains("Sample Application");
            }

            internal set { }
        }

       
        
           

        public void goTo()
        {
            Driver.Navigate().GoToUrl(_testUrl);
        }

        public ultimateQAHomePage FillOutFormAndSubmit(string firstname)
        {
            FirstNameField.SendKeys(firstname);
            SubmitButton.Click();

            return new ultimateQAHomePage(Driver);



        }
    }
}