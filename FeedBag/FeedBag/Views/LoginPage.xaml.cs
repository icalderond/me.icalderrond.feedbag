using System;
using System.Collections.Generic;
using FeedBag.ViewModels;
using Xamarin.Forms;

namespace FeedBag.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //BindingContext
            this.BindingContext = new LoginViewModel();
        }
    }
}

