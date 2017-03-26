using System.IO;
using System.Net;
using System.Text;


namespace MyBookingPalAPItest
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using System;

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
            string json = output.ToString();
            var data = (JObject)JsonConvert.DeserializeObject(json);
            

            response.Close();
        }

        //[Test]
        //public static T _download_serialized_json_data<T>(string url) where T : new()
        //{
        //    using (var w = new WebClient())
        //    {
        //        var json_data = string.Empty;
        //        // attempt to download JSON data as a string
        //        try
        //        {
        //            json_data = w.DownloadString("https://openexchangerates.org/api/latest.json?app_id=YOUR_APP_ID ");
        //        }
        //        catch (Exception) { }
        //        // if string with JSON data is not empty, deserialize it to class and return its instance 
        //        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        //    }
        //    //var url = "https://openexchangerates.org/api/latest.json?app_id=YOUR_APP_ID ";
        //    var currencyRates = _download_serialized_json_data<PorcuctData>(url);
        //}
    }
}
