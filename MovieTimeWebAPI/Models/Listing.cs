using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }

        public int AvisUtil { get; set; }
        [Required]
        [DataMember]
        public bool Visionnage { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public Film Film { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}