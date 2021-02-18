using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MB.Shared
{
    public class Klant : Gebruiker
    {
        public int KlantId { get; set; }

        //[Required]
        public string Logo { get; set; }
        [Required]
        public int KvkNummer { get; set; }
        [Required]
        public string BtwNummer { get; set; }
    }
}
