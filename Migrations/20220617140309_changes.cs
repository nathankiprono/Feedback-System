using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inquiry__Management__System.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Customer_Id",
                table: "Customers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "AgentProductCosts",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.CreateTable(
                name: "Pagers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TotalItems = table.Column<int>(nullable: false),
                    CurrentPage = table.Column<int>(nullable: false),
                    PageSize = table.Column<int>(nullable: false),
                    TotalPages = table.Column<int>(nullable: false),
                    StartPage = table.Column<int>(nullable: false),
                    EndPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagers");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_Id",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "AgentProductCosts",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
