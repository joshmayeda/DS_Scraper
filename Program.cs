using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Text.Json;

namespace DS_Scraper
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var html = await GetHtml();
            Daggers daggers = new Daggers();
            daggers.ParseDaggers(html);
        }

        private static Task<string> GetHtml()
        {
            var client = new HttpClient();
            return client.GetStringAsync("https://darksouls.wiki.fextralife.com/Daggers");
        }

    }
}
