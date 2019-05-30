using GoogleTranslateFreeApi;
using InternationalizationApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Translate.Classes
{
    public static class Translator
    {
        public static async Task<TranslatedText> Translate(string text, string finalLanguage, string originalLanguage = "Auto")
        {
            var translator = new GoogleTranslator();
            Language to = GoogleTranslator.GetLanguageByName(finalLanguage);
            Language from = GoogleTranslator.GetLanguageByName(originalLanguage);

            var translated = await translator.TranslateLiteAsync(text, from, to);

            return new TranslatedText { Original = translated.OriginalText, Translated = translated.MergedTranslation };
        }
    }
}
