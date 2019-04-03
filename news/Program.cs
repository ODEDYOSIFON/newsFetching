using RestSharp;
using System;
//https://newsapi.org/v2/top-headlines?sources=google-news-is&
namespace news
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var client = new RestClient("https://newsapi.org/v2/top-headlines?sources=cnn&apiKey=bd5b5f9000df4a1ea8e071efcca1bf48");
            var client = new RestClient("https://newsapi.org/v2/everything?q=trump&apiKey=bd5b5f9000df4a1ea8e071efcca1bf48");
            var request = new RestRequest(Method.GET);
           // request.AddHeader("Postman-Token", "899535ed-04c1-4943-b292-f36958ecda03");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            string s = response.Content;
            if (string.IsNullOrWhiteSpace(s))
            {
                Console.Write("nothing to retreive");
            } 
            else
                Console.Write(s);
            Console.ReadLine();
        }
    }
}
