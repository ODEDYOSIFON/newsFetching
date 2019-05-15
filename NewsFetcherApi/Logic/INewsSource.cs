using NewsFetcherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFetcherApi.Logic
{
    public interface INewsSource
    {
      
         IEnumerable<Article> FechNewsArticles(string category, string query);
    }
}
