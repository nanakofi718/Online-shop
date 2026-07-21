using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_ZipCode",
                table: "Orders",
                newName: "ShippingAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_State",
                table: "Orders",
                newName: "ShippingAddress_State");

            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_LastName",
                table: "Orders",
                newName: "ShippingAddress_LastName");

            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_FirstName",
                table: "Orders",
                newName: "ShippingAddress_FirstName");

            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_EmailAddress",
                table: "Orders",
                newName: "ShippingAddress_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_Country",
                table: "Orders",
                newName: "ShippingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "ShipppingAddress_AddressLine",
                table: "Orders",
                newName: "ShippingAddress_AddressLine");

            migrationBuilder.RenameColumn(
                name: "Payment_PaymenMethod",
                table: "Orders",
                newName: "Payment_PaymentMethod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress_ZipCode",
                table: "Orders",
                newName: "ShipppingAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_State",
                table: "Orders",
                newName: "ShipppingAddress_State");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_LastName",
                table: "Orders",
                newName: "ShipppingAddress_LastName");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_FirstName",
                table: "Orders",
                newName: "ShipppingAddress_FirstName");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_EmailAddress",
                table: "Orders",
                newName: "ShipppingAddress_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Country",
                table: "Orders",
                newName: "ShipppingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_AddressLine",
                table: "Orders",
                newName: "ShipppingAddress_AddressLine");

            migrationBuilder.RenameColumn(
                name: "Payment_PaymentMethod",
                table: "Orders",
                newName: "Payment_PaymenMethod");
        }
    }
}
