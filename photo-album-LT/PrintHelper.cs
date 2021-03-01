using System;
using System.Linq;
using ConsoleTables;
using Newtonsoft.Json.Linq;

namespace photo_album_LT
{
    public class PrintHelper
    {
        public ConsoleTable orderInfoByPhotoID(JsonParser jp, string albumID)
        {
            jp.setURL(albumID);
            Console.Write("\r\n");

            var table = new ConsoleTable("PHOTO ID", "TITLE");
            foreach (JObject item in jp.getJsonData())
            {
                int id = (int)item.GetValue("id");
                string title = item.GetValue("title").ToString();
                table.AddRow(id, title);
            }
            return table;
        }

        public ConsoleTable orderInfoByTitle(JsonParser jp, string albumID)
        {
            jp.setURL(albumID);
            JArray array = jp.getJsonData();
            JArray sorted = new JArray(array.OrderBy(obj => (string)obj["title"]));

            var table = new ConsoleTable("PHOTO ID", "TITLE");
            foreach (JObject item in sorted)
            {
                int id = (int)item.GetValue("id");
                string title = item.GetValue("title").ToString();
                table.AddRow(id, title);
            }
            return table;
        }
    }
}
