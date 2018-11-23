using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[] { 1, "tom@mail.ru", "Tom", "1234", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[] { 2, "alice@mail.ru", "Alice", "1234", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[] { 3, "sam@mail.ru", "Sam", "1234", null });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Phone", "UserId" },
                values: new object[] { 1, "Tom's friend", "123456789", 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Phone", "UserId" },
                values: new object[] { 2, "Alice's friend", "123456789", 2 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Phone", "UserId" },
                values: new object[] { 3, "Sam's friend", "123456789", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
