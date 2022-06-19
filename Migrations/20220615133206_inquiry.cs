using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inquiry__Management__System.Migrations
{
    public partial class inquiry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentProductCosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Agent_Id = table.Column<string>(nullable: true),
                    Product_Id = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentProductCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Agent_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Agent_Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone_Number = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Agent_Id);
                });

            migrationBuilder.CreateTable(
                name: "Company_Information",
                columns: table => new
                {
                    Company_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company_Name = table.Column<string>(nullable: false),
                    Conctacts = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Information", x => x.Company_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Agent_Id = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Passport_No = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    National_Id = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    DOB = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Feedback_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customer_Id = table.Column<string>(nullable: true),
                    Product_Id = table.Column<string>(nullable: true),
                    Results = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    IsInvoice = table.Column<string>(nullable: false),
                    Invoice_Date = table.Column<string>(nullable: true),
                    Ispaid = table.Column<string>(nullable: true),
                    Invoice_No = table.Column<int>(nullable: false),
                    Payment_Date = table.Column<string>(nullable: true),
                    Payment_Ref = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Feedback_Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Agent_Id = table.Column<string>(nullable: true),
                    Customer_Id = table.Column<string>(nullable: true),
                    Invoice_No = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Product_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Payment_Mode = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Agent_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Product_Name = table.Column<string>(nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentProductCosts");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Company_Information");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
