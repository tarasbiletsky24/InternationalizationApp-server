using InternationalizationApp.BLL.Models;
using InternationalizationApp.BLL.Translate.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly string localPath = "D:/MyFiles/UselessShit/dyplom/InterantionalizationApp/InternationalizationApp-server/InternationalizationApp.BLL/AppData";
        public async Task<bool> CheckAllFiles(string finalLanguage, string originalLanguage)
        {
            var pathes = new List<string>();
            foreach (string path in Directory.EnumerateFiles(localPath, "*.html", SearchOption.AllDirectories))
            {
                pathes.Add(path);
            }
            foreach (string path in pathes)
            {
                var words = HtmlParser.GetWordsFromFile(path);

                var translatedTexts = new List<TranslatedText>();

                foreach (string word in words)
                {
                    var translated = await Translator.Translate(word, finalLanguage, originalLanguage);
                    translatedTexts.Add(translated);
                }

                FileEditor.ReplaceTextInFile(path, translatedTexts);
            }
            return true;
        }

        public void DeleteWorkingFiles()
        {
            DirectoryInfo di = new DirectoryInfo(localPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
