using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Threading;
using demo.framework.Elements;
using NUnit.Core;
using OpenQA.Selenium.Support.UI;
using Rhino.Mocks;

namespace demo.framework.Forms
{
    public class SearchResultsForm : BaseForm
    {
       
        private Button match_result_button = new Button(By.CssSelector(".compare-button__sub_main"),"Match selected results");
        private By byResultItem = By.CssSelector("#schema-products .i-checkbox__faux");
        private By bySearchResultButtonIsActive = By.CssSelector(".schema-filter-button__state_animated"); 
        public SearchResultsForm() : base(By.XPath("//div[contains(@class,'catalog-content')]"), "Search Result Page")
        {
        }

        //метод выбирает все телевизоры отсортированные по параметрам для сравнения (нажимает чекбоксы и кнопку "Сравнить")
        public void Select_All_Founded_Product()
        {
            //Дима, вот здесь у меня валился тест. 
            //Как я поняла, у меня извлечение локаторов - чекбоксы рядом с каждой позицией товара (byResultItem),
            //начинались раньше, чем полностью отработают фильтры, т.е. отсортируются телевизоры по параметрам.
            //В итоге я пыталась нажать чекбокс для товара, которого уже нет на странице (после фильтрации)
            //С помощью ожидания у меня не получилось решить проблему, я поступила по другому

            //Вот этот локатор -bySearchResultButtonIsActive указывает на кнопку "Найдено ХХ товаров". 
            //Когда товар фильтруется для кнопки появляется новый класс ".schema-filter-button__state_animated"
            //В этом методе WaitForElementNotVisible(bySearchResultButtonIsActive) я жду когда фильтрация закончится
            //Но после этого выбрать чекбоксы тоже не получалось, страница возвращала нулевой результат
            //Поэтому я сделала еще один метод, который ждет пока елемент виден и нажимает его - getWhenVisible(byResultItem)
            // метод возвращает коллекцию эелментов

            //Я наверно намудрила стаким колличеством действий
            //напишите, пожалуйста, как можно это все сделать проще

            //Р.S. какое сочетание клавиш добавляет блок комментарий, чтобы не в ручную все закоменчивать?


            Browser.WaitForElementNotVisible(bySearchResultButtonIsActive);
            ReadOnlyCollection<IWebElement> links = Browser.getWhenVisible(byResultItem);

            foreach (var item in links)
            {
                item.Click();
            }
            match_result_button.Click();
        }
    }
}
