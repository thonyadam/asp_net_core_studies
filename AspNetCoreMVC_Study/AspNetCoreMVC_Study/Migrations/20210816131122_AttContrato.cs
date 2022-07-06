using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMVC_Study.Migrations
{
    public partial class AttContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContratoId",
                table: "TipoContrato",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoContrato_ContratoId",
                table: "TipoContrato",
                column: "ContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoContrato_Contratos_ContratoId",
                table: "TipoContrato",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoContrato_Contratos_ContratoId",
                table: "TipoContrato");

            migrationBuilder.DropIndex(
                name: "IX_TipoContrato_ContratoId",
                table: "TipoContrato");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "TipoContrato");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Contratos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
