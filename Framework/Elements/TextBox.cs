using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using demo.framework.Elements;

namespace demo.framework.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, String name) : base(locator, name){}

        public void SetText(String text)
        {
            WaitForElementPresent();
            GetElement().SendKeys(text);
            Log.Info(String.Format("{0} :: type text '{1}'", GetName(), text));
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
