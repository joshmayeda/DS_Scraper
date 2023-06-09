﻿using System.Collections.Generic;
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
            //Weapons
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

            //Armors
            var helmUrl = baseURL + "Helms";
            var chestUrl = baseURL + "Chest+Armor";
            var gauntletUrl = baseURL + "Gauntlets";
            var legUrl = baseURL + "Leg+Armor";

            //Shields
            var smallShieldsUrl = baseURL + "Small+Shields";
            var standardShieldsUrl = baseURL + "Standard+Shields";
            var greatshieldsUrl = baseURL + "Greatshields";

            //Rings
            var ringUrl = baseURL + "Rings";

            //Magic
            var sorceriesUrl = baseURL + "Sorceries";
            var pyromanciesUrl = baseURL + "Pyromancies";
            var miraclesUrl = baseURL + "Miracles";

            //Stats
            var hpUrl = baseURL + "Health";
            var staminaUrl = baseURL + "Stamina";

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


            /*Weapons

            html = await GetHtml(daggerUrl);
            Daggers daggerInstance = new Daggers();
            daggerInstance.ParseDaggers(html);

            html = await GetHtml(straightSwordUrl);
            GeneralWeapons straightSwordInstance = new GeneralWeapons();
            straightSwordInstance.ParseGeneralWeapons(html);

            html = await GetHtml(greatSwordUrl);
            GeneralWeapons greatSwordInstance = new GeneralWeapons();
            greatSwordInstance.ParseGeneralWeapons(html);

            html = await GetHtml(ultraGreatSwordUrl);
            GeneralWeapons ultraGreatSwordInstance = new GeneralWeapons();
            ultraGreatSwordInstance.ParseGeneralWeapons(html);

            html = await GetHtml(curvedSwordUrl);
            GeneralWeapons curvedSwordInstance = new GeneralWeapons();
            curvedSwordInstance.ParseGeneralWeapons(html);

            html = await GetHtml(katanaUrl);
            GeneralWeapons katanaInstance = new GeneralWeapons();
            katanaInstance.ParseGeneralWeapons(html);

            html = await GetHtml(curvedGreatSwordUrl);
            GeneralWeapons curvedGreatSwordInstance = new GeneralWeapons();
            curvedGreatSwordInstance.ParseGeneralWeapons(html);

            html = await GetHtml(piercingSwordUrl);
            GeneralWeapons piercingSwordInstance = new GeneralWeapons();
            piercingSwordInstance.ParseGeneralWeapons(html);

            html = await GetHtml(axeUrl);
            GeneralWeapons axeInstance = new GeneralWeapons();
            axeInstance.ParseGeneralWeapons(html);

            html = await GetHtml(greataxeUrl);
            GeneralWeapons greataxeInstance = new GeneralWeapons();
            greataxeInstance.ParseGeneralWeapons(html);

            html = await GetHtml(hammerUrl);
            GeneralWeapons hammerInstance = new GeneralWeapons();
            hammerInstance.ParseGeneralWeapons(html);

            html = await GetHtml(greatHammerUrl);
            GeneralWeapons greatHammerInstance = new GeneralWeapons();
            greatHammerInstance.ParseGeneralWeapons(html);

            html = await GetHtml(fistAndClawsUrl);
            GeneralWeapons fistAndClawsInstance = new GeneralWeapons();
            fistAndClawsInstance.ParseGeneralWeapons(html);

            html = await GetHtml(spearUrl);
            GeneralWeapons spearInstance = new GeneralWeapons();
            spearInstance.ParseGeneralWeapons(html);

            html = await GetHtml(halberdUrl);
            GeneralWeapons halberdInstance = new GeneralWeapons();
            halberdInstance.ParseGeneralWeapons(html);

            html = await GetHtml(whipUrl);
            GeneralWeapons whipInstance = new GeneralWeapons();
            whipInstance.ParseGeneralWeapons(html);

            html = await GetHtml(bowUrl);
            GeneralWeapons bowInstance = new GeneralWeapons();
            bowInstance.ParseGeneralWeapons(html);

            html = await GetHtml(greatBowUrl);
            GeneralWeapons greatBowInstance = new GeneralWeapons();
            greatBowInstance.ParseGeneralWeapons(html);

            html = await GetHtml(crossbowUrl);
            GeneralWeapons crossbowInstance = new GeneralWeapons();
            crossbowInstance.ParseGeneralWeapons(html);

            html = await GetHtml(catalystUrl);
            MagicWeapons catalystInstance = new MagicWeapons();
            catalystInstance.ParseMagicWeapons(html);

            html = await GetHtml(talismanUrl);
            MagicWeapons talismanInstance = new MagicWeapons();
            talismanInstance.ParseMagicWeapons(html);*/

            /*Armors

            html = await GetHtml(helmUrl);
            GeneralArmor helmInstance = new GeneralArmor();
            helmInstance.ParseArmor(html);

            html = await GetHtml(chestUrl);
            GeneralArmor chestInstance = new GeneralArmor();
            chestInstance.ParseArmor(html);

            html = await GetHtml(gauntletUrl);
            GeneralArmor gauntletInstance = new GeneralArmor();
            gauntletInstance.ParseArmor(html);

            html = await GetHtml(legUrl);
            GeneralArmor legInstance = new GeneralArmor();
            legInstance.ParseArmor(html);
            */


            /*Shields
            html = await GetHtml(smallShieldsUrl);
            GeneralShield smallShieldInstance = new GeneralShield();
            smallShieldInstance.ParseShield(html);

            html = await GetHtml(standardShieldsUrl);
            GeneralShield standardShieldInstance = new GeneralShield();
            standardShieldInstance.ParseShield(html);

            html = await GetHtml(greatshieldsUrl);
            GeneralShield greatshieldInstance = new GeneralShield();
            greatshieldInstance.ParseShield(html);
            */

            /*Rings
            html = await GetHtml(ringUrl);
            GeneralRing ringInstance = new GeneralRing();
            ringInstance.ParseRing(html);
            */


            /*Magic*/
            // html = await GetHtml(sorceriesUrl);
            // GeneralMagic sorceryInstance = new GeneralMagic();
            // sorceryInstance.ParseMagic(html);

            // html = await GetHtml(pyromanciesUrl);
            // GeneralMagic pyromancyInstance = new GeneralMagic();
            // pyromancyInstance.ParseMagic(html);

            // html = await GetHtml(miraclesUrl);
            // GeneralMagic miracleInstance = new GeneralMagic();
            // miracleInstance.ParseMagic(html);

            // html = await GetHtml(hpUrl);
            // GeneralStat hpInstance = new GeneralStat();
            // hpInstance.ParseStat(html);

            // html = await GetHtml(staminaUrl);
            // GeneralStat staminaInstance = new GeneralStat();
            // staminaInstance.ParseStat(html);

        //     var options = new JsonSerializerOptions
        //     {
        //         WriteIndented = true,
        //     };
        //     var data = new List<AttunementSlots>();
        //     for(int i = 0; i < 100; ++i){
        //         var attunementSlots = new AttunementSlots();
        //         if(i < 10){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 0;
        //         }else if(i == 10 || i == 11){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 1;
        //         }else if(i == 12 || i == 13){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 2;
        //         }else if(i == 14 || i == 15){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 3;
        //         }else if(i == 16 || i == 17 || i == 18){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 4;
        //         }else if(i == 19 || i == 20 || i == 21 || i == 22){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 5;
        //         }else if(i == 23 || i == 24 || i == 25 || i == 26 || i == 27){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 6;
        //         }else if(i == 28 || i == 29 || i == 30 || i == 31 || i == 32 || i == 33){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 7;
        //         }else if(i == 34 || i == 35 || i == 36 || i == 37 || i == 38 || i == 39 || i == 40){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 8;
        //         }else if(i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46 || i == 47 || i == 48 || i == 49){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 9;
        //         }else if(i > 49){
        //             attunementSlots.Attunement = i;
        //             attunementSlots.Slots = 10;
        //         }
        //         data.Add(attunementSlots);
        //         string json = JsonSerializer.Serialize(data, options);
        //         File.WriteAllText("./Stats/Tables/AttunementSlots.json", json);
        //     }

        // }

        private static Task<string> GetHtml(string url)
        {
            var client = new HttpClient();
            return client.GetStringAsync(url);
        }

    }
}
