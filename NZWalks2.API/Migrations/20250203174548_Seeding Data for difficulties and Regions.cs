using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks2.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatafordifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6b2f0073-e323-4f68-a877-82df278f9d52"), "Hard" },
                    { new Guid("a9d76f8b-8c1d-460f-bee2-15f66a01b935"), "Easy" },
                    { new Guid("f58c0961-78ff-4409-98c1-78eebd6711af"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUrl" },
                values: new object[,]
                {
                    { new Guid("3dcff596-fc30-41b9-a41b-1f09be94609e"), "5TH", "Fifth Settlement", "https://realogy.co/images/upload/154046762.png" },
                    { new Guid("adcc7a33-c9af-4170-ae95-bdbe84997bed"), "MD", "Maadi", "https://i.pinimg.com/originals/5e/3e/52/5e3e523305335dcb1bbe62197aa9e992.jpg" },
                    { new Guid("b9bd929c-ef15-4da9-8442-ff222663b976"), "ZM", "Zamalek", "https://2.bp.blogspot.com/-xsxTSZLgKag/UMGdtlTX5EI/AAAAAAAAACA/svGNjqTNEtQ/s1600/IMG_0629.JPG" },
                    { new Guid("c6877914-d178-4be0-9042-128d90ce58c1"), "TMG", "Madinaty", "https://th.bing.com/th/id/OIP.yf37VeOe1ka70Q5F0tLs-wHaEo?rs=1&pid=ImgDetMain" },
                    { new Guid("ef78a392-052f-4e97-8a91-749661fddfea"), "DTC", "DownTown cairo", "https://assets.nst.com.my/images/articles/cairo1_1554178412.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6b2f0073-e323-4f68-a877-82df278f9d52"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a9d76f8b-8c1d-460f-bee2-15f66a01b935"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f58c0961-78ff-4409-98c1-78eebd6711af"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("3dcff596-fc30-41b9-a41b-1f09be94609e"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("adcc7a33-c9af-4170-ae95-bdbe84997bed"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("b9bd929c-ef15-4da9-8442-ff222663b976"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("c6877914-d178-4be0-9042-128d90ce58c1"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("ef78a392-052f-4e97-8a91-749661fddfea"));
        }
    }
}
