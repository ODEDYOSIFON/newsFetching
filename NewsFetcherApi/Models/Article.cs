using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFetcherApi.Models
{
    public class Source
    {
        public Source()
        {

        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Article
    {
        public Article()
        {
            source = new Source();
        }
        public Source source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
