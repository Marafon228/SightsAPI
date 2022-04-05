using MobileApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private async void Button_Sights(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SightsView(), true);
        }

        private async void Button_Hotel(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HotelView(), true);
        }
    }
}
