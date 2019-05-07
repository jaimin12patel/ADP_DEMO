using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Nunit_ADP_Test_Demo.BaseClass;
using System.Threading;

namespace Nunit_ADP_Test_Demo.BaseClass
{
    [TestFixture]
    public class Adp_Login_Scenario : Configuring_The_chrome
    {
        public IWebElement email;
        public IWebElement pass;
        public IWebElement sub;
        [Test]
        //This Test case method will going to fail due the error messag pop-up 
        public void Login_Negative_Empty_Username_pass()
        {
            //Writing email with only space
            email = driver.FindElement(By.Id("txtLoginId"));
            email.SendKeys("");

            //Click on Submit Button to verify the error message on different page.
            sub = driver.FindElement(By.Id("btnNext"));
            sub.Click();
            Thread.Sleep(10000);

            //Writing pass with only Space
            //IWebElement pass = driver.FindElement(By.Id("btnNext"));
            //pass.SendKeys("         ");

            //Checking displed error message
            var err = driver.FindElement(By.XPath("//*[@id=\"generic-message-dialog\"]/div/div[1]/p/span/span[2]")).Text;
            Console.Write("Actual Message" + err);
            string expectedTooltip = "Something isn't quite right";
            Assert.AreEqual(expectedTooltip, err);
        }
        [Test]
        public void Login_Positive_Username_pass()
        {
            //Writing valid USername 
            email = driver.FindElement(By.XPath("//*[@id=\"txtLoginId\"]"));
            email.SendKeys("Wavetest004");
            Thread.Sleep(4000);

            //Click on Next Button to verify username on next page
            sub = driver.FindElement(By.XPath("//*[@id=\"btnNext\"]"));
            sub.Click();
            Thread.Sleep(4000);

            //Checking username displayed on next page or not
            var username = driver.FindElement(By.XPath("//*[@id=\"generic-message-dialog\"]/div/div[1]/p/span/span[2]")).Text;
            Console.Write("Actual Message" + username);
            string expectedTooltip = "Hello Wavetest004";
            Assert.AreEqual(expectedTooltip, username);

            //Writing valid USername 
            pass = driver.FindElement(By.Id("PASSWORD"));
            pass.SendKeys("test7711");

            //Click on Next Button to verify username on next page
            sub = driver.FindElement(By.Id("btnNext"));
            sub.Click();
            Thread.Sleep(4000);

            //Checking welcome messge after successfully logged in 
            var success = driver.FindElement(By.Id("UserWelcome")).Text;
            Console.Write("Actual Message" + success);
            string expectedsuccess = "Welcome, NileshFirst Contact Last4";
            Assert.AreEqual(expectedsuccess, username);
        }

    }
}