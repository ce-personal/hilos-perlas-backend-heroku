using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nothing.Migrations
{
    /// <inheritdoc />
    public partial class agregandomigracinoparacampodeclientid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "PartProductCustom",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PartProductCustom_ClientId",
                table: "PartProductCustom",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartProductCustom_Client_ClientId",
                table: "PartProductCustom",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartProductCustom_Client_ClientId",
                table: "PartProductCustom");

            migrationBuilder.DropIndex(
                name: "IX_PartProductCustom_ClientId",
                table: "PartProductCustom");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "PartProductCustom");
        }
    }
}
