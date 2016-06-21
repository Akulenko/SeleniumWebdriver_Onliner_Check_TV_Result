using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace demo.framework.Elements
{
    public class Dropdown : BaseElement
    {
        public Dropdown(By locator, string name) : base(locator, name)
        {
        }

        public void SelectValue(String text)
        {        
            Select(text);
            Log.Info(String.Format("{0} :: type text '{1}'", GetName(), text));
        }
    }
}
