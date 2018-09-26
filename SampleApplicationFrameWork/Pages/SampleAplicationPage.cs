using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleApplicationFrameWork
{
    public class SampleAplicationPage
    {
        // fields
        private string _sprint1Page = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-1/ ";
        private string _sprint2Page = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-2/";
        private string _sprint3Page = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-3/";
        private string _sprint4Page = "https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/";
        private IReadOnlyList<IWebElement> genderOptions;
        private IWebDriver Driver;




        //properties
        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement LastNameField => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        public IWebElement eFirstNameField => Driver.FindElement(By.XPath("//p//input[@name='firstname']"));
        public IWebElement eLastNameField => Driver.FindElement(By.XPath("//p//input[@name='lastname']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        //constructor. Using  This.Driver, sets our Driver object to the driver variable that gets passed
        //in when creating a new page object...this is the Driver that we create in out base class!
        // we could get rid of the this statment and just use a different driver instance, but this makes use of
        //the DRY prinicple do the same on all other pages.
        //could also inherit from the base page but we want to only do that on our test classes
        public SampleAplicationPage(IWebDriver driver)
        {
            this.Driver = driver;  
        }


        //page methods
       public void selectAGender(Gender gender1, Gender gender2)
        {
            IWebElement i = Driver.FindElement(By.XPath("//form[@action='https://www.ultimateqa.com']"));


            genderOptions = i.FindElements(By.XPath("//input[@type='radio']"));

            genderOptions[(int)gender1].Click();

            genderOptions[(int)gender2].Click();
        }








        //Page Actions as methods ( not webdriver actions)
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
            Driver.Navigate().GoToUrl(_sprint4Page);
            Driver.Manage().Window.Maximize();
            
        }

        public ultimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            FirstNameField.SendKeys(user.firstName);
            LastNameField.SendKeys(user.lastName);
            SubmitButton.Click();

            return new ultimateQAHomePage(Driver);



        }

        public ultimateQAHomePage FillOutFormAndSubmit2Users(TestUser testUser, TestUser eTestUser)
        {
            FirstNameField.SendKeys(testUser.firstName);
            LastNameField.SendKeys(testUser.lastName);
            eFirstNameField.SendKeys(eTestUser.eFirstName);
            eLastNameField.SendKeys(eTestUser.eLastName);

            SubmitButton.Click();

            return new ultimateQAHomePage(Driver);
        }
    }
}