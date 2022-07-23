﻿//<auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class updateJobPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "CmsDomain",
                table: "JobPositions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "CmsDomain",
                table: "JobPositions");
        }
    }
}
