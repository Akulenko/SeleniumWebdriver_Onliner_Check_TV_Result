using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace demo.framework
{
    [TestFixture]
    public class BaseTest : BaseEntity
    {
       [SetUp]
        public void SetUp()
       {
            Browser.GetInstance();
            Browser.GetDriver().Manage().Window.Maximize();
            Browser.GetDriver().Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            Browser.GetDriver().Quit();
        }
    }
}
