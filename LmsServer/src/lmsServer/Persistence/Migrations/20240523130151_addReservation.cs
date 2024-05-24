using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("718bdac0-b3ad-4a4d-b84f-a8e07dc67adf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("878fbf1a-b594-4672-b9a3-b7e6660886af"));

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reservations.Admin", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reservations.Read", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reservations.Write", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reservations.Create", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reservations.Update", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reservations.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3c50cbf9-0fd0-44e2-875c-e88fd1e92efb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 110, 114, 133, 122, 140, 35, 194, 93, 50, 149, 212, 89, 79, 5, 95, 234, 177, 32, 85, 167, 25, 118, 193, 81, 136, 214, 97, 37, 36, 2, 17, 122, 217, 249, 226, 121, 214, 105, 198, 182, 225, 63, 44, 225, 54, 158, 77, 81, 27, 145, 108, 10, 8, 170, 1, 19, 206, 209, 207, 133, 243, 128, 210, 52 }, new byte[] { 193, 30, 43, 144, 200, 228, 31, 224, 241, 142, 160, 43, 9, 179, 2, 14, 218, 13, 226, 142, 200, 92, 63, 193, 217, 80, 151, 174, 193, 223, 187, 243, 108, 54, 95, 6, 181, 165, 161, 121, 92, 80, 71, 94, 39, 23, 125, 135, 245, 196, 63, 252, 111, 19, 75, 67, 5, 234, 28, 184, 204, 189, 137, 68, 118, 33, 131, 138, 201, 9, 237, 102, 7, 140, 33, 253, 140, 241, 88, 96, 110, 101, 139, 56, 166, 126, 144, 47, 163, 72, 115, 12, 146, 86, 209, 185, 242, 101, 197, 146, 123, 147, 144, 153, 68, 117, 123, 95, 82, 132, 59, 153, 136, 229, 231, 63, 255, 120, 178, 171, 186, 237, 97, 112, 139, 155, 74, 94 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8f940bdb-0e0d-4e7d-90e1-7132492b014a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3c50cbf9-0fd0-44e2-875c-e88fd1e92efb") });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookId",
                table: "Reservations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8f940bdb-0e0d-4e7d-90e1-7132492b014a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c50cbf9-0fd0-44e2-875c-e88fd1e92efb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("878fbf1a-b594-4672-b9a3-b7e6660886af"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 31, 201, 46, 9, 142, 215, 36, 70, 20, 225, 106, 245, 228, 17, 212, 105, 175, 73, 153, 96, 158, 82, 188, 103, 90, 219, 132, 172, 79, 98, 189, 80, 85, 29, 131, 213, 42, 184, 70, 37, 198, 36, 68, 75, 167, 166, 141, 95, 65, 153, 157, 48, 151, 165, 110, 165, 226, 7, 181, 181, 239, 20, 231, 121 }, new byte[] { 138, 202, 32, 116, 53, 151, 137, 87, 84, 134, 67, 212, 198, 201, 57, 18, 14, 74, 232, 99, 217, 235, 10, 8, 78, 113, 23, 209, 117, 86, 16, 83, 55, 109, 128, 160, 79, 250, 139, 44, 59, 136, 237, 54, 140, 53, 207, 193, 21, 92, 150, 125, 231, 23, 130, 243, 101, 77, 47, 106, 151, 74, 66, 238, 88, 9, 73, 174, 26, 70, 203, 83, 136, 132, 45, 185, 240, 212, 33, 252, 68, 219, 63, 221, 207, 114, 2, 154, 152, 94, 243, 27, 253, 183, 116, 10, 19, 88, 78, 185, 69, 227, 61, 138, 244, 25, 221, 25, 175, 155, 124, 205, 128, 111, 25, 190, 79, 48, 73, 6, 217, 219, 106, 217, 208, 224, 34, 164 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("718bdac0-b3ad-4a4d-b84f-a8e07dc67adf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("878fbf1a-b594-4672-b9a3-b7e6660886af") });
        }
    }
}
