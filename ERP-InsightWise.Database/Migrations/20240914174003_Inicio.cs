using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPInsightWise.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ERPINSIGHTWISE_FUNCIONARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PrimeiroNome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    Departamento = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    CargaHoraria = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERPINSIGHTWISE_FUNCIONARIOS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERPINSIGHTWISE_FUNCIONARIOS");
        }
    }
}
