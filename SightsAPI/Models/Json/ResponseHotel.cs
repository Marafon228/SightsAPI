using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SightsAPI.Models.Json
{
    public class ResponseHotel
    {

        public ResponseHotel(Hotel hotel)
        {
            Id = hotel.Id;
            Name = hotel.Name;
            CountOfStars = hotel.CountOfStars;
            Description = hotel.Description;
            ImagePreview = hotel.ImagePreview;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfStars { get; set; }
        public string Description { get; set; }
        public byte[] ImagePreview { get; set; }
    }
}