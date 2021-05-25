using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations {
	public partial class AlterVeiculo : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.AlterColumn<string>(
				name: "placa",
				table: "vehicles",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.AlterColumn<string>(
				name: "placa",
				table: "vehicles",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(50)",
				oldMaxLength: 50,
				oldNullable: true
			);
		}
	}
}
