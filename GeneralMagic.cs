 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class GeneralMagic
 {
    public List<Magic> ParseMagic(string html)
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

        var data = new List<Magic>(size);

        for(var i = 1; i < items.Count - 1; ++i){
            var magic = new Magic();
            //Console.WriteLine("blah " + items[i].InnerText);
            var splitItems = items[i].InnerText.Split("\n");
            magic.ImageURL = "https://darksouls.wiki.fextralife.com" + items[i].SelectSingleNode("td[1]//img").GetAttributeValue("src", "");
            magic.Name = splitItems[1].Trim();
            magic.Uses = int.Parse(splitItems[2].Trim());
            magic.Slots = int.Parse(splitItems[3].Trim());
            magic.RequiredFaith = int.Parse(splitItems[4].Trim());
            magic.Description = splitItems[5].Trim();
            magic.AcquiredFrom = splitItems[6].Trim();
            magic.Type = splitItems[7].Trim();

            //Console.WriteLine(JsonSerializer.Serialize(magic, options));
            data.Add(magic);
        }
        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText("./Magic/Miracles.json", json);
        return data;
    }
}