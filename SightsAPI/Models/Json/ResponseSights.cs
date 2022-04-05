using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SightsAPI.Models.Json
{
    public class ResponseSights
    {
        public ResponseSights(Sights sights)
        {
            Id = sights.Id;
            Name = sights.Name;
            Description = sights.Description;
            SightsImage = sights.ImagePreview;
            
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] SightsImage { get; set; }


    }
}