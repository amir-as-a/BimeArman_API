using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRMJX.Infrastructure.Migrations
{
    public partial class UpdateRevelationAddCustomFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomeFileId",
                schema: "CmsDomain",
                table: "Revelations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Revelations_CustomeFileId",
                schema: "CmsDomain",
                table: "Revelations",
                column: "CustomeFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revelations_CustomFiles_CustomeFileId",
                schema: "CmsDomain",
                table: "Revelations",
                column: "CustomeFileId",
                principalSchema: "CmsDomain",
                principalTable: "CustomFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revelations_CustomFiles_CustomeFileId",
                schema: "CmsDomain",
                table: "Revelations");

            migrationBuilder.DropIndex(
                name: "IX_Revelations_CustomeFileId",
                schema: "CmsDomain",
                table: "Revelations");

            migrationBuilder.DropColumn(
                name: "CustomeFileId",
                schema: "CmsDomain",
                table: "Revelations");
        }
    }
}
