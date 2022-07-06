using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMVC_Study.Migrations
{
    public partial class AttTipoContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdContrato",
                table: "TipoContrato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdContrato",
                table: "TipoContrato");
        }
    }
}
