using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteCascadeDemandsOfComplaint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demands_Complaints_CompId",
                table: "Demands");

            migrationBuilder.AddForeignKey(
                name: "FK_Demands_Complaints_CompId",
                table: "Demands",
                column: "CompId",
                principalTable: "Complaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demands_Complaints_CompId",
                table: "Demands");

            migrationBuilder.AddForeignKey(
                name: "FK_Demands_Complaints_CompId",
                table: "Demands",
                column: "CompId",
                principalTable: "Complaints",
                principalColumn: "Id");
        }
    }
}
