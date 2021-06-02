using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("vehicles")]
	public class Veiculo {
		public Veiculo() { }
		public Veiculo(string cor, string nome, int idMarca, int ano, string tipo) {
			this.cor = cor;
			this.nome = nome;
			this.idMarca = idMarca;
			this.ano = ano;
			this.tipo = tipo;
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string nome { get; set; }
		public int ano { get; set; }
		public string cor { get; set; }

		[Required]
		[StringLength(8, MinimumLength = 8)]
		public string placa { get; set; }
		public string tipo { get; set; }
		public int idMarca { get; set; }

		[ForeignKey(nameof(Veiculo.idMarca))] //"idMarca"
		public virtual Marca marca { get; set; }
		// http://thebillwagner.com/Blog/Item/2015-07-16-AC6gotchaInitializationvsExpressionBodiedMembers

		// public string Buzinar() => "Biii";

		/* public string Buzinar(string buzina) {
			return buzina;
		} */
	}
}
