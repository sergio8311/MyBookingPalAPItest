using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace MyBookingPalAPItest
{
    public static class ProductHelper
    {
        private static readonly string locationUrl = "https://mybookingpal.com/api/location/getinfo?location=";
        private static readonly string productUrl = "https://www.mybookingpal.com/xml/services/json/reservation/products/";
        private static readonly string productQuoteUrl = "https://mybookingpal.com/xml/services/json/reservation/quotes?pos=a502d2c65c2f75d3&productid=";

        public static int GetLocationId(string location)
        {
            RequestBuilder getLocationJson = new RequestBuilder();
            var urlLocation = locationUrl + location;
            var dictLocation = getLocationJson.getPostRequest(urlLocation);
            return dictLocation.data.ID;
        }

        public static  int GetProductId(int locationId, string expectedProductName)
        {
            var urlGetProductList = productUrl + locationId + "/"+ NextMondayDate() +"/"+ CheckoutDate()+"?pos=a502d2c65c2f75d3&guests=2&amenity=true&currency=USD&exec_match=false&display_inquire_only=false";
            RequestBuilder getProductListJson = new RequestBuilder();
            var dictProduct = getProductListJson.getPostRequest(urlGetProductList);
            var searchResponse = dictProduct.search_response.search_quotes.quote;
            var productList = (List<SelectableProductListItems>)searchResponse.ToObject<List<SelectableProductListItems>>();
            var findProductName = productList.FirstOrDefault(x => x.productname.Equals(expectedProductName));
            return findProductName.productid;
        }

        public static float GetProcudtQuote(int productId, string monday)
        {
            var urlGetProductQuote = productQuoteUrl + productId + "&fromdate=" + monday + "&todate=" + CheckoutDate() + "&currency=USD&adults=2";
            RequestBuilder getProductDetailsJson = new RequestBuilder();
            var dictProductDetails = getProductDetailsJson.getPostRequest(urlGetProductQuote);
            return dictProductDetails.quotes.quote;
        }
        public static float GetProcudtPrice(int productId, string monday)
        {
            var urlGetProductQuote = productQuoteUrl + productId + "&fromdate=" + monday + "&todate=" + CheckoutDate() + "&currency=USD&adults=2";
            RequestBuilder getProductDetailsJson = new RequestBuilder();
            var dictProductDetails = getProductDetailsJson.getPostRequest(urlGetProductQuote);
            return dictProductDetails.quotes.price;
        }


        public static string NextMondayDate()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            int daysUntilModay = ((int)DayOfWeek.Monday - (int)tomorrow.DayOfWeek + 7) % 7;
            DateTime nextMonday = tomorrow.AddDays(daysUntilModay);
            return nextMonday.ToString("yyyy-MM-dd");
        }

        public static string CheckoutDate()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            int daysUntilModay = ((int)DayOfWeek.Monday - (int)tomorrow.DayOfWeek + 7) % 7;
            DateTime nextMonday = tomorrow.AddDays(daysUntilModay);
            DateTime checkoutDateFromMonday = nextMonday.AddDays(7);
            return checkoutDateFromMonday.ToString("yyyy-MM-dd");
        }
    }

    public class SelectableProductListItems
    {
        public string productname { get; set; }
        public int productid { get; set; }

    }

    public class RequestBuilder
    {
        public dynamic getPostRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            string json = @output.ToString();
            return JsonConvert.DeserializeObject(json);          
        }
    }

  
}
