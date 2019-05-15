using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsFetcherApi.Logic;
using NewsFetcherApi.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsFetcherApi.Controllers
{
    [Route("api/NewsFetcher")]
    public class NewsFetcherController : Controller
    {
        // GET: api/<controller> 
        [HttpGet("everything")]
        public IEnumerable<Article> Get()
        {
            
            //IRestResponse response = sendRequest(buildRequest(), "everything", "trump");
             NewsApiNewsSource nas= new NewsApiNewsSource();
            IEnumerable<Article> articles = (nas.FechNewsArticles("everything", "trump"));
            
            return articles;
        }
        [HttpGet("everything/NewYorkTimes")]
        public IEnumerable<Article> GetNewsFromNewYorkTimes()
        {

            IEnumerable<Article> articles = Get();
            return filterNewsBySourceID("the-new-york-times", articles);



        }
        private IEnumerable<Article> filterNewsBySourceID(string newsSoureId, IEnumerable<Article> articles)
        {
            List<Article> filterdArticles = new List<Article>();
           
            foreach (Article a in articles)
            {
                if (a.source==null||a.source.Id == null)
                    continue;
                if (a.source.Id.ToString().Equals(newsSoureId, StringComparison.InvariantCultureIgnoreCase))
                {
                    filterdArticles.Add(a);
                }
            }
            return filterdArticles;
        }
            
        

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
