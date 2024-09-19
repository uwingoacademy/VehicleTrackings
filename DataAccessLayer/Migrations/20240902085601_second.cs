using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVehicles_Drivers_DeviceId",
                table: "DeviceVehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVehicles_Devices_DeviceId",
                table: "DeviceVehicles",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceVehicles_Devices_DeviceId",
                table: "DeviceVehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceVehicles_Drivers_DeviceId",
                table: "DeviceVehicles",
                column: "DeviceId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
