using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.migrations {
	public partial class AddFieldsOnVehicles : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.AddColumn<int>(
				name: "ano",
				table: "vehicles",
				type: "int",
				nullable: true
			);
			migrationBuilder.AddColumn<string>(
				name: "tipo",
				table: "vehicles",
				type: "nvarchar(10)",
				nullable: false,
				defaultValue: "Carro"
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder) {

		}
	}
}
