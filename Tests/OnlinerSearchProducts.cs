using System;
using NUnit.Framework;
using demo.framework;
using demo.framework.Forms;
using Assert = NUnit.Framework.Assert;

namespace demo.Tests
{
    class OnlinerSearchProducts:BaseTest
    {
        private readonly String _product = RunConfigurator.GetValue("product");
        private readonly String _model = RunConfigurator.GetValue("model");
        private readonly String _price = RunConfigurator.GetValue("price");
        private readonly String _data_entry = RunConfigurator.GetValue("data_entry");
        private readonly String _from_diagonal = RunConfigurator.GetValue("from_diagonal");
        private readonly String _till_diagonal = RunConfigurator.GetValue("till_diagonal");

        [Test]
        public void RunTest()
        {
            HomePage home_page = new HomePage();
            Log.Step(1);
            home_page.AssertLogo();
            Log.Step(2);
            home_page.ClickCatalogMenu();
            CatalogPage catalog = new CatalogPage();
            Log.Step(3);
            catalog.Select_Catalog_Product();
            Log.Step(4);
            catalog.Select_Model_Parametr();
            Log.Step(5);
            catalog.Select_Price_Parametr(_price);
            Log.Step(6);
            catalog.Select_Year_Parametr(_data_entry);
            Log.Step(7);
            catalog.Select_First_Diagonal_Parametr(_from_diagonal);
            Log.Step(8);
            catalog.Select_Second_Diagonal_Parametr(_till_diagonal);
            Log.Step(9, "Select all found  products for matching");
            SearchResultsForm result = new SearchResultsForm();
            result.Select_All_Founded_Product();
            Log.Step(10, "check that match the parameters ");
            MatchProductsForm page = new MatchProductsForm();
            var tvs = page.GetTvs();
            foreach (var tv in tvs)
            {
                Assert.AreEqual(_model, tv.Model);
                Assert.LessOrEqual(_price, tv.Price);
                Assert.LessOrEqual((_from_diagonal).Trim('"'), tv.Diagonal);
                Assert.GreaterOrEqual((_till_diagonal).Trim('"'), tv.Diagonal);
                Assert.LessOrEqual(_data_entry,tv.Date);
            }
        }

    }
}

