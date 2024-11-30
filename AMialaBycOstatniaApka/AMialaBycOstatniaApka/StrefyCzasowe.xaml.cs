using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMialaBycOstatniaApka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StrefyCzasowe : ContentPage
    {
        public StrefyCzasowe()
        {
            InitializeComponent();
            PobierzCzas();
        }
        public void PobierzCzas()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DateTime dateTime = DateTime.Now;
                    GMT1.Text = dateTime.ToString("HH:mm:ss");
                    GMT0.Text = dateTime.AddHours(-1).ToString("HH:mm:ss");
                    GMT3.Text = dateTime.AddHours(+2).ToString("HH:mm:ss");
                });
                return true;
            });
        }
    }
}