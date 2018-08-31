using OpenQA.Selenium;

namespace SampleApplicationFrameWork
{
    internal class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }



    }
}