using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttences");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EMPId",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EMPId",
                table: "Attendances",
                column: "EMPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_EMPId",
                table: "Attendances",
                column: "EMPId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_EMPId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EMPId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "EMPId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Attendances");

            migrationBuilder.CreateTable(
                name: "EmployeeAttences",
                columns: table => new
                {
                    EmpID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttendanceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttences", x => new { x.EmpID, x.AttendanceID });
                    table.ForeignKey(
                        name: "FK_EmployeeAttences_AspNetUsers_EmpID",
                        column: x => x.EmpID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAttences_Attendances_AttendanceID",
                        column: x => x.AttendanceID,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttences_AttendanceID",
                table: "EmployeeAttences",
                column: "AttendanceID");
        }
    }
}
