using ConsoleTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace AppTests
{
    [TestClass]
    public class PhotoAppTests
    {
        [TestMethod]
        public void validInputSetsUrl()
        {
            photo_album_LT.JsonParser jp = new photo_album_LT.JsonParser();

            jp.setURL("72");
            Assert.AreEqual(jp.getURL(), "https://jsonplaceholder.typicode.com/photos?albumId=72");
        }

        [TestMethod]
        public void checkJsonDataFormat()
        {
            photo_album_LT.JsonParser jp = new photo_album_LT.JsonParser();

            jp.setURL("49");
            JArray jsonData = jp.getJsonData();
            Assert.IsInstanceOfType(jsonData, typeof(JArray));
        }

        [TestMethod]
        public void checkOrderOfPhotos()
        {
            photo_album_LT.JsonParser jp = new photo_album_LT.JsonParser();
            photo_album_LT.PrintHelper ph = new photo_album_LT.PrintHelper();

            ConsoleTable table1 = ph.orderInfoByPhotoID(jp, "32");
            Assert.IsTrue(table1.ToString().IndexOf("1551") < table1.ToString().IndexOf("1552"));

            ConsoleTable table2 = ph.orderInfoByTitle(jp, "32");
            Assert.IsTrue(table2.ToString().IndexOf("1580") < table2.ToString().IndexOf("1574"));
        }
    }
}
