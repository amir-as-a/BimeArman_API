﻿//<auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class updatemenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FirstFooter",
                schema: "CmsDomain",
                table: "MenuItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SecendFooter",
                schema: "CmsDomain",
                table: "MenuItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ThirdFooter",
                schema: "CmsDomain",
                table: "MenuItems",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstFooter",
                schema: "CmsDomain",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "SecendFooter",
                schema: "CmsDomain",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ThirdFooter",
                schema: "CmsDomain",
                table: "MenuItems");
        }
    }
}