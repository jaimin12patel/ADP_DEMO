using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Nunit_ADP_Test_Demo.BaseClass
{
    public class Configuring_The_chrome
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup_Chrome()
        {
            driver = new ChromeDriver("/Users/DIPAKPATEL/Documents/webdriver");
            driver.Url = "https://runpayroll.adp.com";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void close_chrome()
        {
            driver.Quit();
        }
    }
}
