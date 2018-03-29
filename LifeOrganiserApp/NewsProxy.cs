using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace LifeOrganiserApp
{
    class NewsProxy
    {
        public async static Task<RootObject> GetNews()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://newsapi.org/v2/top-headlines?" +
          //"country=us&" +
          "apiKey=96eea05140b246f5beb991ced70bfe8c");

            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }
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
