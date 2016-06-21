using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;


namespace demo.framework.Forms
{
    public class HomePage:BaseForm
    {
        private Link lbLogo = new Link(By.CssSelector(".onliner_logo"), "onliner.by logo");
        private Link catalog = new Link(By.XPath("//span[contains(.,'Каталог')]"), "go to Catalog");

        public HomePage() : base(By.XPath("//*"), "onliner.by")
        {
        }
        
        public void AssertLogo()
        {
            Assert.AreEqual(lbLogo.IsPresent(), true);
        }

        public void ClickCatalogMenu()
        {
            catalog.Click();
            Browser.WaitForPageToLoad();

        }
    }
}
