using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paylocity.Web.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitAssessmentConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartOfYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPayPeriodsPerYear = table.Column<int>(type: "int", nullable: false),
                    PerPayPeriodSalary = table.Column<float>(type: "real", nullable: false),
                    ActiveAsOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactiveAsOfDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitAssessmentConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitAssessmentConfigurationCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitAssessmentConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    CostPerYear = table.Column<float>(type: "real", nullable: false),
                    HasNameBasedDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<float>(type: "real", nullable: false),
                    NameDiscountMatchingType = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitAssessmentConfigurationCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitAssessmentConfigurationCosts_BenefitAssessmentConfigurations_BenefitAssessmentConfigurationId",
                        column: x => x.BenefitAssessmentConfigurationId,
                        principalTable: "BenefitAssessmentConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitAssessmentConfigurationPayPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitAssessmentConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayPeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayPeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayPeriodPayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitAssessmentConfigurationPayPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitAssessmentConfigurationPayPeriods_BenefitAssessmentConfigurations_BenefitAssessmentConfigurationId",
                        column: x => x.BenefitAssessmentConfigurationId,
                        principalTable: "BenefitAssessmentConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitAssessmentConfigurationCosts_BenefitAssessmentConfigurationId",
                table: "BenefitAssessmentConfigurationCosts",
                column: "BenefitAssessmentConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitAssessmentConfigurationPayPeriods_BenefitAssessmentConfigurationId",
                table: "BenefitAssessmentConfigurationPayPeriods",
                column: "BenefitAssessmentConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitAssessmentConfigurationCosts");

            migrationBuilder.DropTable(
                name: "BenefitAssessmentConfigurationPayPeriods");

            migrationBuilder.DropTable(
                name: "BenefitAssessmentConfigurations");
        }
    }
}
