using System;
namespace FeedBag.Models
{
    public class FeedNew
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string UrlImage { get; set; }
        public string PubDate { get; set; }
        public string Creator { get; set; }
        public string Category { get; internal set; }
    }
}

