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

            var baseURL = "https://darksouls.wiki.fextralife.com/";
            var daggerUrl = baseURL + "Daggers";
            var straightSwordUrl = baseURL + "Straight+Swords";
            var greatSwordUrl = baseURL + "Greatswords";
            var ultraGreatSwordUrl = baseURL + "Ultra+Greatswords";
            var curvedSwordUrl = baseURL + "Curved+Swords";
            var katanaUrl = baseURL + "Katanas";
            var curvedGreatSwordUrl = baseURL + "Curved+Greatswords";
            var piercingSwordUrl = baseURL + "Piercing+Swords";
            var axeUrl = baseURL + "Axes";
            var greataxeUrl = baseURL + "Great+Axes";
            var hammerUrl = baseURL + "Hammers";
            var greatHammerUrl = baseURL + "Great+Hammers";
            var fistAndClawsUrl = baseURL + "Fist+Weapons";
            var spearUrl = baseURL + "Spears";
            var halberdUrl = baseURL + "Halberds";
            var whipUrl = baseURL + "Whips";
            var bowUrl = baseURL + "Bows";
            var greatBowUrl = baseURL + "Greatbows";
            var crossbowUrl = baseURL + "Crossbows";
            var catalystUrl = baseURL + "Catalysts";
            var talismanUrl = baseURL + "Talismans";
            var html = baseURL;

            String[] urls = {
                daggerUrl,
                straightSwordUrl,
                greatSwordUrl,
                ultraGreatSwordUrl,
                curvedSwordUrl,
                katanaUrl,
                curvedGreatSwordUrl,
                piercingSwordUrl,
                axeUrl,
                greataxeUrl,
                hammerUrl,
                greatHammerUrl,
                fistAndClawsUrl,
                spearUrl,
                halberdUrl,
                whipUrl,
                bowUrl,
                greatBowUrl,
                crossbowUrl,
                catalystUrl,
                talismanUrl
            };

            // for (var i = 0; i < urls.Length; ++i)
            // {
            //     if(i == 0) {
            //         var html = await GetHtml(urls[i]);
            //         Daggers daggerInstance = new Daggers();
            //         daggerInstance.ParseDaggers(html);
            //     }else if(i == 19){
            //         var html = await GetHtml(urls[i]);
            //         MagicWeapons catalystInstance = new MagicWeapons();
            //         catalystInstance.ParseMagicWeapons(html);
            //     }else if(i == 20){
            //         var html = await GetHtml(urls[i]);
            //         MagicWeapons talismanInstance = new MagicWeapons();
            //         talismanInstance.ParseMagicWeapons(html);
            //     }else{
            //         var html = await GetHtml(urls[i]);
            //         GeneralWeapons generalWeaponsInstance = new GeneralWeapons();
            //         generalWeaponsInstance.ParseGeneralWeapons(html);
            //     }

            // }

            // html = await GetHtml(daggerUrl);
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

            html = await GetHtml(whipUrl);
            GeneralWeapons whipInstance = new GeneralWeapons();
            whipInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(bowUrl);
            // GeneralWeapons bowInstance = new GeneralWeapons();
            // bowInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(greatBowUrl);
            // GeneralWeapons greatBowInstance = new GeneralWeapons();
            // greatBowInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(crossbowUrl);
            // GeneralWeapons crossbowInstance = new GeneralWeapons();
            // crossbowInstance.ParseGeneralWeapons(html);

            // html = await GetHtml(catalystUrl);
            // MagicWeapons catalystInstance = new MagicWeapons();
            // catalystInstance.ParseMagicWeapons(html);

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
