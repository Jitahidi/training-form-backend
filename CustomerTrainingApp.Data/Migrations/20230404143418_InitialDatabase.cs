using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomerTrainingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Agency_Code = table.Column<string>(type: "text", nullable: true),
                    First_Name = table.Column<string>(type: "text", nullable: true),
                    Last_Name = table.Column<string>(type: "text", nullable: true),
                    Middle_Initial = table.Column<string>(type: "text", nullable: true),
                    Home_Address = table.Column<string>(type: "text", nullable: true),
                    Home_Telephone = table.Column<string>(type: "text", nullable: true),
                    Position_Level = table.Column<string>(type: "text", nullable: true),
                    Organization_Mailing_Address = table.Column<string>(type: "text", nullable: true),
                    Office_Telephone = table.Column<string>(type: "text", nullable: true),
                    Work_Email_Address = table.Column<string>(type: "text", nullable: true),
                    Position_Title = table.Column<string>(type: "text", nullable: true),
                    IsSpecialAccomodationNeeded = table.Column<bool>(type: "boolean", nullable: true),
                    SpecialAccomodation_Details = table.Column<string>(type: "text", nullable: true),
                    Education_Level = table.Column<string>(type: "text", nullable: true),
                    Pay_Plan = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<int>(type: "integer", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: true),
                    Step = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendorId = table.Column<int>(type: "integer", nullable: true),
                    Vendor_Name = table.Column<string>(type: "text", nullable: true),
                    Vendor_Mailing_Address = table.Column<string>(type: "text", nullable: true),
                    Vendor_Telephone_Number = table.Column<string>(type: "text", nullable: true),
                    Vendor_Email_Address = table.Column<string>(type: "text", nullable: true),
                    Vendor_Website = table.Column<string>(type: "text", nullable: true),
                    Vendor_POC = table.Column<string>(type: "text", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true),
                    CourseName = table.Column<string>(type: "text", nullable: true),
                    Training_StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Training_EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Training_DutyHours = table.Column<int>(type: "integer", nullable: true),
                    Training_NonDutyHours = table.Column<int>(type: "integer", nullable: true),
                    Training_PurposeType = table.Column<string>(type: "text", nullable: true),
                    Training_TypeCode = table.Column<int>(type: "integer", nullable: true),
                    Training_SubTypeCode = table.Column<int>(type: "integer", nullable: true),
                    Training_DeliveryTypeCode = table.Column<int>(type: "integer", nullable: true),
                    Training_DesignationTypeCode = table.Column<int>(type: "integer", nullable: true),
                    Training_Credit = table.Column<int>(type: "integer", nullable: true),
                    Training_CreditTypeCode = table.Column<int>(type: "integer", nullable: true),
                    Training_AccreditionIndicator = table.Column<int>(type: "integer", nullable: true),
                    Continued_Service_Agreement_ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Training_Source_TypeCode = table.Column<int>(type: "integer", nullable: true),
                    Individual_or_Group_Training = table.Column<string>(type: "text", nullable: true),
                    Student_Membership_ID = table.Column<string>(type: "text", nullable: true),
                    Skill_Learning_Objective = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
