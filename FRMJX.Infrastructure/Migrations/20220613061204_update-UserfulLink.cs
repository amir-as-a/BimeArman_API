﻿//<auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class updateUserfulLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsefulLinks_CustomFiles_CustomFileId",
                schema: "CmsDomain",
                table: "UsefulLinks");

            migrationBuilder.DropIndex(
                name: "IX_UsefulLinks_CustomFileId",
                schema: "CmsDomain",
                table: "UsefulLinks");

            migrationBuilder.DropColumn(
                name: "CustomFileId",
                schema: "CmsDomain",
                table: "UsefulLinks");

            migrationBuilder.CreateIndex(
                name: "IX_UsefulLinks_FileId",
                schema: "CmsDomain",
                table: "UsefulLinks",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsefulLinks_CustomFiles_FileId",
                schema: "CmsDomain",
                table: "UsefulLinks",
                column: "FileId",
                principalSchema: "CmsDomain",
                principalTable: "CustomFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsefulLinks_CustomFiles_FileId",
                schema: "CmsDomain",
                table: "UsefulLinks");

            migrationBuilder.DropIndex(
                name: "IX_UsefulLinks_FileId",
                schema: "CmsDomain",
                table: "UsefulLinks");

            migrationBuilder.AddColumn<int>(
                name: "CustomFileId",
                schema: "CmsDomain",
                table: "UsefulLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsefulLinks_CustomFileId",
                schema: "CmsDomain",
                table: "UsefulLinks",
                column: "CustomFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsefulLinks_CustomFiles_CustomFileId",
                schema: "CmsDomain",
                table: "UsefulLinks",
                column: "CustomFileId",
                principalSchema: "CmsDomain",
                principalTable: "CustomFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
