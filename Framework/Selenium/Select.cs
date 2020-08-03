using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Selenium
{
    public class Select
    {
        private readonly SelectElement _select;

        public Select(Element element)
        {
            _select = new SelectElement(element);
        }
        public SelectElement Current => _select ?? throw new System.NullReferenceException("_select is null.");

        public void SelectByValue(string value)
        {
            Current.SelectByValue(value);
        }

        public void SelectByIndex(int index)
        {
            Current.SelectByIndex(index);
        }

        public void SelectByText(string text)
        {
            Current.SelectByText(text);
        }

        public void SelectByPartialText(string text)
        {
            Current.SelectByText(text, true);
        }

    }
}
