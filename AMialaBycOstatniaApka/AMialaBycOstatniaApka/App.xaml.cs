using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMialaBycOstatniaApka
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WybieradloXD());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
