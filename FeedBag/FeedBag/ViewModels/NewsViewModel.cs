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

        private RSSService _RSSService;
        public RSSService RSSService
        {
            get => _RSSService = _RSSService ?? new RSSService();
            set => _RSSService = value;
        }

        public async void Initialize()
        {
            var _feedNewList = await RSSService.GetNews();

            FeedNewItem = _feedNewList.FirstOrDefault();
            FeedNewList = new ObservableCollection<FeedNew>(_feedNewList.GetRange(1, _feedNewList.Count - 1));
        }
    }
}

