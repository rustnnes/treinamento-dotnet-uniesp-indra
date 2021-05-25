using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("vehicles")]
	public class Veiculo {
		public Veiculo() { }
		public Veiculo(string cor, string nome, int idMarca) {
			this.cor = cor;
			this.nome = nome;
			this.idMarca = idMarca;
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string nome { get; set; }
		public string ano { get; set; }
		public string cor { get; set; }

		[StringLength(50)]
		public string placa { get; set; }
		public int idMarca { get; set; }

		[ForeignKey("IdMarca")]
		public virtual Marca marca { get; set; }
		// http://thebillwagner.com/Blog/Item/2015-07-16-AC6gotchaInitializationvsExpressionBodiedMembers
		public string tipo { get; } = "Carro";

		// public string Buzinar() => "Biii";

		/* public string Buzinar(string buzina) {
			return buzina;
		} */
	}
}
