using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Core.Migrations
{
    public partial class refreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRefreshTokens_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "M6FO7xLxhdkYwU4pwJKriRvNSDvmKwaovgsqjmM8remcnhHD+hxHP4o/O5t1NfHG");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRefreshTokens_UsuarioID",
                table: "UsuarioRefreshTokens",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRefreshTokens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "E4HTxoLdCoV49AYzf+vx84EhR3VXBIJqfAXDgFE57vmAOteMobsfYef27rrRHymm");
        }
    }
}
