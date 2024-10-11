using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoodyzeAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixAppUserIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emotions_AspNetUsers_AppUserId1",
                table: "Emotions");

            migrationBuilder.DropIndex(
                name: "IX_Emotions_AppUserId1",
                table: "Emotions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0580575b-1451-4e9f-b16f-ff0d5bc14ae0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cd98757-9010-48e9-9a1a-09bc5498650c");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Emotions");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Emotions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37fa0053-876b-4b42-b842-029e53f4516e", null, "Admin", "ADMIN" },
                    { "70432cc7-9993-4985-bed3-01b867f80e5b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emotions_AppUserId",
                table: "Emotions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emotions_AspNetUsers_AppUserId",
                table: "Emotions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emotions_AspNetUsers_AppUserId",
                table: "Emotions");

            migrationBuilder.DropIndex(
                name: "IX_Emotions_AppUserId",
                table: "Emotions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37fa0053-876b-4b42-b842-029e53f4516e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70432cc7-9993-4985-bed3-01b867f80e5b");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Emotions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Emotions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0580575b-1451-4e9f-b16f-ff0d5bc14ae0", null, "Admin", "ADMIN" },
                    { "8cd98757-9010-48e9-9a1a-09bc5498650c", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emotions_AppUserId1",
                table: "Emotions",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Emotions_AspNetUsers_AppUserId1",
                table: "Emotions",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
