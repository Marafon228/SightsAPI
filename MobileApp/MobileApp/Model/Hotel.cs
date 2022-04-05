using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfStars { get; set; }
        public string Description { get; set; }
        public string ImagePreview { get; set; }
        public ImageSource Photo
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(ImagePreview)));
            }
        }
    }
}
