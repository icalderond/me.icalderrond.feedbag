using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using FeedBag.Models;

namespace FeedBag
{
    public class RSSService
    {
        private readonly WebClient _webClient;
        private readonly string _rssWorldUrlString;

        public RSSService()
        {
            _webClient = new WebClient();
            _rssWorldUrlString = @"https://www.theguardian.com/world/rss";
        }

        public async Task<List<FeedNew>> GetNews()
        {
            var xmlString = await _webClient.DownloadStringTaskAsync(_rssWorldUrlString);

            XDocument xDocument = XDocument.Parse(xmlString);
            XNamespace media = xDocument.Root.GetNamespaceOfPrefix("media");
            XNamespace dc = xDocument.Root.GetNamespaceOfPrefix("dc");

            var elements = (from news in xDocument.Descendants("channel").Elements("item")
                            select new FeedNew
                            {
                                Title = news.Element("title").Value,
                                Description = news.Element("description").Value,
                                Link = news.Element("link").Value,
                                UrlImage = news.Elements(media + "content").Last().Attribute("url").Value,
                                PubDate = news.Element("pubDate").Value,
                                Creator = news.Element(dc + "creator").Value,
                                Category = news.Elements("category").Last().Value
                            }).ToList();

            return elements;
        }
    }
}

