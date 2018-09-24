using System;

using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SampleApplicationFrameWork
{
    [TestFixture]
    //name your class somethign that represents a feature or PBI then put all the tests for that item in the class
    public class SampleApplicationPageTests
    {


        private IWebDriver Driver;
        private TestUser testUser;
        private TestUser testUser1;
        private TestUser eTestUser;
        private SampleAplicationPage sampleApplicationPage;

        [SetUp]
        public void initialiseTest()
        {
            Driver = GetChromeDriver();
            sampleApplicationPage = new SampleAplicationPage(Driver);

            testUser = new TestUser();
            testUser.firstName = "chew";
            testUser.lastName = "bacca";
            testUser.genderType = Gender.Other;

            eTestUser = new TestUser();
            eTestUser.eFirstName = "emerguser";
            eTestUser.eLastName = "emerglasname";
            eTestUser.genderType = Gender.eOther;

            testUser1 = new TestUser();
            testUser1.firstName = "princess";
            testUser1.lastName = "leah";
            testUser1.genderType = Gender.Female;



        }

        [Test]
        public void GotToPage1andSubmitForm()
        //tests with a user gender of other
        {


            sampleApplicationPage.goTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            sampleApplicationPage.selectAGender(testUser.genderType, eTestUser.genderType);

            //FillOutFormAndSubmit method needs to return a ultimateQAHomePage so dont forget to set this return 
            //type on the method
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
            AssertPageVisible(ultimateQAHomePage);

        }

      

        [Test]
        public void GotToPage1andSubmitFormFemale()
        //tests with a user gender of female
        {

            
            sampleApplicationPage.goTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            sampleApplicationPage.selectAGender(testUser1.genderType, eTestUser.genderType);

            //FillOutFormAndSubmit method needs to return a ultimateQAHomePage so dont forget to set this return 
            //type on the method
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(testUser1);
            AssertPageVisible(ultimateQAHomePage);





        }








        [Test]
        public void goToPage4AndSubmitForm2Users()
        {
           
           
            sampleApplicationPage.goTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

            sampleApplicationPage.selectAGender(testUser.genderType, eTestUser.genderType);

            //FillOutFormAndSubmit method needs to return a ultimateQAHomePage so dont forget to set this return 
            //type on the method
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit2Users(testUser, eTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        [TearDown]
        public void stopDriver()
        {
            Driver.Close();
            Driver.Quit();
       }



        //helper methods


        private IWebDriver GetChromeDriver()
       {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //pass the path to our new driver
            return new ChromeDriver(path);
            
            //create an explicit wait for reuse

        }


       

        private static void AssertPageVisible(ultimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "test page not visible");
        }



        [Test]
        public void quikTest()
        {
            Driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/basic_html_form.html");

            IWebElement multiSelect = Driver.FindElement(By.CssSelector("select[multiple = 'multiple']"));

            IReadOnlyList<IWebElement> selectOptions = multiSelect.FindElements(By.TagName("option"));
                
                
                
               



        }

      
    
      
    }
}
