using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.Forms
{
    public class CatalogPage : BaseForm
    {
        private Checkbox select_parametr = new Checkbox(By.XPath("//span[@class='schema-filter__checkbox-text'][contains(.,'" + RunConfigurator.GetValue("model") + "')]"), "select" + RunConfigurator.GetValue("model"));
        private Link product = new Link(By.XPath("//a[@class='catalog-bar__link catalog-bar__link_strong'][contains(.,'" + RunConfigurator.GetValue("product") + "')]"), "go to " + RunConfigurator.GetValue("product"));
        private TextBox price = new TextBox(By.XPath("//div[2]/input[contains(@class, 'schema-filter__number-input_price')]"), "type maximum price");
        private TextBox year = new TextBox(By.XPath("//div[3]/div/div[1]/input[contains(@class, 'schema-filter__number-input')]"), "type year of entry");
        private Dropdown from_diagonal = new Dropdown(By.XPath("//div[1]/select[contains(.,'"+ RunConfigurator.GetValue("from_diagonal")+"')]"), "select first diagonal from dropdown list");
        private Dropdown till_diagonal = new Dropdown(By.XPath("//div[2]/select[contains(.,'"+ RunConfigurator.GetValue("from_diagonal")+"')]"), "select second diagonal from dropdown list");

        public CatalogPage() : base(By.XPath("//*"), "catalog of onliner by")
        {
        }

        public void Select_Catalog_Product()
        {
            
            product.Click();
            Browser.WaitForPageToLoad();

        }
        public void Select_Model_Parametr()
        {
            select_parametr.Click();
            Browser.WaitForPageToLoad();
        }

        public void Select_Price_Parametr(string parametr)
        {
            price.SetText(parametr);
            Browser.WaitForPageToLoad();
        }

        public void Select_Year_Parametr(string parametr)
        {
            year.SetText(parametr);
            Browser.WaitForPageToLoad();
        }

        public void Select_First_Diagonal_Parametr(string parametr)
        {
            from_diagonal.Select(parametr);
            Browser.WaitForPageToLoad();
        }

        public void Select_Second_Diagonal_Parametr(string parametr)
        {
            till_diagonal.Select(parametr);
            Browser.WaitForPageToLoad();
        }


    }
}
