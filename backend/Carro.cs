using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("Carro")]
	public class Carro : IVeiculo {
		public Carro() { }
		public Carro(string cor, string nome, int idMarca) {
			this.Cor = cor;
			this.Nome = nome;
			this.IdMarca = idMarca;
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Cor { get; set; }
		public string Nome { get; set; }

		[StringLength(50)]
		public string Placa { get; set; }
		public int IdMarca { get; set; }

		[ForeignKey("IdMarca")]
		public virtual Marca Marca { get; set; }
		public string Tipo => "Carro";

		public string Buzinar() => "Biii";

		public string Buzinar(string buzina) {
			return buzina;
		}
	}
}
