using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomoRay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_AttendanceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelfieImageUrl",
                table: "Attendances",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "PunchInTime",
                table: "Attendances",
                newName: "MarkedAt");

            migrationBuilder.RenameColumn(
                name: "LocationCoordinates",
                table: "Attendances",
                newName: "Longitude");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationAddress",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "LocationAddress",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Attendances",
                newName: "SelfieImageUrl");

            migrationBuilder.RenameColumn(
                name: "MarkedAt",
                table: "Attendances",
                newName: "PunchInTime");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Attendances",
                newName: "LocationCoordinates");
        }
    }
}
