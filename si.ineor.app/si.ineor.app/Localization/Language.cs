using si.ineor.app.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xamarin.Essentials;

namespace si.ineor.app.Models
{

    public class Language
    {
        public static List<Language> languages = new List<Language>() {
            new Language(){FullName = "English", Culture ="en" },
            new Language(){FullName = "Slovenščina", Culture ="sl" },
            new Language(){FullName = "Hrvatski", Culture ="hr" },
            new Language(){FullName = "Deutsch", Culture ="de" },
            new Language(){FullName = "Italiano", Culture ="it" },
        };
        public string FullName { get; set; }
        public string Culture { get; set; }

        public static Language GetLanguage()
        {
            return languages.Find(x => x.Culture == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName) ?? languages[0];
        }

        public static Language GetCurrentLanguage()
        {
            string culture = Preferences.Get("UserSelectedLanguage", Language.GetLanguage().Culture);
            return languages.Find(x => x.Culture == culture) ?? languages[0];
        }

        public static void SetLanguage(Language language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.Culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language.Culture);
            Resource.Culture = new CultureInfo(language.Culture);
        }
    }
}
