using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieTimeWebAPI.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [Required]
        [DataMember]
        public string NomCategorie { get; set; }

        public IList<Film> Films { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }

    }
}