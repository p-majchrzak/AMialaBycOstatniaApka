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
    public partial class PodstronaDnia : ContentPage
    {
        public PodstronaDnia(DateTime data)
        {
            InitializeComponent();
            DzienMiesiacRok.Text = data.ToString("dd MMMM yyyy");
        }
    }
}