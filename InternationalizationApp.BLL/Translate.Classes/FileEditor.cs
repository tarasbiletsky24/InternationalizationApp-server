using InternationalizationApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Translate.Classes
{
    public static class FileEditor
    {
        public static void ReplaceTextInFile(string path, List<TranslatedText> translatedTexts)
        {
            var reader = new StreamReader(path);
            string text = reader.ReadToEnd();
            reader.Close();

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (TranslatedText translatedText in translatedTexts)
                {
                    text = text.Replace(translatedText.Original, translatedText.Translated);
                }

                writer.Write(text);
                writer.Close();
            }
        }
    }
}
