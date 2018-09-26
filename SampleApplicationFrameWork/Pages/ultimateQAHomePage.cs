using OpenQA.Selenium;

namespace SampleApplicationFrameWork
{
    public class ultimateQAHomePage
    {

        private IWebDriver Driver;
        
       
        
        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start learning now"));

   
        public ultimateQAHomePage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        // How this constructor works:  when we create a new ultimateQAHomPage object we pass it a driver which comes from the base class.
        //This is because the Base class is inherited by all of out test classes. Each test class, instantiating new page objects when they are required) 
        //before the ultimateQAHomePage is uses driver we call the base class, passing it the same driver.
        





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