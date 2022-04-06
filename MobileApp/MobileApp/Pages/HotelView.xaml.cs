using MobileApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HotelView : ContentPage
    {
        public HotelView()
        {
            InitializeComponent();

            var client = new WebClient();
            var response = client.DownloadString("http://192.168.0.100:56064/api/Hotels/Hotels");
            ListViewHotels.ItemsSource = JsonConvert.DeserializeObject<List<Hotel>>(response);

        }

        private void ListViewHotels_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DetailsHotel(ListViewHotels.SelectedItem as Hotel));
        }
    }
}