using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vitrine.Infra.Data.Migrations
{
    public partial class AdicionandoNotacoesPedido2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Pedidos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
