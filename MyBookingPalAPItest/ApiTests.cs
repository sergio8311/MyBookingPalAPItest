using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.mybookingpal.com/xml/services/json/reservation/products/21980/2017-04-01/2017-04-08?pos=a502d2c65c2f75d3&guests=2&amenity=true&currency=USD&exec_match=false&display_inquire_only=false");

            request.Method = "GET";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            string json = @output.ToString();
            //var data = (JObject)JsonConvert.DeserializeObject(json);
            //JObject data = JObject.Parse(json);
            //JArray quote = (JArray)data["quote"];
            dynamic dict = JsonConvert.DeserializeObject(json);
            var searchResponse = dict.search_response.search_quotes.quote[1].productname;
            //var targetProductName = "Eiffel Balcony";
            //var productName = Array.FindAll<dynamic>(searchResponse, s => s.Equals(targetProductName));
            //string productName = searchResponse.productname;
            //int productId = searchResponse.productid;




            //Array is also possible
            //string[] result = dict.Select(kv => kv.Value.ToString()).ToArray();


            response.Close();
        }
     
    }
}
