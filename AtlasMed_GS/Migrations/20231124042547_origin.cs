using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasMed_GS.Migrations
{
    /// <inheritdoc />
    public partial class origin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HOSPITAL",
                columns: table => new
                {
                    IdHospital = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HOSPITAL", x => x.IdHospital);
                });

            migrationBuilder.CreateTable(
                name: "TB_MEDICACAO",
                columns: table => new
                {
                    IdMedicacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PrincipioAtivo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Dosagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MEDICACAO", x => x.IdMedicacao);
                });

            migrationBuilder.CreateTable(
                name: "TB_PACIENTE",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PACIENTE", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "TB_MEDICO",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Crm = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdHospital = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MEDICO", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_TB_MEDICO_TB_HOSPITAL_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "TB_HOSPITAL",
                        principalColumn: "IdHospital",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRONTUARIO",
                columns: table => new
                {
                    IdProntuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diagnostico = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Alergias = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdMedicacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRONTUARIO", x => x.IdProntuario);
                    table.ForeignKey(
                        name: "FK_TB_PRONTUARIO_TB_MEDICACAO_IdMedicacao",
                        column: x => x.IdMedicacao,
                        principalTable: "TB_MEDICACAO",
                        principalColumn: "IdMedicacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONSULTA",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdPaciente = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdMedico = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdProntuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdHospital = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Horario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONSULTA", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_TB_CONSULTA_TB_HOSPITAL_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "TB_HOSPITAL",
                        principalColumn: "IdHospital",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CONSULTA_TB_MEDICO_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "TB_MEDICO",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CONSULTA_TB_PACIENTE_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "TB_PACIENTE",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CONSULTA_TB_PRONTUARIO_IdProntuario",
                        column: x => x.IdProntuario,
                        principalTable: "TB_PRONTUARIO",
                        principalColumn: "IdProntuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONSULTA_IdHospital",
                table: "TB_CONSULTA",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONSULTA_IdMedico",
                table: "TB_CONSULTA",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONSULTA_IdPaciente",
                table: "TB_CONSULTA",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONSULTA_IdProntuario",
                table: "TB_CONSULTA",
                column: "IdProntuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MEDICO_IdHospital",
                table: "TB_MEDICO",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRONTUARIO_IdMedicacao",
                table: "TB_PRONTUARIO",
                column: "IdMedicacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONSULTA");

            migrationBuilder.DropTable(
                name: "TB_MEDICO");

            migrationBuilder.DropTable(
                name: "TB_PACIENTE");

            migrationBuilder.DropTable(
                name: "TB_PRONTUARIO");

            migrationBuilder.DropTable(
                name: "TB_HOSPITAL");

            migrationBuilder.DropTable(
                name: "TB_MEDICACAO");
        }
    }
}
