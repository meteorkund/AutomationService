using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationService.EF.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Breakdowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Breakdowns_EmployeeId",
                table: "Breakdowns",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdowns_Employees_EmployeeId",
                table: "Breakdowns",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakdowns_Employees_EmployeeId",
                table: "Breakdowns");

            migrationBuilder.DropIndex(
                name: "IX_Breakdowns_EmployeeId",
                table: "Breakdowns");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Breakdowns");
        }
    }
}
