using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FeedBag.Models;

namespace FeedBag.ViewModels
{
    public class NewsViewModel : ViewModelBase
    {
        public NewsViewModel()
        {
            Initialize();
        }

        private ObservableCollection<FeedNew> _FeedNewList;
        public ObservableCollection<FeedNew> FeedNewList
        {
            get => _FeedNewList;
            set => Set(ref _FeedNewList, value);
        }

        private FeedNew _FeedNewItem;
        public FeedNew FeedNewItem
        {
            get => _FeedNewItem;
            set => Set(ref _FeedNewItem, value);
        }

        public void Initialize()
        {
            var _feedNewList = new List<FeedNew>();
            for (int i = 0; i < 10; i++)
            {
                _feedNewList.Add(new FeedNew
                {
                    Title = "Girls in Africa quitting school over cost of living crisis, says charity",
                    Description = $"<p>Camfed calls for six-year plan to get 6 million girls into school, warning that drop-out rate is limiting children’s chances</p><p>Governments and donors need to redouble efforts to encourage girls back to school across Africa after the cost of living crisis pushed many to spurn education for low-paid work or early marriage, a charity has warned.</p><p>Camfed, which operates in five African countries, said its partnership model proved this could be achieved and <a href=\"https://camfed.org/camfed-launches-vision-for-2030/\">called for a six-year plan</a> to get 6 million girls into school.</p> <a href=\"https://www.theguardian.com/global-development/2023/oct/25/girls-in-africa-quitting-school-over-cost-of-living-crisis-says-charity\">Continue reading...</a>",
                    UrlImage = "https://i.guim.co.uk/img/media/49a7f25a3ef7ecf19b33243a002a34b9cb80a830/0_26_4823_2894/master/4823.jpg?width=460&quality=85&auto=format&fit=max&s=77d735d9b4ab6af6708c85547314746b",
                    Creator = "Phillip Inman",
                    PubDate = DateTime.Now.ToShortDateString()
                });
            }

            FeedNewItem = _feedNewList.FirstOrDefault();
            FeedNewList = new ObservableCollection<FeedNew>(_feedNewList.GetRange(1, _feedNewList.Count - 1));
        }
    }
}

