using Microsoft.EntityFrameworkCore.Migrations;

namespace VkusProekt.Migrations
{
    public partial class Final4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Bludo_BludoID",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "BludoID",
                table: "OrderDetail",
                newName: "bludoID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_BludoID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_bludoID");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Order",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Order",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Order",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adress",
                table: "Order",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Bludo_bludoID",
                table: "OrderDetail",
                column: "bludoID",
                principalTable: "Bludo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Bludo_bludoID",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "bludoID",
                table: "OrderDetail",
                newName: "BludoID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_bludoID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_BludoID");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "adress",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Bludo_BludoID",
                table: "OrderDetail",
                column: "BludoID",
                principalTable: "Bludo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
