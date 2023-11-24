using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasMed_GS.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONSULTA_TB_MEDICO_IdMedico",
                table: "TB_CONSULTA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICO_TB_HOSPITAL_IdHospital",
                table: "TB_MEDICO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_MEDICO",
                table: "TB_MEDICO");

            migrationBuilder.RenameTable(
                name: "TB_MEDICO",
                newName: "TB_MEDICO1");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MEDICO_IdHospital",
                table: "TB_MEDICO1",
                newName: "IX_TB_MEDICO1_IdHospital");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_MEDICO1",
                table: "TB_MEDICO1",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONSULTA_TB_MEDICO1_IdMedico",
                table: "TB_CONSULTA",
                column: "IdMedico",
                principalTable: "TB_MEDICO1",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICO1_TB_HOSPITAL_IdHospital",
                table: "TB_MEDICO1",
                column: "IdHospital",
                principalTable: "TB_HOSPITAL",
                principalColumn: "IdHospital",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONSULTA_TB_MEDICO1_IdMedico",
                table: "TB_CONSULTA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_MEDICO1_TB_HOSPITAL_IdHospital",
                table: "TB_MEDICO1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_MEDICO1",
                table: "TB_MEDICO1");

            migrationBuilder.RenameTable(
                name: "TB_MEDICO1",
                newName: "TB_MEDICO");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MEDICO1_IdHospital",
                table: "TB_MEDICO",
                newName: "IX_TB_MEDICO_IdHospital");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_MEDICO",
                table: "TB_MEDICO",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONSULTA_TB_MEDICO_IdMedico",
                table: "TB_CONSULTA",
                column: "IdMedico",
                principalTable: "TB_MEDICO",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MEDICO_TB_HOSPITAL_IdHospital",
                table: "TB_MEDICO",
                column: "IdHospital",
                principalTable: "TB_HOSPITAL",
                principalColumn: "IdHospital",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
