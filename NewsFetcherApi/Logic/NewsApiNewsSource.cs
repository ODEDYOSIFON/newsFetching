using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsFetcherApi.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace NewsFetcherApi.Logic
{
    public class NewsApiNewsSource : INewsSource
    {

        readonly string url = "https://newsapi.org/v2";
        readonly string apiKey = "bd5b5f9000df4a1ea8e071efcca1bf48";
       
        /// <summary>
        /// /
        /// </summary>
        /// <param name="category"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Article> FechNewsArticles(string category, string query)
        {
            List<Article> result = new List<Article>();
            string requstUrl = string.Format("{0}//{1}?q={2}&apiKey={3}", url, category, query, apiKey);

            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            var client = new RestClient(requstUrl);
            IRestResponse r= client.Execute(request);
            IEnumerable<Article> articles = parseNewsApiJsonToArticle(r.Content);
            result.AddRange(articles);
            return result;
        }

        public IEnumerable<Article> parseNewsApiJsonToArticle(string content)
        {
            var result = new List<Article>();
            var myContentOj = JObject.Parse(content);
            JArray a = (JArray)myContentOj["articles"];
            IList<Article> articles = a.ToObject<IList<Article>>();
            var totalResults = myContentOj["totalResults"];
            return articles;

        }
    }
}
