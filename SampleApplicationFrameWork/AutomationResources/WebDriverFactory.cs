using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace SampleApplicationFrameWork
{
    public class WebDriverFactory
    {
        //So, the webdriver factory is a class that we use to create different browser types
        //when we call the create method. We can implement additional case statments and methods for each browser
        //type as we want to use them in our tests

        public IWebDriver Create(BrowserType browsertype)
        {
            switch(browsertype)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("the browser entered does not exist");
                   }

        }


        //helper methods for each driver
        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //pass the path to our new driver
            return new ChromeDriver(path);

            //create an explicit wait for reuse and possibly use this in each method?

        }
    }
}