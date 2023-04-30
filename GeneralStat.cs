 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class GeneralStat
 {
    public List<Stamina> ParseStat(string html)
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
                .SelectNodes("//*[@class='wiki_table']/tbody/tr");

        var size = items.Count;

        var data = new List<Stamina>(size);


        for(var i = 1; i < size; ++i){
            var stamina = new Stamina();
            Console.WriteLine("blah " + items[i].InnerText);
            var splitItems = items[i].InnerText.Split("\n");
            stamina.Endurance = int.Parse(splitItems[i].Trim());
            Console.WriteLine(JsonSerializer.Serialize(stamina, options));
            //data.Add(stamina);
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Stats/Tables/Stamina_Table.json", json);
        }

        // items =
        //     htmlDoc
        //         .DocumentNode
        //         .SelectNodes("//*[@class='wiki-content-table wiki_table']/tbody/tr");

        //         size = items.Count;

        // for(var i = 1; i < size; ++i){
        //     if(i != 34){
        //         var health = new Health();
        //     //Console.WriteLine("blah " + items[i].InnerText);
        //     var splitItems = items[i].InnerText.Split("\n");
        //     health.Vitality = int.Parse(splitItems[1].Trim());
        //     health.HP = int.Parse(splitItems[2].Trim());
        //     if(splitItems[3].Trim() == "-"){
        //         health.IndividualGain = 0;
        //     }else{
        //         health.IndividualGain = int.Parse(splitItems[3].Trim());
        //     }
        //     //Console.WriteLine(JsonSerializer.Serialize(health, options));
        //     data.Add(health);
        //     string json = JsonSerializer.Serialize(data, options);
        //     File.WriteAllText("./Stats/Tables/HP_Table.json", json);
        //     }
        // }
        return data;
    }
}