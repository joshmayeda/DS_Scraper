 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class GeneralArmor
 {
    public List<Armor> ParseArmor(string html)
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

        var size = items.Count;

        var data = new List<Armor>(size);

        for(var i = 1; i < items.Count - 3; ++i){
            var armor = new Armor();
            //Console.WriteLine("blah " + items[i].InnerText);
            var splitItems = items[i].InnerText.Split("\n");
            if(i != 11)
                armor.ImageURL = "https://darksouls.wiki.fextralife.com" + items[i].SelectSingleNode("td[1]//img").GetAttributeValue("src", "");

            for(var j = 1; j < splitItems.Count(); ++j){
                switch(j)
                {
                    case 1:
                        armor.Name = splitItems[j].Trim();
                        break;
                    case 2:
                        var temp = splitItems[j].Trim().Split(";");
                        if(temp.Length > 1){
                            armor.Durability = int.Parse(temp[1]);
                        }else{
                            armor.Durability = int.Parse(temp[0]);
                        }
                        break;
                    case 3:
                        armor.Weight = double.Parse(splitItems[j].Trim());
                        break;
                    case 4:
                        armor.PhysicalProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 5:
                        armor.StrikeProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 6:
                        armor.SlashProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 7:
                        armor.ThrustProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 8:
                        armor.MagicProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 9:
                        armor.FireProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 10:
                        armor.LightningProtection = double.Parse(splitItems[j].Trim());
                        break;
                    case 11:
                        armor.BleedResistance = double.Parse(splitItems[j].Trim());
                        break;
                    case 12:
                        armor.PoisonResistance = double.Parse(splitItems[j].Trim());
                        break;
                    case 13:
                        armor.CurseResistance = double.Parse(splitItems[j].Trim());
                        break;
                    case 14:
                        armor.Stability = int.Parse(splitItems[j].Trim());
                        break;
                }
            }
            //Console.WriteLine(JsonSerializer.Serialize(armor, options));
            data.Add(armor);
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Armor/Chest.json", json);
        }
        return data;
    }
}