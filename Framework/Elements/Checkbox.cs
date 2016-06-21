using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace demo.framework.Elements
{
    public class Checkbox : BaseElement
    {
        public Checkbox(By locator, string name) : base(locator, name) {}
        public void CheckCheckbox(String text)
        {
            WaitForElementPresent();
            GetElement().Click();
        }

        /// <summary>
        /// clear inpuit field and then set text into it
        /// </summary>
        /// <param name="text">text to fill</param>
        public void ClearAndSetText(String text)
        {
            WaitForElementPresent();
            GetElement().Clear();
            GetElement().SendKeys(text);
        }
    }
}
