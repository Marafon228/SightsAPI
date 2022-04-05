namespace SightsAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelsReservation")]
    public partial class HotelsReservation
    {
        public int Id { get; set; }

        public int HotelsId { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
    }
}
