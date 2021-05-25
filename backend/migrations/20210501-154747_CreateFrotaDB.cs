using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations {
	public partial class CreateFrotaDB : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "countries",
				columns: table => new {
					id = table
								.Column<int>(type: "int", nullable: false)
								.Annotation("SqlServer:Identity", "1, 1"),
					nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Pais", x => x.id);
				}
			);

			migrationBuilder.CreateTable(
				name: "marks",
				columns: table => new {
					id = table
								.Column<int>(type: "int", nullable: false)
								.Annotation("SqlServer:Identity", "1, 1"),
					nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
					idPais = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Marca", x => x.id);
					table.ForeignKey(
						name: "FK_Marca_Pais_IdPais",
						column: x => x.idPais,
						principalTable: "countries",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				}
			);

			migrationBuilder.CreateTable(
				name: "vehicles",
				columns: table => new {
					id = table
								.Column<int>(type: "int", nullable: false)
								.Annotation("SqlServer:Identity", "1, 1"),
					cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
					nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
					idMarca = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Carro", x => x.id);
					table.ForeignKey(
						name: "FK_Carro_Marca_IdMarca",
						column: x => x.idMarca,
						principalTable: "marks",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				}
			);

			migrationBuilder.CreateIndex(
				name: "IX_Carro_IdMarca",
				table: "vehicles",
				column: "idMarca"
			);

			migrationBuilder.CreateIndex(
				name: "IX_Marca_IdPais",
				table: "marks",
				column: "idPais"
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(name: "vehicles");
			migrationBuilder.DropTable(name: "marks");
			migrationBuilder.DropTable(name: "countries");
		}
	}
}
