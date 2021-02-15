using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MB.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    GebruikerId = table.Column<int>(nullable: true),
                    Goedgekeurd = table.Column<bool>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Stad = table.Column<string>(nullable: true),
                    FotoModelId = table.Column<int>(nullable: true),
                    Leeftijd = table.Column<int>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: true),
                    Geslacht = table.Column<int>(nullable: true),
                    Bovenwijdte = table.Column<int>(nullable: true),
                    Taillewijdte = table.Column<int>(nullable: true),
                    Heupwijdte = table.Column<int>(nullable: true),
                    Lengte = table.Column<int>(nullable: true),
                    Fotos = table.Column<string>(nullable: true),
                    KlantId = table.Column<int>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    KvkNummer = table.Column<int>(nullable: true),
                    BtwNummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Achternaam", "Adres", "Bovenwijdte", "FotoModelId", "Fotos", "Geboortedatum", "GebruikerId", "Geslacht", "Goedgekeurd", "Heupwijdte", "Leeftijd", "Lengte", "Postcode", "Stad", "Taillewijdte", "Voornaam" },
                values: new object[,]
                {
                    { "587b89d3-11d0-42c7-b5bc-b7947998dadc", 0, "efaa986a-3208-465a-abeb-b7d3424dd1cf", "FotoModel", "", false, false, null, null, null, "", null, false, "c52c1c5e-e4b5-4a84-9d72-dd9015f2ee8b", false, null, "Vermeulen", "Leemwierde 40", 90, 1, "", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, false, 90, 35, 178, "1353 LT", "Almere", 61, "Fleur" },
                    { "011918d1-95a3-4f3d-ab11-9b9dade39edc", 0, "d78b8fca-b68c-4204-b4d5-7e76e6585e40", "FotoModel", "", false, false, null, null, null, "", null, false, "fc13ab60-2abc-4daf-a86a-0c3f2edd50c3", false, null, "de Wit", "Oregondreef 102", 86, 2, "", new DateTime(1991, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, false, 87, 29, 175, "3565 BG", "Utrecht", 59, "Lynn" },
                    { "8d0021e9-5897-4c0b-be53-8e5fc9539554", 0, "5f579f8d-b5f9-4832-958d-4efd2bd5fbd4", "FotoModel", "", false, false, null, null, null, "", null, false, "9b20a9f2-8854-49dc-a528-458469c499ba", false, null, "Peters", "Dollardstraat 2", 101, 3, "", new DateTime(1980, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, false, 99, 41, 184, "1826 CS", "Alkmaar", 81, "Luuk" },
                    { "7e8dcb3f-7c3c-48f5-b49e-3d6ea7eb7793", 0, "7d47a5df-f94b-4069-b919-e943ac2c5cd5", "FotoModel", "", false, false, null, null, null, "", null, false, "05f2c60d-1609-4b68-a48c-41405ff37f27", false, null, "Meijer", "Martin Luther Kinglaan 93", 100, 4, "", new DateTime(1990, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0, false, 100, 30, 185, "1111 LK", "Diemen", 81, "Stefan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Achternaam", "Adres", "BtwNummer", "GebruikerId", "Goedgekeurd", "KlantId", "KvkNummer", "Logo", "Postcode", "Stad", "Voornaam" },
                values: new object[,]
                {
                    { "2df5e957-a3da-4b33-acf7-e93cb3b6127e", 0, "cb2447ba-6b00-436c-8c5f-8466968a21bc", "Klant", "", false, false, null, null, null, "", null, false, "4dfde062-c6d2-451a-937d-4e5644b45b66", false, null, "Janssen", "Verdilaan 107", "NL123456789B01", 1, false, 1, 12345678, "", "4384 LG", "Vlissingen", "Klaas" },
                    { "a97686cd-bed8-4054-94a9-0cefd92730bf", 0, "9b1eda94-d5e2-475d-bafe-48099d3623a3", "Klant", "", false, false, null, null, null, "", null, false, "68f4ee3f-4264-41d2-abd7-3f47b56dfb63", false, null, "Gerritsen", "Uiterburen 13", "NL234567890B02", 2, false, 2, 23456789, "", "9636 EC", "Groningen", "Angelina" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
