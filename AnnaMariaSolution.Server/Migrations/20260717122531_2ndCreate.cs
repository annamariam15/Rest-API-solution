
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnaMariaSolution.Server.Migrations
{
    /// <inheritdoc />
    public partial class _2ndCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Task_Projects_ProjectId",
                table: "Employee_Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Task",
                table: "Employee_Task");

            migrationBuilder.RenameTable(
                name: "Employee_Task",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Task_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Employee_Task");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "Employee_Task",
                newName: "IX_Employee_Task_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Task",
                table: "Employee_Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Task_Projects_ProjectId",
                table: "Employee_Task",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
