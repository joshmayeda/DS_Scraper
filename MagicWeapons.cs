 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class MagicWeapons
 {
    public List<Weapon> ParseMagicWeapons(string html)
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

        for(var i = 2; i < items.Count; ++i){
            var weapon = new Weapon();
            //Console.WriteLine("blah " + items[i].InnerText);
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
                        var tempArr = splitItems[j].Trim().Split(" ");
                        weapon.RequiredStrength = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            weapon.BaseStrengthScaling = tempArr[1];
                        }
                        break;
                    case 9:
                        tempArr = splitItems[j].Trim().Split(" ");
                        weapon.RequiredDexterity = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            weapon.BaseDexterityScaling = tempArr[1];
                        }
                        break;
                    case 10:
                        tempArr = splitItems[j].Trim().Split(" ");
                        weapon.RequiredIntelligence = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            weapon.BaseIntelligenceScaling = tempArr[1];
                        }
                        break;
                    case 11:
                        tempArr = splitItems[j].Trim().Split(" ");
                        weapon.RequiredFaith = int.Parse(tempArr[0]);
                        if(tempArr[1] != "-"){
                            weapon.BaseFaithScaling = tempArr[1];
                        }
                        break;
                    case 12:
                        weapon.Durability = int.Parse(splitItems[j].Trim().Substring(0, 3));
                        weapon.Weight = double.Parse(splitItems[j].Trim().Substring(3));
                        break;
                    case 13:
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
                    case 14:
                        var tempAcquiredFrom = items[i].SelectSingleNode("td[14]/ul").InnerText.Trim().Split("\n");
                        String acquiredFrom = String.Join("; ", tempAcquiredFrom);
                        //Console.WriteLine(acquiredFrom);
                        weapon.AcquiredFrom = acquiredFrom;
                        break;
                }
            }
            //Console.WriteLine(JsonSerializer.Serialize(weapon, options));
            data.Add(weapon);
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Weapons/Catalysts.json", json);
        }
        return data;
    }
}