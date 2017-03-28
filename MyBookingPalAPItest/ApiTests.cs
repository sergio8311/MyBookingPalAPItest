using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Serialization;
using NUnit.Framework.Internal;


namespace MyBookingPalAPItest
{
    using Newtonsoft.Json;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;



    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void ApiTest()
        {
            
            var poductName = "Alma-Eiffel Tower";
            var location = "Paris, France";
            var nextMonday = ProductHelper.NextMondayDate();

            ////Get location id
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
