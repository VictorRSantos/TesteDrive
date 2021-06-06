using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TesteDrive.Views;
using TesteDrive.Models;

namespace TesteDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {

            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (usuario) =>
            {

                //MainPage = new NavigationPage(new ListagemView());

                MainPage = new FlyoutPageView();

            });

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
