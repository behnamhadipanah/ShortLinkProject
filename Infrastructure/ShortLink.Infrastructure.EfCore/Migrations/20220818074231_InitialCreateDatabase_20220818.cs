using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortLink.Infrastructure.EfCore.Migrations
{
    public partial class InitialCreateDatabase_20220818 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Url");

            migrationBuilder.CreateTable(
                name: "UrlSchemas",
                schema: "Url",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlSchemas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlSchemas_ShortUrl",
                schema: "Url",
                table: "UrlSchemas",
                column: "ShortUrl",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlSchemas",
                schema: "Url");
        }
    }
}
