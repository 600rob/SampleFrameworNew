using OpenQA.Selenium;

namespace SampleApplicationFrameWork
{
    internal class ultimateQAHomePage : BasePage
    {
        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start learning now"));

public ultimateQAHomePage(IWebDriver driver) : base(driver){}



        public bool IsVisible
        {
            get
            {
                return StartHereButton.Displayed;
            }
            internal set { }
        }

        


        //we can rewrite the get in shorthand line this

        //public bool IsVisible => driver.FindElement(By.LinkText("Start here")).Displayed;

    }
}