using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace LifeOrganiserApp
{
    // news proxy class
    class NewsProxy
    {
        // gets a http response message
        private static HttpResponseMessage response;

        // get news function, takes in boolean to determine local news or not, takes in int to determine wheter top news, business news or sports news
        public async static Task<RootObject> GetNews(bool local,int category)
        {
            var http = new HttpClient();
            
            // news for top news
            if (category == 1)
            {
                // if local news is toggled
                if (local == true)
                {
                    // create response string for local top news
                    response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" +
                     GetLocation() +
                     "&apiKey=96eea05140b246f5beb991ced70bfe8c");
                }
                else
                {
                    // create response string for top news all sources
                    response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" +
                     "us" +
                     "&apiKey=96eea05140b246f5beb991ced70bfe8c");
                }
            }

            // news for sports news
            else if (category == 2)
            {
                // if local news is toggled
                if (local == true)
                {
                    // create response string for local sports news
                    response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" +
                     GetLocation() +
                     "&category=sports&apiKey=96eea05140b246f5beb991ced70bfe8c");
                }
                else
                {
                    // create response string for sports news all sources
                    response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" +
                     "us" +
                     "&category=sports&apiKey=96eea05140b246f5beb991ced70bfe8c");
                }
            }
            // news for business news
            else if (category == 3)
            {
                // if local news is toggled
                if (local == true)
                {
                    // create response string for local business news
                    response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" +
                     GetLocation() +
                     "&category=business&apiKey=96eea05140b246f5beb991ced70bfe8c");
                }
                else
                {
                    // create response string for business news all sources
                    response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=" +
                     "us" +
                     "&category=business&apiKey=96eea05140b246f5beb991ced70bfe8c");
                }
            }

            // get result
            var result = await response.Content.ReadAsStringAsync();
            // serialise the json result and convert into rootobject
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            // return root object news result
            return data;
        }


        // search for news, takes in category and keywords
        public async static Task<RootObject> SearchNews(String category, String keywords)
        {
            
            // split keywords and remove punctuation
            var fixedInput = Regex.Replace(keywords, "[^a-zA-Z0-9% ._]", string.Empty);
            var splitted = fixedInput.Split(' ');

            keywords = "";

            // create new keywords string with api parameters
            foreach (string s in splitted)
            {
                keywords = keywords + "q=" + s + "&";
            }
            var http = new HttpClient();

            // search function for general news
            if (category.Equals("General"))
            {
                response = await http.GetAsync("https://newsapi.org/v2/everything?" +
                     keywords +
                     "sortBy=publishedAt&language=en&apiKey=96eea05140b246f5beb991ced70bfe8c");
            }
            else
            {
            // search for non general news
                response = await http.GetAsync("https://newsapi.org/v2/top-headlines?country=us&" +
                     keywords +
                     "category=" +
                     category + "&sortBy=publishedAt&language=en&apiKey=96eea05140b246f5beb991ced70bfe8c");
            }



            // serialise the json result and convert into rootobject
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            // return root object news result
            return data;
        }

        // Gets user location and returns 2 letter country code
        private static String GetLocation()
        {
            var geographicRegion = new Windows.Globalization.GeographicRegion();
            var code = geographicRegion.CodeTwoLetter;

            return code;
        }
    }


    // class for news root object

    [DataContract]
    public class Source
    {   [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Article
    {
        [DataMember]
        public Source source { get; set; }
        [DataMember]
        public string author { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string urlToImage { get; set; }
        [DataMember]
        public string publishedAt { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public int totalResults { get; set; }
        [DataMember]
        public List<Article> articles { get; set; }
    }
}
