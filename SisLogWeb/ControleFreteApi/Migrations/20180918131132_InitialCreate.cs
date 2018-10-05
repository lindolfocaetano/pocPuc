using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleFreteApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "base_frete",
                columns: table => new
                {
                    id_base_frete = table.Column<Guid>(nullable: false),
                    dt_cadastro = table.Column<string>(type: "nchar(10)", nullable: false),
                    id_origem_destino = table.Column<Guid>(nullable: false),
                    vl_ativo = table.Column<bool>(nullable: false),
                    vl_base = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_frete", x => x.id_base_frete);
                });

            migrationBuilder.CreateTable(
                name: "frete_cliente",
                columns: table => new
                {
                    id_frete_cliente = table.Column<Guid>(nullable: false),
                    cnpj = table.Column<string>(type: "char(14)", nullable: true),
                    dt_negociacao = table.Column<DateTime>(type: "date", nullable: true),
                    email_cliente = table.Column<string>(unicode: false, nullable: true),
                    id_cliente = table.Column<Guid>(nullable: true),
                    nm_Cliente = table.Column<string>(nullable: true),
                    vl_ativo = table.Column<bool>(nullable: true),
                    vl_desconto = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frete_cliente", x => x.id_frete_cliente);
                });

            migrationBuilder.CreateTable(
                name: "uf",
                columns: table => new
                {
                    id_uf = table.Column<string>(type: "char(2)", nullable: false),
                    nm_uf = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    sg_uf = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uf", x => x.id_uf);
                });

            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    id_cidade = table.Column<string>(type: "char(7)", nullable: false),
                    id_uf = table.Column<string>(type: "char(2)", nullable: false),
                    nm_cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.id_cidade);
                    table.ForeignKey(
                        name: "FK_cidade_uf",
                        column: x => x.id_uf,
                        principalTable: "uf",
                        principalColumn: "id_uf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "origem_destino",
                columns: table => new
                {
                    id_origem_destino = table.Column<Guid>(nullable: false),
                    id_cidade_destino = table.Column<string>(type: "char(7)", nullable: false),
                    id_cidade_origem = table.Column<string>(type: "char(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origem_destino", x => x.id_origem_destino);
                    table.ForeignKey(
                        name: "FK_origem_destino_cidade1",
                        column: x => x.id_cidade_destino,
                        principalTable: "cidade",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_origem_destino_cidade",
                        column: x => x.id_cidade_origem,
                        principalTable: "cidade",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cidade_id_uf",
                table: "cidade",
                column: "id_uf");

            migrationBuilder.CreateIndex(
                name: "IX_origem_destino_id_cidade_destino",
                table: "origem_destino",
                column: "id_cidade_destino");

            migrationBuilder.CreateIndex(
                name: "IX_origem_destino_id_cidade_origem",
                table: "origem_destino",
                column: "id_cidade_origem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "base_frete");

            migrationBuilder.DropTable(
                name: "frete_cliente");

            migrationBuilder.DropTable(
                name: "origem_destino");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "uf");
        }
    }
}
