using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
