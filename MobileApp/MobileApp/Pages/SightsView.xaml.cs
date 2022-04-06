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
    public partial class SightsView : ContentPage
    {
        public SightsView()
        {
            InitializeComponent();
            var client = new WebClient();
            var response = client.DownloadString("http://192.168.0.100:56064/api/Sights/Sights");
            ListViewSights.ItemsSource = JsonConvert.DeserializeObject<List<Sight>>(response);
        }

        private void ListViewSights_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DetailsSight(ListViewSights.SelectedItem as Sight));
        }
    }
}