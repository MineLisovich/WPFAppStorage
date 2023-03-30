using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfAppStorage.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    NumberHouse = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionsStorage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSections = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionsStorage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeApplicances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeApplicances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TypeAplicancesid = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CountApplicances = table.Column<int>(nullable: false),
                    Providerid = table.Column<int>(nullable: false),
                    SectionsStorageid = table.Column<int>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicances_Providers_Providerid",
                        column: x => x.Providerid,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applicances_SectionsStorage_SectionsStorageid",
                        column: x => x.SectionsStorageid,
                        principalTable: "SectionsStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applicances_TypeApplicances_TypeAplicancesid",
                        column: x => x.TypeAplicancesid,
                        principalTable: "TypeApplicances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "City", "Country", "NameCompany", "NumberHouse", "PhoneNumber", "Street" },
                values: new object[] { 1, "Minsk", "Belarus", "Company the beast", 23, "+375299360451", "Limonnaya" });

            migrationBuilder.InsertData(
                table: "SectionsStorage",
                columns: new[] { "Id", "NameSections" },
                values: new object[] { 1, "Section A" });

            migrationBuilder.InsertData(
                table: "TypeApplicances",
                columns: new[] { "Id", "NameType" },
                values: new object[] { 1, "Пылесос" });

            migrationBuilder.InsertData(
                table: "Applicances",
                columns: new[] { "Id", "AddDate", "CountApplicances", "Name", "Price", "Providerid", "SectionsStorageid", "TypeAplicancesid" },
                values: new object[] { 1, new DateTime(2023, 3, 28, 10, 15, 41, 535, DateTimeKind.Local).AddTicks(2042), 133, "Stiralca", 20m, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Applicances_Providerid",
                table: "Applicances",
                column: "Providerid");

            migrationBuilder.CreateIndex(
                name: "IX_Applicances_SectionsStorageid",
                table: "Applicances",
                column: "SectionsStorageid");

            migrationBuilder.CreateIndex(
                name: "IX_Applicances_TypeAplicancesid",
                table: "Applicances",
                column: "TypeAplicancesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicances");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "SectionsStorage");

            migrationBuilder.DropTable(
                name: "TypeApplicances");
        }
    }
}
