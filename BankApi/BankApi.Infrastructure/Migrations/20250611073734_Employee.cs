using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankRecords_Employees_EmployeeId",
                table: "BankRecords");

            migrationBuilder.DropIndex(
                name: "IX_BankRecords_EmployeeId",
                table: "BankRecords");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BankRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "BankRecords",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankRecords_EmployeeId",
                table: "BankRecords",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankRecords_Employees_EmployeeId",
                table: "BankRecords",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
