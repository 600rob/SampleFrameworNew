using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SampleApplicationFrameWork
{
    public class BasePage
    {
        //make the driver protected, in order for child classes to be able to access it
        // * We've currently set the Driver as a field but we can specifiy the driver as a property with an with auto implemented get and set. This just helps because it
        //the ide provides a reference to where the item is used. For example : protected IWebDriver Driver{get;set;} 
        //(i think referencing only works in VS2017)
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
       }

   
    }
}