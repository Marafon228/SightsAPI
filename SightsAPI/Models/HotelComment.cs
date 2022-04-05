namespace SightsAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelComment")]
    public partial class HotelComment
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
    }
}
