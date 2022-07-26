﻿//<auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class updateInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_CustomFiles_CustomFileId",
                schema: "CmsDomain",
                table: "Insurances");

            migrationBuilder.RenameColumn(
                name: "CustomFileId",
                schema: "CmsDomain",
                table: "Insurances",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_CustomFileId",
                schema: "CmsDomain",
                table: "Insurances",
                newName: "IX_Insurances_ImageId");

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                schema: "CmsDomain",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_CustomFiles_ImageId",
                schema: "CmsDomain",
                table: "Insurances",
                column: "ImageId",
                principalSchema: "CmsDomain",
                principalTable: "CustomFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_CustomFiles_ImageId",
                schema: "CmsDomain",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "IconId",
                schema: "CmsDomain",
                table: "Insurances");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                schema: "CmsDomain",
                table: "Insurances",
                newName: "CustomFileId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_ImageId",
                schema: "CmsDomain",
                table: "Insurances",
                newName: "IX_Insurances_CustomFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_CustomFiles_CustomFileId",
                schema: "CmsDomain",
                table: "Insurances",
                column: "CustomFileId",
                principalSchema: "CmsDomain",
                principalTable: "CustomFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
