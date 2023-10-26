using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FeedBag.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            EnterCommand = new Command(async () => await EnterMethod(null));
        }

        private async Task EnterMethod(object obj)
        {
            //IsLoading = true;
            //await Task.Delay(TimeSpan.FromSeconds(15).Milliseconds);
            //IsLoading = false;

            // Navegar a la siguiente pagina
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set => Set(ref _Email, value);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get => _IsLoading;
            set => Set(ref _IsLoading, value);
        }

        public ICommand EnterCommand { get; set; }
    }
}