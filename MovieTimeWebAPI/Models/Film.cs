using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        [DataMember]
        [Required]
        public string Titre { get; set; }
        [DataMember]
        [Required]
        public string Description { get; set; }
        [Required]
        [DataMember]
        public int Duree { get; set; }
        [Required]
        [DataMember]
        public DateTime DateSortie { get; set; }
        [Required]
        [DataMember]
        public string Realisateur { get; set; }

        public double AvisDuSite { get; set; }

        [Required]
        public Categorie Categorie { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}