using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MB.Shared
{
    public class Gebruiker : IdentityUser
    {
        public int GebruikerId { get; set; }
        [Required]
        public bool Goedgekeurd { get; set; }

        // NAW gegevens
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Stad { get; set; }
    }
}
