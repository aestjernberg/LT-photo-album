using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace photo_album_LT
{
    // This class is utlizied to parse JSON files
    public class JsonParser
    {
        private string url;

        public string getURL()
        {
            return url;
        }

        public JArray getJsonData(string albumID)
        {
            bool checkInteger = Int32.TryParse(albumID, out int number);

            while (!checkInteger || Convert.ToInt32(albumID) < 1 || Convert.ToInt32(albumID) > 100)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid album ID: ");
                albumID = Console.ReadLine();
                checkInteger = Int32.TryParse(albumID, out number);
            }

            url = "https://jsonplaceholder.typicode.com/photos?albumId=" + albumID;

            string json = (new WebClient()).DownloadString(url);
            return JArray.Parse(json);
        }
    }
}
