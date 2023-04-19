 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class GeneralWeapons
 {
public List<Weapon> ParseGeneralWeapons(string html)
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
                    'S',
                    'R'
                };
                for(var j = 2; j < splitItems.Count(); ++j){
                        switch(j)
                        {
                            case 2:
                                weapon.Name = splitItems[j].Trim();
                                break;
                            case 3:
                            Console.WriteLine(i + " " + splitItems[3]);
                                //if(i != 5){
                                    var temp = splitItems[j].Trim().Split(" ");
                                    weapon.AttackPower = int.Parse(temp[0]);
                                    weapon.PhysicalDamageReductionPercent = int.Parse(temp[1]);
                                //}
                                break;
                            case 4:
                                //if(i != 5){
                                    temp = splitItems[j].Trim().Split(" ");
                                    weapon.MagicAttackPower = int.Parse(temp[0]);
                                    weapon.MagicDamageReductionPercent = int.Parse(temp[1]);
                                //}
                                break;
                            case 5:
                                //if(i != 5){
                                    temp = splitItems[j].Trim().Split(" ");
                                    weapon.FireAttackPower = int.Parse(temp[0]);
                                    weapon.FireDamageReductionPercent = int.Parse(temp[1]);
                                //}
                                break;
                            case 6:
                                //if(i != 5){
                                    temp = splitItems[j].Trim().Split(" ");
                                    weapon.LightningAttackPower = int.Parse(temp[0]);
                                    weapon.LightningDamageReductionPercent = int.Parse(temp[1]);
                                //}
                                break;
                            case 7:
                                //if(i != 5){
                                    temp = splitItems[j].Trim().Split(" ");
                                    weapon.CriticalAttackPower = int.Parse(temp[0]);
                                    weapon.CriticalDamageReductionPercent = int.Parse(temp[1]);
                                //}
                                break;
                            case 9:
                                //Console.WriteLine(i + " " + splitItems[2]);
                                //if(i < 8 && i != 3){
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
                                //}
                                break;
                            case 10:
                                // Console.WriteLine(i + " " + splitItems[2]);
                                //if(i < 8 && i != 3){
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
                                //}
                                break;
                            case 11:
                                //Console.WriteLine(i + " " + splitItems[2]);
                                //if(i < 8 && i != 3){
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
                                //}
                                break;
                            case 12:
                                // Console.WriteLine(i + " " + splitItems[2]);
                               // if(i < 8 && i != 3){
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
                                //}
                                break;
                            case 13:
                                // Console.WriteLine(i + " " + splitItems[j]);
                                weapon.Durability = int.Parse(splitItems[j].Trim().Substring(0, 3));
                                weapon.Weight = double.Parse(splitItems[j].Trim().Substring(3));
                                break;
                            case 14:
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
                                    }else if(tempAttackTypes[k] == "egular"){
                                        //Console.WriteLine(tempAttackTypes[k]);
                                        tempAttackTypes[k] = "Regular";
                                    }else if(tempAttackTypes[k] == "pecial"){
                                        tempAttackTypes[k] = "Special";
                                    }

                                    if(k == tempAttackTypes.Count() - 1){
                                        attackTypes += tempAttackTypes[k];
                                    }else{
                                        attackTypes += tempAttackTypes[k] + ", ";
                                    }
                                }
                                weapon.AttackTypes = attackTypes;
                                break;
                            case 15:
                                var tempAcquiredFrom = items[i].SelectSingleNode("td[15]/ul").InnerText.Trim().Split("\n");
                                String acquiredFrom = String.Join("; ", tempAcquiredFrom);
                                //Console.WriteLine(acquiredFrom);
                                weapon.AcquiredFrom = acquiredFrom;
                                break;
                        }
                }
                //Console.WriteLine(JsonSerializer.Serialize(weapon, options));
                data.Add(weapon);
            }
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Weapons/Whips.json", json);
            return data;
        }
    }