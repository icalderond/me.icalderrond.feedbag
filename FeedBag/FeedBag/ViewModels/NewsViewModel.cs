using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FeedBag.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FeedBag.ViewModels
{
    public class NewsViewModel : ViewModelBase
    {
        public NewsViewModel()
        {
            Initialize();
            OpenLinkPubCommand = new Command<object>(OpenLinkPub);
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

        private bool _IsLoading;
        public bool IsLoading
        {
            get => _IsLoading;
            set => Set(ref _IsLoading, value);
        }

        public ICommand OpenLinkPubCommand { get; set; }

        private async void Initialize()
        {
            IsLoading = true;
            var _feedNewList = await RSSService.GetNews();

            FeedNewItem = _feedNewList.FirstOrDefault();
            FeedNewList = new ObservableCollection<FeedNew>(_feedNewList.GetRange(1, _feedNewList.Count - 1));
            IsLoading = false;
        }

        private void OpenLinkPub(object _linkObject)
        {
            var linkString = _linkObject.ToString();
            //Launcher.OpenAsync(linkString);
            Browser.OpenAsync(linkString, BrowserLaunchMode.SystemPreferred);
        }
    }
}