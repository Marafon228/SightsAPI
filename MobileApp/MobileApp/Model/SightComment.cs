using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Model
{
    public class SightComment
    { 
        public int Id { get; set; }
        public int SightsId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
