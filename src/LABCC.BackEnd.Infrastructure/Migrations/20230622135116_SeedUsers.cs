using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABCC.BackEnd.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Document", "Email", "Gender", "IsActive", "Name", "Telephone", "UpdatedAt", "UserType" },
                values: new object[,]
                {
                    { 1L, new DateTime(2000, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1687441875843L, "278.656.291-09", "lucas_diego@gimail.com", 0, true, "Lucas Diego Santos", "(63) 99729-3374", 1687441875843L, 0 },
                    { 2L, new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1687441875843L, "121.682.363-48", "marcos.mateus.campos@doublesp.com.br", 0, true, "Marcos Mateus Anthony Campos", "(75) 99404-5248", 1687441875843L, 3 },
                    { 3L, new DateTime(1954, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1687441875843L, "493.617.515-30", "mirella_beatriz_lima@engeseg.com.br", 1, true, "Mirella Beatriz Lima", "(62) 98420-9876", 1687441875843L, 0 },
                    { 4L, new DateTime(1996, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1687441875843L, "864.306.046-16", "antonio_carlos_dias@lukin4.com.br", 2, true, "Antonio Carlos Eduardo Dias", "(65) 99579-0748", 1687441875843L, 1 },
                    { 5L, new DateTime(1998, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1687441875843L, "945.981.184-15", "kamilly.antonia.almeida@onset.com.br", 1, true, "Kamilly Antônia Almeida", "(93) 98644-1270", 1687441875843L, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
