using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DretBlog.Data.Migrations
{
    public partial class testordestroy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "BlogContent",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BlogContent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
