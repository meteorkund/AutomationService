using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationService.EF.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Breakdowns");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Breakdowns");

            migrationBuilder.AddColumn<int>(
                name: "BreakdownSolverId",
                table: "Breakdowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Breakdowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Breakdowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breakdowns_BreakdownSolverId",
                table: "Breakdowns",
                column: "BreakdownSolverId");

            migrationBuilder.CreateIndex(
                name: "IX_Breakdowns_DepartmentId",
                table: "Breakdowns",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Breakdowns_SectorId",
                table: "Breakdowns",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdowns_BreakdownSolvers_BreakdownSolverId",
                table: "Breakdowns",
                column: "BreakdownSolverId",
                principalTable: "BreakdownSolvers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdowns_Departments_DepartmentId",
                table: "Breakdowns",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdowns_Sectors_SectorId",
                table: "Breakdowns",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakdowns_BreakdownSolvers_BreakdownSolverId",
                table: "Breakdowns");

            migrationBuilder.DropForeignKey(
                name: "FK_Breakdowns_Departments_DepartmentId",
                table: "Breakdowns");

            migrationBuilder.DropForeignKey(
                name: "FK_Breakdowns_Sectors_SectorId",
                table: "Breakdowns");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Breakdowns_BreakdownSolverId",
                table: "Breakdowns");

            migrationBuilder.DropIndex(
                name: "IX_Breakdowns_DepartmentId",
                table: "Breakdowns");

            migrationBuilder.DropIndex(
                name: "IX_Breakdowns_SectorId",
                table: "Breakdowns");

            migrationBuilder.DropColumn(
                name: "BreakdownSolverId",
                table: "Breakdowns");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Breakdowns");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Breakdowns");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Breakdowns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Breakdowns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
