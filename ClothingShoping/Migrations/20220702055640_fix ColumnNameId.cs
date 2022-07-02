using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingShoping.Migrations
{
    public partial class fixColumnNameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Size",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Picture",
                newName: "PictureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 12, 56, 40, 858, DateTimeKind.Local).AddTicks(4795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 12, 42, 34, 502, DateTimeKind.Local).AddTicks(802));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Size",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PictureId",
                table: "Picture",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 12, 42, 34, 502, DateTimeKind.Local).AddTicks(802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 12, 56, 40, 858, DateTimeKind.Local).AddTicks(4795));
        }
    }
}
