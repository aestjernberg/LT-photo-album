using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace photo_album_LT
{
    // This class is utlizied to parse JSON files
    class JsonParser
    {
        private string url;

        public void setURL(string albumID)
        {
            while (!Regex.Match(albumID, "^[0-9]+$").Success || Convert.ToInt32(albumID) < 1 || Convert.ToInt32(albumID) > 100)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid album ID: ");
                albumID = Console.ReadLine();
            }

            url = "https://jsonplaceholder.typicode.com/photos?albumId=" + albumID;
        }

        public string getURL()
        {
            return url;
        }

        public JArray getJsonData()
        {
            string json = (new WebClient()).DownloadString(url);
            return JArray.Parse(json);
        }
    }
}
