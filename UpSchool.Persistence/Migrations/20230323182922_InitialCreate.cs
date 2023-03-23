using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UpSchool.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFavourite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedOn", "IsFavourite", "LastModifiedOn", "Password", "Title", "Url", "UserName" },
                values: new object[,]
                {
                    { new Guid("24af79f6-d586-419e-a684-143de39098e1"), new DateTimeOffset(new DateTime(2023, 3, 22, 2, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzdWRlbXkyMw==", "Udemy", "", "udemy_user" },
                    { new Guid("30d43e66-a177-4d6d-9644-5b9425a83aaf"), new DateTimeOffset(new DateTime(2023, 3, 21, 22, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzdGlrdG9rMTIz", "Tiktok", "", "tiktok_user" },
                    { new Guid("38576d84-cef2-4285-b8aa-a375f6bce7c3"), new DateTimeOffset(new DateTime(2023, 3, 21, 23, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzaW5zdGFncmFtMTIz", "Instagram", "", "instagram_user" },
                    { new Guid("6320cdfc-6e37-4f7b-b8af-0d8c60922994"), new DateTimeOffset(new DateTime(2023, 3, 21, 3, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzZ2V0aXIxMjM==", "Getir", "", "getir_user" },
                    { new Guid("93462dcf-f009-458c-9dce-c813ac2de2ca"), new DateTimeOffset(new DateTime(2023, 3, 21, 21, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzZmFjZWJvb2sxMjM=", "Facebook", "", "facebook_user" },
                    { new Guid("a122163c-b2bc-4068-93de-58c8a1122d88"), new DateTimeOffset(new DateTime(2023, 3, 21, 20, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzZ29vZ2xlMTIz", "Google", "", "google_user" },
                    { new Guid("c2b18a4f-7d5e-4696-932b-6797b7f4d661"), new DateTimeOffset(new DateTime(2023, 3, 21, 5, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzY291cnNlcmExMjM=", "Coursera", "", "coursera_user" },
                    { new Guid("c4d97d5c-4309-4acc-b4b3-078ceffcea4c"), new DateTimeOffset(new DateTime(2023, 3, 22, 1, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzdHJlbmR5b2wxMjM=", "Trendyol", "", "trendyol_user" },
                    { new Guid("c6c5378a-b759-4034-984f-7ec58628c3f7"), new DateTimeOffset(new DateTime(2023, 3, 21, 4, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzaGVwc2lidXJhZGExMjM=", "Hepsiburada", "", "hepsiburada_user" },
                    { new Guid("fa588f1f-b4b0-4330-978c-bd0da99a6567"), new DateTimeOffset(new DateTime(2023, 3, 22, 0, 43, 17, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, null, "MTIzdHdpdHRlcjEyMw==", "Twitter", "", "twitter_user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Title_UserName",
                table: "Accounts",
                columns: new[] { "Title", "UserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
