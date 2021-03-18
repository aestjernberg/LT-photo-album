using System;
using System.Linq;
using ConsoleTables;
using Newtonsoft.Json.Linq;

namespace photo_album_LT
{
    // This class is used to print album information in an appealing, easy-to-read format
    public class PrintHelper
    {
        public ConsoleTable orderInfoByPhotoID(JsonParser jp, string albumID)
        {
            JArray array = jp.getJsonData(albumID);
            Console.Write("\r\n");

            var table = new ConsoleTable("PHOTO ID", "TITLE");
            foreach (JObject item in array)
            {
                int id = (int)item.GetValue("id");
                string title = item.GetValue("title").ToString();
                table.AddRow(id, title);
            }
            return table;
        }

        public ConsoleTable orderInfoByTitle(JsonParser jp, string albumID)
        {
            JArray array = jp.getJsonData(albumID);
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
