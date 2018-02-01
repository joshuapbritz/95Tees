using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace evan.ninetyfivetees.web.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearSeasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearSeasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shirts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    colorId = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    designId = table.Column<int>(type: "int", nullable: true),
                    genderId = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    instock = table.Column<bool>(type: "bit", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    seasonId = table.Column<int>(type: "int", nullable: true),
                    sizeId = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shirts_Color",
                        column: x => x.colorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shirts_Designs",
                        column: x => x.designId,
                        principalTable: "Designs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shirts_genders",
                        column: x => x.genderId,
                        principalTable: "genders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shirts_YearSeasons",
                        column: x => x.seasonId,
                        principalTable: "YearSeasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shirts_Size",
                        column: x => x.sizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_colorId",
                table: "Shirts",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_designId",
                table: "Shirts",
                column: "designId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_genderId",
                table: "Shirts",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_seasonId",
                table: "Shirts",
                column: "seasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_sizeId",
                table: "Shirts",
                column: "sizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shirts");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Designs");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropTable(
                name: "YearSeasons");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
