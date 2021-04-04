using Microsoft.EntityFrameworkCore.Migrations;

namespace e_commerce_sample.Database.Migrations
{
    public partial class _20210404_OrderManagementsDefaultValueForStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "OrderManagements",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "OrderManagements",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
