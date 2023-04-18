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
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var items =
                htmlDoc
                    .DocumentNode
                    .SelectNodes("//*[@id='wiki-content-block']/div/table/tbody/tr");

            var size = items.Count - 2;

            var data = new List<Weapon>(size);

            for(var i = 2; i < items.Count - 2; ++i){
                var weapon = new Weapon();
                //Console.WriteLine(items[i].InnerText);
                var splitItems = items[i].InnerText.Split("\n");
                weapon.ImageURL = "https://darksouls.wiki.fextralife.com" + items[i].SelectSingleNode("td[1]//img").GetAttributeValue("src", "");
                Char[] statDelimiters = {
                    '-',
                    'E',
                    'D',
                    'C',
                    'B',
                    'A',
                    'S',
                    '+'
                };
                Char[] attackTypeDelimiters = {
                    'T',
                    'C',
                    'S'
                };
                for(var j = 2; j < splitItems.Count(); ++j){
                    switch(j)
                    {
                        case 2:
                            weapon.Name = splitItems[j].Trim();
                            break;
                        case 3:
                            var temp = splitItems[j].Trim().Split(" ");
                            //Console.WriteLine(temp[0]);
                            weapon.AttackPower = int.Parse(temp[0]);
                            weapon.PhysicalDamageReductionPercent = int.Parse(temp[1]);
                            break;
                        case 4:
                            temp = splitItems[j].Trim().Split(" ");
                            weapon.MagicAttackPower = int.Parse(temp[0]);
                            weapon.MagicDamageReductionPercent = int.Parse(temp[1]);
                            break;
                        case 5:
                            temp = splitItems[j].Trim().Split(" ");
                            weapon.FireAttackPower = int.Parse(temp[0]);
                            weapon.FireDamageReductionPercent = int.Parse(temp[1]);
                            break;
                        case 6:
                            temp = splitItems[j].Trim().Split(" ");
                            weapon.LightningAttackPower = int.Parse(temp[0]);
                            weapon.LightningDamageReductionPercent = int.Parse(temp[1]);
                            break;
                        case 7:
                            temp = splitItems[j].Trim().Split(" ");
                            weapon.CriticalAttackPower = int.Parse(temp[0]);
                            weapon.CriticalDamageReductionPercent = int.Parse(temp[1]);
                            break;
                        case 8:
                            if(splitItems[j].Trim() == "&nbsp;"){
                                weapon.BleedDamage = 0;
                            }
                            else{
                                weapon.BleedDamage = int.Parse(splitItems[j].Trim());
                            }
                            break;
                        case 9:
                            if(splitItems[j].Trim() == "&nbsp;"){
                                weapon.PoisonDamage = 0;
                            }
                            else{
                                weapon.PoisonDamage = int.Parse(splitItems[j].Trim());
                            }
                            break;
                        case 10:
                            if(splitItems[j].Trim() == "&nbsp;"){
                                weapon.DivineDamage = 0;
                            }
                            else{
                                weapon.DivineDamage = int.Parse(splitItems[j].Trim());
                            }
                            break;
                        case 11:
                            if(splitItems[j].Trim() == "&nbsp;"){
                                weapon.OccultDamage = 0;
                            }
                            else{
                                weapon.OccultDamage = int.Parse(splitItems[j].Trim());
                            }
                            break;
                        case 12:
                            string tempStr = splitItems[j].Trim();
                            string tempReqNum = "";
                            string tempUpgradeNum = "";
                            for(var w = 0; w < tempStr.Length; ++w){
                                if(w == 0){
                                    tempReqNum += tempStr[w];
                                    if(tempStr[w + 1] == '0' || tempStr[w + 1] == '1' || tempStr[w + 1] == '2' || tempStr[w + 1] == '3' || tempStr[w + 1] == '4' || tempStr[w + 1] == '5' || tempStr[w + 1] == '6' || tempStr[w + 1] == '7' || tempStr[w + 1] == '8' || tempStr[w + 1] == '9'){
                                        tempReqNum += tempStr[w + 1];
                                    }
                                    weapon.RequiredStrength = int.Parse(tempReqNum);
                                }else if(tempStr[w] == 'E' || tempStr[w] == 'D' || tempStr[w] == 'C' || tempStr[w] == 'B' || tempStr[w] == 'A' || tempStr[w] == 'S'){
                                    if(tempStr[w + 1] == '+'){
                                        weapon.MaxStrengthScaling = tempStr[w].ToString();
                                    }else{
                                        weapon.BaseStrengthScaling = tempStr[w].ToString();
                                    }
                                }else if(tempStr[w] == '+'){
                                    ++w;
                                    tempUpgradeNum += tempStr[w];
                                    if(w == tempStr.Length - 1){
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }else{
                                        tempUpgradeNum += tempStr[w + 1];
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }
                                }
                            }
                            break;
                        case 13:
                            tempStr = splitItems[j].Trim();
                            tempReqNum = "";
                            tempUpgradeNum = "";
                            for(var w = 0; w < tempStr.Length; ++w){
                                if(w == 0){
                                    tempReqNum += tempStr[w];
                                    if(tempStr[w + 1] == '0' || tempStr[w + 1] == '1' || tempStr[w + 1] == '2' || tempStr[w + 1] == '3' || tempStr[w + 1] == '4' || tempStr[w + 1] == '5' || tempStr[w + 1] == '6' || tempStr[w + 1] == '7' || tempStr[w + 1] == '8' || tempStr[w + 1] == '9'){
                                        tempReqNum += tempStr[w + 1];
                                    }
                                    weapon.RequiredDexterity = int.Parse(tempReqNum);
                                }else if(tempStr[w] == 'E' || tempStr[w] == 'D' || tempStr[w] == 'C' || tempStr[w] == 'B' || tempStr[w] == 'A' || tempStr[w] == 'S'){
                                    if(tempStr[w + 1] == '+'){
                                        weapon.MaxDexterityScaling = tempStr[w].ToString();
                                    }else{
                                        weapon.BaseDexterityScaling = tempStr[w].ToString();
                                    }
                                }else if(tempStr[w] == '+'){
                                    ++w;
                                    tempUpgradeNum += tempStr[w];
                                    if(w == tempStr.Length - 1){
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }else{
                                        tempUpgradeNum += tempStr[w + 1];
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }
                                }
                            }
                            break;
                        case 14:
                            tempStr = splitItems[j].Trim();
                            tempReqNum = "";
                            tempUpgradeNum = "";
                            for(var w = 0; w < tempStr.Length; ++w){
                                if(w == 0){
                                    tempReqNum += tempStr[w];
                                    if(tempStr[w + 1] == '0' || tempStr[w + 1] == '1' || tempStr[w + 1] == '2' || tempStr[w + 1] == '3' || tempStr[w + 1] == '4' || tempStr[w + 1] == '5' || tempStr[w + 1] == '6' || tempStr[w + 1] == '7' || tempStr[w + 1] == '8' || tempStr[w + 1] == '9'){
                                        tempReqNum += tempStr[w + 1];
                                    }
                                    weapon.RequiredIntelligence = int.Parse(tempReqNum);
                                }else if(tempStr[w] == 'E' || tempStr[w] == 'D' || tempStr[w] == 'C' || tempStr[w] == 'B' || tempStr[w] == 'A' || tempStr[w] == 'S'){
                                    if(tempStr[w + 1] == '+'){
                                        weapon.MaxIntelligenceScaling = tempStr[w].ToString();
                                    }else{
                                        weapon.BaseIntelligenceScaling = tempStr[w].ToString();
                                    }
                                }else if(tempStr[w] == '+'){
                                    ++w;
                                    tempUpgradeNum += tempStr[w];
                                    if(w == tempStr.Length - 1){
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }else{
                                        tempUpgradeNum += tempStr[w + 1];
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }
                                }
                            }
                            break;
                        case 15:
                            tempStr = splitItems[j].Trim();
                            tempReqNum = "";
                            tempUpgradeNum = "";
                            for(var w = 0; w < tempStr.Length; ++w){
                                if(w == 0){
                                    tempReqNum += tempStr[w];
                                    if(tempStr[w + 1] == '0' || tempStr[w + 1] == '1' || tempStr[w + 1] == '2' || tempStr[w + 1] == '3' || tempStr[w + 1] == '4' || tempStr[w + 1] == '5' || tempStr[w + 1] == '6' || tempStr[w + 1] == '7' || tempStr[w + 1] == '8' || tempStr[w + 1] == '9'){
                                        tempReqNum += tempStr[w + 1];
                                    }
                                    weapon.RequiredFaith = int.Parse(tempReqNum);
                                }else if(tempStr[w] == 'E' || tempStr[w] == 'D' || tempStr[w] == 'C' || tempStr[w] == 'B' || tempStr[w] == 'A' || tempStr[w] == 'S'){
                                    if(tempStr[w + 1] == '+'){
                                        weapon.MaxFaithScaling = tempStr[w].ToString();
                                    }else{
                                        weapon.BaseFaithScaling = tempStr[w].ToString();
                                    }
                                }else if(tempStr[w] == '+'){
                                    ++w;
                                    tempUpgradeNum += tempStr[w];
                                    if(w == tempStr.Length - 1){
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }else{
                                        tempUpgradeNum += tempStr[w + 1];
                                        weapon.MaxUpgradeLevel = int.Parse(tempUpgradeNum);
                                    }
                                }
                            }
                            break;
                        case 16:
                            weapon.Durability = int.Parse(splitItems[j].Trim().Substring(0, 3));
                            weapon.Weight = double.Parse(splitItems[j].Trim().Substring(3));
                            break;
                        case 17:
                            var tempAttackTypes = splitItems[j].Trim().Split(attackTypeDelimiters);
                            String attackTypes = tempAttackTypes[0];
                            for(var k = 1; k < tempAttackTypes.Count(); ++k){
                                if(tempAttackTypes[k] == "lash"){
                                    tempAttackTypes[k] = "Slash";
                                }else if(tempAttackTypes[k] == "trike"){
                                    tempAttackTypes[k] = "Strike";
                                }else if(tempAttackTypes[k] == "hrust"){
                                    tempAttackTypes[k] = "Thrust";
                                }else if(tempAttackTypes[k] == "ombo"){
                                    tempAttackTypes[k] = "Combo";
                                }


                                if(k == tempAttackTypes.Count() - 1){
                                    attackTypes += tempAttackTypes[k];
                                }else{
                                    attackTypes += tempAttackTypes[k] + ", ";
                                }
                            }
                            weapon.AttackTypes = attackTypes;
                            break;
                        case 20:
                            var tempAcquiredFrom = items[i].SelectSingleNode("td[18]/ul").InnerText.Trim().Split('\n');
                            String acquiredFrom = String.Join("; ", tempAcquiredFrom);
                            weapon.AcquiredFrom = acquiredFrom;
                            break;
                    }
                }
                data.Add(weapon);
            }
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Weapons/Daggers.json", json);
            return data;
        }
    }
}
