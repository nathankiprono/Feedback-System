﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Inquiry__Management__System.Migrations
{
    public partial class str : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Payment_Mode",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Payment_Mode",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
