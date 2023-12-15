using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Waiters_WaiterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Statu",
                table: "Orders",
                newName: "WaiterId1");

            migrationBuilder.AlterColumn<string>(
                name: "WaiterId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterId1",
                table: "Orders",
                column: "WaiterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Waiters_WaiterId1",
                table: "Orders",
                column: "WaiterId1",
                principalTable: "Waiters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Waiters_WaiterId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WaiterId1",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WaiterId1",
                table: "Orders",
                newName: "Statu");

            migrationBuilder.AlterColumn<int>(
                name: "WaiterId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Waiters_WaiterId",
                table: "Orders",
                column: "WaiterId",
                principalTable: "Waiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
