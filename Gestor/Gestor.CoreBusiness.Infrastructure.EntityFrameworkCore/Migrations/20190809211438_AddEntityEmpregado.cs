using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class AddEntityEmpregado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empregados",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_Cpf",
                table: "Empregados",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_Nome",
                table: "Empregados",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empregados");
        }
    }
}
