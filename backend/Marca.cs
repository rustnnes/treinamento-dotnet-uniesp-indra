using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("Marca")]
	public class Marca {
		//MAPEAMENTO UTILIZANDO FLUENT-API

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Nome { get; set; }
		public int IdPais { get; set; }

		[ForeignKey(nameof(Marca.IdPais))] //"IdPais"
		public virtual Pais Pais { get; set; }
		public virtual ICollection<Carro> Carros { get; set; }
	}
}
