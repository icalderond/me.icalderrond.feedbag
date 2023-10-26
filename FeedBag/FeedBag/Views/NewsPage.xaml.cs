using FeedBag.ViewModels;
using Xamarin.Forms;

namespace FeedBag.Views
{
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            this.BindingContext = new NewsViewModel();
        }
    }
}

