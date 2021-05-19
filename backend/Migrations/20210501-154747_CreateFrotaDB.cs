using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations {
	public partial class CreateFrotaDB : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Pais",
				columns: table => new {
					Id = table
								.Column<int>(type: "int", nullable: false)
								.Annotation("SqlServer:Identity", "1, 1"),
					Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Pais", x => x.Id);
				}
			);

			migrationBuilder.CreateTable(
				name: "Marca",
				columns: table => new {
					Id = table
								.Column<int>(type: "int", nullable: false)
								.Annotation("SqlServer:Identity", "1, 1"),
					Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
					IdPais = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Marca", x => x.Id);
					table.ForeignKey(
						name: "FK_Marca_Pais_IdPais",
						column: x => x.IdPais,
						principalTable: "Pais",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				}
			);

			migrationBuilder.CreateTable(
				name: "Carro",
				columns: table => new {
					Id = table
								.Column<int>(type: "int", nullable: false)
								.Annotation("SqlServer:Identity", "1, 1"),
					Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
					IdMarca = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Carro", x => x.Id);
					table.ForeignKey(
						name: "FK_Carro_Marca_IdMarca",
						column: x => x.IdMarca,
						principalTable: "Marca",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				}
			);

			migrationBuilder.CreateIndex(
				name: "IX_Carro_IdMarca",
				table: "Carro",
				column: "IdMarca"
			);

			migrationBuilder.CreateIndex(
				name: "IX_Marca_IdPais",
				table: "Marca",
				column: "IdPais"
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(name: "Carro");

			migrationBuilder.DropTable(name: "Marca");

			migrationBuilder.DropTable(name: "Pais");
		}
	}
}
