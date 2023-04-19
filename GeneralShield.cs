 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class GeneralShield
 {
    public List<Shield> ParseShield(string html)
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

        var data = new List<Shield>(size);

        for(var i = 2; i < items.Count; ++i){
            var shield = new Shield();
            //Console.WriteLine("blah " + items[i].InnerText);
            var splitItems = items[i].InnerText.Split("\n");
            shield.ImageURL = "https://darksouls.wiki.fextralife.com" + items[i].SelectSingleNode("td[1]//img").GetAttributeValue("src", "");
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
            Char[] parrySpeedDelimiters = {
                'F',
                'N',
                'B',
                'S'
            };

            for(var j = 2; j < splitItems.Count(); ++j){
                if(i != 8){
                    switch(j)
                {
                    case 2:
                        shield.Name = splitItems[j].Trim();
                        break;
                    case 3:
                        var temp = splitItems[j].Trim().Split(" ");
                        shield.AttackPower = int.Parse(temp[0]);
                        shield.PhysicalDamageReductionPercent = int.Parse(temp[1]);
                        break;
                    case 4:
                        temp = splitItems[j].Trim().Split(" ");
                        shield.MagicAttackPower = int.Parse(temp[0]);
                        shield.MagicDamageReductionPercent = int.Parse(temp[1]);
                        break;
                    case 5:
                        temp = splitItems[j].Trim().Split(" ");
                        shield.FireAttackPower = int.Parse(temp[0]);
                        shield.FireDamageReductionPercent = int.Parse(temp[1]);
                        break;
                    case 6:
                        temp = splitItems[j].Trim().Split(" ");
                        shield.LightningAttackPower = int.Parse(temp[0]);
                        shield.LightningDamageReductionPercent = int.Parse(temp[1]);
                        break;
                    case 7:
                        temp = splitItems[j].Trim().Split(" ");
                        shield.CriticalAttackPower = int.Parse(temp[0]);
                        shield.Stability = int.Parse(temp[1]);
                        break;
                    case 8:
                        var tempArr = splitItems[j].Trim().Split(" ");
                        shield.RequiredStrength = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            shield.MaxStrengthScaling = tempArr[1];
                        }
                        break;
                    case 9:
                        tempArr = splitItems[j].Trim().Split(" ");
                        shield.RequiredDexterity = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            shield.MaxDexterityScaling = tempArr[1];
                        }
                        break;
                    case 10:
                        tempArr = splitItems[j].Trim().Split(" ");
                        shield.RequiredIntelligence = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            shield.MaxIntelligenceScaling = tempArr[1];
                        }
                        break;
                    case 11:
                        tempArr = splitItems[j].Trim().Split(" ");
                        shield.RequiredFaith = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            shield.MaxFaithScaling = tempArr[1];
                        }
                        break;
                    case 12:
                        shield.Durability = int.Parse(splitItems[j].Trim().Substring(0, 3));
                        shield.Weight = double.Parse(splitItems[j].Trim().Substring(3));
                        break;
                    case 13:
                        shield.Deflection = splitItems[j].Trim();
                        break;
                    case 14:
                        shield.ParrySpeed = splitItems[j].Trim();
                        break;
                    case 15:
                        var tempAcquiredFrom = items[i].SelectSingleNode("td[15]").InnerText.Trim().Split("\n");
                        String acquiredFrom = String.Join("; ", tempAcquiredFrom);
                        //Console.WriteLine(acquiredFrom);
                        shield.AcquiredFrom = acquiredFrom;
                        break;
                }
                }

            }
            //Console.WriteLine(JsonSerializer.Serialize(shield, options));
            data.Add(shield);
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Shields/Greatshields.json", json);
        }
        return data;
    }
}