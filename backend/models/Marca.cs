using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend {
	[Table("marks")]
	public class Marca {
		//MAPEAMENTO UTILIZANDO FLUENT-API

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string nome { get; set; }
		public int idPais { get; set; }

		[ForeignKey(nameof(Marca.idPais))] //"IdPais"
		public virtual Pais pais { get; set; }
		public virtual ICollection<Veiculo> veiculos { get; set; }
	}
}
