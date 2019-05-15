using NewsFetcherApi.Logic;
using NewsFetcherApi.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace NewsFetchingTestProject
{

    public class NewsApiSourceTests
    {
        [Test]
        public void NewApiResultParseTest()
        {
            var a=TestContext.CurrentContext.TestDirectory;
            string content = File.ReadAllText("../../../testData.json");
           
            IEnumerable<Article> articles = new NewsApiNewsSource().parseNewsApiJsonToArticle(content);
            Assert.GreaterOrEqual(articles.Count(), 1);
        }
    }
}
