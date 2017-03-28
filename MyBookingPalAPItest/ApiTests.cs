
namespace MyBookingPalAPItest
{
    using NUnit.Framework;



    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void ApiTest()
        {           
            var poductName = "Apartment Pelleport";
            var location = "Paris, France";
            var nextMonday = ProductHelper.NextMondayDate();

            //Get location id
            var locationId = ProductHelper.GetLocationId(location);

            //Get product id
            var productId = ProductHelper.GetProductId(locationId, poductName);
           
            //Get price and quote
            var productQuote = ProductHelper.GetProcudtQuote(productId, nextMonday);
            var productPrice = ProductHelper.GetProcudtPrice(productId, nextMonday);
            //Check that quote equal price
            Assert.AreEqual(productQuote, productPrice, "Price and Quote are not equal");
        }   
    }
}
