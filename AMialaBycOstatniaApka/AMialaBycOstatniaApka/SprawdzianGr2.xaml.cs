﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMialaBycOstatniaApka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SprawdzianGr2 : ContentPage
    {
        DateTime wybrany = DateTime.Now;
        public SprawdzianGr2()
        {
            InitializeComponent();
            PobierzCzas();
            PobierzMiesiac();
        }
        public void PobierzCzas()
        {
            Device.StartTimer(new TimeSpan(0,0,0,1), () => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    GodzinaBTN.Text = DateTime.Now.ToString("HH:mm:ss");
                });
                return true;
            });
        }
        public void PobierzMiesiac()
        {
            Kalendarz.Children.Clear();
            MiesiacTXT.Text = wybrany.ToString("MMMM yyyy");
            int dzien = 1;
            int dniWMiesiacu = DateTime.DaysInMonth(wybrany.Year, wybrany.Month);
            DateTime pierwszy = new DateTime(wybrany.Year, wybrany.Month, 1);
            int start = ((int)pierwszy.DayOfWeek+6) % 7;
            
            for(int i=0; i<6; i++)
            {
                for(int j=0; j<7; j++)
                {
                    if(dzien > dniWMiesiacu)
                    {
                        return;
                    }
                    if(i==0 && j < start)
                    {
                        continue;
                    }
                    Label label = new Label
                    {
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Text = dzien.ToString()
                    };
                    if(DateTime.Now.Day == dzien && DateTime.Now.Year == wybrany.Year && DateTime.Now.Month == wybrany.Month)
                    {
                        label.TextColor = Color.LightBlue;
                    }
                    Grid.SetRow(label,i);
                    Grid.SetColumn(label,j);
                    dzien++;
                    Kalendarz.Children.Add(label);
                }
            }
        }
        private void Poprzedni_Clicked(object sender, EventArgs e)
        {
            wybrany = wybrany.AddMonths(-1);
            PobierzMiesiac();
        }

        private void Nastepny_Clicked(object sender, EventArgs e)
        {
            wybrany = wybrany.AddMonths(+1);
            PobierzMiesiac();
        }
    }
}