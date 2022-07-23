﻿//<auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class updateuserIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "SecurityDomain",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "SecurityDomain",
                table: "Users");
        }
    }
}