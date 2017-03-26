using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBookingPalAPItest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyBookingPalAPItest.Tests
{
    [TestClass()]
    public class ApiTestsTests
    {
        [TestMethod()]
        public void ApiTestTest()
        {
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.mybookingpal.com/xml/services/json/reservation/products/21980/2017-03-27/2017-04-03?pos=a502d2c65c2f75d3&guests=2&amenity=true&currency=USD&exec_match=false&display_inquire_only=false");

            request.Method = "GET";
            request.Accept = "application/json";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            //var json = output.ToString();
            //dynamic data = JObject.Parse(json);
            //var data = (JObject)JsonConvert.DeserializeObject(json);
            //Console.WriteLine(data.productname);
            //Console.WriteLine(data.productid);
            //Console.WriteLine(data.quote);

            
            //var data = (JObject)JsonConvert.DeserializeObject(json);
            //string productname = data["Apartment Belleville"].Value<string>();


            response.Close();
        }
    }
}