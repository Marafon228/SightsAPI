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
    public partial class DetailsHotel : ContentPage
    {

        public Hotel CurrentHotel { get; set; }
        public HotelComment CurrentComment { get; set; } = new HotelComment();
        public DetailsHotel(Hotel currentHotel)
        {
            InitializeComponent();

            CurrentHotel = currentHotel;
            CurrentComment.HotelId = currentHotel.Id;
            BindingContext = this;

            UpdateComments();

        }

        private void UpdateComments()
        {
            var client = new WebClient();
            var response = client.DownloadString("http://192.168.0.101:56064/api/HotelComments/getHotelComments?hotelId=" + CurrentHotel.Id);
            ListViewComments.ItemsSource = JsonConvert.DeserializeObject<List<HotelComment>>(response);
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var result = client.UploadString("http://192.168.0.101:56064/api/HotelComments/PostHotelComments", JsonConvert.SerializeObject(CurrentComment));
            UpdateComments();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReservationHotel(CurrentHotel));
        }
    }
}