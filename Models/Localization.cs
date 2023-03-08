using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Test_Task_New.Models
{
    static class Localization
    {
        public static ResourceDictionary SwitchLanguage(string language)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (language)
            {
                case "ua":
                    dictionary.Source = new Uri("..\\Properties\\DictionaryUkrainian.xaml", UriKind.Relative);
                    break;
                case "en":
                    dictionary.Source = new Uri("..\\Properties\\DictionaryEnglish.xaml", UriKind.Relative);
                    break;

            }
            return dictionary;
        }
    }
}
