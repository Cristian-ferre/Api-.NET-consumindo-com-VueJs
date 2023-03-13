using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionarioApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Re = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ramal = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioImagens",
                columns: table => new
                {
                    IdFuncionarioImagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagemBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioImagens", x => x.IdFuncionarioImagem);
                    table.ForeignKey(
                        name: "FK_FuncionarioImagens_Funcionarios_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioImagens_IdFuncionario",
                table: "FuncionarioImagens",
                column: "IdFuncionario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioImagens");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
