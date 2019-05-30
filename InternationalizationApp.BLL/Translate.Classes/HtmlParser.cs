using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Translate.Classes
{
    public static class HtmlParser
    {
        public static List<string> GetWordsFromFile(string file)
        {
            var result = new List<string>();

            var contents = File.ReadAllText(file);

            contents = "<div>" + contents.Replace("\n", "") + "</div>";

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(contents);

            var words = html.DocumentNode.SelectNodes("//div//text()");

            foreach (HtmlAgilityPack.HtmlNode word in words)
            {
                if ((!string.IsNullOrWhiteSpace(word.InnerText)) &&
                    (word.InnerText.IndexOf("{") == -1))
                {
                    result.Add(word.InnerText);
                }
            }

            return result;
        }

    }
}
