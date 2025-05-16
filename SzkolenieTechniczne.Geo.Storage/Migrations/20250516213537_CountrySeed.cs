using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolenieTechniczne.Geo.Storage.Migrations
{
    public partial class CountrySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var polId = Guid.NewGuid();
            var usaId = Guid.NewGuid();
            var gbrId = Guid.NewGuid();
            var deuId = Guid.NewGuid();
            var fraId = Guid.NewGuid();

            migrationBuilder.InsertData(
                schema: "Geo",
                table: "Countries",
                columns: new[] { "Id", "Alpha3Code" },
                values: new object[,]
                {
                    { polId, "POL" },
                    { usaId, "USA" },
                    { gbrId, "GBR" },
                    { deuId, "DEU" },
                    { fraId, "FRA" }
                });

            migrationBuilder.InsertData(
                schema: "Geo",
                table: "CountryTranslations",
                columns: new[] { "Id", "CountryId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { Guid.NewGuid(), polId, "pl", "Polska" },
                    { Guid.NewGuid(), polId, "en", "Poland" },
                    { Guid.NewGuid(), usaId, "pl", "Stany Zjednoczone" },
                    { Guid.NewGuid(), usaId, "en", "United States" },
                    { Guid.NewGuid(), gbrId, "pl", "Wielka Brytania" },
                    { Guid.NewGuid(), gbrId, "en", "Great Britain" },
                    { Guid.NewGuid(), deuId, "pl", "Niemcy" },
                    { Guid.NewGuid(), deuId, "en", "Germany" },
                    { Guid.NewGuid(), fraId, "pl", "Francja" },
                    { Guid.NewGuid(), fraId, "en", "France" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Geo.CountryTranslations");
            migrationBuilder.Sql("DELETE FROM Geo.Countries");
        }
    }
}