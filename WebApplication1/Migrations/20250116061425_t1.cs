using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "Transactions",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropColumn(
        //        name: "Role",
        //        table: "Users");

        //    migrationBuilder.AlterColumn<int>(
        //        name: "userName",
        //        table: "Users",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(max)",
        //        oldNullable: true);

        //    migrationBuilder.AlterColumn<int>(
        //        name: "amount",
        //        table: "Transactions",
        //        type: "int",
        //        nullable: false,
        //        oldClrType: typeof(decimal),
        //        oldType: "decimal(18,2)",
        //        oldPrecision: 18,
        //        oldScale: 2);
        //}
    }
}
