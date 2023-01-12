using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nothing.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_UserAdmin_RecordId",
                table: "File");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecordId",
                table: "File",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_File_UserAdmin_RecordId",
                table: "File",
                column: "RecordId",
                principalTable: "UserAdmin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_UserAdmin_RecordId",
                table: "File");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecordId",
                table: "File",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_File_UserAdmin_RecordId",
                table: "File",
                column: "RecordId",
                principalTable: "UserAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
