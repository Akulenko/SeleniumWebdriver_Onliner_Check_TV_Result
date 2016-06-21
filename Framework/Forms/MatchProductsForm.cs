using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using demo.framework.Models;

namespace demo.framework.Forms
{
    public class MatchProductsForm : BaseForm
    {
        private string model = "^\\S+";
        private string price = "^(\\s+)?\\d+";
        private string date = "^\\d+";
        private string diagonal = "^\\d+";

        private By byPrice = By.XPath("//tbody[2]//a[contains(@class,'primary')]");
        private By byDate = By.XPath("//tbody[4]//span[contains(@class,'value__text')]");
        private By byDiagonal = By.XPath("//tbody[5]/tr[4]//span[contains(@class,'value__text')]");
        private By byNameModel = By.XPath("//tbody[2]//span[contains(@class,'caption')]");

        public MatchProductsForm() : base(By.CssSelector(".catalog-wrapper_overflow-hidden"), "Match Result Page")
        {
        }

        
        public TV[] GetTvs()
        {
            Regex regex_model = new Regex(model);
            Regex regex_diagonal = new Regex(diagonal);
            Regex regex_price = new Regex(price);
            Regex regex_date = new Regex(date);

            IWebDriver driver = Browser.GetDriver();

            var modelNames = driver.FindElements(byNameModel);
            var dioganals = driver.FindElements(byDiagonal);
            var prices = driver.FindElements(byPrice);
            var dates = driver.FindElements(byDate);

            int modelsCount = modelNames.Count;
            TV[] tvs = new TV[modelsCount];

            for (int i = 0; i < modelsCount; i++)
            {
                Match modelNameMatch = regex_model.Match(modelNames[i].Text);
                Match dioganalMatch = regex_diagonal.Match(dioganals[i].Text);
                Match priceMatch = regex_price.Match(prices[i].Text);
                Match dateMatch = regex_date.Match(dates[i].Text);

                tvs[i] = new TV
                {
                    Model = modelNameMatch.Value,
                    Diagonal = dioganalMatch.Value,
                    Price = priceMatch.Value,
                    Date = dateMatch.Value
                };
            }

            return tvs;
        }

    }
}
