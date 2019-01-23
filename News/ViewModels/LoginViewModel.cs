using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Models;
using News.Services;
using News.Views;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IDataStore<UserInfo> LoginStore => DependencyService.Get<IDataStore<UserInfo>>() ?? new LoginDataStore();

        private UserInfo currentUser;

        public UserInfo CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged();
            }
        }

        private bool pageIsBusy = false;

        public bool PageIsBusy
        {
            get { return pageIsBusy; }
            set
            {
                pageIsBusy = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            currentUser = new UserInfo();
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        async Task ExecuteLoginCommand()
        {
            ////*****NOTE*****
            /// Implement your (WebAPI) service call here through HttpClient
            /// Pass UserInfo object as parameters and save return response in local database
            /// 
            /// *********************************************
            /// For demo purpose i'll use hardcode user object
            /// 
            ////Get admin user using First record.(this value should be taken through Server).

            PageIsBusy = true;
            await Task.Delay(3000);////Uncomment this line once check loading icon

            UserInfo user = LoginStore.GetItemAsync("1").Result;

            if (user != null)
            {
                if (CurrentUser.UserName == user.UserName && CurrentUser.Password == user.Password)
                {
                    App.Current.MainPage = new ItemsPage();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Wrong Username or Password!", "Please try again", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error!","Please contact administrator","Ok"); 
            }

            ///Demo code end....
            ///*********************************************


            PageIsBusy = false;
            return;

            ///TODO.. save token value to local database. 
        }


    }
}
