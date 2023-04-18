using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DS_Scraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var html = await GetHtml();
            var data = ParseHtmlUsingHtmlAgilityPack(html);
            //Console.WriteLine("blah "+ data);
        }

        private static Task<string> GetHtml()
        {
            var client = new HttpClient();
            return client.GetStringAsync("https://darksouls.wiki.fextralife.com/Daggers");
        }

        private static List<Weapon> ParseHtmlUsingHtmlAgilityPack(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var items =
                htmlDoc
                    .DocumentNode
                    .SelectNodes("//*[@id='wiki-content-block']/div/table/tbody/tr");

            var size = items.Count - 2;

            var data = new List<Weapon>(size);

            for(var i = 2; i < items.Count; ++i){
                var weapon = new Weapon();
                // for(var j = 0; j < items[i].ChildNodes.Count; ++j){
                //     Console.WriteLine("blah "+ items[i].ChildNodes[j].InnerText);
                // }
                Console.WriteLine("blah "+ items[i].InnerText);
            }
            return data;
        }
    }
}
