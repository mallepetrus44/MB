using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MB.Server.Migrations
{
    public partial class _23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Achternaam", "Adres", "Bovenwijdte", "FotoModelId", "Fotos", "Geboortedatum", "GebruikerId", "Geslacht", "Goedgekeurd", "Heupwijdte", "Leeftijd", "Lengte", "Postcode", "Stad", "Taillewijdte", "Voornaam" },
                values: new object[,]
                {
                    { "76fac058-760b-48a2-8686-f6e5a2e23a1e", 0, "ee2ba444-29f4-4dc5-a601-444ea07c2532", "FotoModel", "", false, false, null, null, null, "", null, false, "0994e0f4-b8ae-4daa-b86e-6dd2696b6f97", false, null, "Vermeulen", "Leemwierde 40", 90, 1, "", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, false, 90, 35, 178, "1353 LT", "Almere", 61, "Fleur" },
                    { "6e53523d-a016-479a-b4c5-77b5357b00b8", 0, "7e5c2af0-fea1-488d-8d79-c5d0683b3ec4", "FotoModel", "", false, false, null, null, null, "", null, false, "c282a858-09f9-4f5e-a42e-1fc1a6a5db55", false, null, "de Wit", "Oregondreef 102", 86, 2, "", new DateTime(1991, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, false, 87, 29, 175, "3565 BG", "Utrecht", 59, "Lynn" },
                    { "a1191c5e-b2e4-47b2-a748-09dd916135b2", 0, "be9f4d37-c767-400e-a1eb-81c649658f5f", "FotoModel", "", false, false, null, null, null, "", null, false, "a261543b-c2d3-47f1-92d5-0471cd84d0d9", false, null, "Peters", "Dollardstraat 2", 101, 3, "", new DateTime(1980, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, false, 99, 41, 184, "1826 CS", "Alkmaar", 81, "Luuk" },
                    { "fcd3901d-0b7e-4178-b077-e0e93d7b00e1", 0, "3fe28157-f647-46a9-94a0-301e3c0289a5", "FotoModel", "", false, false, null, null, null, "", null, false, "c063424d-0acf-410c-b35b-67290d79a242", false, null, "Meijer", "Martin Luther Kinglaan 93", 100, 4, "", new DateTime(1990, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0, false, 100, 30, 185, "1111 LK", "Diemen", 81, "Stefan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Achternaam", "Adres", "BtwNummer", "GebruikerId", "Goedgekeurd", "KlantId", "KvkNummer", "Logo", "Postcode", "Stad", "Voornaam" },
                values: new object[,]
                {
                    { "024a0ef7-dd29-4e27-82f5-dfb220a872da", 0, "9e0d04d4-cbb3-437f-b4c2-9166099d2e0f", "Klant", "", false, false, null, null, null, "", null, false, "186b603e-cfd0-4ebb-a2e7-b2bc9eb22f0b", false, null, "Janssen", "Verdilaan 107", "NL123456789B01", 1, false, 1, 12345678, "", "4384 LG", "Vlissingen", "Klaas" },
                    { "f641ec09-1ec5-4f27-b09f-0aeed4a9c645", 0, "499eb86d-59ba-45d5-a3f9-16059553fc1f", "Klant", "", false, false, null, null, null, "", null, false, "ff6e1e98-0977-45d5-8179-04aae47c581c", false, null, "Gerritsen", "Uiterburen 13", "NL234567890B02", 2, false, 2, 23456789, "", "9636 EC", "Groningen", "Angelina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e53523d-a016-479a-b4c5-77b5357b00b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76fac058-760b-48a2-8686-f6e5a2e23a1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1191c5e-b2e4-47b2-a748-09dd916135b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fcd3901d-0b7e-4178-b077-e0e93d7b00e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "024a0ef7-dd29-4e27-82f5-dfb220a872da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f641ec09-1ec5-4f27-b09f-0aeed4a9c645");
        }
    }
}
