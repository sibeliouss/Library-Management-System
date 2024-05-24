using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editedAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b3774536-0771-4ff1-98aa-384c4fe80820"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ba860eb-62aa-461e-bf7f-0911ca8fb3f9"));

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Announcements");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Admin", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Read", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Write", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Create", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Update", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Announcements.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("878fbf1a-b594-4672-b9a3-b7e6660886af"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 31, 201, 46, 9, 142, 215, 36, 70, 20, 225, 106, 245, 228, 17, 212, 105, 175, 73, 153, 96, 158, 82, 188, 103, 90, 219, 132, 172, 79, 98, 189, 80, 85, 29, 131, 213, 42, 184, 70, 37, 198, 36, 68, 75, 167, 166, 141, 95, 65, 153, 157, 48, 151, 165, 110, 165, 226, 7, 181, 181, 239, 20, 231, 121 }, new byte[] { 138, 202, 32, 116, 53, 151, 137, 87, 84, 134, 67, 212, 198, 201, 57, 18, 14, 74, 232, 99, 217, 235, 10, 8, 78, 113, 23, 209, 117, 86, 16, 83, 55, 109, 128, 160, 79, 250, 139, 44, 59, 136, 237, 54, 140, 53, 207, 193, 21, 92, 150, 125, 231, 23, 130, 243, 101, 77, 47, 106, 151, 74, 66, 238, 88, 9, 73, 174, 26, 70, 203, 83, 136, 132, 45, 185, 240, 212, 33, 252, 68, 219, 63, 221, 207, 114, 2, 154, 152, 94, 243, 27, 253, 183, 116, 10, 19, 88, 78, 185, 69, 227, 61, 138, 244, 25, 221, 25, 175, 155, 124, 205, 128, 111, 25, 190, 79, 48, 73, 6, 217, 219, 106, 217, 208, 224, 34, 164 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("718bdac0-b3ad-4a4d-b84f-a8e07dc67adf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("878fbf1a-b594-4672-b9a3-b7e6660886af") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("718bdac0-b3ad-4a4d-b84f-a8e07dc67adf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("878fbf1a-b594-4672-b9a3-b7e6660886af"));

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4ba860eb-62aa-461e-bf7f-0911ca8fb3f9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 216, 227, 156, 19, 240, 18, 200, 100, 154, 149, 220, 102, 155, 27, 26, 39, 63, 121, 175, 90, 192, 39, 212, 23, 249, 54, 104, 221, 88, 133, 206, 181, 243, 60, 242, 1, 185, 80, 214, 243, 89, 31, 66, 143, 29, 158, 0, 215, 28, 208, 184, 201, 36, 123, 174, 6, 120, 246, 196, 169, 23, 215, 187, 113 }, new byte[] { 18, 187, 25, 139, 248, 71, 134, 45, 200, 231, 52, 68, 235, 180, 223, 169, 89, 122, 57, 56, 22, 118, 103, 145, 219, 14, 3, 110, 224, 150, 27, 54, 23, 5, 89, 18, 37, 2, 137, 151, 20, 250, 204, 184, 141, 130, 7, 113, 150, 52, 77, 200, 54, 64, 247, 62, 213, 161, 199, 245, 118, 78, 67, 248, 243, 166, 181, 83, 190, 189, 138, 247, 112, 35, 72, 41, 52, 254, 238, 158, 183, 150, 132, 18, 172, 135, 169, 152, 197, 30, 189, 212, 112, 85, 114, 109, 235, 187, 206, 223, 60, 222, 52, 185, 24, 173, 131, 61, 150, 92, 128, 173, 5, 240, 156, 141, 56, 183, 186, 152, 19, 42, 8, 0, 37, 70, 50, 190 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b3774536-0771-4ff1-98aa-384c4fe80820"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4ba860eb-62aa-461e-bf7f-0911ca8fb3f9") });
        }
    }
}
