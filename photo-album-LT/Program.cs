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
            // Declare variables
            string input;
            string[] inputArray;
            string albumID;
            string flag;
            JsonParser jp = new JsonParser();

            // Display instructions for the user
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter the desired album ID (1-100).");
            Console.WriteLine("2. Enter a space and an 'i' vo numerically order the photos based on photo ID.");
            Console.WriteLine("3. Enter a space and a 't' to alphabetically order the photos information based on the title.");
            Console.WriteLine("   Example: Enter '49 t' to view album 49 in alphabetical order.");
            Console.WriteLine("4. Enter a 'Q' or 'q' to exit.");
            input = Console.ReadLine();
            int numSpaces = input.Count(c => c == ' ');

            // Ensure that only 1 space was entered by the user
            while (numSpaces != 1)
            {
                Console.WriteLine("Please enter a single space between the album ID and the flag.");
                input = Console.ReadLine();
                numSpaces = input.Count(c => c == ' ');
            }

            // Continue looping through the program until the user enters a 'Q'
            while (input != "Q" && input != "q")
            {
                inputArray = input.Split(" ");
                albumID = inputArray[0];
                flag = inputArray[1];

                // Ensure that the flag entered by the user is either an 'i' or a 't'
                while (flag != "i" && flag != "t")
                {
                    Console.WriteLine("Please enter an 'i' or a 't' depending on how you want to order the photos.");
                    flag = Console.ReadLine();
                }

                if (flag == "i")
                {
                    printInfoByPhotoID(jp, albumID);
                }
                else if (flag == "t")
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
