using MB.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<FotoModel> FotoModellen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data Customer
            modelBuilder.Entity<Klant>().HasData(new Klant
            {
                KlantId = 1,
                KvkNummer = 12345678,
                BtwNummer = "NL123456789B01",
                GebruikerId = 1,
                Voornaam = "Klaas",
                Achternaam = "Janssen",
                Adres = "Verdilaan 107",
                Stad = "Vlissingen",
                Postcode = "4384 LG",
                Email = "",
                PasswordHash = "",
                Logo = ""
            });
            modelBuilder.Entity<Klant>().HasData(new Klant
            {
                KlantId = 2,
                KvkNummer = 23456789,
                BtwNummer = "NL234567890B02",
                GebruikerId = 2,
                Voornaam = "Angelina",
                Achternaam = "Gerritsen",
                Adres = "Uiterburen 13",
                Stad = "Groningen",
                Postcode = "9636 EC",
                Email = "",
                PasswordHash = "",
                Logo = ""
            });

            // Seed data Photomodel
            modelBuilder.Entity<FotoModel>().HasData(new FotoModel
            {
                GebruikerId = 3,
                Voornaam = "Fleur",
                Achternaam = "Vermeulen",
                Adres = "Leemwierde 40",
                Stad = "Almere",
                Postcode = "1353 LT",
                Email = "",
                PasswordHash = "",
                FotoModelId = 1,
                Geboortedatum = DateTime.ParseExact("15/06/1985", "dd/MM/yyyy", null),
                Geslacht = Geslacht.Vrouw,
                Bovenwijdte = 90,
                Taillewijdte = 61,
                Heupwijdte = 90,
                Lengte = 178,
                Fotos = ""
            });
            modelBuilder.Entity<FotoModel>().HasData(new FotoModel
            {
                GebruikerId = 4,
                Voornaam = "Lynn",
                Achternaam = "de Wit",
                Adres = "Oregondreef 102",
                Stad = "Utrecht",
                Postcode = "3565 BG",
                Email = "",
                PasswordHash = "",
                FotoModelId = 2,
                Geboortedatum = DateTime.ParseExact("23/08/1991", "dd/MM/yyyy", null),
                Geslacht = Geslacht.Vrouw,
                Bovenwijdte = 86,
                Taillewijdte = 59,
                Heupwijdte = 87,
                Lengte = 175,
                Fotos = ""
            });
            modelBuilder.Entity<FotoModel>().HasData(new FotoModel
            {
                GebruikerId = 5,
                Voornaam = "Luuk",
                Achternaam = "Peters",
                Adres = "Dollardstraat 2",
                Stad = "Alkmaar",
                Postcode = "1826 CS",
                Email = "",
                PasswordHash = "",
                FotoModelId = 3,
                Geboortedatum = DateTime.ParseExact("04/01/1980", "dd/MM/yyyy", null),
                Geslacht = Geslacht.Man,
                Bovenwijdte = 101,
                Taillewijdte = 81,
                Heupwijdte = 99,
                Lengte = 184,
                Fotos = ""
            });
            modelBuilder.Entity<FotoModel>().HasData(new FotoModel
            {
                GebruikerId = 6,
                Voornaam = "Stefan",
                Achternaam = "Meijer",
                Adres = "Martin Luther Kinglaan 93",
                Stad = "Diemen",
                Postcode = "1111 LK",
                Email = "",
                PasswordHash = "",
                FotoModelId = 4,
                Geboortedatum = DateTime.ParseExact("25/11/1990", "dd/MM/yyyy", null),
                Geslacht = Geslacht.Man,
                Bovenwijdte = 100,
                Taillewijdte = 81,
                Heupwijdte = 100,
                Lengte = 185,
                Fotos = ""
            });
            //modelBuilder.Entity<Admin>().HasData(new Admin
            //{
            //    AppUserId = 7,
            //    AdminId = 1,
            //    Voornaam = "Admin",
            //    Achternaam = "Beheerder",
            //    Adres = "Karel Luther Queenlaan 12",
            //    Stad = "Den Haag",
            //    Postcode = "1212 DE",
            //    Email = "",
            //    Paswoord = "",
            //});
        }
    }


}
