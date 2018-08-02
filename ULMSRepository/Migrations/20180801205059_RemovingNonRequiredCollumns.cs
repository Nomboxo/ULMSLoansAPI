using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ULMSRepository.Migrations
{
    public partial class RemovingNonRequiredCollumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    ActualPaymentDate = table.Column<DateTime>(nullable: false),
                    FullyPaid = table.Column<bool>(nullable: false),
                    Profit = table.Column<double>(nullable: false),
                    AmountPaidThusFar = table.Column<double>(nullable: false),
                    InterestValue = table.Column<double>(nullable: false),
                    TotalAmountToBePaid = table.Column<double>(nullable: false),
                    CurrentStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
