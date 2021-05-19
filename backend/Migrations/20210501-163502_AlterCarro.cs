using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations {
	public partial class AlterCarro : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.AlterColumn<string>(
				name: "Placa",
				table: "Carro",
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
				name: "Placa",
				table: "Carro",
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
