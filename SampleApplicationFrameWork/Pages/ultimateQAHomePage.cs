using OpenQA.Selenium;

namespace SampleApplicationFrameWork
{
    public class ultimateQAHomePage : BasePage
    {
        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start learning now"));

        //since this is a derrived class, the consructor is a little differetnt in that it uses colon base.
        //i.e.   :base{driver}   This is the base keyword
        //The use of the base keyword allows you to access the base class members directly at any time from a
        //So what actually happens here is that when we create an ultimateQAHomePage we pass in a driver
        // we also pass that same driver into the base class constructor
        public ultimateQAHomePage(IWebDriver driver) : base(driver){}
        // How this constructor works:  when we create a new ultimateQAHomPage object we pass it a driver, 
        //before the ultimateQAHomePage is uses driver we call the base class, passing it the same driver.
        //the base class constructor then sets Driver to the diver that we passed in.
        //because Driver is protected, we can now use it for all of the methods on our newly instantiared page






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