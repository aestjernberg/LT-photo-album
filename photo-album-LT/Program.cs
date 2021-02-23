using ConsoleTables;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace photo_album_LT
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string[] inputArray;
            string albumID;
            string flag;
            JsonParser jp = new JsonParser();
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter the desired album ID (1-100)");
            input = Console.ReadLine();

            while (input != "Q" && input != "q")
            {
                inputArray = input.Split(" ");
                albumID = inputArray[0];
                flag = inputArray[1];

                if (flag == "a")
                {
                    printInfoByPhotoID(jp, albumID);
                }
                else if (flag == "b")
                {
                    printInfoByTitle(jp, albumID);
                }

                Console.WriteLine("Please enter your desired command:");
                input = Console.ReadLine();
            }
        }

        public static void printInfoByPhotoID(JsonParser jp, string albumID)
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
            table.Write(Format.Minimal);
        }

        public static void printInfoByTitle(JsonParser jp, string albumID)
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
            table.Write(Format.Minimal);
        }
    }
}
