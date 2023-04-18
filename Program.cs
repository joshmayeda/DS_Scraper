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
            var url = "https://darksouls.wiki.fextralife.com/";
            var daggerURL = url + "Daggers";
            var straightSwordUrl = url + "Straight+Swords";
            var greatSwordUrl = url + "Greatswords";
            var ultraGreatSwordUrl = url + "Ultra+Greatswords";
            var curvedSwordUrl = url + "Curved+Swords";
            var katanaUrl = url + "Katanas";
            var curvedGreatSwordUrl = url + "Curved+Greatswords";
            var piercingSwordUrl = url + "Piercing+Swords";
            var axeUrl = url + "Axes";
            var greataxeUrl = url + "Great+Axes";
            var hammerUrl = url + "Hammers";
            var greatHammerUrl = url + "Great+Hammers";
            var fistAndClawsUrl = url + "Fist+Weapons";
            var spearUrl = url + "Spears";
            var halberdUrl = url + "Halberds";
            var whipUrl = url + "Whips";
            var bowUrl = url + "Bows";
            var greatBowUrl = url + "Greatbows";
            var crossbowUrl = url + "Crossbows";
            var catalystUrl = url + "Catalysts";
            var flameUrl = url + "Flames";
            var talismanUrl = url + "Talismans";
            var html = url;

            // html = await GetHtml(daggerURL);
            // Daggers daggerInstance = new Daggers();
            // daggerInstance.ParseDaggers(html);

            // html = await GetHtml(straightSwordUrl);
            // GeneralWeapons straightSwordInstance = new GeneralWeapons();
            // straightSwordInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(greatSwordUrl);
            // GeneralWeapons greatSwordInstance = new GeneralWeapons();
            // greatSwordInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(ultraGreatSwordUrl);
            // GeneralWeapons ultraGreatSwordInstance = new GeneralWeapons();
            // ultraGreatSwordInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(curvedSwordUrl);
            // GeneralWeapons curvedSwordInstance = new GeneralWeapons();
            // curvedSwordInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(katanaUrl);
            // GeneralWeapons katanaInstance = new GeneralWeapons();
            // katanaInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(curvedGreatSwordUrl);
            // GeneralWeapons curvedGreatSwordInstance = new GeneralWeapons();
            // curvedGreatSwordInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(piercingSwordUrl);
            // GeneralWeapons piercingSwordInstance = new GeneralWeapons();
            // piercingSwordInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(axeUrl);
            // GeneralWeapons axeInstance = new GeneralWeapons();
            // axeInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(greataxeUrl);
            // GeneralWeapons greataxeInstance = new GeneralWeapons();
            // greataxeInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(hammerUrl);
            // GeneralWeapons hammerInstance = new GeneralWeapons();
            // hammerInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(greatHammerUrl);
            // GeneralWeapons greatHammerInstance = new GeneralWeapons();
            // greatHammerInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(fistAndClawsUrl);
            // GeneralWeapons fistAndClawsInstance = new GeneralWeapons();
            // fistAndClawsInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(spearUrl);
            // GeneralWeapons spearInstance = new GeneralWeapons();
            // spearInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(halberdUrl);
            // GeneralWeapons halberdInstance = new GeneralWeapons();
            // halberdInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(whipUrl);
            // GeneralWeapons whipInstance = new GeneralWeapons();
            // whipInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(bowUrl);
            // GeneralWeapons bowInstance = new GeneralWeapons();
            // bowInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(greatBowUrl);
            // GeneralWeapons greatBowInstance = new GeneralWeapons();
            // greatBowInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(crossbowUrl);
            // GeneralWeapons crossbowInstance = new GeneralWeapons();
            // crossbowInstance.ParseGeneralWeapons(html);

            html = await GetHtml(catalystUrl);
            MagicWeapons catalystInstance = new MagicWeapons();
            catalystInstance.ParseMagicWeapons(html);

            // html = await GetHtml(flameUrl);
            // MagicWeapons flameInstance = new MagicWeapons();
            // flameInstance.ParseMagicWeapons(html);

            // html = await GetHtml(talismanUrl);
            // MagicWeapons talismanInstance = new MagicWeapons();
            // talismanInstance.ParseMagicWeapons(html);

        }

        private static Task<string> GetHtml(string url)
        {
            var client = new HttpClient();
            return client.GetStringAsync(url);
        }

    }
}
