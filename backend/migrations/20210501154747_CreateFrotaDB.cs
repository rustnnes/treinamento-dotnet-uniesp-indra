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
					table.PrimaryKey("PK_countries", x => x.id);
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
					table.PrimaryKey("PK_marks", x => x.id);
					table.ForeignKey(
						name: "FK_marks_countries_idPais",
						column: x => x.idPais,
						principalTable: "countries",
						principalColumn: "id",
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
					table.PrimaryKey("PK_vehicles", x => x.id);
					table.ForeignKey(
						name: "FK_vehicles_marks_idMarca",
						column: x => x.idMarca,
						principalTable: "marks",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				}
			);

			migrationBuilder.CreateIndex(
				name: "IX_vehicles_idMarca",
				table: "vehicles",
				column: "idMarca"
			);

			migrationBuilder.CreateIndex(
				name: "IX_marks_idPais",
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
