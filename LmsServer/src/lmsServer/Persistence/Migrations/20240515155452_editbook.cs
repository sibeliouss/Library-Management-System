using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("05bf2080-58b9-465a-9c37-4ede96940286"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c087aef-6732-48f6-a7da-f1eb943fb484"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4ba860eb-62aa-461e-bf7f-0911ca8fb3f9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 216, 227, 156, 19, 240, 18, 200, 100, 154, 149, 220, 102, 155, 27, 26, 39, 63, 121, 175, 90, 192, 39, 212, 23, 249, 54, 104, 221, 88, 133, 206, 181, 243, 60, 242, 1, 185, 80, 214, 243, 89, 31, 66, 143, 29, 158, 0, 215, 28, 208, 184, 201, 36, 123, 174, 6, 120, 246, 196, 169, 23, 215, 187, 113 }, new byte[] { 18, 187, 25, 139, 248, 71, 134, 45, 200, 231, 52, 68, 235, 180, 223, 169, 89, 122, 57, 56, 22, 118, 103, 145, 219, 14, 3, 110, 224, 150, 27, 54, 23, 5, 89, 18, 37, 2, 137, 151, 20, 250, 204, 184, 141, 130, 7, 113, 150, 52, 77, 200, 54, 64, 247, 62, 213, 161, 199, 245, 118, 78, 67, 248, 243, 166, 181, 83, 190, 189, 138, 247, 112, 35, 72, 41, 52, 254, 238, 158, 183, 150, 132, 18, 172, 135, 169, 152, 197, 30, 189, 212, 112, 85, 114, 109, 235, 187, 206, 223, 60, 222, 52, 185, 24, 173, 131, 61, 150, 92, 128, 173, 5, 240, 156, 141, 56, 183, 186, 152, 19, 42, 8, 0, 37, 70, 50, 190 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b3774536-0771-4ff1-98aa-384c4fe80820"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4ba860eb-62aa-461e-bf7f-0911ca8fb3f9") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b3774536-0771-4ff1-98aa-384c4fe80820"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ba860eb-62aa-461e-bf7f-0911ca8fb3f9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9c087aef-6732-48f6-a7da-f1eb943fb484"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 92, 99, 88, 197, 40, 61, 174, 18, 160, 199, 211, 60, 158, 225, 183, 34, 37, 53, 122, 62, 60, 159, 230, 74, 10, 78, 95, 124, 129, 40, 6, 22, 169, 48, 111, 125, 107, 14, 52, 204, 153, 86, 154, 98, 48, 167, 180, 92, 70, 28, 22, 152, 156, 188, 87, 77, 177, 203, 124, 204, 226, 116, 126, 65 }, new byte[] { 189, 199, 31, 15, 199, 76, 92, 164, 66, 62, 248, 164, 190, 84, 153, 220, 235, 194, 10, 65, 136, 62, 33, 24, 200, 195, 7, 211, 64, 131, 234, 25, 246, 183, 12, 12, 232, 9, 190, 58, 33, 253, 15, 233, 133, 162, 143, 53, 155, 181, 228, 55, 177, 8, 201, 107, 73, 144, 111, 7, 116, 87, 176, 50, 135, 240, 107, 170, 196, 58, 117, 149, 150, 96, 246, 126, 73, 223, 27, 121, 38, 117, 97, 78, 210, 142, 246, 14, 237, 195, 88, 188, 177, 41, 42, 61, 209, 118, 140, 171, 115, 3, 244, 189, 127, 2, 25, 68, 222, 246, 155, 140, 13, 125, 22, 222, 187, 28, 144, 50, 253, 72, 5, 20, 168, 106, 94, 196 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("05bf2080-58b9-465a-9c37-4ede96940286"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("9c087aef-6732-48f6-a7da-f1eb943fb484") });
        }
    }
}
