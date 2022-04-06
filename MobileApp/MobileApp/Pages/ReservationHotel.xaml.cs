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
    public partial class ReservationHotel : ContentPage
    {
        public Hotel CurrentHotel { get; set; }
        public HotelsReservation CurrentReservationHotel { get; set; } = new HotelsReservation();
        public ReservationHotel(Hotel hotel)
        {
            InitializeComponent();


            CurrentHotel = hotel;
            CurrentReservationHotel.HotelsId = hotel.Id;
            BindingContext = this;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var result = client.UploadString("http://192.168.0.100:56064/api/HotelsReservations/PostReservationHotel", JsonConvert.SerializeObject(CurrentReservationHotel));

            DisplayAlert("Уведомление", "В ближайшее время с вами свяжется отель", "Oк");
        }
    }
}