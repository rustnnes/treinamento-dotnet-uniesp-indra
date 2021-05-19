using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations {
	public partial class AddPlacaInCarro : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.AddColumn<string>(
				name: "Placa",
				table: "Carro",
				type: "nvarchar(max)",
				nullable: true
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropColumn(
				name: "Placa",
				table: "Carro"
			);
		}
	}
}
