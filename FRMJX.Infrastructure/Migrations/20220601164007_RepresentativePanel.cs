﻿//<auto-generated/>
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class RepresentativePanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepresentativePanels",
                schema: "CmsDomain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanelCategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomFileId = table.Column<int>(type: "int", nullable: false),
                    Ordering = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CultureLcid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativePanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentativePanels_CustomFiles_CustomFileId",
                        column: x => x.CustomFileId,
                        principalSchema: "CmsDomain",
                        principalTable: "CustomFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepresentativePanels_RepresentativePanelCategories_PanelCategoryId",
                        column: x => x.PanelCategoryId,
                        principalSchema: "CmsDomain",
                        principalTable: "RepresentativePanelCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativePanels_CustomFileId",
                schema: "CmsDomain",
                table: "RepresentativePanels",
                column: "CustomFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativePanels_PanelCategoryId",
                schema: "CmsDomain",
                table: "RepresentativePanels",
                column: "PanelCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepresentativePanels",
                schema: "CmsDomain");
        }
    }
}
