 using DS_Scraper;
 using HtmlAgilityPack;
 using System.Text.Json;

 class GeneralRing
 {
    public List<Ring> ParseRing(string html)
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

        var data = new List<Ring>(size);

        for(var i = 1; i < items.Count; ++i){
            var ring = new Ring();
            //Console.WriteLine("blah " + items[i].InnerText);
            var splitItems = items[i].InnerText.Split("\n");
            ring.ImageURL = "https://darksouls.wiki.fextralife.com" + items[i].SelectSingleNode("td[1]//img").GetAttributeValue("src", "");
            ring.Name = splitItems[1].Trim();
            ring.Effects = splitItems[2].Trim();
            ring.AcquiredFrom = splitItems[3].Trim();

            //Console.WriteLine(JsonSerializer.Serialize(ring, options));
            data.Add(ring);
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText("./Rings/AllRings.json", json);
        }
        return data;
    }
}