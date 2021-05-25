using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations {
	public partial class AddPlacaInVeiculo : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.AddColumn<string>(
				name: "placa",
				table: "vehicles",
				type: "nvarchar(max)",
				nullable: true
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropColumn(
				name: "placa",
				table: "vehicles"
			);
		}
	}
}
