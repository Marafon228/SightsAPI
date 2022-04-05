using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Model
{
    public class HotelsReservation
    {
        public int Id { get; set; }
        public int HotelsId { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public string Phone { get; set; }
    }
}
