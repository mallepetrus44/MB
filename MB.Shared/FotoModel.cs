using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MB.Shared
{
    public class FotoModel : Gebruiker
    {
        public int FotoModelId { get; set; }
        public int Leeftijd
        {
            get { return (DateTime.Today - Geboortedatum).Days / 365; }
            set { }
        }


        [Required]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }
        [Required]
        public Geslacht Geslacht { get; set; }

        [Required]
        public int Bovenwijdte { get; set; }
        [Required]
        public int Taillewijdte { get; set; }
        [Required]
        public int Heupwijdte { get; set; }
        [Required]
        public int Lengte { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Fotos { get; set; }
    }
}
