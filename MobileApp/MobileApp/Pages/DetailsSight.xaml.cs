using MobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsSight : ContentPage
    {
        public Sight CurrentSight { get; set; }
        public DetailsSight(Sight sight)
        {
            InitializeComponent();
            CurrentSight = sight;
            BindingContext = this;
        }
    }
}