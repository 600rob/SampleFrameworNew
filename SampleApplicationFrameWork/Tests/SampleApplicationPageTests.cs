using System;

using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SampleApplicationFrameWork
{
    [TestFixture]
    //name your class somethign that represents a feature or PBI then put all the tests for that item in the class
    public class SampleApplicationPageTests
    {


        private IWebDriver Driver;

        [Test]
        public void GotToPage1andSubmitForm()
        {
            
            Driver = GetChromeDriver();

            //we want the page that we can go to
            var sampleApplicationPage = new SampleAplicationPage(Driver);
            sampleApplicationPage.goTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            //FillOutFormAndSubmit method needs to return a ultimateQAHomePage so dont forget to set this return 
            //type on the method
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit("robbo");
            Assert.IsTrue(ultimateQAHomePage.IsVisible);

            Driver.Close();
            Driver.Quit();

            

        }

        private IWebDriver GetChromeDriver()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //pass the path to our new driver
            return new ChromeDriver(path);
            
            //create an explicit wait for reuse

        }

      
    
      
    }
}
