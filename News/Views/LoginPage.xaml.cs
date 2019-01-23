using System;
using System.Collections.Generic;
using News.ViewModels;
using Xamarin.Forms;

namespace News.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
